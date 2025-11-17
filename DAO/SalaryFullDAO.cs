using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class SalaryFullDAO
    {

        public List<SalaryFullDTO> GetAllSalaryFull(int thang, int nam)
        {
            List<SalaryFullDTO> list = new List<SalaryFullDTO>();

            string sql = @"
                SELECT nv.MaNhanVien, l.MaLuong, l.LuongCoBan, l.LuongTheoGio,
                    IFNULL(SUM(CASE WHEN p.Loai='PhuCap' THEN p.SoTien ELSE 0 END),0) AS TongPhuCap,
                    IFNULL(SUM(CASE WHEN p.Loai='KhoanTru' THEN p.SoTien ELSE 0 END),0) AS TongKhoanTru,
                    IFNULL(SUM(t.PhanTramThuong),0) AS TongThuong
                FROM nhanvien nv
                JOIN luong l ON nv.MaNhanVien = l.MaNhanVien
                LEFT JOIN phucapkhoantru p 
                    ON p.MaNhanVien = nv.MaNhanVien 
                    AND p.ThangApDung = @Thang 
                    AND p.NamApDung = @Nam
                LEFT JOIN thuong t
                    ON t.MaNhanVien = nv.MaNhanVien
                    AND t.ThangApDung = @Thang
                    AND t.NamApDung = @Nam
                GROUP BY nv.MaNhanVien, l.MaLuong, l.LuongCoBan, l.LuongTheoGio;
                ";

            using (var conn = connectDB.getConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dto = new SalaryFullDTO
                            {
                                MaNhanVien = reader["MaNhanVien"].ToString(),
                                MaLuong = reader["MaLuong"].ToString(),
                                LuongCoBan = Convert.ToDecimal(reader["LuongCoBan"]),
                                LuongTheoGio = Convert.ToDecimal(reader["LuongTheoGio"]),
                                TongPhuCap = Convert.ToDecimal(reader["TongPhuCap"]),
                                TongKhoanTru = Convert.ToDecimal(reader["TongKhoanTru"]),
                                TongThuong = Convert.ToDecimal(reader["TongThuong"])
                            };

                            list.Add(dto);
                        }
                    }
                }
            }

            return list;
        }


        public SalaryFullDTO GetSalaryData(string maNhanVien, int thang, int nam)
        {
            SalaryFullDTO salary = null;

            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT nv.MaNhanVien, l.MaLuong, l.LuongCoBan, l.LuongTheoGio,
                            IFNULL(SUM(CASE WHEN p.Loai='PhuCap' THEN p.SoTien ELSE 0 END),0) AS TongPhuCap,
                            IFNULL(SUM(CASE WHEN p.Loai='KhoanTru' THEN p.SoTien ELSE 0 END),0) AS TongKhoanTru,
                            IFNULL(SUM(t.PhanTramThuong),0) AS TongThuong
                        FROM nhanvien nv
                        JOIN luong l ON nv.MaLuong = l.MaLuong
                        LEFT JOIN phucapkhoantru p 
                            ON p.MaNhanVien = nv.MaNhanVien 
                            AND p.ThangApDung = @Thang 
                            AND p.NamApDung = @Nam
                        LEFT JOIN thuong t
                            ON t.MaNhanVien = nv.MaNhanVien
                            AND t.ThangApDung = @Thang
                            AND t.NamApDung = @Nam
                        GROUP BY nv.MaNhanVien, l.MaLuong, l.LuongCoBan, l.LuongTheoGio;
                    ";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cmd.Parameters.AddWithValue("@Thang", thang);
                        cmd.Parameters.AddWithValue("@Nam", nam);

                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                salary = new SalaryFullDTO
                                {
                                    MaNhanVien = rd["MaNhanVien"].ToString(),
                                    MaLuong = rd["MaLuong"].ToString(),
                                    LuongCoBan = Convert.ToDecimal(rd["LuongCoBan"]),
                                    LuongTheoGio = Convert.ToDecimal(rd["LuongTheoGio"]),
                                    TongPhuCap = Convert.ToDecimal(rd["TongPhuCap"]),
                                    TongKhoanTru = Convert.ToDecimal(rd["TongKhoanTru"]),
                                    TongThuong = Convert.ToDecimal(rd["TongThuong"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SalaryFullDAO.GetSalaryData SQL Error: " + ex.Message);
            }

            return salary;
        }
    }
}
