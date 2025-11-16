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
        // LẤY TẤT CẢ (cập nhật để phù hợp schema thực tế)
        // Sẽ lấy tất cả dòng trong bảng `luong` và gom các phụ cấp/khoản trừ/tiền thưởng
        // theo tháng/năm hiện tại từ các bảng `thuong` và `phucapkhoantru`.
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

                    // Lấy tháng/năm hiện tại
                    int month = DateTime.Now.Month;
                    int year = DateTime.Now.Year;

                    const string sql = @"
                        SELECT l.MaLuong, l.MaNhanVien, hs.hoTen, l.LuongCoBan, l.LuongTheoGio,
                               COALESCE(SUM(CASE WHEN tr.Loai = 'PhuCap' THEN tr.SoTien ELSE 0 END),0) AS PhuCapTotal,
                               COALESCE(SUM(CASE WHEN tr.Loai = 'KhoanTru' THEN tr.SoTien ELSE 0 END),0) AS KhoanTruTotal,
                               COALESCE(SUM(t.PhanTramThuong),0) AS TotalPercentThuong
                        FROM luong l
                        LEFT JOIN nhanvien nv ON l.MaNhanVien = nv.MaNhanVien
                        LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
                        LEFT JOIN thuong t ON t.MaNhanVien = l.MaNhanVien AND t.ThangApDung = @month AND t.NamApDung = @year
                        LEFT JOIN phucapkhoantru tr ON tr.MaNhanVien = l.MaNhanVien AND tr.ThangApDung = @month AND tr.NamApDung = @year
                        GROUP BY l.MaLuong, l.MaNhanVien, hs.hoTen, l.LuongCoBan, l.LuongTheoGio
                        ORDER BY hs.hoTen ASC";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@year", year);

                        using (var rd = cmd.ExecuteReader())
                        {
                            int stt = 1;
                            while (rd.Read())
                            {
                                decimal luongCoBan = rd["LuongCoBan"] != DBNull.Value ? Convert.ToDecimal(rd["LuongCoBan"]) : 0m;
                                decimal phuCap = rd["PhuCapTotal"] != DBNull.Value ? Convert.ToDecimal(rd["PhuCapTotal"]) : 0m;
                                decimal khoanTru = rd["KhoanTruTotal"] != DBNull.Value ? Convert.ToDecimal(rd["KhoanTruTotal"]) : 0m;
                                decimal percentThuong = rd["TotalPercentThuong"] != DBNull.Value ? Convert.ToDecimal(rd["TotalPercentThuong"]) : 0m;

                                decimal luongThuong = luongCoBan * percentThuong / 100m;

                                decimal thue = 0m; // nếu chưa có công thức
                                decimal thucLanh = luongCoBan + phuCap + luongThuong - khoanTru - thue;

                                list.Add(new SalaryDTO
                                {
                                    MaLuong = rd["MaLuong"].ToString(),
                                    MaNhanVien = rd["MaNhanVien"].ToString(),
                                    HoTen = rd["hoTen"] != DBNull.Value ? rd["hoTen"].ToString() : "",
                                    LuongCoBan = luongCoBan,
                                    LuongThuong = luongThuong,
                                    LuongThucTe = null,
                                    PhuCapChucVu = phuCap,
                                    PhuCapKhac = 0m,
                                    KhoanTruBaoHiem = 0m,
                                    KhoanTruKhac = khoanTru,
                                    Thue = thue,
                                    ThucLanh = thucLanh,
                                    NgayLap = DateTime.Now
                                });
                            }
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
        // (unchanged)
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
                        @"SELECT MaLuong, MaNhanVien, LuongCoBan, LuongTheoGio FROM luong WHERE MaLuong = @MaLuong";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                        using (var rd = cmd.ExecuteReader())
                        {
                            if (!rd.Read()) return null;

                            return new SalaryDTO
                            {
                                MaLuong = rd["MaLuong"].ToString(),
                                MaNhanVien = rd["MaNhanVien"].ToString(),
                                LuongCoBan = rd["LuongCoBan"] != DBNull.Value ? Convert.ToDecimal(rd["LuongCoBan"]) : 0m,
                                LuongThucTe = null,
                                LuongThuong = 0m
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
        // THÊM (kept)
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
                        @"INSERT INTO luong (MaLuong, MaNhanVien, LuongCoBan, LuongTheoGio) VALUES (@MaLuong, @MaNhanVien, @LuongCoBan, @LuongTheoGio)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", s.MaLuong);
                        cmd.Parameters.AddWithValue("@MaNhanVien", s.MaNhanVien);
                        cmd.Parameters.AddWithValue("@LuongCoBan", s.LuongCoBan);
                        cmd.Parameters.AddWithValue("@LuongTheoGio", s.LuongThucTe ?? 0m);
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
        // UPDATE simplified
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
                        @"UPDATE luong SET LuongCoBan = @LuongCoBan, LuongTheoGio = @LuongTheoGio WHERE MaLuong = @MaLuong";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", s.MaLuong);
                        cmd.Parameters.AddWithValue("@LuongCoBan", s.LuongCoBan);
                        cmd.Parameters.AddWithValue("@LuongTheoGio", s.LuongThucTe ?? 0m);
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

        public bool Delete(string maLuong)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    const string sql = @"DELETE FROM luong WHERE MaLuong = @MaLuong";
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
        // Cập nhật: sử dụng các bảng thuong và phucapkhoantru để tính toán
        // ==========================
        public SalaryDTO GetSalaryByEmployee(string maNhanVien)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();

                    int month = DateTime.Now.Month;
                    int year = DateTime.Now.Year;

                    const string sql =
                        @"SELECT
                              nv.maNhanVien,
                              hs.hoTen,
                              cv.tenChucVu,
                              pb.tenPhong,
                              l.maLuong,
                              l.luongCoBan,
                              COALESCE(SUM(CASE WHEN tr.Loai = 'PhuCap' THEN tr.SoTien ELSE 0 END),0) AS PhuCapTotal,
                              COALESCE(SUM(CASE WHEN tr.Loai = 'KhoanTru' THEN tr.SoTien ELSE 0 END),0) AS KhoanTruTotal,
                              COALESCE(SUM(t.PhanTramThuong),0) AS TotalPercentThuong
                          FROM nhanvien nv
                          LEFT JOIN luong l ON l.MaNhanVien = nv.maNhanVien
                          LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
                          LEFT JOIN chucvu      cv ON nv.maChucVu = cv.maChucVu
                          LEFT JOIN phongban    pb ON nv.maPhong  = pb.maPhong
                          LEFT JOIN thuong t ON t.MaNhanVien = nv.maNhanVien AND t.ThangApDung = @month AND t.NamApDung = @year
                          LEFT JOIN phucapkhoantru tr ON tr.MaNhanVien = nv.maNhanVien AND tr.ThangApDung = @month AND tr.NamApDung = @year
                          WHERE nv.maNhanVien = @MaNhanVien
                          GROUP BY nv.maNhanVien, hs.hoTen, cv.tenChucVu, pb.tenPhong, l.maLuong, l.luongCoBan
                          LIMIT 1";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@year", year);

                        using (var rd = cmd.ExecuteReader())
                        {
                            if (!rd.Read()) return null;

                            var dto = new SalaryDTO();

                            // safe reads
                            string GetStringSafe(string name)
                            {
                                try { return rd[name] != DBNull.Value ? rd[name].ToString() : null; }
                                catch { return null; }
                            }

                            decimal GetDecimalSafe(string name)
                            {
                                try { return rd[name] != DBNull.Value ? Convert.ToDecimal(rd[name]) : 0m; }
                                catch { return 0m; }
                            }

                            dto.MaNhanVien = GetStringSafe("maNhanVien");
                            dto.HoTen = GetStringSafe("hoTen");
                            dto.TenChucVu = GetStringSafe("tenChucVu");
                            dto.TenPhong = GetStringSafe("tenPhong");
                            dto.MaLuong = GetStringSafe("maLuong");

                            dto.LuongCoBan = GetDecimalSafe("luongCoBan");

                            decimal phuCapTotal = GetDecimalSafe("PhuCapTotal");
                            decimal khoanTruTotal = GetDecimalSafe("KhoanTruTotal");
                            decimal percentThuong = GetDecimalSafe("TotalPercentThuong");

                            dto.PhuCapChucVu = phuCapTotal;
                            dto.PhuCapKhac = 0m;
                            dto.KhoanTruBaoHiem = 0m;
                            dto.KhoanTruKhac = khoanTruTotal;

                            dto.LuongThuong = dto.LuongCoBan * percentThuong / 100m;

                            dto.Thue = 0m; // chưa có công thức

                            dto.ThucLanh = dto.LuongCoBan + dto.PhuCapChucVu + dto.LuongThuong - dto.KhoanTruBaoHiem - dto.KhoanTruKhac - dto.Thue;

                            dto.NgayLap = DateTime.Now;

                            return dto;
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

        // Helper: get MaNhanVien by MaLuong
        public string GetMaNhanVienByMaLuong(string maLuong)
        {
            if (string.IsNullOrWhiteSpace(maLuong)) return null;
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    const string sql = "SELECT MaNhanVien FROM luong WHERE MaLuong = @MaLuong LIMIT 1";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                        var result = cmd.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SalaryDAO.GetMaNhanVienByMaLuong Error: " + ex.Message);
                return null;
            }
        }
    }
}
