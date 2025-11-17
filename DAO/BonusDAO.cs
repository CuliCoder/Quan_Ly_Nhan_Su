using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class BonusDAO
    {
        private MySqlConnection conn;

        public List<BonusDTO> GetAll()
        {
            List<BonusDTO> list = new List<BonusDTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM thuong";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new BonusDTO
                            {
                                MaThuong = Convert.ToInt32(reader["MaThuong"]),
                                MaNhanVien = reader["MaNhanVien"].ToString(),
                                TenThuong = reader["TenThuong"].ToString(),
                                PhanTramThuong = Convert.ToDecimal(reader["PhanTramThuong"]),
                                ThangApDung = Convert.ToInt32(reader["ThangApDung"]),
                                NamApDung = Convert.ToInt32(reader["NamApDung"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy danh sách thưởng: " + ex.Message);
            }
            return list;
        }

        public bool Insert(BonusDTO dto)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO thuong (MaNhanVien, TenThuong, PhanTramThuong, ThangApDung, NamApDung)
                                   VALUES (@MaNhanVien, @TenThuong, @PhanTramThuong, @ThangApDung, @NamApDung)";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", dto.MaNhanVien);
                        cmd.Parameters.AddWithValue("@TenThuong", dto.TenThuong);
                        cmd.Parameters.AddWithValue("@PhanTramThuong", dto.PhanTramThuong);
                        cmd.Parameters.AddWithValue("@ThangApDung", dto.ThangApDung);
                        cmd.Parameters.AddWithValue("@NamApDung", dto.NamApDung);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm thưởng: " + ex.Message);
                return false;
            }
        }

        public bool Update(BonusDTO dto)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE thuong 
                                   SET MaNhanVien=@MaNhanVien, TenThuong=@TenThuong, PhanTramThuong=@PhanTramThuong,
                                       ThangApDung=@ThangApDung, NamApDung=@NamApDung
                                   WHERE MaThuong=@MaThuong";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaThuong", dto.MaThuong);
                        cmd.Parameters.AddWithValue("@MaNhanVien", dto.MaNhanVien);
                        cmd.Parameters.AddWithValue("@TenThuong", dto.TenThuong);
                        cmd.Parameters.AddWithValue("@PhanTramThuong", dto.PhanTramThuong);
                        cmd.Parameters.AddWithValue("@ThangApDung", dto.ThangApDung);
                        cmd.Parameters.AddWithValue("@NamApDung", dto.NamApDung);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật thưởng: " + ex.Message);
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
                    string sql = "DELETE FROM thuong WHERE MaThuong=@id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa thưởng: " + ex.Message);
                return false;
            }
        }

        public List<BonusDTO> Search(string keyword)
        {
            List<BonusDTO> list = new List<BonusDTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"SELECT * FROM thuong 
                                   WHERE MaNhanVien LIKE @kw";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new BonusDTO
                                {
                                    MaThuong = Convert.ToInt32(reader["MaThuong"]),
                                    MaNhanVien = reader["MaNhanVien"].ToString(),
                                    TenThuong = reader["TenThuong"].ToString(),
                                    PhanTramThuong = Convert.ToDecimal(reader["PhanTramThuong"]),
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
                Console.WriteLine("Lỗi tìm kiếm thưởng: " + ex.Message);
            }
            return list;
        }
    }
}
