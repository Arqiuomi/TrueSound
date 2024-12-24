using System;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using MySql.Data.MySqlClient;

namespace TrueSound.model
{

    public static class DB
    {
        static string connectionString = $"Server={Config.Host}; Port={Config.Port}; Database={Config.DbName};" +
                                                    $" User ID={Config.User}; Password={Config.Password};";
        public static string userNameInfo()
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
        public static bool validUser(string username, string password)
        {
            /*
             проверяет, есть ли пользователь с таким именем и паролем в БД
             username - имя пользователя
             password - пароль
             */

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT username FROM user WHERE username=\"{username}\" and password=\"{password}\"";
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader()) //используем using, чтобы не прописывать reader.Close()
                    {
                        if (reader.HasRows) // если есть данные
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex) { return false; }
            }
            return false;
        }
    }
}
