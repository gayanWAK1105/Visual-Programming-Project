namespace Visual_Programming.Models
{
    /// <summary>
    /// Data model for JSON serialization/deserialization.
    /// Represents the player's saved progress.
    /// </summary>
    public class PlayerProgress
    {
        public string PlayerName { get; set; } = "Player";
        public int CurrentLevel { get; set; } = 1;
        public int HighestUnlockedLevel { get; set; } = 1;
        public int Lives { get; set; } = 3;
        public int TotalScore { get; set; } = 0;

        /// <summary>
        /// Best score achieved per level. Key = level number, Value = best score.
        /// </summary>
        public Dictionary<string, int> LevelScores { get; set; } = new();
    }
}
