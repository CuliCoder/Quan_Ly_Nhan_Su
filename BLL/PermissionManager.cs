using System;
using System.Collections.Generic;
using System.Linq;

namespace Quan_Ly_Nhan_Su.BLL
{
    /// <summary>
    /// Quản lý phân quyền linh động dựa trên tên chức năng
    /// Hỗ trợ cache và kiểm tra quyền nhanh chóng
    /// </summary>
    public class PermissionManager
    {
        private static PermissionManager _instance;
        private Dictionary<string, PermissionSet> _userPermissions;

        public static PermissionManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PermissionManager();
                return _instance;
            }
        }

        private PermissionManager()
        {
            _userPermissions = new Dictionary<string, PermissionSet>();
        }

        /// <summary>
        /// Load quyền của user từ database
        /// </summary>
        public void LoadUserPermissions(int permissionGroupId)
        {
            _userPermissions.Clear();

            var permissionDetailBLL = new PermissionDetailBLL();
            var functionBLL = new FunctionBLL();

            // Lấy danh sách quyền chi tiết
            var permissionDetails = permissionDetailBLL.GetByPermissionGroup(permissionGroupId);
            var functions = functionBLL.GetAll();

            foreach (var detail in permissionDetails)
            {
                var function = functions.FirstOrDefault(f => f.MaChucNang == detail.FunctionID);
                if (function != null)
                {
                    _userPermissions[function.TenChucNang] = new PermissionSet
                    {
                        CanRead = detail.CanRead,
                        CanCreate = detail.CanCreate,
                        CanUpdate = detail.CanUpdate,
                        CanDelete = detail.CanDelete
                    };
                }
            }
        }

        /// <summary>
        /// Kiểm tra quyền đọc
        /// </summary>
        public bool CanRead(string functionName)
        {
            return _userPermissions.ContainsKey(functionName) &&
                   _userPermissions[functionName].CanRead;
        }

        /// <summary>
        /// Kiểm tra quyền tạo
        /// </summary>
        public bool CanCreate(string functionName)
        {
            return _userPermissions.ContainsKey(functionName) &&
                   _userPermissions[functionName].CanCreate;
        }

        /// <summary>
        /// Kiểm tra quyền cập nhật
        /// </summary>
        public bool CanUpdate(string functionName)
        {
            return _userPermissions.ContainsKey(functionName) &&
                   _userPermissions[functionName].CanUpdate;
        }

        /// <summary>
        /// Kiểm tra quyền xóa
        /// </summary>
        public bool CanDelete(string functionName)
        {
            return _userPermissions.ContainsKey(functionName) &&
                   _userPermissions[functionName].CanDelete;
        }

        /// <summary>
        /// Kiểm tra có ít nhất một quyền trên chức năng
        /// </summary>
        public bool HasAnyPermission(string functionName)
        {
            if (!_userPermissions.ContainsKey(functionName))
                return false;

            var perm = _userPermissions[functionName];
            return perm.CanRead || perm.CanCreate || perm.CanUpdate || perm.CanDelete;
        }

        /// <summary>
        /// Lấy tất cả quyền của một chức năng
        /// </summary>
        public PermissionSet GetPermissions(string functionName)
        {
            return _userPermissions.ContainsKey(functionName)
                ? _userPermissions[functionName]
                : new PermissionSet();
        }

        /// <summary>
        /// Xóa cache quyền (dùng khi logout)
        /// </summary>
        public void ClearPermissions()
        {
            _userPermissions.Clear();
        }
    }

    /// <summary>
    /// Đại diện cho một bộ quyền
    /// </summary>
    public class PermissionSet
    {
        public bool CanRead { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}