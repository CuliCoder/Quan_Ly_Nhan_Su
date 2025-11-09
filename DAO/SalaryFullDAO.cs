using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class SalaryFullDAO
    {
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
                               IFNULL(SUM(CASE WHEN pcst.Loai='PhuCap' THEN pcst.SoTien ELSE 0 END),0) AS TongPhuCap,
                               IFNULL(SUM(CASE WHEN pcst.Loai='KhoanTru' THEN pcst.SoTien ELSE 0 END),0) AS TongKhoanTru
                        FROM nhanvien nv
                        JOIN luong l ON nv.MaLuong = l.MaLuong
                        LEFT JOIN phucapkhoantru pcst ON pcst.MaNhanVien = nv.MaNhanVien AND pcst.ThangApDung=@Thang AND pcst.NamApDung=@Nam
                        WHERE nv.MaNhanVien = @MaNhanVien
                        GROUP BY nv.MaNhanVien, l.MaLuong, l.LuongCoBan, l.LuongTheoGio
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
                                    TongKhoanTru = Convert.ToDecimal(rd["TongKhoanTru"])
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
