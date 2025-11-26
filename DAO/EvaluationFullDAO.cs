using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class EvaluationFullDAO
    {
        /// <summary>
        /// Lấy danh sách đánh giá đầy đủ thông tin
        /// </summary>
        public List<EvaluationFullDTO> GetAllEvaluationsFull()
        {
            var list = new List<EvaluationFullDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                string query = @"
                    SELECT 
                        dg.maDanhGia,
                        dg.maNhanVien,
                        hs1.hoTen AS tenNhanVien,
                        pb.tenPhong AS phongBan,
                        cv.tenChucVu AS chucVu,
                        dg.maNguoiDanhGia,
                        hs2.hoTen AS tenNguoiDanhGia,
                        dg.ngayDanhGia,
                        dg.diemDanhGia,
                        dg.xepLoai,
                        dg.chiTietDanhGia,
                        dg.ghiChu,
                        hs1.anh AS hinhAnh
                    FROM danhgia dg
                    INNER JOIN nhanvien nv1 ON dg.maNhanVien = nv1.maNhanVien
                    INNER JOIN hosocanhan hs1 ON nv1.soCmnd = hs1.soCmnd
                    LEFT JOIN nhanvien nv2 ON dg.maNguoiDanhGia = nv2.maNhanVien
                    LEFT JOIN hosocanhan hs2 ON nv2.soCmnd = hs2.soCmnd
                    LEFT JOIN phongban pb ON nv1.maPhong = pb.maPhong
                    LEFT JOIN chucvu cv ON nv1.maChucVu = cv.maChucVu
                    ORDER BY dg.ngayDanhGia DESC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new EvaluationFullDTO
                        {
                            MaDanhGia = reader["maDanhGia"].ToString(),
                            MaNhanVien = reader["maNhanVien"].ToString(),
                            TenNhanVien = reader["tenNhanVien"].ToString(),
                            PhongBan = reader["phongBan"]?.ToString() ?? "Chưa có",
                            ChucVu = reader["chucVu"]?.ToString() ?? "Chưa có",
                            MaNguoiDanhGia = reader["maNguoiDanhGia"].ToString(),
                            TenNguoiDanhGia = reader["tenNguoiDanhGia"]?.ToString() ?? "N/A",
                            NgayDanhGia = Convert.ToDateTime(reader["ngayDanhGia"]),
                            DiemDanhGia = Convert.ToInt32(reader["diemDanhGia"]),
                            XepLoai = reader["xepLoai"]?.ToString() ?? "",
                            ChiTietDanhGia = reader["chiTietDanhGia"]?.ToString() ?? "",
                            GhiChu = reader["ghiChu"]?.ToString() ?? "",
                            HinhAnh = reader["hinhAnh"]?.ToString() ?? ""
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EvaluationFullDAO.GetAllEvaluationsFull: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return list;
        }

        /// <summary>
        /// Tìm kiếm đánh giá
        /// </summary>
        public List<EvaluationFullDTO> Search(string keyword)
        {
            var list = new List<EvaluationFullDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                string query = @"
                    SELECT 
                        dg.maDanhGia,
                        dg.maNhanVien,
                        hs1.hoTen AS tenNhanVien,
                        pb.tenPhong AS phongBan,
                        cv.tenChucVu AS chucVu,
                        dg.maNguoiDanhGia,
                        hs2.hoTen AS tenNguoiDanhGia,
                        dg.ngayDanhGia,
                        dg.diemDanhGia,
                        dg.xepLoai,
                        dg.chiTietDanhGia,
                        dg.ghiChu,
                        hs1.anh AS hinhAnh
                    FROM danhgia dg
                    INNER JOIN nhanvien nv1 ON dg.maNhanVien = nv1.maNhanVien
                    INNER JOIN hosocanhan hs1 ON nv1.soCmnd = hs1.soCmnd
                    LEFT JOIN nhanvien nv2 ON dg.maNguoiDanhGia = nv2.maNhanVien
                    LEFT JOIN hosocanhan hs2 ON nv2.soCmnd = hs2.soCmnd
                    LEFT JOIN phongban pb ON nv1.maPhong = pb.maPhong
                    LEFT JOIN chucvu cv ON nv1.maChucVu = cv.maChucVu
                    WHERE dg.maDanhGia LIKE @keyword
                        OR hs1.hoTen LIKE @keyword
                        OR hs2.hoTen LIKE @keyword
                        OR dg.xepLoai LIKE @keyword
                        OR pb.tenPhong LIKE @keyword
                    ORDER BY dg.ngayDanhGia DESC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new EvaluationFullDTO
                        {
                            MaDanhGia = reader["maDanhGia"].ToString(),
                            MaNhanVien = reader["maNhanVien"].ToString(),
                            TenNhanVien = reader["tenNhanVien"].ToString(),
                            PhongBan = reader["phongBan"]?.ToString() ?? "Chưa có",
                            ChucVu = reader["chucVu"]?.ToString() ?? "Chưa có",
                            MaNguoiDanhGia = reader["maNguoiDanhGia"].ToString(),
                            TenNguoiDanhGia = reader["tenNguoiDanhGia"]?.ToString() ?? "N/A",
                            NgayDanhGia = Convert.ToDateTime(reader["ngayDanhGia"]),
                            DiemDanhGia = Convert.ToInt32(reader["diemDanhGia"]),
                            XepLoai = reader["xepLoai"]?.ToString() ?? "",
                            ChiTietDanhGia = reader["chiTietDanhGia"]?.ToString() ?? "",
                            GhiChu = reader["ghiChu"]?.ToString() ?? "",
                            HinhAnh = reader["hinhAnh"]?.ToString() ?? ""
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EvaluationFullDAO.Search: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return list;
        }

        /// <summary>
        /// Lọc theo ngày đánh giá
        /// </summary>
        public List<EvaluationFullDTO> FilterByDate(DateTime fromDate, DateTime toDate)
        {
            var list = new List<EvaluationFullDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                string query = @"
                    SELECT 
                        dg.maDanhGia,
                        dg.maNhanVien,
                        hs1.hoTen AS tenNhanVien,
                        pb.tenPhong AS phongBan,
                        cv.tenChucVu AS chucVu,
                        dg.maNguoiDanhGia,
                        hs2.hoTen AS tenNguoiDanhGia,
                        dg.ngayDanhGia,
                        dg.diemDanhGia,
                        dg.xepLoai,
                        dg.chiTietDanhGia,
                        dg.ghiChu,
                        hs1.anh AS hinhAnh
                    FROM danhgia dg
                    INNER JOIN nhanvien nv1 ON dg.maNhanVien = nv1.maNhanVien
                    INNER JOIN hosocanhan hs1 ON nv1.soCmnd = hs1.soCmnd
                    LEFT JOIN nhanvien nv2 ON dg.maNguoiDanhGia = nv2.maNhanVien
                    LEFT JOIN hosocanhan hs2 ON nv2.soCmnd = hs2.soCmnd
                    LEFT JOIN phongban pb ON nv1.maPhong = pb.maPhong
                    LEFT JOIN chucvu cv ON nv1.maChucVu = cv.maChucVu
                    WHERE dg.ngayDanhGia BETWEEN @fromDate AND @toDate
                    ORDER BY dg.ngayDanhGia DESC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@toDate", toDate.Date.AddDays(1).AddSeconds(-1));
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new EvaluationFullDTO
                        {
                            MaDanhGia = reader["maDanhGia"].ToString(),
                            MaNhanVien = reader["maNhanVien"].ToString(),
                            TenNhanVien = reader["tenNhanVien"].ToString(),
                            PhongBan = reader["phongBan"]?.ToString() ?? "Chưa có",
                            ChucVu = reader["chucVu"]?.ToString() ?? "Chưa có",
                            MaNguoiDanhGia = reader["maNguoiDanhGia"].ToString(),
                            TenNguoiDanhGia = reader["tenNguoiDanhGia"]?.ToString() ?? "N/A",
                            NgayDanhGia = Convert.ToDateTime(reader["ngayDanhGia"]),
                            DiemDanhGia = Convert.ToInt32(reader["diemDanhGia"]),
                            XepLoai = reader["xepLoai"]?.ToString() ?? "",
                            ChiTietDanhGia = reader["chiTietDanhGia"]?.ToString() ?? "",
                            GhiChu = reader["ghiChu"]?.ToString() ?? "",
                            HinhAnh = reader["hinhAnh"]?.ToString() ?? ""
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EvaluationFullDAO.FilterByDate: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return list;
        }
    }
}