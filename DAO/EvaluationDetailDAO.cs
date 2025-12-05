using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class EvaluationDetailDAO
    {
        /// <summary>
        /// Lấy danh sách tiêu chí đánh giá chuẩn
        /// </summary>
        public List<EvaluationCriteriaDTO> GetStandardCriteria()
        {
            var list = new List<EvaluationCriteriaDTO>();

            // Danh sách tiêu chí chuẩn theo database
            list.Add(new EvaluationCriteriaDTO { MaTieuChi = "TC01A", TenTieuChi = "Tuân thủ nội quy lao động công ty", NhomTieuChi = "Ý thức kỷ luật", DiemToiDa = 4 });
            list.Add(new EvaluationCriteriaDTO { MaTieuChi = "TC01B", TenTieuChi = "Tuân thủ quy chế – quy định làm việc", NhomTieuChi = "Ý thức kỷ luật", DiemToiDa = 4 });
            list.Add(new EvaluationCriteriaDTO { MaTieuChi = "TC02A", TenTieuChi = "Trang phục gọn gàng, lịch sự", NhomTieuChi = "Tác phong làm việc", DiemToiDa = 4 });
            list.Add(new EvaluationCriteriaDTO { MaTieuChi = "TC02B", TenTieuChi = "Giữ gìn vệ sinh chung và vệ sinh nơi làm việc", NhomTieuChi = "Tác phong làm việc", DiemToiDa = 4 });
            list.Add(new EvaluationCriteriaDTO { MaTieuChi = "TC02C", TenTieuChi = "Nhanh nhẹn, linh hoạt", NhomTieuChi = "Tác phong làm việc", DiemToiDa = 4 });
            list.Add(new EvaluationCriteriaDTO { MaTieuChi = "TC03A", TenTieuChi = "Quan hệ với cấp trên, đồng nghiệp và khách hàng", NhomTieuChi = "Quan hệ làm việc", DiemToiDa = 4 });
            list.Add(new EvaluationCriteriaDTO { MaTieuChi = "TC03B", TenTieuChi = "Giải quyết yêu cầu của khách hàng nhanh chóng, kịp thời", NhomTieuChi = "Quan hệ làm việc", DiemToiDa = 4 });
            list.Add(new EvaluationCriteriaDTO { MaTieuChi = "TC03C", TenTieuChi = "Chăm sóc khách hàng chu đáo, thân thiện", NhomTieuChi = "Quan hệ làm việc", DiemToiDa = 4 });
            list.Add(new EvaluationCriteriaDTO { MaTieuChi = "TC04A", TenTieuChi = "Tinh thần hợp tác trong công việc", NhomTieuChi = "Hiệu quả công việc", DiemToiDa = 4 });
            list.Add(new EvaluationCriteriaDTO { MaTieuChi = "TC04B", TenTieuChi = "Thao tác thực hiện công việc", NhomTieuChi = "Hiệu quả công việc", DiemToiDa = 4 });
            list.Add(new EvaluationCriteriaDTO { MaTieuChi = "TC04C", TenTieuChi = "Chất lượng và số lượng công việc hoàn thành", NhomTieuChi = "Hiệu quả công việc", DiemToiDa = 4 });

            return list;
        }

        /// <summary>
        /// Lấy chi tiết đánh giá theo mã đánh giá
        /// </summary>
        public List<EvaluationDetailDTO> GetByEvaluationId(string maDanhGia)
        {
            var list = new List<EvaluationDetailDTO>();
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM danhgia_chitiet WHERE maDanhGia = @maDanhGia ORDER BY maTieuChi";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDanhGia", maDanhGia);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new EvaluationDetailDTO
                                {
                                    MaChiTiet = reader.GetInt32("maChiTiet"),
                                    MaDanhGia = reader.GetString("maDanhGia"),
                                    MaTieuChi = reader.GetString("maTieuChi"),
                                    TenTieuChi = reader.GetString("tenTieuChi"),
                                    MucDanhGia = reader.GetInt32("mucDanhGia"),
                                    DiemToiDa = reader.GetInt32("diemToiDa"),
                                    DiemDatDuoc = reader.GetInt32("diemDatDuoc"),
                                    GhiChu = reader.IsDBNull(reader.GetOrdinal("ghiChu")) ? null : reader.GetString("ghiChu")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting evaluation details: {ex.Message}");
            }
            return list;
        }

        /// <summary>
        /// Thêm chi tiết đánh giá
        /// </summary>
        public bool Insert(EvaluationDetailDTO detail)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO danhgia_chitiet 
                                    (maDanhGia, maTieuChi, tenTieuChi, mucDanhGia, diemToiDa, diemDatDuoc, ghiChu)
                                    VALUES (@maDanhGia, @maTieuChi, @tenTieuChi, @mucDanhGia, @diemToiDa, @diemDatDuoc, @ghiChu)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDanhGia", detail.MaDanhGia);
                        cmd.Parameters.AddWithValue("@maTieuChi", detail.MaTieuChi);
                        cmd.Parameters.AddWithValue("@tenTieuChi", detail.TenTieuChi);
                        cmd.Parameters.AddWithValue("@mucDanhGia", detail.MucDanhGia);
                        cmd.Parameters.AddWithValue("@diemToiDa", detail.DiemToiDa);
                        cmd.Parameters.AddWithValue("@diemDatDuoc", detail.DiemDatDuoc);
                        cmd.Parameters.AddWithValue("@ghiChu", (object)detail.GhiChu ?? DBNull.Value);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting evaluation detail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật chi tiết đánh giá
        /// </summary>
        public bool Update(EvaluationDetailDTO detail)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string query = @"UPDATE danhgia_chitiet 
                                    SET mucDanhGia = @mucDanhGia, 
                                        diemDatDuoc = @diemDatDuoc,
                                        ghiChu = @ghiChu
                                    WHERE maChiTiet = @maChiTiet";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mucDanhGia", detail.MucDanhGia);
                        cmd.Parameters.AddWithValue("@diemDatDuoc", detail.DiemDatDuoc);
                        cmd.Parameters.AddWithValue("@ghiChu", (object)detail.GhiChu ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@maChiTiet", detail.MaChiTiet);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating evaluation detail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa chi tiết đánh giá theo mã đánh giá
        /// </summary>
        public bool DeleteByEvaluationId(string maDanhGia)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM danhgia_chitiet WHERE maDanhGia = @maDanhGia";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDanhGia", maDanhGia);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting evaluation details: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lưu toàn bộ chi tiết đánh giá (xóa cũ, thêm mới)
        /// </summary>
        public bool SaveDetails(string maDanhGia, List<EvaluationDetailDTO> details)
        {
            using (var conn = connectDB.getConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Xóa chi tiết cũ
                        string deleteQuery = "DELETE FROM danhgia_chitiet WHERE maDanhGia = @maDanhGia";
                        using (var deleteCmd = new MySqlCommand(deleteQuery, conn, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue("@maDanhGia", maDanhGia);
                            deleteCmd.ExecuteNonQuery();
                        }

                        // Thêm chi tiết mới
                        string insertQuery = @"INSERT INTO danhgia_chitiet 
                                             (maDanhGia, maTieuChi, tenTieuChi, mucDanhGia, diemToiDa, diemDatDuoc, ghiChu)
                                             VALUES (@maDanhGia, @maTieuChi, @tenTieuChi, @mucDanhGia, @diemToiDa, @diemDatDuoc, @ghiChu)";

                        foreach (var detail in details)
                        {
                            using (var insertCmd = new MySqlCommand(insertQuery, conn, transaction))
                            {
                                insertCmd.Parameters.AddWithValue("@maDanhGia", detail.MaDanhGia);
                                insertCmd.Parameters.AddWithValue("@maTieuChi", detail.MaTieuChi);
                                insertCmd.Parameters.AddWithValue("@tenTieuChi", detail.TenTieuChi);
                                insertCmd.Parameters.AddWithValue("@mucDanhGia", detail.MucDanhGia);
                                insertCmd.Parameters.AddWithValue("@diemToiDa", detail.DiemToiDa);
                                insertCmd.Parameters.AddWithValue("@diemDatDuoc", detail.DiemDatDuoc);
                                insertCmd.Parameters.AddWithValue("@ghiChu", (object)detail.GhiChu ?? DBNull.Value);
                                insertCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error saving evaluation details: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }
}