using System;
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