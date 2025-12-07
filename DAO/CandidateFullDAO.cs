using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.DAO.Data;
using System;
using System.Collections.Generic;
using Quan_Ly_Nhan_Su.DAO.Models;


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
                    td.soLuongCanTuyen,

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
                            SoLuongCanTuyen = Convert.ToInt32(reader["soLuongCanTuyen"]),
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


        public bool DeleteCandidateWithProfile(string soCccd, string maUngVien)
        {
            using (var conn = connectDB.getConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {

                        string sqlCandidate = "DELETE FROM ungvien WHERE maUngVien=@maUngVien";
                        using (var cmdCandidate = new MySqlCommand(sqlCandidate, conn, transaction))
                        {
                            cmdCandidate.Parameters.AddWithValue("@maUngVien", maUngVien);
                            int rowCandidate = cmdCandidate.ExecuteNonQuery();
                            if (rowCandidate == 0)
                            {
                                throw new Exception("Không tìm thấy dữ liệu trong bảng ungvien để xóa!");
                            }
                        }

                        string sqlProfile = "DELETE FROM hosocanhan WHERE socmnd=@soCccd";
                        using (var cmdProfile = new MySqlCommand(sqlProfile, conn, transaction))
                        {
                            cmdProfile.Parameters.AddWithValue("@soCccd", soCccd);
                            int rowProfile = cmdProfile.ExecuteNonQuery();
                            if (rowProfile == 0)
                            {
                                throw new Exception("Không tìm thấy dữ liệu trong bảng hosocanhan để xóa!");
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) 
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception rollbackEx)
                        {
                            Console.WriteLine($"Lỗi rollback: {rollbackEx.Message}");
                        }

                        Console.WriteLine($"Lỗi khi xóa ứng viên: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public bool ORMCreateCandidateWithProfile(PersonalProfileDTO profile, CandidateDTO candidate)
        {
            using (var db = new AppDbContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        PersonalProfileEntity profileEntity = new PersonalProfileEntity
                        {
                            SoCmnd = profile.SoCmnd,
                            HoTen = profile.HoTen,
                            NgaySinh = profile.NgaySinh,
                            GioiTinh = profile.GioiTinh,
                            DiaChi = profile.DiaChi,
                            Email = profile.Email,
                            SoDienThoai = profile.SoDienThoai,
                            NoiCap = profile.NoiCap,
                            NgayCap = profile.NgayCap,
                            TinhTrangHonNhan = profile.HonNhan,
                            DanToc = profile.DanToc,
                            HocVan = profile.HocVan,
                            ChuyenNganh = profile.ChuyenNganh,
                            HinhAnh = profile.HinhAnh
                        };

                        CandidateEntity candidateEntity = new CandidateEntity
                        {
                            MaUngVien = candidate.MaUngVien,
                            SoCmnd = candidate.SoCmnd,
                            MaTuyenDung = candidate.MaTuyenDung,
                            MucLuongDeal = candidate.MucLuongDeal,
                            ChucVu = candidate.ChucVu,
                            TrangThai = candidate.TrangThai
                        };

                        db.PersonalProfileEntities.Add(profileEntity);
                        db.CandidateEntities.Add(candidateEntity);
                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();                  
                        System.Diagnostics.Debug.WriteLine("Lỗi Insert: " + ex.Message);
                        if (ex.InnerException != null)
                        {
                            System.Diagnostics.Debug.WriteLine("Chi tiết: " + ex.InnerException.Message);
                        }
                        return false;
                    }
                }
            }
        }
        public bool CreateCandidateWithProfile(PersonalProfileDTO profile, CandidateDTO candidate)
        {
            using (var conn = connectDB.getConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var insertProfileCmd = new MySqlCommand(@"
                    INSERT INTO hosocanhan (soCmnd, hoTen, gioiTinh, ngaySinh, diaChi, email, sdt, noiCap, ngayCap, tinhTrangHonNhan, danToc, hocVan, chuyenNganh, anh)
                    VALUES (@soCmnd, @hoTen, @gioiTinh, @ngaySinh, @diaChi, @email, @sdt, @noiCap, @ngayCap, @tinhTrangHonNhan, @danToc, @hocVan, @chuyenNganh, @anh)", conn, transaction);

                        insertProfileCmd.Parameters.AddWithValue("@soCmnd", profile.SoCmnd);
                        insertProfileCmd.Parameters.AddWithValue("@hoTen", profile.HoTen);
                        insertProfileCmd.Parameters.AddWithValue("@gioiTinh", profile.GioiTinh);
                        insertProfileCmd.Parameters.AddWithValue("@ngaySinh", profile.NgaySinh);
                        insertProfileCmd.Parameters.AddWithValue("@diaChi", (object)profile.DiaChi ?? DBNull.Value);
                        insertProfileCmd.Parameters.AddWithValue("@email", (object)profile.Email ?? DBNull.Value);
                        insertProfileCmd.Parameters.AddWithValue("@sdt", (object)profile.SoDienThoai ?? DBNull.Value);
                        insertProfileCmd.Parameters.AddWithValue("@noiCap", (object)profile.NoiCap ?? DBNull.Value);
                        insertProfileCmd.Parameters.AddWithValue("@ngayCap", profile.NgayCap);
                        insertProfileCmd.Parameters.AddWithValue("@tinhTrangHonNhan", (object)profile.HonNhan ?? DBNull.Value);
                        insertProfileCmd.Parameters.AddWithValue("@danToc", (object)profile.DanToc ?? DBNull.Value);
                        insertProfileCmd.Parameters.AddWithValue("@hocVan", (object)profile.HocVan ?? DBNull.Value);
                        insertProfileCmd.Parameters.AddWithValue("@chuyenNganh", (object)profile.ChuyenNganh ?? DBNull.Value);
                        insertProfileCmd.Parameters.AddWithValue("@anh", (object)profile.HinhAnh ?? DBNull.Value);
                        insertProfileCmd.ExecuteNonQuery();

                        var insertCandidateCmd = new MySqlCommand(@"
                    INSERT INTO ungvien (maUngVien, soCmnd, maTuyenDung, mucLuongDeal, chucVu, trangThai)
                    VALUES (@maUngVien, @soCmnd, @maTuyenDung, @mucLuongDeal, @chucVu, @trangThai)", conn, transaction);

                        insertCandidateCmd.Parameters.AddWithValue("@maUngVien", candidate.MaUngVien);
                        insertCandidateCmd.Parameters.AddWithValue("@soCmnd", candidate.SoCmnd);
                        insertCandidateCmd.Parameters.AddWithValue("@maTuyenDung", candidate.MaTuyenDung);
                        insertCandidateCmd.Parameters.AddWithValue("@mucLuongDeal", (object)candidate.MucLuongDeal ?? DBNull.Value);
                        insertCandidateCmd.Parameters.AddWithValue("@chucVu", (object)candidate.ChucVu ?? DBNull.Value);
                        insertCandidateCmd.Parameters.AddWithValue("@trangThai", (object)candidate.TrangThai ?? DBNull.Value);
                        insertCandidateCmd.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"❌ Lỗi khi thêm hồ sơ & ứng viên: {ex.Message}");
                        return false;
                    }
                }
            }
        }
        public bool UpdateCandidateWithProfile(CandidateFullDTO cand)
        {
            using (var conn = connectDB.getConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {        
                        var updateProfileCmd = new MySqlCommand(@"
                        UPDATE hosocanhan 
                        SET hoTen = @hoTen, 
                            gioiTinh = @gioiTinh, 
                            ngaySinh = @ngaySinh, 
                            diaChi = @diaChi, 
                            email = @email, 
                            sdt = @sdt, 
                            noiCap = @noiCap, 
                            ngayCap = @ngayCap, 
                            tinhTrangHonNhan = @tinhTrangHonNhan, 
                            danToc = @danToc, 
                            hocVan = @hocVan, 
                            chuyenNganh = @chuyenNganh, 
                            anh = @anh
                        WHERE soCmnd = @soCmnd", conn, transaction); 

                        updateProfileCmd.Parameters.AddWithValue("@hoTen", cand.HoTen);
                        updateProfileCmd.Parameters.AddWithValue("@gioiTinh", cand.GioiTinh);
                        updateProfileCmd.Parameters.AddWithValue("@ngaySinh", cand.NgaySinh);
                        updateProfileCmd.Parameters.AddWithValue("@diaChi", (object)cand.DiaChi ?? DBNull.Value);
                        updateProfileCmd.Parameters.AddWithValue("@email", (object)cand.Email ?? DBNull.Value);
                        updateProfileCmd.Parameters.AddWithValue("@sdt", (object)cand.SoDienThoai ?? DBNull.Value);
                        updateProfileCmd.Parameters.AddWithValue("@noiCap", (object)cand.NoiCap ?? DBNull.Value);
                        updateProfileCmd.Parameters.AddWithValue("@ngayCap", cand.NgayCap);
                        updateProfileCmd.Parameters.AddWithValue("@tinhTrangHonNhan", (object)cand.HonNhan ?? DBNull.Value);
                        updateProfileCmd.Parameters.AddWithValue("@danToc", (object)cand.DanToc ?? DBNull.Value);
                        updateProfileCmd.Parameters.AddWithValue("@hocVan", (object)cand.TrinhDoHocVan ?? DBNull.Value);
                        updateProfileCmd.Parameters.AddWithValue("@chuyenNganh", (object)cand.ChuyenNganh ?? DBNull.Value);
                        updateProfileCmd.Parameters.AddWithValue("@anh", (object)cand.HinhAnh ?? DBNull.Value);
                        updateProfileCmd.Parameters.AddWithValue("@soCmnd", cand.SoCmnd);
                        updateProfileCmd.ExecuteNonQuery();
                    
                        var updateCandidateCmd = new MySqlCommand(@"
                        UPDATE ungvien 
                        SET mucLuongDeal = @mucLuongDeal
                        WHERE maUngVien = @maUngVien", conn, transaction);

                        updateCandidateCmd.Parameters.AddWithValue("@mucLuongDeal", (object)cand.MucLuongDeal ?? DBNull.Value);
                        updateCandidateCmd.Parameters.AddWithValue("@maUngVien", cand.MaUngVien);

                        updateCandidateCmd.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Lỗi khi cập nhật hồ sơ & ứng viên: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public List<CandidateFullDTO> Search(string keyWord)
        {
            List<CandidateFullDTO> list = new List<CandidateFullDTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
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
                    td.soLuongCanTuyen,

                    uv.maUngVien,
                    uv.mucLuongDeal,
                    uv.trangThai
                FROM ungvien uv
                LEFT JOIN hosocanhan hs ON uv.soCmnd = hs.soCmnd
                LEFT JOIN dottuyendung td ON uv.maTuyenDung = td.maTuyenDung
                WHERE (
                    @keyword IS NULL 
                    OR uv.maTuyenDung LIKE CONCAT('%', @keyword, '%')
                    OR uv.maUngVien LIKE CONCAT('%', @keyword, '%')
                    OR hs.hoTen LIKE CONCAT('%', @keyword, '%')
                    OR td.chucVu LIKE CONCAT('%', @keyword, '%')
                    OR uv.soCmnd LIKE CONCAT('%', @keyword, '%')
                    OR hs.gioiTinh LIKE CONCAT('%', @keyword, '%')
                    OR hs.email LIKE CONCAT('%', @keyword, '%')
                    OR hs.sdt LIKE CONCAT('%', @keyword, '%')
                    OR uv.trangThai LIKE CONCAT('%', @keyword, '%')
                )
            ";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", keyWord);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CandidateFullDTO dto = new CandidateFullDTO
                                {
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

                                    MaTuyenDung = reader["maTuyenDung"].ToString(),
                                    ChucVu = reader["chucVu"].ToString(),
                                    GioiTinhTuyenDung = reader["gioiTinhTuyenDung"].ToString(),
                                    DoTuoi = reader["doTuoi"].ToString(),
                                    HanNopHoSo = Convert.ToDateTime(reader["hanNopHoSo"]),
                                    MucLuongToiThieu = reader["mucLuongToiThieu"] as decimal?,
                                    MucLuongToiDa = reader["mucLuongToiDa"] as decimal?,
                                    SoLuongNop = Convert.ToInt32(reader["soLuongNop"]),
                                    SoLuongDaTuyen = Convert.ToInt32(reader["soLuongDaTuyen"]),
                                    SoLuongCanTuyen = Convert.ToInt32(reader["soLuongCanTuyen"]),
                                    MaUngVien = reader["maUngVien"].ToString(),
                                    MucLuongDeal = reader["mucLuongDeal"] as decimal?,
                                    TrangThai = reader["trangThai"].ToString()
                                };

                                list.Add(dto);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Lỗi khi lấy ứng viên: {ex.Message}");
                return null;
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
                    td.soLuongCanTuyen,

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
                                    SoLuongCanTuyen = reader["soLuongCanTuyen"] == DBNull.Value ? 0 : Convert.ToInt32(reader["soLuongCanTuyen"]),

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
