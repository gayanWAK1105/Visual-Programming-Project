using System;

namespace Visual_Programming.Models
{
    public class GameScore
    {
        public int ScoreId { get; set; }
        public int PlayerId { get; set; }
        public string GameType { get; set; }
        public int Level { get; set; }
        public int HighScore { get; set; }
    }
}
