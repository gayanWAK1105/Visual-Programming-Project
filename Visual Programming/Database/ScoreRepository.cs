using System;
using MySql.Data.MySqlClient;

namespace Visual_Programming.Database
{
    public class ScoreRepository
    {
        public int GetHighScore(int playerId, string gameType, int level)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT high_score FROM game_scores WHERE player_id = @playerId AND game_type = @gameType AND level = @level";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@playerId", playerId);
                    cmd.Parameters.AddWithValue("@gameType", gameType);
                    cmd.Parameters.AddWithValue("@level", level);
                    
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return 0; // Default high score if no record exists
        }

        public int GetHighestUnlockedLevel(int playerId, string gameType)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT MAX(level) FROM game_scores WHERE player_id = @playerId AND game_type = @gameType";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@playerId", playerId);
                    cmd.Parameters.AddWithValue("@gameType", gameType);
                    
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return 0; // Default if no levels have been completed
        }

        public void UpdateHighScore(int playerId, string gameType, int level, int newScore)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                // We use INSERT ... ON DUPLICATE KEY UPDATE to elegantly handle inserting or updating
                string query = @"
                    INSERT INTO game_scores (player_id, game_type, level, high_score) 
                    VALUES (@playerId, @gameType, @level, @score) 
                    ON DUPLICATE KEY UPDATE high_score = @score";
                
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@playerId", playerId);
                    cmd.Parameters.AddWithValue("@gameType", gameType);
                    cmd.Parameters.AddWithValue("@level", level);
                    cmd.Parameters.AddWithValue("@score", newScore);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
