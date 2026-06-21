namespace Visual_Programming.Game
{
    /// <summary>
    /// Manages score calculation and tracking.
    /// Score rules:
    ///   First half of threshold → +10 points
    ///   Second half of threshold → +5 points
    ///   Wrong answer → +0 points
    ///   No negative scores.
    /// </summary>
    public static class ScoreManager
    {
        /// <summary>
        /// Calculates points for a correct answer based on how quickly
        /// the player responded.
        /// </summary>
        /// <param name="elapsedMs">Milliseconds taken to answer.</param>
        /// <returns>Points earned (10 or 5).</returns>
        public static int CalculatePoints(long elapsedMs)
        {
            return GameState.CalculateScore(elapsedMs);
        }

        /// <summary>
        /// Records a correct answer into the game state.
        /// </summary>
        public static void RecordCorrectAnswer(GameState state, long elapsedMs)
        {
            int points = CalculatePoints(elapsedMs);
            state.LevelScore += points;
            state.CorrectAnswersThisLevel++;
            state.QuestionsCompletedThisLevel++;
        }

        /// <summary>
        /// Records a wrong answer into the game state.
        /// Deducts one life and increments question count.
        /// Score is not affected (0 points for wrong answer).
        /// </summary>
        public static void RecordWrongAnswer(GameState state)
        {
            state.Lives--;
            state.QuestionsCompletedThisLevel++;
        }

        /// <summary>
        /// Finalizes a completed level — updates best score and total score.
        /// </summary>
        public static void FinalizeLevel(GameState state)
        {
            int level = state.CurrentLevel;

            // Update best score for this level
            if (!state.BestScorePerLevel.ContainsKey(level) ||
                state.LevelScore > state.BestScorePerLevel[level])
            {
                state.BestScorePerLevel[level] = state.LevelScore;
            }

            // Accumulate total score
            state.TotalScore += state.LevelScore;

            // Unlock next level
            int nextLevel = level + 1;
            if (nextLevel > state.HighestUnlockedLevel)
            {
                state.HighestUnlockedLevel = nextLevel;
            }
        }
    }
}
