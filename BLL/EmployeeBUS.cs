using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class EmployeeBUS
    {
        private readonly EmployeeDAO _dao;
        private static List<EmployeeDTO> list;

        public EmployeeBUS()
        {
            _dao = new EmployeeDAO();
            if (list == null)
                list = _dao.getAll();
        }

        public List<EmployeeDTO> GetAll() => new List<EmployeeDTO>(list);

        public bool Insert(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
                throw new ArgumentNullException(nameof(employeeDTO), "Dữ liệu nhân viên không hợp lệ!");

            bool success = _dao.createEmployee(employeeDTO);
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
    }
}
