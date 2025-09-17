using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su
{
    internal static class Program
    {
        static void Main()
        {
            connectDB connectDB = new connectDB();
            MySqlConnection con = connectDB.getConnection();
            con.Open();
            string query = "select * from nhanvien";
            MySqlCommand mySqlCommand = new MySqlCommand(query, con);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(1));
            }
        }
    }
}
