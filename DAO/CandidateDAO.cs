using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DAO
{
    internal class CandidateDAO
    {
        private MySqlConnection conn;

        public List<CandidateDTO> getAll()
        {
            List<CandidateDTO> list = new List<CandidateDTO>();

            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM ungvien";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CandidateDTO dto = new CandidateDTO
                            {
                                MaUngVien = reader["maUngVien"].ToString(),
                                SoCmnd = reader["soCmnd"].ToString(),
                                MaTuyenDung = reader["maTuyenDung"].ToString(),
                                MucLuongDeal = reader["mucLuongDeal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["mucLuongDeal"]),
                                ChucVu = reader["chucVu"].ToString(),
                                TrangThai = reader["trangThai"].ToString()
                            };
                            list.Add(dto);
                        }
                    }
                }
                return list;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"❌ Lỗi khi lấy danh sách ứng viên: {ex.Message}");
                return list;
            }
        }

        public CandidateDTO getById(string id)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM ungvien WHERE maUngVien = @id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new CandidateDTO
                                {
                                    MaUngVien = reader["maUngVien"].ToString(),
                                    SoCmnd = reader["soCmnd"].ToString(),
                                    MaTuyenDung = reader["maTuyenDung"].ToString(),
                                    MucLuongDeal = reader["mucLuongDeal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["mucLuongDeal"]),               
                                    ChucVu = reader["chucVu"].ToString(),
                                    TrangThai = reader["trangThai"].ToString()
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"❌ Lỗi khi lấy ứng viên: {ex.Message}");
                return null;
            }
        }
        public bool CheckId(string id)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM ungvien WHERE maUngVien = @id";
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    using (var cmd = new  MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count == 0; 
                    }
                }
            }
            catch (MySqlException ex)
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
        // ✅ Thêm ứng viên
        public bool Create(CandidateDTO dto)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO ungvien (maUngVien, soCmnd, maTuyenDung, mucLuongDeal, chucVu, trangThai)
                           VALUES (@maUngVien, @soCmnd, @maTuyenDung, @mucLuongDeal, @chucVu, @trangThai)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maUngVien", dto.MaUngVien);
                        cmd.Parameters.AddWithValue("@soCmnd", dto.SoCmnd);
                        cmd.Parameters.AddWithValue("@maTuyenDung", dto.MaTuyenDung);
                        cmd.Parameters.AddWithValue("@mucLuongDeal", (object)dto.MucLuongDeal ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@chucVu", (object)dto.ChucVu ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@trangThai", (object)dto.TrangThai ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"❌ Lỗi khi thêm ứng viên: {ex.Message}");
                return false;
            }
        }


        // ✅ Cập nhật ứng viên
        public bool update(CandidateDTO dto)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE ungvien SET 
                                soCmnd = @soCmnd, 
                                maTuyenDung = @maTuyenDung, 
                                mucLuongDeal = @mucLuongDeal, 
                                maTrinhDo = @maTrinhDo, 
                                chucVu = @chucVu, 
                                trangThai = @trangThai
                            WHERE maUngVien = @maUngVien";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maUngVien", dto.MaUngVien);
                        cmd.Parameters.AddWithValue("@soCmnd", dto.SoCmnd);
                        cmd.Parameters.AddWithValue("@maTuyenDung", dto.MaTuyenDung);
                        cmd.Parameters.AddWithValue("@mucLuongDeal", dto.MucLuongDeal);
                        cmd.Parameters.AddWithValue("@chucVu", dto.ChucVu);
                        cmd.Parameters.AddWithValue("@trangThai", dto.TrangThai);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"❌ Lỗi khi cập nhật ứng viên: {ex.Message}");
                return false;
            }
        }

        // ✅ Xóa ứng viên
        public bool delete(string id)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM ungvien WHERE maUngVien = @id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"❌ Lỗi khi xóa ứng viên: {ex.Message}");
                return false;
            }
        }

        public List<CandidateDTO> search(string keyword)
        {
            List<CandidateDTO> list = new List<CandidateDTO>();

            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM ungvien WHERE chucVu LIKE @kw OR trangThai LIKE @kw";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CandidateDTO dto = new CandidateDTO
                                {
                                    MaUngVien = reader["maUngVien"].ToString(),
                                    SoCmnd = reader["soCmnd"].ToString(),
                                    MaTuyenDung = reader["maTuyenDung"].ToString(),
                                    MucLuongDeal = reader["mucLuongDeal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["mucLuongDeal"]),                                 
                                    ChucVu = reader["chucVu"].ToString(),
                                    TrangThai = reader["trangThai"].ToString()
                                };
                                list.Add(dto);
                            }
                        }
                    }
                }
                return list;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"❌ Lỗi khi tìm kiếm ứng viên: {ex.Message}");
                return list;
            }
        }

        public bool UpdateStatus(string maUngVien, string trangThai)
        {
            try
            {
                string sql = @"
                    UPDATE ungvien
                    SET trangthai = @trangThai
                    WHERE maUngVien = @maUngVien
                ";
                using (conn = connectDB.getConnection())                 
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(sql,conn))
                    {
                        cmd.Parameters.AddWithValue("@trangThai", trangThai);
                        cmd.Parameters.AddWithValue("@maUngVien", maUngVien);
                        int rowsAffected = cmd.ExecuteNonQuery(); 
                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"❌ Lỗi khi cập nhật trạng thái ứng viên: {ex.Message}");
                return false;
            }

        }
    }
}
