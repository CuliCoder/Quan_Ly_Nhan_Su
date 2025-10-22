using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class EmployeeDAO
    {

        private MySqlConnection conn;
        public List<EmployeeDTO> getAll()
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM nhanvien";
                    using (var command = new MySqlCommand(sql, conn))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) {
                            EmployeeDTO emp = new EmployeeDTO
                            {
                                MaNhanVien = reader["maNhanVien"].ToString(),
                                SoCmnd = reader["soCmnd"].ToString(),
                                MaLuong = reader["maluong"].ToString(),
                                MaHopDong = reader["mahopdong"].ToString(),                     
                                MaChucVu = reader["maChucVu"] == DBNull.Value ? null : reader["maChucVu"].ToString(),
                                MaTaiKhoan = reader["maTaiKhoan"] == DBNull.Value ? null : reader["maTaiKhoan"].ToString(),
                                MaPhong = reader["maPhong"] == DBNull.Value ? null : reader["maPhong"].ToString(),
                                MucLuong = reader["mucLuong"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["mucLuong"])
                            };
                            list.Add(emp);
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            return list;
        }

        public bool createEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO nhanvien 
                          (maNhanVien, soCmnd, maLuong, maHopDong, maTrinhDo, maChucVu, maTaiKhoan, maPhong, mucLuong) 
                          VALUES 
                          (@maNhanVien, @soCmnd, @maLuong, @maHopDong, @maTrinhDo, @maChucVu, @maTaiKhoan, @maPhong, @mucLuong)";

                    using (var cmd = new MySqlCommand(sql, conn)) 
                    {
                        cmd.Parameters.AddWithValue("@maNhanVien", employeeDTO.MaNhanVien);
                        cmd.Parameters.AddWithValue("@soCmnd", employeeDTO.SoCmnd);
                        cmd.Parameters.AddWithValue("@maLuong", employeeDTO.MaLuong);
                        cmd.Parameters.AddWithValue("@maHopDong", employeeDTO.MaHopDong);
                        cmd.Parameters.AddWithValue("@maChucVu", employeeDTO.MaChucVu);
                        cmd.Parameters.AddWithValue("@maTaiKhoan", employeeDTO.MaTaiKhoan);
                        cmd.Parameters.AddWithValue("@maPhong", employeeDTO.MaPhong);
                        cmd.Parameters.AddWithValue("@mucLuong", employeeDTO.MucLuong.HasValue ? employeeDTO.MucLuong.Value : (object)DBNull.Value);      
                        
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating position: {ex.Message}");
                return false;
            }
        }

        public bool updateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE nhanvien 
                           SET soCmnd = @soCmnd,
                               maLuong = @maLuong,
                               maHopDong = @maHopDong,
                               maTrinhDo = @maTrinhDo,
                               maChucVu = @maChucVu,
                               maTaiKhoan = @maTaiKhoan,
                               maPhong = @maPhong,
                               mucLuong = @mucLuong
                           WHERE maNhanVien = @maNhanVien";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhanVien", employeeDTO.MaNhanVien);
                        cmd.Parameters.AddWithValue("@soCmnd", employeeDTO.SoCmnd);
                        cmd.Parameters.AddWithValue("@maLuong", employeeDTO.MaLuong);
                        cmd.Parameters.AddWithValue("@maHopDong", employeeDTO.MaHopDong);
                        cmd.Parameters.AddWithValue("@maChucVu", employeeDTO.MaChucVu ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@maTaiKhoan", employeeDTO.MaTaiKhoan ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@maPhong", employeeDTO.MaPhong ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@mucLuong", employeeDTO.MucLuong.HasValue ? employeeDTO.MucLuong.Value : (object)DBNull.Value);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating employee: {ex.Message}");
                return false;
            }
        }

        public bool deleteEmployee(string maNhanVien)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM nhanvien WHERE maNhanVien = @maNhanVien";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
                return false;
            }
        }

        public List<EmployeeDTO> searchEmployee(string keyword)
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();

            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"SELECT * FROM nhanvien 
                           WHERE maNhanVien LIKE @keyword 
                              OR soCmnd LIKE @keyword
                              OR maLuong LIKE @keyword
                              OR maHopDong LIKE @keyword
                              OR maTrinhDo LIKE @keyword
                              OR maChucVu LIKE @keyword
                              OR maTaiKhoan LIKE @keyword
                              OR maPhong LIKE @keyword";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeDTO dto = new EmployeeDTO(
                                    reader["maNhanVien"].ToString(),
                                    reader["soCmnd"].ToString(),
                                    reader["maluong"].ToString(),
                                    reader["mahopdong"].ToString(),
                                    reader["maTrinhDo"] == DBNull.Value ? null : reader["maTrinhDo"].ToString(),
                                    reader["maChucVu"] == DBNull.Value ? null : reader["maChucVu"].ToString(),
                                    reader["maTaiKhoan"] == DBNull.Value ? null : reader["maTaiKhoan"].ToString(),
                                    reader["maPhong"] == DBNull.Value ? null : reader["maPhong"].ToString(),
                                    reader["mucLuong"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["mucLuong"])
                                );

                                list.Add(dto);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($" Error searching employees: {ex.Message}");
            }

            return list;
        }

        /// <summary>
        /// Gets a specific employee by their account ID (maTaiKhoan).
        /// </summary>
        public EmployeeDTO GetByAccountId(string maTaiKhoan)
        {
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM nhanvien WHERE maTaiKhoan = @maTaiKhoan";
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Giả định bạn có một phương thức helper để map dữ liệu
                                // Nếu không, bạn có thể map trực tiếp tại đây:
                                return new EmployeeDTO
                                {
                                    MaNhanVien = reader["maNhanVien"].ToString(),
                                    SoCmnd = reader["soCmnd"].ToString(),
                                    MaLuong = reader["maluong"].ToString(),
                                    MaHopDong = reader["mahopdong"].ToString(),
                                    MaChucVu = reader["maChucVu"] != DBNull.Value ? reader["maChucVu"].ToString() : null,
                                    MaTaiKhoan = reader["maTaiKhoan"] != DBNull.Value ? reader["maTaiKhoan"].ToString() : null,
                                    MaPhong = reader["maPhong"] != DBNull.Value ? reader["maPhong"].ToString() : null,
                                    MucLuong = reader["mucLuong"] != DBNull.Value ? Convert.ToDecimal(reader["mucLuong"]) : (decimal?)null
                                };
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting employee by account ID: {ex.Message}");
                }
            }
            return null; // Trả về null nếu không tìm thấy
        }
    }
}