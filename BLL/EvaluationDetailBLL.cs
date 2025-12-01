using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class EvaluationDetailBLL
    {
        private readonly EvaluationDetailDAO _dao = new EvaluationDetailDAO();

        /// <summary>
        /// Lấy danh sách tiêu chí đánh giá chuẩn
        /// Nếu không có trong DB, trả về danh sách mặc định
        /// </summary>
        public List<EvaluationCriteriaDTO> GetStandardCriteria()
        {
            try
            {
                var criteria = _dao.GetStandardCriteria();

                // Nếu không có trong DB, trả về danh sách mặc định
                if (criteria == null || criteria.Count == 0)
                {
                    return GetDefaultCriteria();
                }

                return criteria;
            }
            catch
            {
                // Nếu có lỗi, trả về danh sách mặc định
                return GetDefaultCriteria();
            }
        }

        /// <summary>
        /// Danh sách tiêu chí mặc định (fallback)
        /// </summary>
        private List<EvaluationCriteriaDTO> GetDefaultCriteria()
        {
            return new List<EvaluationCriteriaDTO>
            {
                // Nhóm 1: Ý THỨC KỶ LUẬT
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC01_01",
                    TenTieuChi = "Chấp hành nội quy, quy định của công ty",
                    DiemToiDa = 4,
                    MoTa = "Tuân thủ giờ giấc, trang phục, quy trình làm việc"
                },
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC01_02",
                    TenTieuChi = "Tinh thần trách nhiệm với công việc",
                    DiemToiDa = 4,
                    MoTa = "Hoàn thành công việc được giao đúng hạn"
                },
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC01_03",
                    TenTieuChi = "Ý thức bảo mật thông tin công ty",
                    DiemToiDa = 4,
                    MoTa = "Không tiết lộ thông tin nội bộ ra bên ngoài"
                },

                // Nhóm 2: TÁC PHONG LÀM VIỆC
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC02_01",
                    TenTieuChi = "Năng suất làm việc",
                    DiemToiDa = 4,
                    MoTa = "Khối lượng công việc hoàn thành trong thời gian quy định"
                },
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC02_02",
                    TenTieuChi = "Chất lượng công việc",
                    DiemToiDa = 4,
                    MoTa = "Độ chính xác, sai sót trong công việc"
                },
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC02_03",
                    TenTieuChi = "Khả năng sáng tạo, đổi mới",
                    DiemToiDa = 4,
                    MoTa = "Đề xuất cải tiến quy trình, phương pháp làm việc"
                },
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC02_04",
                    TenTieuChi = "Khả năng tự học hỏi, phát triển",
                    DiemToiDa = 4,
                    MoTa = "Chủ động nâng cao kiến thức, kỹ năng nghề nghiệp"
                },

                // Nhóm 3: QUAN HỆ LÀM VIỆC
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC03_01",
                    TenTieuChi = "Tinh thần hợp tác với đồng nghiệp",
                    DiemToiDa = 4,
                    MoTa = "Sẵn sàng hỗ trợ, chia sẻ kinh nghiệm"
                },
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC03_02",
                    TenTieuChi = "Kỹ năng giao tiếp",
                    DiemToiDa = 4,
                    MoTa = "Truyền đạt thông tin rõ ràng, lắng nghe hiệu quả"
                },
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC03_03",
                    TenTieuChi = "Thái độ phục vụ khách hàng",
                    DiemToiDa = 4,
                    MoTa = "Nhiệt tình, lịch sự, giải quyết vấn đề khách hàng"
                },

                // Nhóm 4: HIỆU QUẢ CÔNG VIỆC
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC04_01",
                    TenTieuChi = "Khả năng giải quyết vấn đề",
                    DiemToiDa = 4,
                    MoTa = "Xử lý tình huống phát sinh hiệu quả"
                },
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC04_02",
                    TenTieuChi = "Khả năng quản lý thời gian",
                    DiemToiDa = 4,
                    MoTa = "Sắp xếp, ưu tiên công việc hợp lý"
                },
                new EvaluationCriteriaDTO
                {
                    MaTieuChi = "TC04_03",
                    TenTieuChi = "Đóng góp vào mục tiêu chung",
                    DiemToiDa = 4,
                    MoTa = "Kết quả công việc góp phần đạt KPI của phòng ban"
                }
            };
        }

        /// <summary>
        /// Lấy chi tiết đánh giá theo mã đánh giá
        /// </summary>
        public List<EvaluationDetailDTO> GetByEvaluationId(string maDanhGia)
        {
            if (string.IsNullOrWhiteSpace(maDanhGia))
                return new List<EvaluationDetailDTO>();

            return _dao.GetByEvaluationId(maDanhGia);
        }

        /// <summary>
        /// Tính điểm tự động dựa trên mức đánh giá
        /// </summary>
        public int CalculateScore(int mucDanhGia, int diemToiDa = 4)
        {
            if (mucDanhGia < 1 || mucDanhGia > diemToiDa)
                return 0;

            return mucDanhGia;
        }

        /// <summary>
        /// Tính tổng điểm từ danh sách chi tiết
        /// </summary>
        public int CalculateTotalScore(List<EvaluationDetailDTO> details)
        {
            return details?.Sum(d => d.DiemDatDuoc) ?? 0;
        }

        /// <summary>
        /// Xác định xếp loại dựa trên tổng điểm
        /// </summary>
        public string DetermineRating(int tongDiem, int tongDiemToiDa)
        {
            if (tongDiemToiDa == 0)
                return "Chưa đánh giá";

            double tyLe = (double)tongDiem / tongDiemToiDa * 100;

            if (tyLe >= 90)
                return "Xuất sắc";
            else if (tyLe >= 80)
                return "Tốt";
            else if (tyLe >= 65)
                return "Khá";
            else if (tyLe >= 50)
                return "Trung bình";
            else
                return "Yếu";
        }

        /// <summary>
        /// Lưu chi tiết đánh giá
        /// </summary>
        public bool SaveEvaluationDetails(string maDanhGia, List<EvaluationDetailDTO> details)
        {
            if (string.IsNullOrWhiteSpace(maDanhGia) || details == null || details.Count == 0)
                return false;

            // Tự động tính điểm cho từng tiêu chí
            foreach (var detail in details)
            {
                detail.MaDanhGia = maDanhGia;
                detail.DiemDatDuoc = CalculateScore(detail.MucDanhGia, detail.DiemToiDa);
            }

            return _dao.SaveDetails(maDanhGia, details);
        }

        /// <summary>
        /// Tạo chi tiết đánh giá mặc định từ tiêu chí chuẩn
        /// </summary>
        public List<EvaluationDetailDTO> CreateDefaultDetails(string maDanhGia)
        {
            var criteria = GetStandardCriteria();
            var details = new List<EvaluationDetailDTO>();

            foreach (var criterion in criteria)
            {
                details.Add(new EvaluationDetailDTO
                {
                    MaDanhGia = maDanhGia,
                    MaTieuChi = criterion.MaTieuChi,
                    TenTieuChi = criterion.TenTieuChi,
                    MucDanhGia = 0,
                    DiemToiDa = criterion.DiemToiDa,
                    DiemDatDuoc = 0,
                    GhiChu = null
                });
            }

            return details;
        }

        /// <summary>
        /// Validate chi tiết đánh giá
        /// </summary>
        public List<string> ValidateDetails(List<EvaluationDetailDTO> details)
        {
            var errors = new List<string>();

            if (details == null || details.Count == 0)
            {
                errors.Add("Danh sách chi tiết đánh giá không được rỗng");
                return errors;
            }

            foreach (var detail in details)
            {
                if (string.IsNullOrWhiteSpace(detail.MaTieuChi))
                {
                    errors.Add("Mã tiêu chí không được để trống");
                }

                if (string.IsNullOrWhiteSpace(detail.TenTieuChi))
                {
                    errors.Add($"Tên tiêu chí {detail.MaTieuChi} không được để trống");
                }

                if (detail.MucDanhGia < 0 || detail.MucDanhGia > detail.DiemToiDa)
                {
                    errors.Add($"Mức đánh giá của {detail.TenTieuChi} phải từ 0 đến {detail.DiemToiDa}");
                }
            }

            return errors;
        }

        /// <summary>
        /// Cập nhật đánh giá chính với tổng điểm và xếp loại
        /// </summary>
        public bool UpdateMainEvaluationScore(string maDanhGia, int tongDiem, string xepLoai)
        {
            try
            {
                var evaluationDAO = new EvaluationDAO();
                var evaluation = evaluationDAO.GetById(maDanhGia);

                if (evaluation == null)
                    return false;

                evaluation.DiemDanhGia = tongDiem;
                evaluation.XepLoai = xepLoai;

                return evaluationDAO.Update(evaluation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating main evaluation: {ex.Message}");
                return false;
            }
        }
    }
}