using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class PermissionDetailBLL
    {
        private readonly PermissionDetailDAO _dao = new PermissionDetailDAO();

        public List<PermissionDetailDTO> GetByGroupId(int permissionGroupId)
        {
            return _dao.GetByGroupId(permissionGroupId);
        }

        public bool SavePermissions(int permissionGroupId, List<PermissionDetailDTO> permissions)
        {
            // Ở đây bạn có thể thêm các logic kiểm tra dữ liệu nếu cần
            return _dao.SavePermissions(permissionGroupId, permissions);
        }
    }
}