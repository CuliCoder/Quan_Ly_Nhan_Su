using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class EvaluationBLL
    {
        private readonly EvaluationDAO _dao = new EvaluationDAO();

        // Lấy tất cả
        public List<EvaluationDTO> GetAll()
        {
            return _dao.GetAll();
        }

        // Lấy theo mã
        public EvaluationDTO GetById(string maDanhGia)
        {
            if (string.IsNullOrWhiteSpace(maDanhGia))
                return null;
            return _dao.GetById(maDanhGia);
        }

        /// <summary>
        /// Xác định quý dựa trên ngày đánh giá
        /// Q1: Tháng 1-3
        /// Q2: Tháng 4-6
        /// Q3: Tháng 7-9
        /// Q4: Tháng 10-12
        /// </summary>
        public int GetQuarter(DateTime date)
        {
            int month = date.Month;
            if (month >= 1 && month <= 3) return 1;
            if (month >= 4 && month <= 6) return 2;
            if (month >= 7 && month <= 9) return 3;
            return 4; // Tháng 10-12
        }

        /// <summary>
        /// Kiểm tra nhân viên đã được đánh giá trong quý chưa
        /// </summary>
        public bool IsEmployeeEvaluatedInQuarter(string maNhanVien, DateTime ngayDanhGia, string excludeMaDanhGia = null)
        {
            if (string.IsNullOrWhiteSpace(maNhanVien))
                return false;

            var allEvaluations = _dao.GetAll();
            if (allEvaluations == null || allEvaluations.Count == 0)
                return false;

            int quarter = GetQuarter(ngayDanhGia);
            int year = ngayDanhGia.Year;

            // Lọc các đánh giá của nhân viên trong cùng năm và quý
            var existingEvaluations = allEvaluations.Where(e =>
                e.MaNhanVien == maNhanVien &&
                e.NgayDanhGia.Year == year &&
                GetQuarter(e.NgayDanhGia) == quarter &&
                (string.IsNullOrEmpty(excludeMaDanhGia) || e.MaDanhGia != excludeMaDanhGia)
            ).ToList();

            return existingEvaluations.Count > 0;
        }

        /// <summary>
        /// Lấy thông tin đánh giá đã tồn tại trong quý
        /// </summary>
        public EvaluationDTO GetExistingQuarterEvaluation(string maNhanVien, DateTime ngayDanhGia, string excludeMaDanhGia = null)
        {
            if (string.IsNullOrWhiteSpace(maNhanVien))
                return null;

            var allEvaluations = _dao.GetAll();
            if (allEvaluations == null || allEvaluations.Count == 0)
                return null;

            int quarter = GetQuarter(ngayDanhGia);
            int year = ngayDanhGia.Year;

            return allEvaluations.FirstOrDefault(e =>
                e.MaNhanVien == maNhanVien &&
                e.NgayDanhGia.Year == year &&
                GetQuarter(e.NgayDanhGia) == quarter &&
                (string.IsNullOrEmpty(excludeMaDanhGia) || e.MaDanhGia != excludeMaDanhGia)
            );
        }

        /// <summary>
        /// Lấy tên quý
        /// </summary>
        public string GetQuarterName(DateTime date)
        {
            int quarter = GetQuarter(date);
            return $"Quý {quarter}/{date.Year}";
        }

        /// <summary>
        /// Lấy khoảng thời gian của quý
        /// </summary>
        public (DateTime StartDate, DateTime EndDate) GetQuarterDateRange(DateTime date)
        {
            int quarter = GetQuarter(date);
            int year = date.Year;

            DateTime startDate, endDate;

            switch (quarter)
            {
                case 1:
                    startDate = new DateTime(year, 1, 1);
                    endDate = new DateTime(year, 3, 31);
                    break;
                case 2:
                    startDate = new DateTime(year, 4, 1);
                    endDate = new DateTime(year, 6, 30);
                    break;
                case 3:
                    startDate = new DateTime(year, 7, 1);
                    endDate = new DateTime(year, 9, 30);
                    break;
                default: // Q4
                    startDate = new DateTime(year, 10, 1);
                    endDate = new DateTime(year, 12, 31);
                    break;
            }

            return (startDate, endDate);
        }

        // Thêm mới
        public bool Insert(EvaluationDTO evaluation)
        {
            if (evaluation == null ||
                string.IsNullOrWhiteSpace(evaluation.MaDanhGia) ||
                string.IsNullOrWhiteSpace(evaluation.MaNhanVien) ||
                string.IsNullOrWhiteSpace(evaluation.MaNguoiDanhGia) ||
                evaluation.NgayDanhGia == default(DateTime) ||
                evaluation.DiemDanhGia < 0)
            {
                return false;
            }

            if (_dao.GetById(evaluation.MaDanhGia) != null)
                return false;

            // Kiểm tra giới hạn quý
            if (IsEmployeeEvaluatedInQuarter(evaluation.MaNhanVien, evaluation.NgayDanhGia))
            {
                throw new Exception($"Nhân viên đã được đánh giá trong {GetQuarterName(evaluation.NgayDanhGia)}. Mỗi nhân viên chỉ được đánh giá 1 lần mỗi quý!");
            }

            return _dao.Insert(evaluation);
        }

        // Cập nhật
        public bool Update(EvaluationDTO evaluation)
        {
            if (evaluation == null ||
                string.IsNullOrWhiteSpace(evaluation.MaDanhGia) ||
                string.IsNullOrWhiteSpace(evaluation.MaNhanVien) ||
                string.IsNullOrWhiteSpace(evaluation.MaNguoiDanhGia) ||
                evaluation.NgayDanhGia == default(DateTime) ||
                evaluation.DiemDanhGia < 0)
            {
                return false;
            }

            if (_dao.GetById(evaluation.MaDanhGia) == null)
                return false;

            // Kiểm tra giới hạn quý (loại trừ bản ghi hiện tại)
            if (IsEmployeeEvaluatedInQuarter(evaluation.MaNhanVien, evaluation.NgayDanhGia, evaluation.MaDanhGia))
            {
                throw new Exception($"Nhân viên đã được đánh giá trong {GetQuarterName(evaluation.NgayDanhGia)}. Mỗi nhân viên chỉ được đánh giá 1 lần mỗi quý!");
            }

            return _dao.Update(evaluation);
        }

        // Xóa (xóa vật lý)
        public bool Delete(string maDanhGia)
        {
            if (string.IsNullOrWhiteSpace(maDanhGia))
                return false;
            if (_dao.GetById(maDanhGia) == null)
                return false;

            return _dao.Delete(maDanhGia);
        }

        // Tìm kiếm
        public List<EvaluationDTO> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<EvaluationDTO>();
            return _dao.Search(searchTerm);
        }

        /// <summary>
        /// Lấy danh sách đánh giá theo quý
        /// </summary>
        public List<EvaluationDTO> GetByQuarter(int quarter, int year)
        {
            if (quarter < 1 || quarter > 4)
                return new List<EvaluationDTO>();

            var allEvaluations = _dao.GetAll();
            if (allEvaluations == null)
                return new List<EvaluationDTO>();

            return allEvaluations
                .Where(e => e.NgayDanhGia.Year == year && GetQuarter(e.NgayDanhGia) == quarter)
                .ToList();
        }

        /// <summary>
        /// Lấy danh sách đánh giá của nhân viên theo năm
        /// </summary>
        public List<EvaluationDTO> GetEmployeeEvaluationsByYear(string maNhanVien, int year)
        {
            if (string.IsNullOrWhiteSpace(maNhanVien))
                return new List<EvaluationDTO>();

            var allEvaluations = _dao.GetAll();
            if (allEvaluations == null)
                return new List<EvaluationDTO>();

            return allEvaluations
                .Where(e => e.MaNhanVien == maNhanVien && e.NgayDanhGia.Year == year)
                .OrderBy(e => GetQuarter(e.NgayDanhGia))
                .ToList();
        }

        public double GetTotalEvaluationScore(string maNhanVien, int year)
        {
            if (string.IsNullOrWhiteSpace(maNhanVien))
                return 0;

            var allEvaluations = _dao.GetAll();
            if (allEvaluations == null)
                return 0;

            return allEvaluations
                .Where(e => e.MaNhanVien == maNhanVien && e.NgayDanhGia.Year == year)
                .Sum(e => e.DiemDanhGia);
        }
    }
}