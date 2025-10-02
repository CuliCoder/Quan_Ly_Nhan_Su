using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class DepartmentDAO
    {
        /// <summary>
        /// Lấy danh sách tất cả phòng ban.
        /// </summary>
        /// <returns>List<DepartmentDTO> chứa thông tin phòng ban.</returns>
        public List<DepartmentDTO> GetAll()
        {
            List<DepartmentDTO> departments = new List<DepartmentDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                if (conn == null)
                {
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                }

                conn.Open();
                string query = "SELECT maPhong AS MaPhong, tenPhong AS TenPhong FROM phongban";  // Sửa: Tên bảng + alias cho cột
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DepartmentDTO dept = new DepartmentDTO
                            {
                                MaPhong = reader["MaPhong"].ToString(),  // Giờ dùng alias để khớp property
                                TenPhong = reader["TenPhong"].ToString()
                            };
                            departments.Add(dept);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Thêm log chi tiết hơn để debug (tùy chọn)
                Console.WriteLine($"Chi tiết lỗi DAO: {ex.Message} | StackTrace: {ex.StackTrace}");
                throw new Exception($"Lỗi khi lấy danh sách phòng ban: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return departments;
        }

        /// <summary>
        /// Lấy thông tin phòng ban theo mã.
        /// </summary>
        /// <param name="maPhong">Mã phòng ban.</param>
        /// <returns>DepartmentDTO nếu tìm thấy, null nếu không.</returns>
        public DepartmentDTO GetById(string maPhong)
        {
            DepartmentDTO dept = null;
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                if (conn == null)
                {
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                }

                conn.Open();
                string query = "SELECT MaPhong, TenPhong FROM Departments WHERE MaPhong = @MaPhong";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dept = new DepartmentDTO
                            {
                                MaPhong = reader["MaPhong"].ToString(),
                                TenPhong = reader["TenPhong"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin phòng ban: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return dept;
        }

        /// <summary>
        /// Thêm phòng ban mới.
        /// </summary>
        /// <param name="department">Thông tin phòng ban cần thêm.</param>
        /// <returns>True nếu thành công, false nếu thất bại.</returns>
        public bool Insert(DepartmentDTO department)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                if (conn == null)
                {
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                }

                conn.Open();
                string query = "INSERT INTO Departments (MaPhong, TenPhong) VALUES (@MaPhong, @TenPhong)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhong", department.MaPhong);
                    cmd.Parameters.AddWithValue("@TenPhong", department.TenPhong);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm phòng ban: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Cập nhật thông tin phòng ban.
        /// </summary>
        /// <param name="department">Thông tin phòng ban cần cập nhật.</param>
        /// <returns>True nếu thành công, false nếu thất bại.</returns>
        public bool Update(DepartmentDTO department)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                if (conn == null)
                {
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                }

                conn.Open();
                string query = "UPDATE Departments SET TenPhong = @TenPhong WHERE MaPhong = @MaPhong";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhong", department.MaPhong);
                    cmd.Parameters.AddWithValue("@TenPhong", department.TenPhong);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật phòng ban: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Xóa phòng ban theo mã.
        /// </summary>
        /// <param name="maPhong">Mã phòng ban cần xóa.</param>
        /// <returns>True nếu thành công, false nếu thất bại.</returns>
        public bool Delete(string maPhong)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                if (conn == null)
                {
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                }

                conn.Open();
                string query = "DELETE FROM Departments WHERE MaPhong = @MaPhong";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa phòng ban: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }
    }
}