using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class TimesheetDAO
    {
        // Lấy tất cả timesheet
        public List<TimesheetDTO> GetAll()
        {
            var list = new List<TimesheetDTO>();
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM bangchamcong", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TimesheetDTO
                            {
                                MaBangChamCong = reader.GetString("maBangChamCong"),
                                MaNV = reader.GetString("maNV"),
                                ThangChamCong = reader.GetInt32("thangChamCong"),
                                NamChamCong = reader.GetInt32("namChamCong"),
                                SoNgayLamViec = reader.GetInt32("soNgayLamViec"),
                                SoNgayNghi = reader.GetInt32("soNgayNghi"),
                                SoNgayTre = reader.GetInt32("soNgayTre"),
                                SoGioLamThem = reader.GetInt32("soGioLamThem"),
                                ChiTiet = reader.IsDBNull(reader.GetOrdinal("chiTiet")) ? null : reader.GetString("chiTiet"),
                                TrangThai = reader.IsDBNull(reader.GetOrdinal("trangThai")) ? null : reader.GetString("trangThai")
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

        // Lấy timesheet theo mã
        public TimesheetDTO GetById(string maBangChamCong)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM bangchamcong WHERE maBangChamCong = @maBangChamCong", conn);
                    cmd.Parameters.AddWithValue("@maBangChamCong", maBangChamCong);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TimesheetDTO
                            {
                                MaBangChamCong = reader.GetString("maBangChamCong"),
                                MaNV = reader.GetString("maNV"),
                                ThangChamCong = reader.GetInt32("thangChamCong"),
                                NamChamCong = reader.GetInt32("namChamCong"),
                                SoNgayLamViec = reader.GetInt32("soNgayLamViec"),
                                SoNgayNghi = reader.GetInt32("soNgayNghi"),
                                SoNgayTre = reader.GetInt32("soNgayTre"),
                                SoGioLamThem = reader.GetInt32("soGioLamThem"),
                                ChiTiet = reader.IsDBNull(reader.GetOrdinal("chiTiet")) ? null : reader.GetString("chiTiet"),
                                TrangThai = reader.IsDBNull(reader.GetOrdinal("trangThai")) ? null : reader.GetString("trangThai")
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

        // Thêm mới timesheet
        public bool Insert(TimesheetDTO timesheet)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "INSERT INTO bangchamcong (maBangChamCong, maNV, thangChamCong, namChamCong, soNgayLamViec, soNgayNghi, soNgayTre, soGioLamThem, chiTiet, trangThai) " +
                        "VALUES (@maBangChamCong, @maNV, @thangChamCong, @namChamCong, @soNgayLamViec, @soNgayNghi, @soNgayTre, @soGioLamThem, @chiTiet, @trangThai)", conn);
                    cmd.Parameters.AddWithValue("@maBangChamCong", timesheet.MaBangChamCong);
                    cmd.Parameters.AddWithValue("@maNV", timesheet.MaNV);
                    cmd.Parameters.AddWithValue("@thangChamCong", timesheet.ThangChamCong);
                    cmd.Parameters.AddWithValue("@namChamCong", timesheet.NamChamCong);
                    cmd.Parameters.AddWithValue("@soNgayLamViec", timesheet.SoNgayLamViec);
                    cmd.Parameters.AddWithValue("@soNgayNghi", timesheet.SoNgayNghi);
                    cmd.Parameters.AddWithValue("@soNgayTre", timesheet.SoNgayTre);
                    cmd.Parameters.AddWithValue("@soGioLamThem", timesheet.SoGioLamThem);
                    cmd.Parameters.AddWithValue("@chiTiet", (object)timesheet.ChiTiet ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@trangThai", (object)timesheet.TrangThai ?? DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }

        // Cập nhật timesheet
        public bool Update(TimesheetDTO timesheet)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "UPDATE bangchamcong SET maNV = @maNV, thangChamCong = @thangChamCong, namChamCong = @namChamCong, soNgayLamViec = @soNgayLamViec, soNgayNghi = @soNgayNghi, soNgayTre = @soNgayTre, soGioLamThem = @soGioLamThem, chiTiet = @chiTiet, trangThai = @trangThai WHERE maBangChamCong = @maBangChamCong", conn);
                    cmd.Parameters.AddWithValue("@maBangChamCong", timesheet.MaBangChamCong);
                    cmd.Parameters.AddWithValue("@maNV", timesheet.MaNV);
                    cmd.Parameters.AddWithValue("@thangChamCong", timesheet.ThangChamCong);
                    cmd.Parameters.AddWithValue("@namChamCong", timesheet.NamChamCong);
                    cmd.Parameters.AddWithValue("@soNgayLamViec", timesheet.SoNgayLamViec);
                    cmd.Parameters.AddWithValue("@soNgayNghi", timesheet.SoNgayNghi);
                    cmd.Parameters.AddWithValue("@soNgayTre", timesheet.SoNgayTre);
                    cmd.Parameters.AddWithValue("@soGioLamThem", timesheet.SoGioLamThem);
                    cmd.Parameters.AddWithValue("@chiTiet", (object)timesheet.ChiTiet ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@trangThai", (object)timesheet.TrangThai ?? DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }

        // Xóa timesheet (xóa vật lý)
        public bool Delete(string maBangChamCong)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand("DELETE FROM bangchamcong WHERE maBangChamCong = @maBangChamCong", conn);
                    cmd.Parameters.AddWithValue("@maBangChamCong", maBangChamCong);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }

        // Tìm kiếm timesheet theo mã hoặc mã nhân viên
        public List<TimesheetDTO> Search(string searchTerm)
        {
            var list = new List<TimesheetDTO>();
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM bangchamcong WHERE maBangChamCong = @searchTerm OR maNV LIKE @searchTermLike", conn);
                    cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
                    cmd.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TimesheetDTO
                            {
                                MaBangChamCong = reader.GetString("maBangChamCong"),
                                MaNV = reader.GetString("maNV"),
                                ThangChamCong = reader.GetInt32("thangChamCong"),
                                NamChamCong = reader.GetInt32("namChamCong"),
                                SoNgayLamViec = reader.GetInt32("soNgayLamViec"),
                                SoNgayNghi = reader.GetInt32("soNgayNghi"),
                                SoNgayTre = reader.GetInt32("soNgayTre"),
                                SoGioLamThem = reader.GetInt32("soGioLamThem"),
                                ChiTiet = reader.IsDBNull(reader.GetOrdinal("chiTiet")) ? null : reader.GetString("chiTiet"),
                                TrangThai = reader.IsDBNull(reader.GetOrdinal("trangThai")) ? null : reader.GetString("trangThai")
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
    }
}