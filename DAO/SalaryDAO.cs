using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class SalaryDAO
    {
        // Hiện tại đang viết theo kiểu có trạng thái,
        // vì database chưa biết có thêm cột trạng thái hay kh

        // Lấy tất cả bản ghi lương
        public List<SalaryDTO> GetAll()
        {
            var list = new List<SalaryDTO>();
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "SELECT khoanTruBaoHiem, " +
                        "khoanTruKhac, " +
                        "luongCoBan, " +
                        "luongThucTe, " +
                        "luongThuong, " +
                        "maluong, " +
                        "phuCapChucVu, " +
                        "phuCapKhac, " +
                        "thucLanh, " +
                        "thue " +
                        "FROM luong WHERE TinhTrang = 1", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new SalaryDTO
                            {
                                KhoanTruBaoHiem = Convert.ToDecimal(reader["khoanTruBaoHiem"]),
                                KhoanTruKhac = Convert.ToDecimal(reader["khoanTruKhac"]),
                                LuongCoBan = Convert.ToDecimal(reader["luongCoBan"]),
                                LuongThucTe = reader["luongThucTe"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["luongThucTe"]),
                                LuongThuong = Convert.ToDecimal(reader["luongThuong"]),
                                MaLuong = reader["maluong"].ToString(),
                                PhuCapChucVu = Convert.ToDecimal(reader["phuCapChucVu"]),
                                PhuCapKhac = Convert.ToDecimal(reader["phuCapKhac"]),
                                ThucLanh = reader["thucLanh"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["thucLanh"]),
                                Thue = Convert.ToDecimal(reader["thue"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return null;
            }
            return list;
        }

        // get by ID
        public SalaryDTO GetById(string maLuong)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "SELECT MaLuong, LuongCoBan, LuongThuong, LuongThucTe, PhuCapChucVu, PhuCapKhac, KhoanTruBaoHiem, KhoanTruKhac, Thue, ThucLanh " +
                        "FROM luong WHERE MaLuong = @MaLuong AND TinhTrang = 1", conn);
                    cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new SalaryDTO
                            {
                                MaLuong = reader["MaLuong"].ToString(),
                                LuongCoBan = Convert.ToDecimal(reader["LuongCoBan"]),
                                LuongThuong = Convert.ToDecimal(reader["LuongThuong"]),
                                LuongThucTe = reader["LuongThucTe"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["LuongThucTe"]),
                                PhuCapChucVu = Convert.ToDecimal(reader["PhuCapChucVu"]),
                                PhuCapKhac = Convert.ToDecimal(reader["PhuCapKhac"]),
                                KhoanTruBaoHiem = Convert.ToDecimal(reader["KhoanTruBaoHiem"]),
                                KhoanTruKhac = Convert.ToDecimal(reader["KhoanTruKhac"]),
                                Thue = Convert.ToDecimal(reader["Thue"]),
                                ThucLanh = reader["ThucLanh"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["ThucLanh"])
                            };
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return null;
            }
        }

        // Thêm
        public bool Insert(SalaryDTO salary)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "INSERT INTO luong (MaLuong, LuongCoBan, LuongThuong, LuongThucTe, PhuCapChucVu, PhuCapKhac, KhoanTruBaoHiem, KhoanTruKhac, Thue, ThucLanh, TinhTrang) " +
                        "VALUES (@MaLuong, @LuongCoBan, @LuongThuong, @LuongThucTe, @PhuCapChucVu, @PhuCapKhac, @KhoanTruBaoHiem, @KhoanTruKhac, @Thue, @ThucLanh, 1)", conn);
                    cmd.Parameters.AddWithValue("@MaLuong", salary.MaLuong);
                    cmd.Parameters.AddWithValue("@LuongCoBan", salary.LuongCoBan);
                    cmd.Parameters.AddWithValue("@LuongThuong", salary.LuongThuong);
                    cmd.Parameters.AddWithValue("@LuongThucTe", (object)salary.LuongThucTe ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhuCapChucVu", salary.PhuCapChucVu);
                    cmd.Parameters.AddWithValue("@PhuCapKhac", salary.PhuCapKhac);
                    cmd.Parameters.AddWithValue("@KhoanTruBaoHiem", salary.KhoanTruBaoHiem);
                    cmd.Parameters.AddWithValue("@KhoanTruKhac", salary.KhoanTruKhac);
                    cmd.Parameters.AddWithValue("@Thue", salary.Thue);
                    cmd.Parameters.AddWithValue("@ThucLanh", (object)salary.ThucLanh ?? DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }

        // Update
        public bool Update(SalaryDTO salary)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "UPDATE luong SET LuongCoBan = @LuongCoBan, LuongThuong = @LuongThuong, LuongThucTe = @LuongThucTe, " +
                        "PhuCapChucVu = @PhuCapChucVu, PhuCapKhac = @PhuCapKhac, KhoanTruBaoHiem = @KhoanTruBaoHiem, KhoanTruKhac = @KhoanTruKhac, " +
                        "Thue = @Thue, ThucLanh = @ThucLanh WHERE MaLuong = @MaLuong AND TinhTrang = 1", conn);
                    cmd.Parameters.AddWithValue("@MaLuong", salary.MaLuong);
                    cmd.Parameters.AddWithValue("@LuongCoBan", salary.LuongCoBan);
                    cmd.Parameters.AddWithValue("@LuongThuong", salary.LuongThuong);
                    cmd.Parameters.AddWithValue("@LuongThucTe", (object)salary.LuongThucTe ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhuCapChucVu", salary.PhuCapChucVu);
                    cmd.Parameters.AddWithValue("@PhuCapKhac", salary.PhuCapKhac);
                    cmd.Parameters.AddWithValue("@KhoanTruBaoHiem", salary.KhoanTruBaoHiem);
                    cmd.Parameters.AddWithValue("@KhoanTruKhac", salary.KhoanTruKhac);
                    cmd.Parameters.AddWithValue("@Thue", salary.Thue);
                    cmd.Parameters.AddWithValue("@ThucLanh", (object)salary.ThucLanh ?? DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }

        // Xóa
        public bool Delete(string maLuong)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand("UPDATE luong SET TinhTrang = 0 WHERE MaLuong = @MaLuong", conn);
                    cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }
    }
}
