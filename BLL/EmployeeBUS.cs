using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class EmployeeBUS
    {
        private readonly Employee2DAO _dao;
        private static List<Employee2DTO> list;

        public EmployeeBUS()
        {
            _dao = new Employee2DAO();
            if (list == null)
                list = _dao.getAll();
        }

        public List<Employee2DTO> GetAll() => new List<Employee2DTO>(list);

        public bool Insert(Employee2DTO employeeDTO)
        {
            if (employeeDTO == null)
                throw new ArgumentNullException(nameof(employeeDTO), "Dữ liệu nhân viên không hợp lệ!");

            bool success = _dao.createEmployee(employeeDTO);
            if (success)
                list.Add(employeeDTO);

            return success;
        }

        public bool Update(Employee2DTO employeeDTO)
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

        public List<Employee2DTO> SearchEmployee(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<Employee2DTO>(list);

            return _dao.searchEmployee(keyword);
        }
    }
}
