using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Quan_Ly_Nhan_Su.config
{
    public class connectDB
    {
        public static MySqlConnection getConnection()
        {
            string server = "localhost";
            string database = "quan_ly_nhan_su";
            string uid = "root";
            string password = "123456";
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                Console.WriteLine("Database connection successful.");
                return mySqlConnection;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Database connection error: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
                return null;
            }
        }
        public void closeConnection(MySqlConnection conn)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
