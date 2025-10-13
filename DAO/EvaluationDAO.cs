using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class EvaluationDAO
    {
        // Lấy tất cả evaluation
        public List<EvaluationDTO> GetAll()
        {
            var list = new List<EvaluationDTO>();
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM danhgia", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new EvaluationDTO
                            {
                                MaDanhGia = reader.GetString("maDanhGia"),
                                MaNhanVien = reader.GetString("maNhanVien"),
                                MaNguoiDanhGia = reader.GetString("maNguoiDanhGia"),
                                NgayDanhGia = reader.GetDateTime("ngayDanhGia"),
                                DiemDanhGia = reader.GetInt32("diemDanhGia"),
                                XepLoai = reader.IsDBNull(reader.GetOrdinal("xepLoai")) ? null : reader.GetString("xepLoai"),
                                ChiTietDanhGia = reader.IsDBNull(reader.GetOrdinal("chiTietDanhGia")) ? null : reader.GetString("chiTietDanhGia"),
                                GhiChu = reader.IsDBNull(reader.GetOrdinal("ghiChu")) ? null : reader.GetString("ghiChu")
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

        // Lấy evaluation theo mã
        public EvaluationDTO GetById(string maDanhGia)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM danhgia WHERE maDanhGia = @maDanhGia", conn);
                    cmd.Parameters.AddWithValue("@maDanhGia", maDanhGia);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EvaluationDTO
                            {
                                MaDanhGia = reader.GetString("maDanhGia"),
                                MaNhanVien = reader.GetString("maNhanVien"),
                                MaNguoiDanhGia = reader.GetString("maNguoiDanhGia"),
                                NgayDanhGia = reader.GetDateTime("ngayDanhGia"),
                                DiemDanhGia = reader.GetInt32("diemDanhGia"),
                                XepLoai = reader.IsDBNull(reader.GetOrdinal("xepLoai")) ? null : reader.GetString("xepLoai"),
                                ChiTietDanhGia = reader.IsDBNull(reader.GetOrdinal("chiTietDanhGia")) ? null : reader.GetString("chiTietDanhGia"),
                                GhiChu = reader.IsDBNull(reader.GetOrdinal("ghiChu")) ? null : reader.GetString("ghiChu")
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

        // Thêm mới evaluation
        public bool Insert(EvaluationDTO evaluation)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "INSERT INTO danhgia (maDanhGia, maNhanVien, maNguoiDanhGia, ngayDanhGia, diemDanhGia, xepLoai, chiTietDanhGia, ghiChu) " +
                        "VALUES (@maDanhGia, @maNhanVien, @maNguoiDanhGia, @ngayDanhGia, @diemDanhGia, @xepLoai, @chiTietDanhGia, @ghiChu)", conn);
                    cmd.Parameters.AddWithValue("@maDanhGia", evaluation.MaDanhGia);
                    cmd.Parameters.AddWithValue("@maNhanVien", evaluation.MaNhanVien);
                    cmd.Parameters.AddWithValue("@maNguoiDanhGia", evaluation.MaNguoiDanhGia);
                    cmd.Parameters.AddWithValue("@ngayDanhGia", evaluation.NgayDanhGia);
                    cmd.Parameters.AddWithValue("@diemDanhGia", evaluation.DiemDanhGia);
                    cmd.Parameters.AddWithValue("@xepLoai", (object)evaluation.XepLoai ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@chiTietDanhGia", (object)evaluation.ChiTietDanhGia ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ghiChu", (object)evaluation.GhiChu ?? DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }

        // Cập nhật evaluation
        public bool Update(EvaluationDTO evaluation)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "UPDATE danhgia SET maNhanVien = @maNhanVien, maNguoiDanhGia = @maNguoiDanhGia, ngayDanhGia = @ngayDanhGia, diemDanhGia = @diemDanhGia, xepLoai = @xepLoai, chiTietDanhGia = @chiTietDanhGia, ghiChu = @ghiChu WHERE maDanhGia = @maDanhGia", conn);
                    cmd.Parameters.AddWithValue("@maDanhGia", evaluation.MaDanhGia);
                    cmd.Parameters.AddWithValue("@maNhanVien", evaluation.MaNhanVien);
                    cmd.Parameters.AddWithValue("@maNguoiDanhGia", evaluation.MaNguoiDanhGia);
                    cmd.Parameters.AddWithValue("@ngayDanhGia", evaluation.NgayDanhGia);
                    cmd.Parameters.AddWithValue("@diemDanhGia", evaluation.DiemDanhGia);
                    cmd.Parameters.AddWithValue("@xepLoai", (object)evaluation.XepLoai ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@chiTietDanhGia", (object)evaluation.ChiTietDanhGia ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ghiChu", (object)evaluation.GhiChu ?? DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }

        // Xóa evaluation (xóa vật lý)
        public bool Delete(string maDanhGia)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand("DELETE FROM danhgia WHERE maDanhGia = @maDanhGia", conn);
                    cmd.Parameters.AddWithValue("@maDanhGia", maDanhGia);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }

        // Tìm kiếm evaluation theo mã hoặc mã nhân viên
        public List<EvaluationDTO> Search(string searchTerm)
        {
            var list = new List<EvaluationDTO>();
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM danhgia WHERE maDanhGia = @searchTerm OR maNhanVien LIKE @searchTermLike", conn);
                    cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
                    cmd.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new EvaluationDTO
                            {
                                MaDanhGia = reader.GetString("maDanhGia"),
                                MaNhanVien = reader.GetString("maNhanVien"),
                                MaNguoiDanhGia = reader.GetString("maNguoiDanhGia"),
                                NgayDanhGia = reader.GetDateTime("ngayDanhGia"),
                                DiemDanhGia = reader.GetInt32("diemDanhGia"),
                                XepLoai = reader.IsDBNull(reader.GetOrdinal("xepLoai")) ? null : reader.GetString("xepLoai"),
                                ChiTietDanhGia = reader.IsDBNull(reader.GetOrdinal("chiTietDanhGia")) ? null : reader.GetString("chiTietDanhGia"),
                                GhiChu = reader.IsDBNull(reader.GetOrdinal("ghiChu")) ? null : reader.GetString("ghiChu")
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