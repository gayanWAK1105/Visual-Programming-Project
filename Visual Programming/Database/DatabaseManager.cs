using System;
using MySql.Data.MySqlClient;

namespace Visual_Programming.Database
{
    public static class DatabaseManager
    {
        // Default XAMPP MySQL connection string
        private static readonly string ConnectionString = "server=localhost;user=root;password=;database=algoride_db;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
