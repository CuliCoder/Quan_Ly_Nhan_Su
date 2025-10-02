using System;
using System.Collections.Generic;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class DepartmentBLL
    {
        private DepartmentDAO _departmentDAO;  // Sửa: Dùng DepartmentDAO thay vì EmployeeDAO

        public DepartmentBLL()
        {
            _departmentDAO = new DepartmentDAO();  // Sửa: Khởi tạo đúng
        }

        /// <summary>
        /// Lấy danh sách tất cả phòng ban.
        /// </summary>
        /// <returns>List<DepartmentDTO> chứa thông tin phòng ban.</returns>
        public List<DepartmentDTO> GetAllDepartments()
        {
            try
            {
                return _departmentDAO.GetAll();
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần (sử dụng logger hoặc throw lên)
                throw new Exception($"Lỗi khi lấy danh sách phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy thông tin phòng ban theo mã.
        /// </summary>
        /// <param name="maPhong">Mã phòng ban.</param>
        /// <returns>DepartmentDTO nếu tìm thấy, null nếu không.</returns>
        public DepartmentDTO GetDepartmentById(string maPhong)  // Sửa tên method cho đúng
        {
            if (string.IsNullOrWhiteSpace(maPhong))
            {
                throw new ArgumentException("Mã phòng ban không được rỗng.");
            }

            try
            {
                return _departmentDAO.GetById(maPhong);  // Sửa: Gọi _departmentDAO
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm phòng ban mới.
        /// </summary>
        /// <param name="department">Thông tin phòng ban cần thêm.</param>
        /// <returns>True nếu thành công, false nếu thất bại.</returns>
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

            // Kiểm tra trùng mã
            if (GetDepartmentById(department.MaPhong) != null)
            {
                throw new InvalidOperationException("Mã phòng ban đã tồn tại.");
            }

            try
            {
                return _departmentDAO.Insert(department);  // Sửa: Gọi _departmentDAO
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật thông tin phòng ban.
        /// </summary>
        /// <param name="department">Thông tin phòng ban cần cập nhật.</param>
        /// <returns>True nếu thành công, false nếu thất bại.</returns>
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

            try
            {
                return _departmentDAO.Update(department);  // Sửa: Gọi _departmentDAO
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa phòng ban theo mã.
        /// </summary>
        /// <param name="maPhong">Mã phòng ban cần xóa.</param>
        /// <returns>True nếu thành công, false nếu thất bại.</returns>
        public bool DeleteDepartment(string maPhong)
        {
            if (string.IsNullOrWhiteSpace(maPhong))
            {
                throw new ArgumentException("Mã phòng ban không được rỗng.");
            }

            // Kiểm tra tồn tại
            var dept = GetDepartmentById(maPhong);
            if (dept == null)
            {
                throw new InvalidOperationException("Phòng ban không tồn tại.");
            }

            // TODO: Kiểm tra có nhân viên không (nếu cần, gọi EmployeeBLL)
            // var employeeBLL = new EmployeeBLL();
            // if (employeeBLL.GetEmployeesByDepartment(maPhong).Count > 0) { throw ... }

            try
            {
                return _departmentDAO.Delete(maPhong);  // Sửa: Gọi _departmentDAO
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa phòng ban: {ex.Message}");
            }
        }
    }
}