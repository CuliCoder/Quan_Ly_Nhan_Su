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
            if(list == null) list = _dao.getAll();
        }

        public List<Employee2DTO> getAll() => list;

        public void insert(Employee2DTO employeeDTO) { 
            if(_dao.createEmployee(employeeDTO))
            {
                list.Add(employeeDTO);
            }
        }

        public void update(Employee2DTO employeeDTO) {
            if (_dao.updateEmployee(employeeDTO)) {
                var index = list.FindIndex(x => x.MaNhanVien ==  employeeDTO.MaNhanVien);
                list[index] = employeeDTO;
            }
        }

        public void delete(String maNhanVien) { 
            if(_dao.deleteEmployee(maNhanVien))
            {
                var item = list.FirstOrDefault(x => x.MaNhanVien == maNhanVien);
                list.Remove(item);
            }
        }

        public List<Employee2DTO> searchEmployee(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _dao.getAll();
            return _dao.searchEmployee(keyword);
        }
    }
}