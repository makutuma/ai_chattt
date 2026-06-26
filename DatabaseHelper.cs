using System;
using MySql.Data.MySqlClient;

namespace ai_chatttt
{
    internal class DatabaseHelper
    {
        private string connectionString =
            "server=localhost;database=aichatttt;uid=root;pwd=@1Makutuma;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}