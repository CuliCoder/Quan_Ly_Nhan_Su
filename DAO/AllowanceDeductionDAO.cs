using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class AllowanceDeductionDAO
    {
        private MySqlConnection conn;

        public List<AllowanceDeductionDTO> GetAll()
        {
            List<AllowanceDeductionDTO> list = new List<AllowanceDeductionDTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM phucapkhoantru";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new AllowanceDeductionDTO
                            {
                                MaPhuCapKhoanTru = Convert.ToInt32(reader["MaPhuCapKhoanTru"]),
                                MaNhanVien = reader["MaNhanVien"].ToString(),
                                Loai = reader["Loai"].ToString(),
                                MoTa = reader["MoTa"].ToString(),
                                SoTien = Convert.ToDecimal(reader["SoTien"]),
                                ThangApDung = Convert.ToInt32(reader["ThangApDung"]),
                                NamApDung = Convert.ToInt32(reader["NamApDung"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy danh sách phụ cấp/khoản trừ: " + ex.Message);
            }
            return list;
        }

        public bool Insert(AllowanceDeductionDTO dto)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO phucapkhoantru 
                                   (MaNhanVien, Loai, MoTa, SoTien, ThangApDung, NamApDung)
                                   VALUES (@MaNhanVien, @Loai, @MoTa, @SoTien, @ThangApDung, @NamApDung)";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", dto.MaNhanVien);
                        cmd.Parameters.AddWithValue("@Loai", dto.Loai);
                        cmd.Parameters.AddWithValue("@MoTa", dto.MoTa);
                        cmd.Parameters.AddWithValue("@SoTien", dto.SoTien);
                        cmd.Parameters.AddWithValue("@ThangApDung", dto.ThangApDung);
                        cmd.Parameters.AddWithValue("@NamApDung", dto.NamApDung);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm phụ cấp/khoản trừ: " + ex.Message);
                return false;
            }
        }

        public bool Update(AllowanceDeductionDTO dto)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE phucapkhoantru 
                                   SET MaNhanVien=@MaNhanVien, Loai=@Loai, MoTa=@MoTa, SoTien=@SoTien, 
                                       ThangApDung=@ThangApDung, NamApDung=@NamApDung
                                   WHERE MaPhuCapKhoanTru=@MaPhuCapKhoanTru";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhuCapKhoanTru", dto.MaPhuCapKhoanTru);
                        cmd.Parameters.AddWithValue("@MaNhanVien", dto.MaNhanVien);
                        cmd.Parameters.AddWithValue("@Loai", dto.Loai);
                        cmd.Parameters.AddWithValue("@MoTa", dto.MoTa);
                        cmd.Parameters.AddWithValue("@SoTien", dto.SoTien);
                        cmd.Parameters.AddWithValue("@ThangApDung", dto.ThangApDung);
                        cmd.Parameters.AddWithValue("@NamApDung", dto.NamApDung);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật phụ cấp/khoản trừ: " + ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM phucapkhoantru WHERE MaPhuCapKhoanTru=@id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa phụ cấp/khoản trừ: " + ex.Message);
                return false;
            }
        }

        public List<AllowanceDeductionDTO> Search(string keyword)
        {
            List<AllowanceDeductionDTO> list = new List<AllowanceDeductionDTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"SELECT * FROM phucapkhoantru 
                                   WHERE MaNhanVien LIKE @kw OR MoTa LIKE @kw";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new AllowanceDeductionDTO
                                {
                                    MaPhuCapKhoanTru = Convert.ToInt32(reader["MaPhuCapKhoanTru"]),
                                    MaNhanVien = reader["MaNhanVien"].ToString(),
                                    Loai = reader["Loai"].ToString(),
                                    MoTa = reader["MoTa"].ToString(),
                                    SoTien = Convert.ToDecimal(reader["SoTien"]),
                                    ThangApDung = Convert.ToInt32(reader["ThangApDung"]),
                                    NamApDung = Convert.ToInt32(reader["NamApDung"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm phụ cấp/khoản trừ: " + ex.Message);
            }
            return list;
        }
    }
}
