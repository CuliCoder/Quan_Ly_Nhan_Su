using System;
using System.Collections.Generic;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.DAO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class EmployeeFullBLL
    {
        private readonly EmployeeFullDAO _dao;

        public EmployeeFullBLL()
        {
            _dao = new EmployeeFullDAO();
        }

        /// <summary>
        /// Lấy danh sách tất cả nhân viên.
        /// </summary>
        /// <returns>List<EmployeeDTO></returns>
        public List<EmployeeFullDTO> GetAllEmployees()
        {
            try
            {
                return _dao.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách nhân viên: {ex.Message}");
            }
        }
        // Thêm method này vào class EmployeeBLL
        public List<EmployeeFullDTO> GetEmployeesWithoutContract()
        {
            try
            {
                return _dao.GetEmployeesWithoutContract();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách nhân viên chưa ký hợp đồng: {ex.Message}");
            }
        }

        public EmployeeFullDTO GetEmployeeById(string maNhanVien)
        {
            if (string.IsNullOrEmpty(maNhanVien))
            {
                throw new ArgumentException("Mã nhân viên không được để trống.");
            }
            return _dao.GetEmployeeById(maNhanVien);
        }

        // Thêm hàm mới: Lấy thông tin kết hợp nhân viên và hợp đồng
        public LaborContractDTO GetEmployeeContractDetails(string maNhanVien)
        {
            if (string.IsNullOrEmpty(maNhanVien))
            {
                throw new ArgumentException("Mã nhân viên không được để trống.");
            }
            return _dao.GetEmployeeContractDetails(maNhanVien);
        }
    }
}