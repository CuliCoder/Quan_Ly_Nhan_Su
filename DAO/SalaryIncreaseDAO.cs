using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class SalaryIncreaseDAO
    {
        private MySqlConnection conn;

        public List<SalaryIncreaseDTO> GetAll()
        {
            List<SalaryIncreaseDTO> list = new List<SalaryIncreaseDTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM tangluong";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalaryIncreaseDTO dto = new SalaryIncreaseDTO
                            {
                                Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                                MaNhanVien = reader["MaNhanVien"]?.ToString(),
                                LuongHienTai = reader["LuongHienTai"] != DBNull.Value ? Convert.ToDecimal(reader["LuongHienTai"]) : 0m,
                                DiemDanhGia = reader["DiemDanhGia"] != DBNull.Value ? Convert.ToSingle(reader["DiemDanhGia"]) : 0f,
                                PhanTramTang = reader["PhanTramTang"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["PhanTramTang"]) : null,
                                LuongMoi = reader["LuongMoi"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["LuongMoi"]) : null,
                                NgayDuyet = reader["NgayDuyet"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["NgayDuyet"]) : null,
                                TrangThai = reader["TrangThai"]?.ToString()
                            };
                            list.Add(dto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách tăng lương: " + ex.Message);
            }
            return list;
        }

        public SalaryIncreaseDTO GetById(int id)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM tangluong WHERE Id = @Id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                                return MapReaderToDTO(reader);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("SQL Error (GetById tangluong): " + ex.Message);
            }
            return null;
        }

        public bool Insert(SalaryIncreaseDTO dto)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO tangluong
                        (MaNhanVien, LuongHienTai, DiemDanhGia, PhanTramTang, LuongMoi, NgayDuyet, TrangThai)
                        VALUES
                        (@MaNhanVien, @LuongHienTai, @DiemDanhGia, @PhanTramTang, @LuongMoi, @NgayDuyet, @TrangThai)";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", dto.MaNhanVien ?? "");
                        cmd.Parameters.AddWithValue("@LuongHienTai", dto.LuongHienTai);
                        cmd.Parameters.AddWithValue("@DiemDanhGia", dto.DiemDanhGia);
                        cmd.Parameters.AddWithValue("@PhanTramTang", dto.PhanTramTang.HasValue ? (object)dto.PhanTramTang.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@LuongMoi", dto.LuongMoi.HasValue ? (object)dto.LuongMoi.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@NgayDuyet", dto.NgayDuyet.HasValue ? (object)dto.NgayDuyet.Value.Date : DBNull.Value);
                        cmd.Parameters.AddWithValue("@TrangThai", dto.TrangThai ?? (object)DBNull.Value);

                        int affected = cmd.ExecuteNonQuery();
                        if (affected > 0)
                        {
                            dto.Id = (int)cmd.LastInsertedId;
                            return true;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("SQL Error (Insert tangluong): " + ex.Message);
            }
            return false;
        }

        public bool Update(SalaryIncreaseDTO dto)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"
                        UPDATE tangluong SET
                            MaNhanVien = @MaNhanVien,
                            LuongHienTai = @LuongHienTai,
                            DiemDanhGia = @DiemDanhGia,
                            PhanTramTang = @PhanTramTang,
                            LuongMoi = @LuongMoi,
                            NgayDuyet = @NgayDuyet,
                            TrangThai = @TrangThai
                        WHERE Id = @Id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", dto.MaNhanVien ?? "");
                        cmd.Parameters.AddWithValue("@LuongHienTai", dto.LuongHienTai);
                        cmd.Parameters.AddWithValue("@DiemDanhGia", dto.DiemDanhGia);
                        cmd.Parameters.AddWithValue("@PhanTramTang", dto.PhanTramTang.HasValue ? (object)dto.PhanTramTang.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@LuongMoi", dto.LuongMoi.HasValue ? (object)dto.LuongMoi.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@NgayDuyet", dto.NgayDuyet.HasValue ? (object)dto.NgayDuyet.Value.Date : DBNull.Value);
                        cmd.Parameters.AddWithValue("@TrangThai", dto.TrangThai ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Id", dto.Id);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("SQL Error (Update tangluong): " + ex.Message);
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM tangluong WHERE Id = @Id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("SQL Error (Delete tangluong): " + ex.Message);
            }
            return false;
        }

        public List<SalaryIncreaseDTO> Search(string keyword)
        {
            var list = new List<SalaryIncreaseDTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"SELECT * FROM tangluong
                                   WHERE MaNhanVien LIKE @kw
                                      OR TrangThai LIKE @kw";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + (keyword ?? "") + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                list.Add(MapReaderToDTO(reader));
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("SQL Error (Search tangluong): " + ex.Message);
            }
            return list;
        }

        private SalaryIncreaseDTO MapReaderToDTO(MySqlDataReader reader)
        {
            return new SalaryIncreaseDTO
            {
                Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                MaNhanVien = reader["MaNhanVien"] != DBNull.Value ? reader["MaNhanVien"].ToString() : null,
                LuongHienTai = reader["LuongHienTai"] != DBNull.Value ? Convert.ToDecimal(reader["LuongHienTai"]) : 0m,
                DiemDanhGia = reader["DiemDanhGia"] != DBNull.Value ? Convert.ToSingle(reader["DiemDanhGia"]) : 0f,
                PhanTramTang = reader["PhanTramTang"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["PhanTramTang"]) : null,
                LuongMoi = reader["LuongMoi"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["LuongMoi"]) : null,
                NgayDuyet = reader["NgayDuyet"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["NgayDuyet"]) : null,
                TrangThai = reader["TrangThai"] != DBNull.Value ? reader["TrangThai"].ToString() : null
            };
        }
    }
}
