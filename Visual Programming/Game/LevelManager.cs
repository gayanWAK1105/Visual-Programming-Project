namespace Visual_Programming.Game
{
    /// <summary>
    /// Centralized difficulty and question generation.
    /// All difficulty logic lives here — do not scatter ranges in Form2.
    /// </summary>
    public static class LevelManager
    {
        // ── Level difficulty ranges ─────────────────────────────────────────
        // Each level defines the min and max values for operands.
        private static readonly Dictionary<int, (int min, int max)> LevelRanges = new()
        {
            { 1, (1, 10) },
            { 2, (1, 20) },
            { 3, (1, 50) },
            { 4, (1, 100) }
        };

        /// <summary>
        /// Returns the operand range (min, max) for the given level.
        /// Levels beyond 4 are capped at 1-100.
        /// </summary>
        public static (int min, int max) GetQuestionRange(int level)
        {
            if (LevelRanges.TryGetValue(level, out var range))
                return range;

            // Extrapolate for levels beyond 4 — cap at 100
            return (1, 100);
        }

        /// <summary>
        /// Generates a single arithmetic question appropriate for the given level and game type.
        /// Returns (num1, num2, correctAnswer).
        /// This is the ONLY method that should generate questions.
        /// </summary>
        public static (int num1, int num2, int answer) GenerateQuestionForLevel(int level, string gameType, Random rng)
        {
            var (min, max) = GetQuestionRange(level);
            int num1 = rng.Next(min, max + 1);
            int num2 = rng.Next(min, max + 1);

            switch (gameType)
            {
                case "Subtraction":
                    // Avoid negative answers by making num1 the larger one
                    if (num1 < num2)
                    {
                        int temp = num1;
                        num1 = num2;
                        num2 = temp;
                    }
                    return (num1, num2, num1 - num2);
                case "Multiplication":
                    // Multiplication values should be slightly smaller for levels to be playable
                    int multMax = Math.Min(max, level * 3 + 7);
                    num1 = rng.Next(1, multMax + 1);
                    num2 = rng.Next(1, multMax + 1);
                    return (num1, num2, num1 * num2);
                case "Division":
                    // For clean integer division, we pick num2 first, then generate answer, and then set num1 = num2 * answer
                    int divMax = Math.Min(max, level * 3 + 7);
                    num2 = rng.Next(1, divMax + 1); // Avoid division by zero
                    int answer = rng.Next(1, 11); // Simple quotient range
                    num1 = num2 * answer;
                    return (num1, num2, answer);
                case "Addition":
                default:
                    return (num1, num2, num1 + num2);
            }
        }

        /// <summary>
        /// Returns the total number of available levels.
        /// </summary>
        public static int TotalLevels => LevelRanges.Count;
    }
}
