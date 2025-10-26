using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for RecruitmentBatch table
    /// </summary>
    public class RecruitmentBatchDAO
    {
        private MySqlConnection conn;

        public List<RecruitmentBatchDTO> getAll()
        {
            List<RecruitmentBatchDTO> list = new List<RecruitmentBatchDTO>();
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null)
                    {
                        Console.WriteLine("Khong tao duoc connection");
                        return new List<RecruitmentBatchDTO>();
                    }

                    conn.Open();
                    string sql = "SELECT * FROM dottuyendung";

                    using (var command = new MySqlCommand(sql, conn))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RecruitmentBatchDTO dto = new RecruitmentBatchDTO()
                            {
                                MaTuyenDung = reader["maTuyenDung"].ToString(),
                                ChucVu = reader["chucVu"].ToString(),
                                HocVan = reader["hocVan"].ToString(),
                                GioiTinh = reader["gioiTinh"].ToString(),
                                DoTuoi = reader["doTuoi"].ToString(),
                                SoLuongCanTuyen = reader["soLuongCanTuyen"] == DBNull.Value ? 0 : Convert.ToInt32(reader["soLuongCanTuyen"]),
                                HanNopHoSo = reader["HanNopHoSo"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HanNopHoSo"]),
                                MucLuongToiThieu = reader["MucLuongToiThieu"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MucLuongToiThieu"]),
                                MucLuongToiDa = reader["MucLuongToiDa"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MucLuongToiDa"]),
                                SoLuongNop = reader["SoLuongNopHoSo"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongNopHoSo"]),
                                SoLuongDaTuyen = reader["SoLuongDaTuyen"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDaTuyen"])
                            };
                            list.Add(dto);
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

        public RecruitmentBatchDTO GetById(String maTuyenDung)
        {
            try
            {
                using(conn = connectDB.getConnection())
                {
                    if(conn == null)
                    {
                        throw new Exception("Không thể kết nối đến database");
                    }
                    conn.Open();
                    string query = "SELECT * FROM dottuyendung WHERE maTuyenDung = @maTuyenDung";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTuyenDung", maTuyenDung);
                        using(MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new RecruitmentBatchDTO
                                {
                                    MaTuyenDung = reader["maTuyenDung"].ToString(),
                                    ChucVu = reader["chucVu"].ToString(),
                                    HocVan = reader["hocVan"].ToString(),
                                    GioiTinh = reader["gioiTinh"].ToString(),
                                    DoTuoi = reader["doTuoi"].ToString(),
                                    SoLuongCanTuyen = reader["soLuongCanTuyen"] == DBNull.Value ? 0 : Convert.ToInt32(reader["soLuongCanTuyen"]),
                                    HanNopHoSo = reader["HanNopHoSo"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HanNopHoSo"]),
                                    MucLuongToiThieu = reader["MucLuongToiThieu"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MucLuongToiThieu"]),
                                    MucLuongToiDa = reader["MucLuongToiDa"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MucLuongToiDa"]),
                                    SoLuongNop = reader["SoLuongNopHoSo"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongNopHoSo"]),
                                    SoLuongDaTuyen = reader["SoLuongDaTuyen"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDaTuyen"])
                                };
                            }
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
            return null;
        }

        public bool checkID(string maTuyenDung)
        {
            
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM dottuyendung WHERE maTuyenDung = @maTuyenDung";
                    using(var cmd = new  MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTuyenDung", maTuyenDung);
                        
                        int count = (int)cmd.ExecuteNonQuery();
                        return count == 0;
                    }
                     
                }
            } catch (MySqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool Create(RecruitmentBatchDTO batch)
        {
            try
            {
                using(conn = connectDB.getConnection())
                {
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
                        command.Parameters.AddWithValue("@soLuongNopHoSo", batch.SoLuongNop);
                        command.Parameters.AddWithValue("@soLuongDaTuyen", batch.SoLuongDaTuyen);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating recruitment batch: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Updates an existing recruitment batch in the dottuyendung table
        /// </summary>
        public bool Update(RecruitmentBatchDTO batch)
        {
            try
            {
                using(conn = connectDB.getConnection())
                {
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
                        command.Parameters.AddWithValue("@soLuongNopHoSo", batch.SoLuongNop);
                        command.Parameters.AddWithValue("@soLuongDaTuyen", batch.SoLuongDaTuyen);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating recruitment batch: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Deletes a recruitment batch from the dottuyendung table
        /// </summary>
        public bool Delete(string maTuyenDung)
        {
            try
            {
                using(conn = connectDB.getConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM dottuyendung WHERE maTuyenDung = @maTuyenDung";
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@maTuyenDung", maTuyenDung);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting recruitment batch: {ex.Message}");
                return false;
            }
        }

        public List<RecruitmentBatchDTO> searchRecruitmentBatch(string keyWord)
        {
            List<RecruitmentBatchDTO> list = new List<RecruitmentBatchDTO>();

            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"
                SELECT * 
                FROM dottuyendung 
                WHERE maTuyenDung LIKE @keyWord 
                   OR chucVu LIKE @keyWord 
                   OR hocVan LIKE @keyWord 
                   OR gioiTinh LIKE @keyWord 
                   OR doTuoi LIKE @keyWord
            ";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyWord", "%" + keyWord + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RecruitmentBatchDTO dto = new RecruitmentBatchDTO()
                                {
                                    MaTuyenDung = reader["maTuyenDung"].ToString(),
                                    ChucVu = reader["chucVu"].ToString(),
                                    HocVan = reader["hocVan"].ToString(),
                                    GioiTinh = reader["gioiTinh"].ToString(),
                                    DoTuoi = reader["doTuoi"].ToString(),
                                    SoLuongCanTuyen = reader["soLuongCanTuyen"] == DBNull.Value ? 0 : Convert.ToInt32(reader["soLuongCanTuyen"]),
                                    HanNopHoSo = reader["HanNopHoSo"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HanNopHoSo"]),
                                    MucLuongToiThieu = reader["MucLuongToiThieu"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MucLuongToiThieu"]),
                                    MucLuongToiDa = reader["MucLuongToiDa"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MucLuongToiDa"]),
                                    SoLuongNop = reader["SoLuongNopHoSo"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongNopHoSo"]),
                                    SoLuongDaTuyen = reader["SoLuongDaTuyen"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDaTuyen"])
                                };

                                list.Add(dto);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm: {ex.Message}");
                return null;
            }

            return list;
        }

        public List<RecruitmentBatchDTO> searchDayRecruitmentBatch(DateTime startDay, DateTime endDay)
        {
            List<RecruitmentBatchDTO> list = new List<RecruitmentBatchDTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"
                            SELECT *
                            FROM dottuyendung
                            WHERE 
                            (
                                (@NgayTu = @NgayDen AND DATE(hanNopHoso) = @NgayTu)
                            )
                            OR
                            (
                                (@NgayTu <> @NgayDen AND DATE(hanNopHoso) BETWEEN @NgayTu AND @NgayDen)
                            )
                           ";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@NgayTu", startDay.Date);
                        cmd.Parameters.AddWithValue("@NgayDen", endDay.Date);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RecruitmentBatchDTO dto = new RecruitmentBatchDTO()
                                {
                                    MaTuyenDung = reader["maTuyenDung"].ToString(),
                                    ChucVu = reader["chucVu"].ToString(),
                                    HocVan = reader["hocVan"].ToString(),
                                    GioiTinh = reader["gioiTinh"].ToString(),
                                    DoTuoi = reader["doTuoi"].ToString(),
                                    SoLuongCanTuyen = reader["soLuongCanTuyen"] == DBNull.Value ? 0 : Convert.ToInt32(reader["soLuongCanTuyen"]),
                                    HanNopHoSo = reader["HanNopHoSo"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HanNopHoSo"]),
                                    MucLuongToiThieu = reader["MucLuongToiThieu"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MucLuongToiThieu"]),
                                    MucLuongToiDa = reader["MucLuongToiDa"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MucLuongToiDa"]),
                                    SoLuongNop = reader["SoLuongNopHoSo"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongNopHoSo"]),
                                    SoLuongDaTuyen = reader["SoLuongDaTuyen"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDaTuyen"])
                                };

                                list.Add(dto);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm: {ex.Message}");
                return null;
            }
            return list;
        }
    }
}