using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text;

namespace ProjetFilRouge.Utils
{
    sealed class ConnectionSql    
    {
        private static string server = "localhost";
        private static string user = "root";
        private static string password = "123456789";
        private static string db = "projetbdd";
        private static string port = "3306";

        private ConnectionSql() { }
        public static MySqlConnection getConnection()
        {
            return new MySqlConnection(getConnStr());
        }

        private static string getConnStr()
        {
            StringBuilder connStr = new StringBuilder();
            connStr.Append($"server={server};");
            connStr.Append($"user={user};");
            connStr.Append($"database={db};");
            connStr.Append($"port={port};");
            connStr.Append($"password={password}");
            return connStr.ToString();
        }
    }
}


