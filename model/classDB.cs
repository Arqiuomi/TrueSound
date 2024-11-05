using System;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using MySql.Data.MySqlClient;

namespace TrueSound.model
{

    public class DB
    {
        string connectionString;

        public DB(Config config)
        {
            connectionString = $"Server={config.host}; Port={config.port}; Database={config.dbName};" +
                                                    $" User ID={config.user}; Password={config.password};";
        }

        public string userNameInfo()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Пример запроса
                    string query = "SELECT * FROM user";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Чтение данных из базы
                            return reader["username"].ToString();
                        }
                    }
                }

                catch (Exception ex)
                {
                    return "NULL";
                }
                return "NULL";
            }
        }
    }
}
