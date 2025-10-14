using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class FunctionDAO
    {
        public FunctionDTO GetById(int maChucNang)
        {
            FunctionDTO func = null;
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM chucnang WHERE maChucNang = @maChucNang";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maChucNang", maChucNang);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            func = new FunctionDTO
                            {
                                MaChucNang = reader.GetInt32("maChucNang"),
                                TenChucNang = reader.GetString("tenChucNang"),
                                MoTa = reader.IsDBNull(reader.GetOrdinal("moTa")) ? null : reader.GetString("moTa"),
                                TinhTrang = reader.GetBoolean("tinhTrang")
                            };
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting function by ID: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return func;
        }

        public List<FunctionDTO> GetAll()
        {
            var list = new List<FunctionDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                // SỬA: Thêm "tinhTrang" vào câu select (dùng * là đủ)
                string query = "SELECT * FROM chucnang";
                using (var command = new MySqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var func = new FunctionDTO
                            {
                                // SỬA: Đọc MaChucNang là GetInt32 và TinhTrang là GetBoolean
                                MaChucNang = reader.GetInt32("maChucNang"),
                                TenChucNang = reader.GetString("tenChucNang"),
                                MoTa = reader.IsDBNull(reader.GetOrdinal("moTa")) ? null : reader.GetString("moTa"),
                                TinhTrang = reader.GetBoolean("tinhTrang")
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

        public bool Create(FunctionDTO function)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                // SỬA: Bỏ maChucNang khỏi câu INSERT (giả sử nó là auto-increment)
                string query = "INSERT INTO chucnang (tenChucNang, tinhTrang) VALUES (@tenChucNang, @tinhTrang)";
                using (var command = new MySqlCommand(query, conn))
                {
                    // SỬA: Không cần add maChucNang
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
                    command.Parameters.AddWithValue("@maChucNang", function.MaChucNang); // Giữ nguyên vì cần cho WHERE
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

        // SỬA: Tham số đầu vào là int
        public bool Delete(int maChucNang)
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

        // Ghi chú: Tìm kiếm theo ID sẽ không hoạt động tốt nếu người dùng nhập văn bản.
        // Tạm thời chỉ tìm kiếm theo tên.
        public List<FunctionDTO> Search(string searchTerm)
        {
            var functions = new List<FunctionDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM chucnang WHERE tenChucNang LIKE @searchTermLike";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            functions.Add(new FunctionDTO
                            {
                                MaChucNang = reader.GetInt32("maChucNang"),
                                TenChucNang = reader.GetString("tenChucNang"),
                                TinhTrang = reader.GetBoolean("tinhTrang")
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