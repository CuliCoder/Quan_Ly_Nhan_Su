using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for Decision table
    /// </summary>
    public class DecisionDAO
    {
        /// <summary>
        /// Creates a new decision in the quyetdinh table
        /// </summary>
        public bool Create(DecisionDTO decision)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "INSERT INTO quyetdinh (maQuyetDinh, maNhanVien, ngayQuyetDinh, chucVuBanDau, chucVuSauQuyetDinh, nguoiLapQuyetDinh, lyDo) VALUES (@maQuyetDinh, @maNhanVien, @ngayQuyetDinh, @chucVuBanDau, @chucVuSauQuyetDinh, @nguoiLapQuyetDinh, @lyDo)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maQuyetDinh", decision.MaQuyetDinh);
                    command.Parameters.AddWithValue("@maNhanVien", decision.MaNhanVien);
                    command.Parameters.AddWithValue("@ngayQuyetDinh", decision.NgayQuyetDinh);
                    command.Parameters.AddWithValue("@chucVuBanDau", (object)decision.ChucVuBanDau ?? DBNull.Value);
                    command.Parameters.AddWithValue("@chucVuSauQuyetDinh", decision.ChucVuSauQuyetDinh);
                    command.Parameters.AddWithValue("@nguoiLapQuyetDinh", decision.NguoiLapQuyetDinh);
                    command.Parameters.AddWithValue("@lyDo", (object)decision.LyDo ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating decision: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing decision in the quyetdinh table
        /// </summary>
        public bool Update(DecisionDTO decision)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "UPDATE quyetdinh SET maNhanVien = @maNhanVien, ngayQuyetDinh = @ngayQuyetDinh, chucVuBanDau = @chucVuBanDau, chucVuSauQuyetDinh = @chucVuSauQuyetDinh, nguoiLapQuyetDinh = @nguoiLapQuyetDinh, lyDo = @lyDo WHERE maQuyetDinh = @maQuyetDinh";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maQuyetDinh", decision.MaQuyetDinh);
                    command.Parameters.AddWithValue("@maNhanVien", decision.MaNhanVien);
                    command.Parameters.AddWithValue("@ngayQuyetDinh", decision.NgayQuyetDinh);
                    command.Parameters.AddWithValue("@chucVuBanDau", (object)decision.ChucVuBanDau ?? DBNull.Value);
                    command.Parameters.AddWithValue("@chucVuSauQuyetDinh", decision.ChucVuSauQuyetDinh);
                    command.Parameters.AddWithValue("@nguoiLapQuyetDinh", decision.NguoiLapQuyetDinh);
                    command.Parameters.AddWithValue("@lyDo", (object)decision.LyDo ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating decision: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Deletes a decision from the quyetdinh table
        /// </summary>
        public bool Delete(string maQuyetDinh)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM quyetdinh WHERE maQuyetDinh = @maQuyetDinh";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maQuyetDinh", maQuyetDinh);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting decision: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Searches for decisions by maQuyetDinh or maNhanVien
        /// </summary>
        public List<DecisionDTO> Search(string searchTerm)
        {
            var decisions = new List<DecisionDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM quyetdinh WHERE maQuyetDinh = @searchTerm OR maNhanVien LIKE @searchTermLike";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decisions.Add(new DecisionDTO
                            {
                                MaQuyetDinh = reader.GetString("maQuyetDinh"),
                                MaNhanVien = reader.GetString("maNhanVien"),
                                NgayQuyetDinh = reader.GetDateTime("ngayQuyetDinh"),
                                ChucVuBanDau = reader.IsDBNull(reader.GetOrdinal("chucVuBanDau")) ? null : reader.GetString("chucVuBanDau"),
                                ChucVuSauQuyetDinh = reader.GetString("chucVuSauQuyetDinh"),
                                NguoiLapQuyetDinh = reader.GetString("nguoiLapQuyetDinh"),
                                LyDo = reader.IsDBNull(reader.GetOrdinal("lyDo")) ? null : reader.GetString("lyDo")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching decisions: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return decisions;
        }
    }
}