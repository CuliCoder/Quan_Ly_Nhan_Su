using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

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
    }
}