using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    /// <summary>
    /// BLL cho chức năng - Tương thích với hệ thống cũ và mới
    /// </summary>
    public class FunctionBLL
    {
        private readonly FunctionDAO dao;

        public FunctionBLL()
        {
            dao = new FunctionDAO();
        }

        /// <summary>
        /// Lấy chức năng theo ID (GIỮ NGUYÊN - chức năng cũ)
        /// </summary>
        public FunctionDTO GetById(int id)
        {
            return dao.GetById(id);
        }

        /// <summary>
        /// Lấy chức năng theo tên (MỚI - hỗ trợ PermissionManager)
        /// </summary>
        public FunctionDTO GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Tên chức năng không được để trống!");
            }
            return dao.GetByName(name);
        }

        /// <summary>
        /// Lấy tất cả chức năng (GIỮ NGUYÊN - chức năng cũ)
        /// </summary>
        public List<FunctionDTO> GetAll()
        {
            return dao.GetAll();
        }

        /// <summary>
        /// Lấy các chức năng đang hoạt động (MỚI - hỗ trợ PermissionManager)
        /// </summary>
        public List<FunctionDTO> GetActive()
        {
            return dao.GetActive();
        }

        /// <summary>
        /// Thêm một chức năng mới, với kiểm tra nghiệp vụ không cho trùng tên
        /// CẢI TIẾN: Dùng ExistsByName từ DAO thay vì GetAll
        /// </summary>
        public bool Create(FunctionDTO function)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản
            if (function == null || string.IsNullOrWhiteSpace(function.TenChucNang))
            {
                throw new ArgumentException("Tên chức năng không được để trống!");
            }

            // 2. Kiểm tra quy tắc nghiệp vụ: Tên chức năng không được trùng
            // CẢI TIẾN: Dùng ExistsByName thay vì GetAll (hiệu quả hơn)
            if (dao.ExistsByName(function.TenChucNang))
            {
                throw new InvalidOperationException("Tên chức năng đã tồn tại!");
            }

            // 3. Nếu mọi thứ hợp lệ, gọi DAO để tạo mới
            return dao.Create(function);
        }

        /// <summary>
        /// Cập nhật chức năng, với kiểm tra nghiệp vụ
        /// CẢI TIẾN: Dùng ExistsByName từ DAO
        /// </summary>
        public bool Update(FunctionDTO function)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản
            if (function == null || function.MaChucNang <= 0 || string.IsNullOrWhiteSpace(function.TenChucNang))
            {
                throw new ArgumentException("Dữ liệu cập nhật không hợp lệ!");
            }

            // 2. Kiểm tra quy tắc nghiệp vụ: Tên mới không được trùng với tên của một chức năng KHÁC
            // CẢI TIẾN: Dùng ExistsByName với excludeId
            if (dao.ExistsByName(function.TenChucNang, function.MaChucNang))
            {
                throw new InvalidOperationException("Tên chức năng này đã được sử dụng bởi một chức năng khác!");
            }

            // 3. Nếu hợp lệ, gọi DAO để cập nhật
            return dao.Update(function);
        }

        /// <summary>
        /// Xóa chức năng theo ID (GIỮ NGUYÊN - chức năng cũ)
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
        /// Xóa vĩnh viễn chức năng (MỚI - cẩn thận khi dùng!)
        /// </summary>
        public bool HardDelete(int maChucNang)
        {
            if (maChucNang <= 0)
            {
                throw new ArgumentException("Mã chức năng không hợp lệ!");
            }

            // Kiểm tra xem chức năng có đang được sử dụng trong phân quyền không
            // TODO: Thêm logic kiểm tra nếu cần

            return dao.HardDelete(maChucNang);
        }

        /// <summary>
        /// Tìm kiếm chức năng (GIỮ NGUYÊN - chức năng cũ)
        /// </summary>
        public List<FunctionDTO> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new List<FunctionDTO>(); // Trả về danh sách rỗng nếu không có từ khóa
            }
            return dao.Search(searchTerm);
        }

        /// <summary>
        /// Kiểm tra tên chức năng có tồn tại không (MỚI)
        /// </summary>
        public bool ExistsByName(string tenChucNang, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(tenChucNang))
            {
                return false;
            }
            return dao.ExistsByName(tenChucNang, excludeId);
        }

        /// <summary>
        /// Validate dữ liệu chức năng (MỚI - helper method)
        /// </summary>
        public List<string> ValidateFunction(FunctionDTO function, bool isUpdate = false)
        {
            var errors = new List<string>();

            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(function.TenChucNang))
            {
                errors.Add("Tên chức năng không được để trống");
            }
            else if (function.TenChucNang.Length > 100)
            {
                errors.Add("Tên chức năng không được vượt quá 100 ký tự");
            }

            // Kiểm tra mô tả
            if (!string.IsNullOrEmpty(function.MoTa) && function.MoTa.Length > 500)
            {
                errors.Add("Mô tả không được vượt quá 500 ký tự");
            }

            // Kiểm tra trùng tên
            if (!string.IsNullOrWhiteSpace(function.TenChucNang))
            {
                int? excludeId = isUpdate ? (int?)function.MaChucNang : null;
                if (dao.ExistsByName(function.TenChucNang, excludeId))
                {
                    errors.Add("Tên chức năng đã tồn tại trong hệ thống");
                }
            }

            return errors;
        }

        /// <summary>
        /// Kích hoạt/Vô hiệu hóa chức năng (MỚI)
        /// </summary>
        public bool ToggleStatus(int maChucNang)
        {
            if (maChucNang <= 0)
            {
                throw new ArgumentException("Mã chức năng không hợp lệ!");
            }

            var function = dao.GetById(maChucNang);
            if (function == null)
            {
                throw new InvalidOperationException("Không tìm thấy chức năng!");
            }

            function.TinhTrang = !function.TinhTrang;
            return dao.Update(function);
        }

        /// <summary>
        /// Lấy số lượng chức năng hoạt động (MỚI - cho dashboard)
        /// </summary>
        public int GetActiveCount()
        {
            return dao.GetActive().Count;
        }

        /// <summary>
        /// Lấy số lượng chức năng không hoạt động (MỚI - cho dashboard)
        /// </summary>
        public int GetInactiveCount()
        {
            var all = dao.GetAll();
            var active = dao.GetActive();
            return all.Count - active.Count;
        }
    }
}