using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlLessons
{
    internal class DB
    {
        MySqlConnection conn = new MySqlConnection(
            "server = localhost; port = 3306; username = root; password = root; database = testdb");

        public void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }

        // Davai pozharim Ved`mu na troih

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        
        }

        public MySqlConnection getConn()
        {
            return conn;
        }
    }
}
