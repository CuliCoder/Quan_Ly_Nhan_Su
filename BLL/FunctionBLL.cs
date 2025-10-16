using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class FunctionBLL
    {
        private readonly FunctionDAO dao;

        public FunctionBLL()
        {
            dao = new FunctionDAO();
        }

        // Giữ nguyên, đã đúng
        public FunctionDTO GetById(int id)
        {
            return dao.GetById(id);
        }

        // Giữ nguyên, đã đúng
        public List<FunctionDTO> GetAll()
        {
            return dao.GetAll();
        }

        /// <summary>
        /// Thêm một chức năng mới, với kiểm tra nghiệp vụ không cho trùng tên
        /// </summary>
        public bool Create(FunctionDTO function)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản
            if (function == null || string.IsNullOrWhiteSpace(function.TenChucNang))
            {
                throw new ArgumentException("Tên chức năng không được để trống!");
            }

            // 2. Kiểm tra quy tắc nghiệp vụ: Tên chức năng không được trùng
            // Lấy tất cả chức năng và kiểm tra xem có cái nào trùng tên không
            var allFunctions = dao.GetAll();
            if (allFunctions.Any(f => f.TenChucNang.Equals(function.TenChucNang, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Tên chức năng đã tồn tại!");
            }

            // 3. Nếu mọi thứ hợp lệ, gọi DAO để tạo mới
            return dao.Create(function);
        }

        /// <summary>
        /// Cập nhật chức năng, với kiểm tra nghiệp vụ
        /// </summary>
        public bool Update(FunctionDTO function)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản
            if (function == null || function.MaChucNang <= 0 || string.IsNullOrWhiteSpace(function.TenChucNang))
            {
                throw new ArgumentException("Dữ liệu cập nhật không hợp lệ!");
            }

            // 2. Kiểm tra quy tắc nghiệp vụ: Tên mới không được trùng với tên của một chức năng KHÁC
            var allFunctions = dao.GetAll();
            if (allFunctions.Any(f => f.TenChucNang.Equals(function.TenChucNang, StringComparison.OrdinalIgnoreCase) && f.MaChucNang != function.MaChucNang))
            {
                throw new InvalidOperationException("Tên chức năng này đã được sử dụng bởi một chức năng khác!");
            }

            // 3. Nếu hợp lệ, gọi DAO để cập nhật
            return dao.Update(function);
        }

        /// <summary>
        /// Xóa chức năng theo ID (SỬA: đổi tham số sang int)
        /// </summary>
        public bool Delete(int maChucNang)
        {
            if (maChucNang <= 0)
            {
                throw new ArgumentException("Mã chức năng không hợp lệ!");
            }
            return dao.Delete(maChucNang);
        }

        /// <summary>
        /// Tìm kiếm chức năng (SỬA: Bỏ Console.WriteLine)
        /// </summary>
        public List<FunctionDTO> Search(string searchTerm)
        {
            // Không cần ghi ra console ở lớp BLL
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new List<FunctionDTO>(); // Trả về danh sách rỗng nếu không có từ khóa
            }
            return dao.Search(searchTerm);
        }
    }
}