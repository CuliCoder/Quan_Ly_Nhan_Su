using System;
using System.Collections.Generic;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.DAO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAO _dao;

        public EmployeeBLL()
        {
            _dao = new EmployeeDAO();
        }

        /// <summary>
        /// Lấy danh sách tất cả nhân viên.
        /// </summary>
        /// <returns>List<EmployeeDTO></returns>
        public List<EmployeeDTO> GetAllEmployees()
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
        public List<EmployeeDTO> GetEmployeesWithoutContract()
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

        public EmployeeDTO GetEmployeeById(string maNhanVien)
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