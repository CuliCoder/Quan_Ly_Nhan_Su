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
        public List<FunctionDTO> GetAll()
        {
            var list = new List<FunctionDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM chucnang";
                using (var command = new MySqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var func = new FunctionDTO
                            {
                                MaChucNang = reader.GetString("maChucNang"),
                                TenChucNang = reader.GetString("tenChucNang"),
                                MoTa = reader["moTa"] as string   // có thể null
                            };
                            list.Add(func);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting functions: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return list;
        }

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
                // SỬA: Đổi tên cột "tenChucNang" thành "TenCN" để khớp với CSDL
                string query = "INSERT INTO chucnang (TenCN, TinhTrang) VALUES (@tenChucNang, @tinhTrang)";
                using (var command = new MySqlCommand(query, conn))
                {
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
                // SỬA: Đổi tên các cột cho đúng với CSDL ("TenCN", "TinhTrang", "MaCN")
                string query = "UPDATE chucnang SET TenCN = @tenChucNang, TinhTrang = @tinhTrang WHERE MaCN = @maChucNang";
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
        public bool Delete(int maChucNang)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM chucnang WHERE MaCN = @maChucNang"; // Câu lệnh này đã đúng
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
        /// Searches for functions by tenChucNang
        /// </summary>
        public List<FunctionDTO> Search(string searchTerm)
        {
            var functions = new List<FunctionDTO>();
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    // Câu lệnh này đã đúng
                    string query = "SELECT MaCN, TenCN, TinhTrang FROM chucnang WHERE TenCN LIKE @searchTermLike"; // Bỏ điều kiện TinhTrang để tìm kiếm tất cả
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                functions.Add(new FunctionDTO
                                {
                                    MaChucNang = reader.GetInt32("MaCN"),
                                    TenChucNang = reader.GetString("TenCN"),
                                    TinhTrang = reader.GetBoolean("TinhTrang")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching functions: {ex.Message}");
            }
            return functions;
        }
    }
}