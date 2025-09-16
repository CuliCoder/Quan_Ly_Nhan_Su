using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for RecruitmentBatch table
    /// </summary>
    public class RecruitmentBatchDAO
    {
        /// <summary>
        /// Creates a new recruitment batch in the dottuyendung table
        /// </summary>
        public bool Create(RecruitmentBatchDTO batch)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "INSERT INTO dottuyendung (maTuyenDung, chucVu, hocVan, gioiTinh, doTuoi, soLuongCanTuyen, hanNopHoSo, mucLuongToiThieu, mucLuongToiDa, soLuongNopHoSo, soLuongDaTuyen) VALUES (@maTuyenDung, @chucVu, @hocVan, @gioiTinh, @doTuoi, @soLuongCanTuyen, @hanNopHoSo, @mucLuongToiThieu, @mucLuongToiDa, @soLuongNopHoSo, @soLuongDaTuyen)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maTuyenDung", batch.MaTuyenDung);
                    command.Parameters.AddWithValue("@chucVu", batch.ChucVu);
                    command.Parameters.AddWithValue("@hocVan", (object)batch.HocVan ?? DBNull.Value);
                    command.Parameters.AddWithValue("@gioiTinh", (object)batch.GioiTinh ?? DBNull.Value);
                    command.Parameters.AddWithValue("@doTuoi", (object)batch.DoTuoi ?? DBNull.Value);
                    command.Parameters.AddWithValue("@soLuongCanTuyen", batch.SoLuongCanTuyen);
                    command.Parameters.AddWithValue("@hanNopHoSo", batch.HanNopHoSo);
                    command.Parameters.AddWithValue("@mucLuongToiThieu", (object)batch.MucLuongToiThieu ?? DBNull.Value);
                    command.Parameters.AddWithValue("@mucLuongToiDa", (object)batch.MucLuongToiDa ?? DBNull.Value);
                    command.Parameters.AddWithValue("@soLuongNopHoSo", batch.SoLuongNopHoSo);
                    command.Parameters.AddWithValue("@soLuongDaTuyen", batch.SoLuongDaTuyen);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating recruitment batch: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing recruitment batch in the dottuyendung table
        /// </summary>
        public bool Update(RecruitmentBatchDTO batch)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "UPDATE dottuyendung SET chucVu = @chucVu, hocVan = @hocVan, gioiTinh = @gioiTinh, doTuoi = @doTuoi, soLuongCanTuyen = @soLuongCanTuyen, hanNopHoSo = @hanNopHoSo, mucLuongToiThieu = @mucLuongToiThieu, mucLuongToiDa = @mucLuongToiDa, soLuongNopHoSo = @soLuongNopHoSo, soLuongDaTuyen = @soLuongDaTuyen WHERE maTuyenDung = @maTuyenDung";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maTuyenDung", batch.MaTuyenDung);
                    command.Parameters.AddWithValue("@chucVu", batch.ChucVu);
                    command.Parameters.AddWithValue("@hocVan", (object)batch.HocVan ?? DBNull.Value);
                    command.Parameters.AddWithValue("@gioiTinh", (object)batch.GioiTinh ?? DBNull.Value);
                    command.Parameters.AddWithValue("@doTuoi", (object)batch.DoTuoi ?? DBNull.Value);
                    command.Parameters.AddWithValue("@soLuongCanTuyen", batch.SoLuongCanTuyen);
                    command.Parameters.AddWithValue("@hanNopHoSo", batch.HanNopHoSo);
                    command.Parameters.AddWithValue("@mucLuongToiThieu", (object)batch.MucLuongToiThieu ?? DBNull.Value);
                    command.Parameters.AddWithValue("@mucLuongToiDa", (object)batch.MucLuongToiDa ?? DBNull.Value);
                    command.Parameters.AddWithValue("@soLuongNopHoSo", batch.SoLuongNopHoSo);
                    command.Parameters.AddWithValue("@soLuongDaTuyen", batch.SoLuongDaTuyen);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating recruitment batch: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Deletes a recruitment batch from the dottuyendung table
        /// </summary>
        public bool Delete(string maTuyenDung)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM dottuyendung WHERE maTuyenDung = @maTuyenDung";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maTuyenDung", maTuyenDung);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting recruitment batch: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Searches for recruitment batches by maTuyenDung or chucVu
        /// </summary>
        public List<RecruitmentBatchDTO> Search(string searchTerm)
        {
            var batches = new List<RecruitmentBatchDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM dottuyendung WHERE maTuyenDung = @searchTerm OR chucVu LIKE @searchTermLike";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            batches.Add(new RecruitmentBatchDTO
                            {
                                MaTuyenDung = reader.GetString("maTuyenDung"),
                                ChucVu = reader.GetString("chucVu"),
                                HocVan = reader.IsDBNull(reader.GetOrdinal("hocVan")) ? null : reader.GetString("hocVan"),
                                GioiTinh = reader.IsDBNull(reader.GetOrdinal("gioiTinh")) ? null : reader.GetString("gioiTinh"),
                                DoTuoi = reader.IsDBNull(reader.GetOrdinal("doTuoi")) ? null : reader.GetString("doTuoi"),
                                SoLuongCanTuyen = reader.GetInt32("soLuongCanTuyen"),
                                HanNopHoSo = reader.GetDateTime("hanNopHoSo"),
                                MucLuongToiThieu = reader.IsDBNull(reader.GetOrdinal("mucLuongToiThieu")) ? null : reader.GetDecimal("mucLuongToiThieu"),
                                MucLuongToiDa = reader.IsDBNull(reader.GetOrdinal("mucLuongToiDa")) ? null : reader.GetDecimal("mucLuongToiDa"),
                                SoLuongNopHoSo = reader.GetInt32("soLuongNopHoSo"),
                                SoLuongDaTuyen = reader.GetInt32("soLuongDaTuyen")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching recruitment batches: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return batches;
        }
    }
}