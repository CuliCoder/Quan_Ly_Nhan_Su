using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for Evaluation table
    /// </summary>
    public class EvaluationDAO
    {
        /// <summary>
        /// Creates a new evaluation in the danhgia table
        /// </summary>
        public bool Create(EvaluationDTO evaluation)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "INSERT INTO danhgia (maDanhGia, maNhanVien, maNguoiDanhGia, ngayDanhGia, diemDanhGia, xepLoai, chiTietDanhGia, ghiChu) VALUES (@maDanhGia, @maNhanVien, @maNguoiDanhGia, @ngayDanhGia, @diemDanhGia, @xepLoai, @chiTietDanhGia, @ghiChu)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maDanhGia", evaluation.MaDanhGia);
                    command.Parameters.AddWithValue("@maNhanVien", evaluation.MaNhanVien);
                    command.Parameters.AddWithValue("@maNguoiDanhGia", evaluation.MaNguoiDanhGia);
                    command.Parameters.AddWithValue("@ngayDanhGia", evaluation.NgayDanhGia);
                    command.Parameters.AddWithValue("@diemDanhGia", evaluation.DiemDanhGia);
                    command.Parameters.AddWithValue("@xepLoai", (object)evaluation.XepLoai ?? DBNull.Value);
                    command.Parameters.AddWithValue("@chiTietDanhGia", (object)evaluation.ChiTietDanhGia ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ghiChu", (object)evaluation.GhiChu ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating evaluation: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing evaluation in the danhgia table
        /// </summary>
        public bool Update(EvaluationDTO evaluation)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "UPDATE danhgia SET maNhanVien = @maNhanVien, maNguoiDanhGia = @maNguoiDanhGia, ngayDanhGia = @ngayDanhGia, diemDanhGia = @diemDanhGia, xepLoai = @xepLoai, chiTietDanhGia = @chiTietDanhGia, ghiChu = @ghiChu WHERE maDanhGia = @maDanhGia";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maDanhGia", evaluation.MaDanhGia);
                    command.Parameters.AddWithValue("@maNhanVien", evaluation.MaNhanVien);
                    command.Parameters.AddWithValue("@maNguoiDanhGia", evaluation.MaNguoiDanhGia);
                    command.Parameters.AddWithValue("@ngayDanhGia", evaluation.NgayDanhGia);
                    command.Parameters.AddWithValue("@diemDanhGia", evaluation.DiemDanhGia);
                    command.Parameters.AddWithValue("@xepLoai", (object)evaluation.XepLoai ?? DBNull.Value);
                    command.Parameters.AddWithValue("@chiTietDanhGia", (object)evaluation.ChiTietDanhGia ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ghiChu", (object)evaluation.GhiChu ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating evaluation: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Deletes an evaluation from the danhgia table
        /// </summary>
        public bool Delete(string maDanhGia)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM danhgia WHERE maDanhGia = @maDanhGia";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maDanhGia", maDanhGia);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting evaluation: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Searches for evaluations by maDanhGia or maNhanVien
        /// </summary>
        public List<EvaluationDTO> Search(string searchTerm)
        {
            var evaluations = new List<EvaluationDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM danhgia WHERE maDanhGia = @searchTerm OR maNhanVien LIKE @searchTermLike";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            evaluations.Add(new EvaluationDTO
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
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching evaluations: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return evaluations;
        }
    }
}