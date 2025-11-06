using System;
using System.Collections.Generic;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.DAO;
using System.Linq;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class EmployeeFullBLL
    {
        private readonly EmployeeFullDAO _dao;
        private static List<EmployeeFullDTO> _cachedEmployees;

        public EmployeeFullBLL()
        {
            _dao = new EmployeeFullDAO();
            if(_cachedEmployees == null)
                _cachedEmployees = _dao.GetAll();
            
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

        // Thêm method này để hỗ trợ form frmAccountCU (lấy nhân viên chưa có tài khoản)
        public List<EmployeeFullDTO> GetEmployeesWithoutAccount()
        {
            try
            {
                // Phương thức này gọi xuống EmployeeFullDAO.GetEmployeesWithoutAccount()
                // mà chúng ta đã thảo luận ở bước trước.
                return _dao.GetEmployeesWithoutAccount();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách nhân viên chưa có tài khoản: {ex.Message}");
            }
        }

        public List<EmployeeFullDTO> SearchEmployeesLINQ(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return new List<EmployeeFullDTO>(_cachedEmployees);
            }
            List<EmployeeFullDTO> _result = _cachedEmployees;

            string lowerKeyword = keyword.ToLower().Trim();
            var filteredList = _cachedEmployees.Where(emp =>
                    (emp.HoTen ?? "").ToLower().Contains(lowerKeyword) ||
                    (emp.ChucVu ?? "").ToLower().Contains(lowerKeyword) ||
                    (emp.HocVan ?? "").ToLower().Contains(lowerKeyword) ||
                    (emp.PhongBan ?? "").ToLower().Contains(lowerKeyword) ||
                    (emp.Email ?? "").ToLower().Contains(lowerKeyword) ||
                    (emp.Sdt ?? "").ToLower().Contains(lowerKeyword) ||
                    (emp.SoCmnd ?? "").ToLower().Contains(lowerKeyword) ||
                    (emp.ChuyenNganh ?? "").ToLower().Contains(lowerKeyword)
            );
            return filteredList.ToList();
        }

        public List<EmployeeFullDTO> SearchDateLINQ(DateTime startDay, DateTime endDay)
        {
            List<EmployeeFullDTO> _result = _cachedEmployees;

            var filteredList = _cachedEmployees.Where(emp =>
                emp.NgaySinh >= startDay && emp.NgaySinh <= endDay
            );
            return filteredList.ToList();
        }
    }
}