using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for Function table
    /// </summary>
    public class FunctionDAO
    {
        /// <summary>
        /// Creates a new function in the chucnang table
        /// </summary>
        public bool Create(FunctionDTO function)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "INSERT INTO chucnang (maChucNang, tenChucNang, tinhTrang) VALUES (@maChucNang, @tenChucNang, @tinhTrang)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maChucNang", function.MaChucNang);
                    command.Parameters.AddWithValue("@tenChucNang", function.TenChucNang);
                    command.Parameters.AddWithValue("@tinhTrang", function.TinhTrang);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating function: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing function in the chucnang table
        /// </summary>
        public bool Update(FunctionDTO function)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "UPDATE chucnang SET tenChucNang = @tenChucNang, tinhTrang = @tinhTrang WHERE maChucNang = @maChucNang";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maChucNang", function.MaChucNang);
                    command.Parameters.AddWithValue("@tenChucNang", function.TenChucNang);
                    command.Parameters.AddWithValue("@tinhTrang", function.TinhTrang);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating function: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Deletes a function from the chucnang table
        /// </summary>
        public bool Delete(string maChucNang)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM chucnang WHERE maChucNang = @maChucNang";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maChucNang", maChucNang);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting function: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Searches for functions by maChucNang or tenChucNang
        /// </summary>
        public List<FunctionDTO> Search(string searchTerm)
        {
            var functions = new List<FunctionDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM chucnang WHERE maChucNang = @searchTerm OR tenChucNang LIKE @searchTermLike";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            functions.Add(new FunctionDTO
                            {
                                MaChucNang = reader.GetString("maChucNang"),
                                TenChucNang = reader.GetString("tenChucNang"),
                                TinhTrang = reader.GetString("tinhTrang")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching functions: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return functions;
        }
    }
}