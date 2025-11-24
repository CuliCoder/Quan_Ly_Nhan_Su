using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class SalaryDAO
    {
        private MySqlConnection conn;

        /// <summary>
        /// Lấy toàn bộ danh sách lương
        /// </summary>
        public List<SalaryDTO> GetAll()
        {
            List<SalaryDTO> list = new List<SalaryDTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM luong";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalaryDTO dto = new SalaryDTO
                            {
                                MaLuong = reader["MaLuong"].ToString(),
                                MaNhanVien = reader["MaNhanVien"]?.ToString(),
                                LuongCoBan = Convert.ToDecimal(reader["LuongCoBan"]),
                                LuongTheoGio = Convert.ToDecimal(reader["LuongTheoGio"])
                            };
                            list.Add(dto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách lương: " + ex.Message);
            }
            return list;
        }

        /// <summary>
        /// Thêm mới một bản ghi lương
        /// </summary>
        public bool Insert(SalaryDTO dto)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO luong (MaLuong, MaNhanVien, LuongCoBan, LuongTheoGio)
                                   VALUES (@MaLuong, @MaNhanVien, @LuongCoBan, @LuongTheoGio)";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", dto.MaLuong);
                        cmd.Parameters.AddWithValue("@MaNhanVien", dto.MaNhanVien);
                        cmd.Parameters.AddWithValue("@LuongCoBan", dto.LuongCoBan);
                        cmd.Parameters.AddWithValue("@LuongTheoGio", dto.LuongTheoGio);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm lương: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin lương
        /// </summary>
        public bool Update(SalaryDTO dto)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE luong 
                                   SET MaNhanVien=@MaNhanVien, LuongCoBan=@LuongCoBan, LuongTheoGio=@LuongTheoGio
                                   WHERE MaLuong=@MaLuong";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", dto.MaLuong);
                        cmd.Parameters.AddWithValue("@MaNhanVien", dto.MaNhanVien);
                        cmd.Parameters.AddWithValue("@LuongCoBan", dto.LuongCoBan);
                        cmd.Parameters.AddWithValue("@LuongTheoGio", dto.LuongTheoGio);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật lương: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Xóa lương theo mã
        /// </summary>
        public bool Delete(string salaryId)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM luong WHERE MaLuong=@MaLuong";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", salaryId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khi xóa lương: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Tìm kiếm lương theo từ khóa (mã hoặc nhân viên)
        /// </summary>
        public List<SalaryDTO> Search(string keyword)
        {
            List<SalaryDTO> list = new List<SalaryDTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"SELECT * FROM luong 
                                   WHERE MaLuong LIKE @kw OR MaNhanVien LIKE @kw";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new SalaryDTO
                                {
                                    MaLuong = reader["MaLuong"].ToString(),
                                    MaNhanVien = reader["MaNhanVien"]?.ToString(),
                                    LuongCoBan = Convert.ToDecimal(reader["LuongCoBan"]),
                                    LuongTheoGio = Convert.ToDecimal(reader["LuongTheoGio"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm lương: " + ex.Message);
            }
            return list;
        }

        // Helper: get MaNhanVien by MaLuong
        public string GetMaNhanVienByMaLuong(string maLuong)
        {
            if (string.IsNullOrWhiteSpace(maLuong)) return null;
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    const string sql = "SELECT MaNhanVien FROM luong WHERE MaLuong = @MaLuong LIMIT 1";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                        var result = cmd.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SalaryDAO.GetMaNhanVienByMaLuong Error: " + ex.Message);
                return null;
            }
        }
    }
}
