using System.Text.Json;
using Visual_Programming.Game;
using Visual_Programming.Models;

namespace Visual_Programming.Persistence
{
    /// <summary>
    /// Handles saving and loading player progress to/from JSON.
    /// File location: Data/playerProgress.json (relative to executable).
    /// </summary>
    public static class SaveManager
    {
        private static readonly string SaveDir = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Data");

        private static readonly string SavePath = Path.Combine(
            SaveDir, "playerProgress.json");

        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true
        };

        // ════════════════════════════════════════════════════════════════════
        // SAVE
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Saves the current game state to playerProgress.json.
        /// Creates the Data/ directory if it does not exist.
        /// </summary>
        public static void Save(GameState state)
        {
            try
            {
                Directory.CreateDirectory(SaveDir);

                // Convert GameState → PlayerProgress for clean JSON shape
                var progress = new PlayerProgress
                {
                    PlayerName = state.PlayerName,
                    CurrentLevel = state.CurrentLevel,
                    HighestUnlockedLevel = state.HighestUnlockedLevel,
                    Lives = state.Lives,
                    TotalScore = state.TotalScore,
                    LevelScores = new Dictionary<string, int>()
                };

                // Convert int keys to string keys for JSON
                foreach (var kvp in state.BestScorePerLevel)
                {
                    progress.LevelScores[kvp.Key.ToString()] = kvp.Value;
                }

                string json = JsonSerializer.Serialize(progress, Options);
                File.WriteAllText(SavePath, json);
            }
            catch (Exception ex)
            {
                // Silently fail — don't crash the game for save errors
                System.Diagnostics.Debug.WriteLine($"Save failed: {ex.Message}");
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // LOAD
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Loads player progress from playerProgress.json.
        /// Returns a fresh GameState if file doesn't exist or is corrupt.
        /// </summary>
        public static GameState Load()
        {
            if (!File.Exists(SavePath))
                return new GameState();

            try
            {
                string json = File.ReadAllText(SavePath);
                var progress = JsonSerializer.Deserialize<PlayerProgress>(json);

                if (progress == null)
                    return new GameState();

                // Convert PlayerProgress → GameState
                var state = new GameState
                {
                    PlayerName = progress.PlayerName,
                    CurrentLevel = progress.CurrentLevel,
                    HighestUnlockedLevel = progress.HighestUnlockedLevel,
                    Lives = progress.Lives,
                    TotalScore = progress.TotalScore,
                    BestScorePerLevel = new Dictionary<int, int>()
                };

                // Convert string keys back to int keys
                foreach (var kvp in progress.LevelScores)
                {
                    if (int.TryParse(kvp.Key, out int level))
                    {
                        state.BestScorePerLevel[level] = kvp.Value;
                    }
                }

                return state;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Load failed: {ex.Message}");
                return new GameState();
            }
        }
    }
}
