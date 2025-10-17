using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class CandidateFullDAO
    {
        MySqlConnection conn = null;

        public List<CandidateFullDTO> GetAll()
        {
            List<CandidateFullDTO> list = new List<CandidateFullDTO>();

            string query = @"
                SELECT 
                    hs.soCmnd,
                    hs.hoTen,
                    DATE(hs.ngaySinh) AS ngaySinh,      
                    hs.gioiTinh,
                    hs.diaChi,
                    hs.email,
                    hs.sdt AS soDienThoai,
                    hs.noiCap,
                    DATE(hs.ngayCap) AS ngayCap,         
                    hs.danToc,
                    hs.hocVan AS trinhDoHocVan,
                    hs.tinhTrangHonNhan AS honNhan,
                    hs.chuyenNganh,
                    hs.anh AS hinhAnh,

                    td.maTuyenDung,
                    td.chucVu,
                    td.gioiTinh AS gioiTinhTuyenDung,
                    td.doTuoi,
                    DATE(td.hanNopHoSo) AS hanNopHoSo,   
                    td.mucLuongToiThieu,
                    td.mucLuongToiDa,
                    td.soLuongNopHoSo AS soLuongNop,
                    td.soLuongDaTuyen,

                    uv.maUngVien,
                    uv.mucLuongDeal,
                    uv.trangThai

                FROM ungvien uv
                LEFT JOIN hosocanhan hs ON uv.soCmnd = hs.soCmnd
                LEFT JOIN dottuyendung td ON uv.maTuyenDung = td.maTuyenDung;
            ";

            using ( conn = connectDB.getConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CandidateFullDTO dto = new CandidateFullDTO
                        {
                            // Hồ sơ cá nhân
                            SoCmnd = reader["soCmnd"].ToString(),
                            HoTen = reader["hoTen"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["ngaySinh"]),
                            GioiTinh = reader["gioiTinh"].ToString(),
                            DiaChi = reader["diaChi"].ToString(),
                            Email = reader["email"].ToString(),
                            SoDienThoai = reader["soDienThoai"].ToString(),
                            NoiCap = reader["noiCap"].ToString(),
                            NgayCap = Convert.ToDateTime(reader["ngayCap"]),
                            DanToc = reader["danToc"].ToString(),
                            TrinhDoHocVan = reader["trinhDoHocVan"].ToString(),
                            HonNhan = reader["honNhan"].ToString(),
                            ChuyenNganh = reader["chuyenNganh"].ToString(),
                            HinhAnh = reader["hinhAnh"].ToString(),

                            // Tuyển dụng
                            MaTuyenDung = reader["maTuyenDung"].ToString(),
                            ChucVu = reader["chucVu"].ToString(),
                            GioiTinhTuyenDung = reader["gioiTinhTuyenDung"].ToString(),
                            DoTuoi = reader["doTuoi"].ToString(),
                            HanNopHoSo = Convert.ToDateTime(reader["hanNopHoSo"]),
                            MucLuongToiThieu = reader["mucLuongToiThieu"] as decimal?,
                            MucLuongToiDa = reader["mucLuongToiDa"] as decimal?,
                            SoLuongNop = Convert.ToInt32(reader["soLuongNop"]),
                            SoLuongDaTuyen = Convert.ToInt32(reader["soLuongDaTuyen"]),

                            // Ứng viên
                            MaUngVien = reader["maUngVien"].ToString(),
                            MucLuongDeal = reader["mucLuongDeal"] as decimal?,
                            TrangThai = reader["trangThai"].ToString()
                        };

                        list.Add(dto);
                    }
                }
            }

            return list;
        }
        public CandidateFullDTO GetByID(string maUngVien)
        {
            try
            {
                string sql = @"
                SELECT 
                    hs.soCmnd,
                    hs.hoTen,
                    DATE(hs.ngaySinh) AS ngaySinh,      
                    hs.gioiTinh,
                    hs.diaChi,
                    hs.email,
                    hs.sdt AS soDienThoai,
                    hs.noiCap,
                    DATE(hs.ngayCap) AS ngayCap,         
                    hs.danToc,
                    hs.hocVan AS trinhDoHocVan,
                    hs.tinhTrangHonNhan AS honNhan,
                    hs.chuyenNganh,
                    hs.anh AS hinhAnh,

                    td.maTuyenDung,
                    td.chucVu,
                    td.gioiTinh AS gioiTinhTuyenDung,
                    td.doTuoi,
                    DATE(td.hanNopHoSo) AS hanNopHoSo,   
                    td.mucLuongToiThieu,
                    td.mucLuongToiDa,
                    td.soLuongNopHoSo AS soLuongNop,
                    td.soLuongDaTuyen,

                    uv.maUngVien,
                    uv.mucLuongDeal,
                    uv.trangThai

                FROM ungvien uv
                LEFT JOIN hosocanhan hs ON uv.soCmnd = hs.soCmnd
                LEFT JOIN dottuyendung td ON uv.maTuyenDung = td.maTuyenDung
                WHERE uv.maUngVien = @maUngVien;
                ";

                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maUngVien", maUngVien);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new CandidateFullDTO
                                {
                                    // Hồ sơ cá nhân
                                    SoCmnd = reader["soCmnd"]?.ToString(),
                                    HoTen = reader["hoTen"]?.ToString(),
                                    NgaySinh = reader["ngaySinh"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["ngaySinh"]),
                                    GioiTinh = reader["gioiTinh"]?.ToString(),
                                    DiaChi = reader["diaChi"]?.ToString(),
                                    Email = reader["email"]?.ToString(),
                                    SoDienThoai = reader["soDienThoai"]?.ToString(),
                                    NoiCap = reader["noiCap"]?.ToString(),
                                    NgayCap = reader["ngayCap"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["ngayCap"]),
                                    DanToc = reader["danToc"]?.ToString(),
                                    TrinhDoHocVan = reader["trinhDoHocVan"]?.ToString(),
                                    HonNhan = reader["honNhan"]?.ToString(),
                                    ChuyenNganh = reader["chuyenNganh"]?.ToString(),
                                    HinhAnh = reader["hinhAnh"]?.ToString(),

                                    // Tuyển dụng
                                    MaTuyenDung = reader["maTuyenDung"]?.ToString(),
                                    ChucVu = reader["chucVu"]?.ToString(),
                                    GioiTinhTuyenDung = reader["gioiTinhTuyenDung"]?.ToString(),
                                    DoTuoi = reader["doTuoi"]?.ToString(),
                                    HanNopHoSo = reader["hanNopHoSo"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["hanNopHoSo"]),
                                    MucLuongToiThieu = reader["mucLuongToiThieu"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["mucLuongToiThieu"]),
                                    MucLuongToiDa = reader["mucLuongToiDa"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["mucLuongToiDa"]),
                                    SoLuongNop = reader["soLuongNop"] == DBNull.Value ? 0 : Convert.ToInt32(reader["soLuongNop"]),
                                    SoLuongDaTuyen = reader["soLuongDaTuyen"] == DBNull.Value ? 0 : Convert.ToInt32(reader["soLuongDaTuyen"]),

                                    // Ứng viên
                                    MaUngVien = reader["maUngVien"]?.ToString(),
                                    MucLuongDeal = reader["mucLuongDeal"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["mucLuongDeal"]),
                                    TrangThai = reader["trangThai"]?.ToString()
                                };
                            }
                            else
                            {
                                return null; // Không tìm thấy ứng viên
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"❌ Lỗi khi lấy ứng viên: {ex.Message}");
                return null;
            }
        }
    }
}
