using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAO _dao;
        private static List<EmployeeDTO> list = new List<EmployeeDTO>();

        public EmployeeBLL()
        {
            _dao = new EmployeeDAO();
            if (list == null)
                list = _dao.getAll();
        }

        public List<EmployeeDTO> GetAll() => new List<EmployeeDTO>(list);

        public bool Insert(EmployeeDTO employeeDTO, string maTuyenDung, PositionDTO positionDTO)
        {
            if (employeeDTO == null)
                throw new ArgumentNullException(nameof(employeeDTO), "Dữ liệu nhân viên không hợp lệ!");

            bool success = _dao.createEmployee(employeeDTO, maTuyenDung, positionDTO);
            if (success)
                list.Add(employeeDTO);

            return success;
        }

        public bool InsertNoCandiDate(EmployeeDTO employeeDTO, PersonalProfileDTO personalProfileDTO, PositionDTO positionDTO)
        {
            if (employeeDTO == null)
                throw new ArgumentNullException(nameof(employeeDTO), "Dữ liệu nhân viên không hợp lệ!");

            bool success = _dao.createEmployeeNoCandiDate(employeeDTO, personalProfileDTO, positionDTO);
            if (success)
                list.Add(employeeDTO);

            return success;
        }

        public bool Update(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
                throw new ArgumentNullException(nameof(employeeDTO), "Dữ liệu nhân viên không hợp lệ!");

            bool success = _dao.updateEmployee(employeeDTO);
            if (success)
            {
                int index = list.FindIndex(x => x.MaNhanVien == employeeDTO.MaNhanVien);
                if (index != -1)
                    list[index] = employeeDTO;
            }

            return success;
        }

        public bool Delete(string maNhanVien)
        {
            if (string.IsNullOrWhiteSpace(maNhanVien))
                throw new ArgumentException("Mã nhân viên không được để trống!");

            bool success = _dao.deleteEmployee(maNhanVien);
            if (success)
                list.RemoveAll(x => x.MaNhanVien == maNhanVien);

            return success;
        }

        public List<EmployeeDTO> SearchEmployee(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<EmployeeDTO>(list);

            return _dao.searchEmployee(keyword);
        }

        // Thêm method này để hỗ trợ form frmAccountCU (tìm nhân viên bằng mã tài khoản)
        public EmployeeDTO GetByAccountId(string maTaiKhoan)
        {
            if (string.IsNullOrWhiteSpace(maTaiKhoan))
            {
                throw new ArgumentException("Mã tài khoản không được để trống!");
            }

            // Phương thức này gọi xuống EmployeeDAO.GetByAccountId()
            // mà chúng ta đã thảo luận ở bước trước.
            // Nó không dùng cache 'list' vì đây là một truy vấn cụ thể, 
            // tương tự như SearchEmployee()
            return _dao.GetByAccountId(maTaiKhoan);
        }
    }
}
