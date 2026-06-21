namespace Visual_Programming.Game
{
    /// <summary>
    /// Holds all mutable session data for the current game.
    /// No UI logic — pure state management.
    /// </summary>
    public class GameState
    {
        // ── Constants (configurable) ────────────────────────────────────────
        public const int QuestionsPerLevel = 10;
        public const int DefaultLives = 3;

        /// <summary>
        /// Threshold in milliseconds for score calculation.
        /// Answer within this time = +10, after = +5.
        /// </summary>
        public const long ScoreThresholdMs = 5000;

        // ── Player info ─────────────────────────────────────────────────────
        public string PlayerName { get; set; } = "Player";

        // ── Level progression ───────────────────────────────────────────────
        public int CurrentLevel { get; set; } = 1;
        public int HighestUnlockedLevel { get; set; } = 1;

        // ── Current level state ─────────────────────────────────────────────
        public int Lives { get; set; } = DefaultLives;
        public int LevelScore { get; set; } = 0;
        public int QuestionsCompletedThisLevel { get; set; } = 0;
        public int CorrectAnswersThisLevel { get; set; } = 0;

        // ── Cumulative stats ────────────────────────────────────────────────
        public int TotalScore { get; set; } = 0;

        // ── Per-level best scores ───────────────────────────────────────────
        public Dictionary<int, int> BestScorePerLevel { get; set; } = new();

        // ════════════════════════════════════════════════════════════════════
        // SCORE CALCULATION
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Calculates points earned for a correct answer based on elapsed time.
        /// First half of threshold → +10, second half → +5.
        /// </summary>
        public static int CalculateScore(long elapsedMs)
        {
            return elapsedMs <= ScoreThresholdMs ? 10 : 5;
        }

        // ════════════════════════════════════════════════════════════════════
        // RESET HELPERS
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Resets state for starting (or restarting) a level.
        /// Keeps cumulative stats and best scores intact.
        /// </summary>
        public void ResetForLevel(int level)
        {
            CurrentLevel = level;
            Lives = DefaultLives;
            LevelScore = 0;
            QuestionsCompletedThisLevel = 0;
            CorrectAnswersThisLevel = 0;
        }
    }
}
