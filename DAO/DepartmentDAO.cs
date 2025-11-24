using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;
using System.Linq.Expressions;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class DepartmentDAO
    {
        private MySqlConnection conn;
        public List<DepartmentDTO> GetAll()
        {
            List<DepartmentDTO> departments = new List<DepartmentDTO>();
            try
            {
                using(conn = connectDB.getConnection())
                {
                    if (conn == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }

                    conn.Open();
                    string query = "SELECT * FROM phongban";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DepartmentDTO dept = new DepartmentDTO
                                {
                                    MaPhong = reader["maPhong"].ToString(),
                                    TenPhong = reader["tenPhong"].ToString(),
                                    NgayThanhLap = reader["ngayThanhLap"] != DBNull.Value ? Convert.ToDateTime(reader["ngayThanhLap"]) : DateTime.MinValue,
                                    MaTruongPhong = reader["maTruongPhong"].ToString()
                                };
                                departments.Add(dept);
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chi tiết lỗi DAO: {ex.Message} | StackTrace: {ex.StackTrace}");
                throw new Exception($"Lỗi khi lấy danh sách phòng ban: {ex.Message}");
            }
            return departments;
        }

        public DepartmentDTO GetById(string maPhong)
        {
            try
            {
                using(conn = connectDB.getConnection())
                {
                    if (conn == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }

                    conn.Open();
                    string query = "SELECT MaPhong, TenPhong, maTruongPhong, ngayThanhLap FROM phongban WHERE MaPhong = @maPhong";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new DepartmentDTO
                                {
                                    MaPhong = reader["MaPhong"].ToString(),
                                    TenPhong = reader["TenPhong"].ToString(),
                                    MaTruongPhong = reader["maTruongPhong"].ToString(),
                                    NgayThanhLap = reader["ngayThanhLap"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ngayThanhLap"])
                                };
                            }
                        }
                    }
                }      
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin phòng ban: {ex.Message}");
            }
            return null;
        }

        /// Thêm phòng ban mới.
  
        public bool Insert(DepartmentDTO department)
        {
            MySqlConnection conn = null;
            try
            {
               using (conn = connectDB.getConnection())
                {
                    if (conn == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }

                    conn.Open();
                    string query = "INSERT INTO phongban (MaPhong, TenPhong, ngayThanhLap) VALUES (@MaPhong, @TenPhong, @ngayThanhLap)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhong", department.MaPhong);
                        cmd.Parameters.AddWithValue("@TenPhong", department.TenPhong);
                        cmd.Parameters.AddWithValue("@ngayThanhLap", department.NgayThanhLap);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm phòng ban: {ex.Message}");
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
                using(conn = connectDB.getConnection())
                {
                    if (conn == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }

                    conn.Open();
                    string query = "UPDATE phongban SET TenPhong = @TenPhong, maTruongPhong = @TruongPhong WHERE MaPhong = @MaPhong";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhong", department.MaPhong);
                        cmd.Parameters.AddWithValue("@TenPhong", department.TenPhong);
                        cmd.Parameters.AddWithValue("@TruongPhong", department.MaTruongPhong);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật phòng ban: {ex.Message}");
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
                using(conn = connectDB.getConnection())
                {
                    if (conn == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }

                    conn.Open();
                    string query = "DELETE FROM phongban WHERE MaPhong = @MaPhong";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa phòng ban: {ex.Message}");
            }
        }

        public List<DepartmentDTO> search(string keyWord)
        {
            List<DepartmentDTO> list = new List<DepartmentDTO> ();
            try
            {
                using(conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * " +
                        "FROM phongban" +
                        "WHERE maphong LIKE @keyWord " +
                        "OR tenphong LIKE @keyWord";
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Parameters.AddWithValue("keyWord", "%" + keyWord + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DepartmentDTO dto = new DepartmentDTO
                                {
                                    MaPhong = reader["maPhong"].ToString(),
                                    TenPhong = reader["tenPhong"].ToString(),
                                    NgayThanhLap = reader["ngayThanhLap"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ngayThanhLap"]),
                                    MaTruongPhong = reader["maTruongPhong"].ToString()
                                };
                                list.Add(dto);
                            }
                            
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($" Error searching employees: {ex.Message}");
            }
            return list;             
        }
    }
}