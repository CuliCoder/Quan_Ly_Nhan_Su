// In file: BLL/FunctionBLL.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    // Đổi tên class từ FunctionBUS thành FunctionBLL cho nhất quán
    public class FunctionBLL
    {
        private readonly FunctionDAO dao;

        public FunctionBLL()
        {
            dao = new FunctionDAO();
        }

        public List<FunctionDTO> GetAll()
        {
            return dao.Search("");
        }

        public bool Create(FunctionDTO function)
        {
            // Sửa logic kiểm tra: Thay vì kiểm tra MaChucNang, hãy kiểm tra TenChucNang
            if (function == null || string.IsNullOrWhiteSpace(function.TenChucNang))
            {
                throw new Exception("Tên chức năng không được để trống!");
            }

            // Kiểm tra xem tên chức năng đã tồn tại chưa
            // Phương thức Search tìm kiếm theo LIKE, nên ta cần lọc lại kết quả để tìm chính xác
            var existingFunction = dao.Search(function.TenChucNang)
                                      .FirstOrDefault(f => f.TenChucNang.Equals(function.TenChucNang, StringComparison.OrdinalIgnoreCase));

            if (existingFunction != null)
            {
                throw new Exception("Tên chức năng đã tồn tại!");
            }

            return dao.Create(function);
        }

        public bool Update(FunctionDTO function)
        {
            // Điều kiện hợp lệ cho Update là phải có MaChucNang
            if (function == null || function.MaChucNang <= 0)
            {
                throw new Exception("Dữ liệu cập nhật không hợp lệ!");
            }

            return dao.Update(function);
        }

        // Sửa: Đổi kiểu dữ liệu của tham số từ string sang int
        public bool Delete(int maChucNang)
        {
            if (maChucNang <= 0)
            {
                throw new Exception("Mã chức năng không hợp lệ!");
            }
            return dao.Delete(maChucNang);
        }
    }
}