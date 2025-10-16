using System;
using System.Collections.Generic;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class RecruitmentBatchEmployeeBLL
    {
        private readonly RecruitmentBatchEmployeeDAO dao;

        public RecruitmentBatchEmployeeBLL()
        {
          dao = new RecruitmentBatchEmployeeDAO();
        }

        public List<RecruitmentBatchEmployeeDTO> GetAll()
        {
          return dao.GetAll();
        }

          public bool Create(RecruitmentBatchEmployeeDTO batchEmployee)
    {
      if (batchEmployee == null ||
          string.IsNullOrWhiteSpace(batchEmployee.MaTuyenDung) ||
          string.IsNullOrWhiteSpace(batchEmployee.MaNhanVien))
      {
        Console.WriteLine("Dữ liệu không hợp lệ khi thêm đợt tuyển dụng - nhân viên!");
        return false;
      }

      if (dao.Exists(batchEmployee.MaTuyenDung, batchEmployee.MaNhanVien))
      {
        Console.WriteLine("Bản ghi đã tồn tại (maTuyenDung + maNhanVien), không thể thêm mới!");
        return false;
      }

      return dao.Create(batchEmployee);
    }

        /// <summary>
        /// Cập nhật thông tin nhân viên trong đợt tuyển dụng
        /// </summary>
        public bool Update(RecruitmentBatchEmployeeDTO batchEmployee)
        {
            if (batchEmployee == null ||
                string.IsNullOrWhiteSpace(batchEmployee.MaTuyenDung) ||
                string.IsNullOrWhiteSpace(batchEmployee.MaNhanVien))
            {
                Console.WriteLine("Dữ liệu không hợp lệ khi cập nhật!");
                return false;
            }

            return dao.Update(batchEmployee);
        }

        /// <summary>
        /// Xóa nhân viên khỏi đợt tuyển dụng
        /// </summary>
        public bool Delete(string maTuyenDung, string maNhanVien)
        {
            if (string.IsNullOrWhiteSpace(maTuyenDung) ||
                string.IsNullOrWhiteSpace(maNhanVien))
            {
                Console.WriteLine("Mã tuyển dụng hoặc mã nhân viên không hợp lệ khi xóa!");
                return false;
            }

            return dao.Delete(maTuyenDung, maNhanVien);
        }

        /// <summary>
        /// Tìm kiếm theo mã tuyển dụng hoặc mã nhân viên
        /// </summary>
        public List<RecruitmentBatchEmployeeDTO> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Từ khóa tìm kiếm không hợp lệ!");
                return new List<RecruitmentBatchEmployeeDTO>();
            }

            return dao.Search(searchTerm);
        }
    }
}
