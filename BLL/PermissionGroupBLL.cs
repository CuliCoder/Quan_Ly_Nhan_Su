using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class PermissionGroupBLL
    {
        private readonly PermissionGroupDAO _dao = new PermissionGroupDAO();

        // Lấy tất cả
        public List<PermissionGroupDTO> GetAll()
        {
            return _dao.GetAll();
        }

        // Lấy theo mã
        public PermissionGroupDTO GetById(int id)
        {
            if (id <= 0)
                return null;
            return _dao.GetbyID(id);
        }

        // Thêm mới
        public bool Insert(PermissionGroupDTO group)
        {
            if (group == null ||
                string.IsNullOrWhiteSpace(group.TenNhomQuyen))
            {
                return false;
            }
            // Không cho thêm nếu đã tồn tại mã nhóm quyền (nếu có thể kiểm tra)
            // Nếu cần kiểm tra trùng tên nhóm quyền:
            var allGroups = _dao.GetAll();
            if (allGroups != null && allGroups.Exists(g => g.TenNhomQuyen == group.TenNhomQuyen))
                return false;

            return _dao.Insert(group);
        }

        // Cập nhật
        public bool Update(PermissionGroupDTO group)
        {
            if (group == null ||
                group.MaNhomQuyen <= 0 ||
                string.IsNullOrWhiteSpace(group.TenNhomQuyen))
            {
                return false;
            }
            if (_dao.GetbyID(group.MaNhomQuyen) == null)
                return false;

            return _dao.Update(group);
        }

        // Xóa (chuyển trạng thái)
        public bool Delete(int id)
        {
            if (id <= 0)
                return false;
            if (_dao.GetbyID(id) == null)
                return false;

            return _dao.Delete(id);
        }
    }
}