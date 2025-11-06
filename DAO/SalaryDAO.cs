using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class SalaryDAO
    {
        // ==========================
        // LẤY TẤT CẢ
        // ==========================
        public List<SalaryDTO> GetAll()
        {
            var list = new List<SalaryDTO>();
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();

                    const string sql =
                        @"SELECT MaLuong, LuongCoBan, LuongThuong, LuongThucTe,
                                 PhuCapChucVu, PhuCapKhac, KhoanTruBaoHiem,
                                 KhoanTruKhac, Thue, ThucLanh
                          FROM luong
                          WHERE TinhTrang = 1";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            list.Add(new SalaryDTO
                            {
                                MaLuong = rd["MaLuong"].ToString(),
                                LuongCoBan = Convert.ToDecimal(rd["LuongCoBan"]),
                                LuongThuong = Convert.ToDecimal(rd["LuongThuong"]),
                                LuongThucTe = rd["LuongThucTe"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rd["LuongThucTe"]),
                                PhuCapChucVu = Convert.ToDecimal(rd["PhuCapChucVu"]),
                                PhuCapKhac = Convert.ToDecimal(rd["PhuCapKhac"]),
                                KhoanTruBaoHiem = Convert.ToDecimal(rd["KhoanTruBaoHiem"]),
                                KhoanTruKhac = Convert.ToDecimal(rd["KhoanTruKhac"]),
                                Thue = Convert.ToDecimal(rd["Thue"]),
                                ThucLanh = rd["ThucLanh"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rd["ThucLanh"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SalaryDAO.GetAll SQL Error: " + ex.Message);
                return null;
            }
            return list;
        }

        // ==========================
        // LẤY THEO MÃ LƯƠNG
        // ==========================
        public SalaryDTO GetById(string maLuong)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();

                    const string sql =
                        @"SELECT MaLuong, LuongCoBan, LuongThuong, LuongThucTe,
                                 PhuCapChucVu, PhuCapKhac, KhoanTruBaoHiem,
                                 KhoanTruKhac, Thue, ThucLanh
                          FROM luong
                          WHERE MaLuong = @MaLuong AND TinhTrang = 1";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                        using (var rd = cmd.ExecuteReader())
                        {
                            if (!rd.Read()) return null;

                            return new SalaryDTO
                            {
                                MaLuong = rd["MaLuong"].ToString(),
                                LuongCoBan = Convert.ToDecimal(rd["LuongCoBan"]),
                                LuongThuong = Convert.ToDecimal(rd["LuongThuong"]),
                                LuongThucTe = rd["LuongThucTe"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rd["LuongThucTe"]),
                                PhuCapChucVu = Convert.ToDecimal(rd["PhuCapChucVu"]),
                                PhuCapKhac = Convert.ToDecimal(rd["PhuCapKhac"]),
                                KhoanTruBaoHiem = Convert.ToDecimal(rd["KhoanTruBaoHiem"]),
                                KhoanTruKhac = Convert.ToDecimal(rd["KhoanTruKhac"]),
                                Thue = Convert.ToDecimal(rd["Thue"]),
                                ThucLanh = rd["ThucLanh"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rd["ThucLanh"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SalaryDAO.GetById SQL Error: " + ex.Message);
                return null;
            }
        }

        // ==========================
        // THÊM
        // ==========================
        public bool Insert(SalaryDTO s)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();

                    const string sql =
                        @"INSERT INTO luong
                          (MaLuong, LuongCoBan, LuongThuong, LuongThucTe,
                           PhuCapChucVu, PhuCapKhac, KhoanTruBaoHiem,
                           KhoanTruKhac, Thue, ThucLanh, TinhTrang)
                          VALUES
                          (@MaLuong, @LuongCoBan, @LuongThuong, @LuongThucTe,
                           @PhuCapChucVu, @PhuCapKhac, @KhoanTruBaoHiem,
                           @KhoanTruKhac, @Thue, @ThucLanh, 1)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", s.MaLuong);
                        cmd.Parameters.AddWithValue("@LuongCoBan", s.LuongCoBan);
                        cmd.Parameters.AddWithValue("@LuongThuong", s.LuongThuong);
                        cmd.Parameters.AddWithValue("@LuongThucTe", (object)s.LuongThucTe ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@PhuCapChucVu", s.PhuCapChucVu);
                        cmd.Parameters.AddWithValue("@PhuCapKhac", s.PhuCapKhac);
                        cmd.Parameters.AddWithValue("@KhoanTruBaoHiem", s.KhoanTruBaoHiem);
                        cmd.Parameters.AddWithValue("@KhoanTruKhac", s.KhoanTruKhac);
                        cmd.Parameters.AddWithValue("@Thue", s.Thue);
                        cmd.Parameters.AddWithValue("@ThucLanh", (object)s.ThucLanh ?? DBNull.Value);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SalaryDAO.Insert SQL Error: " + ex.Message);
                return false;
            }
        }

        // ==========================
        // CẬP NHẬT
        // ==========================
        public bool Update(SalaryDTO s)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();

                    const string sql =
                        @"UPDATE luong
                          SET LuongCoBan = @LuongCoBan,
                              LuongThuong = @LuongThuong,
                              LuongThucTe = @LuongThucTe,
                              PhuCapChucVu = @PhuCapChucVu,
                              PhuCapKhac = @PhuCapKhac,
                              KhoanTruBaoHiem = @KhoanTruBaoHiem,
                              KhoanTruKhac = @KhoanTruKhac,
                              Thue = @Thue,
                              ThucLanh = @ThucLanh
                          WHERE MaLuong = @MaLuong AND TinhTrang = 1";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", s.MaLuong);
                        cmd.Parameters.AddWithValue("@LuongCoBan", s.LuongCoBan);
                        cmd.Parameters.AddWithValue("@LuongThuong", s.LuongThuong);
                        cmd.Parameters.AddWithValue("@LuongThucTe", (object)s.LuongThucTe ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@PhuCapChucVu", s.PhuCapChucVu);
                        cmd.Parameters.AddWithValue("@PhuCapKhac", s.PhuCapKhac);
                        cmd.Parameters.AddWithValue("@KhoanTruBaoHiem", s.KhoanTruBaoHiem);
                        cmd.Parameters.AddWithValue("@KhoanTruKhac", s.KhoanTruKhac);
                        cmd.Parameters.AddWithValue("@Thue", s.Thue);
                        cmd.Parameters.AddWithValue("@ThucLanh", (object)s.ThucLanh ?? DBNull.Value);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SalaryDAO.Update SQL Error: " + ex.Message);
                return false;
            }
        }

        // ==========================
        // XÓA MỀM (TinhTrang = 0)
        // ==========================
        public bool Delete(string maLuong)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    const string sql = @"UPDATE luong SET TinhTrang = 0 WHERE MaLuong = @MaLuong";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SalaryDAO.Delete SQL Error: " + ex.Message);
                return false;
            }
        }

        // ==========================
        // LẤY PHIẾU LƯƠNG THEO MÃ NHÂN VIÊN (JOIN nhiều bảng)
        // ==> HÀM NÀY CHỈ KHAI BÁO 1 LẦN TRONG FILE
        // ==========================
        public SalaryDTO GetSalaryByEmployee(string maNhanVien)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();

                    const string sql =
                        @"SELECT  nv.maNhanVien,
                                  hs.hoTen,
                                  cv.tenChucVu,
                                  pb.tenPhong,
                                  l.maLuong,
                                  l.luongCoBan,
                                  l.luongThuong,
                                  l.luongThucTe,
                                  l.phuCapChucVu,
                                  l.phuCapKhac,
                                  l.khoanTruBaoHiem,
                                  l.khoanTruKhac,
                                  l.thue,
                                  l.thucLanh
                          FROM nhanvien nv
                          JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
                          JOIN chucvu      cv ON nv.maChucVu = cv.maChucVu
                          JOIN phongban    pb ON nv.maPhong  = pb.maPhong
                          JOIN luong        l ON nv.maluong   = l.maluong
                          WHERE nv.maNhanVien = @MaNhanVien
                          LIMIT 1;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        using (var rd = cmd.ExecuteReader())
                        {
                            if (!rd.Read()) return null;

                            return new SalaryDTO
                            {
                                MaNhanVien = rd["maNhanVien"].ToString(),
                                HoTen = rd["hoTen"].ToString(),
                                TenChucVu = rd["tenChucVu"].ToString(),
                                TenPhong = rd["tenPhong"].ToString(),

                                MaLuong = rd["maLuong"].ToString(),
                                LuongCoBan = Convert.ToDecimal(rd["luongCoBan"]),
                                LuongThuong = Convert.ToDecimal(rd["luongThuong"]),
                                LuongThucTe = rd["luongThucTe"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rd["luongThucTe"]),
                                PhuCapChucVu = Convert.ToDecimal(rd["phuCapChucVu"]),
                                PhuCapKhac = Convert.ToDecimal(rd["phuCapKhac"]),
                                KhoanTruBaoHiem = Convert.ToDecimal(rd["khoanTruBaoHiem"]),
                                KhoanTruKhac = Convert.ToDecimal(rd["khoanTruKhac"]),
                                Thue = Convert.ToDecimal(rd["thue"]),
                                ThucLanh = rd["thucLanh"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rd["thucLanh"]),
                                NgayLap = DateTime.Now
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SalaryDAO.GetSalaryByEmployee SQL Error: " + ex.Message);
                return null;
            }
        }
    }
}
