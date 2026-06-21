using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Visual_Programming.Models;

namespace Visual_Programming.Database
{
    public class PlayerRepository
    {
        public List<Player> GetAllPlayers()
        {
            var players = new List<Player>();
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT player_id, player_name, created_at FROM players ORDER BY player_name ASC";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        players.Add(new Player
                        {
                            PlayerId = reader.GetInt32("player_id"),
                            PlayerName = reader.GetString("player_name"),
                            CreatedAt = reader.GetDateTime("created_at")
                        });
                    }
                }
            }
            return players;
        }

        public Player CreatePlayer(string playerName)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                
                // First check if player already exists
                string checkQuery = "SELECT player_id, player_name, created_at FROM players WHERE player_name = @name";
                using (var checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@name", playerName);
                    using (var reader = checkCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Player
                            {
                                PlayerId = reader.GetInt32("player_id"),
                                PlayerName = reader.GetString("player_name"),
                                CreatedAt = reader.GetDateTime("created_at")
                            };
                        }
                    }
                }

                // If not, insert
                string insertQuery = "INSERT INTO players (player_name) VALUES (@name)";
                using (var insertCmd = new MySqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@name", playerName);
                    insertCmd.ExecuteNonQuery();
                    int newId = (int)insertCmd.LastInsertedId;

                    return new Player
                    {
                        PlayerId = newId,
                        PlayerName = playerName,
                        CreatedAt = DateTime.Now
                    };
                }
            }
        }
    }
}
