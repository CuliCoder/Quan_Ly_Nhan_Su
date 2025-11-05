using System;
using System.Collections.Generic;
using Mysqlx.Prepare;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class DepartmentBLL
    {
        private readonly DepartmentDAO _departmentDAO; 
        private static List<DepartmentDTO> list;
        public DepartmentBLL()
        {
            _departmentDAO = new DepartmentDAO();
            if (list == null)
                list = _departmentDAO.GetAll();
        }

        public List<DepartmentDTO> 
            
            GetAllDepartments()
        {
            try
            {
                return new List<DepartmentDTO>(list);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách phòng ban: {ex.Message}");
            }
        }

        public DepartmentDTO GetDepartmentById(string maPhong)  
        {
            if (string.IsNullOrWhiteSpace(maPhong))
            {
                throw new ArgumentException("Mã phòng ban không được rỗng.");
            }

            try
            {
                return _departmentDAO.GetById(maPhong); 
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin phòng ban: {ex.Message}");
            }
        }

        public bool AddDepartment(DepartmentDTO department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }

            if (string.IsNullOrWhiteSpace(department.MaPhong) || string.IsNullOrWhiteSpace(department.TenPhong))
            {
                throw new ArgumentException("Mã và tên phòng ban không được rỗng.");
            }

            if (GetDepartmentById(department.MaPhong) != null)
            {
                throw new InvalidOperationException("Mã phòng ban đã tồn tại.");
            }
            foreach (var dept in GetAllDepartments())
            {
                if (dept.TenPhong.Equals(department.TenPhong, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("Tên phòng ban đã tồn tại.");
                }
            }
            bool success = _departmentDAO.Insert(department);
            if (success)
            {
                list.Add(department);
            }
            return success;
        }

        public bool UpdateDepartment(DepartmentDTO department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }

            if (string.IsNullOrWhiteSpace(department.MaPhong) || string.IsNullOrWhiteSpace(department.TenPhong))
            {
                throw new ArgumentException("Mã và tên phòng ban không được rỗng.");
            }

            // Kiểm tra tồn tại
            if (GetDepartmentById(department.MaPhong) == null)
            {
                throw new InvalidOperationException("Phòng ban không tồn tại.");
            }

            bool success = _departmentDAO.Update(department);
            if (success)
            {
                var index = list.FindIndex(x => x.MaPhong == department.MaPhong);
                list[index] = department;
            }
            return success;
        }
        public bool DeleteDepartment(string maPhong)
        {
            if (string.IsNullOrWhiteSpace(maPhong))
            {
                throw new ArgumentException("Mã phòng ban không được rỗng.");
            }

            var dept = GetDepartmentById(maPhong);
            if (dept == null)
            {
                throw new InvalidOperationException("Phòng ban không tồn tại.");
            }
            bool success = _departmentDAO.Delete(maPhong);
            if(success)
            {
                list.RemoveAll(x => x.MaPhong == maPhong);
            }
            return success;
        }

        public List<DepartmentDTO> SearchDepartmentDTO(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<DepartmentDTO>(list);

            return _departmentDAO.search(keyword);
        }
    }
}