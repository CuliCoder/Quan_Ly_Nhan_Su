using MySql.Data.MySqlClient;
using System;
using System.Configuration; // để đọc App.config
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.config
{
    public class connectDB
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public static MySqlConnection getConnection()
        {
            try
            {
                // Đọc connection string từ App.config
                string connectionString = ConfigurationManager
                                          .ConnectionStrings["MyDB"]
                                          .ConnectionString;

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

        public static void closeConnection(MySqlConnection conn)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
