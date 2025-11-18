using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class EvaluationFullBLL
    {
        private readonly EvaluationFullDAO _dao = new EvaluationFullDAO();

        public List<EvaluationFullDTO> GetAllEvaluationsFull()
        {
            try
            {
                return _dao.GetAllEvaluationsFull();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách đánh giá: {ex.Message}");
            }
        }

        public List<EvaluationFullDTO> Search(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return GetAllEvaluationsFull();

                return _dao.Search(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm đánh giá: {ex.Message}");
            }
        }

        public List<EvaluationFullDTO> FilterByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (fromDate > toDate)
                    throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!");

                return _dao.FilterByDate(fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lọc đánh giá theo ngày: {ex.Message}");
            }
        }
    }
}