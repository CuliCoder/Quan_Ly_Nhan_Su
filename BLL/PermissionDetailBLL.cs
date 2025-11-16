using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quan_Ly_Nhan_Su.BLL
{
    /// <summary>
    /// BLL cho chi tiết phân quyền - Tương thích với hệ thống cũ và mới
    /// </summary>
    public class PermissionDetailBLL
    {
        private readonly PermissionDetailDAO _dao = new PermissionDetailDAO();

        /// <summary>
        /// Lấy quyền theo mã nhóm quyền (GIỮ NGUYÊN - chức năng cũ)
        /// </summary>
        public List<PermissionDetailDTO> GetByGroupId(int permissionGroupId)
        {
            return _dao.GetByGroupId(permissionGroupId);
        }

        /// <summary>
        /// Alias method cho GetByGroupId (MỚI - tương thích PermissionManager)
        /// </summary>
        public List<PermissionDetailDTO> GetByPermissionGroup(int permissionGroupId)
        {
            return GetByGroupId(permissionGroupId);
        }

        /// <summary>
        /// Lưu danh sách quyền cho một nhóm quyền (GIỮ NGUYÊN - chức năng cũ)
        /// CẢI TIẾN: Thêm validation logic
        /// </summary>
        public bool SavePermissions(int permissionGroupId, List<PermissionDetailDTO> permissions)
        {
            // Validation
            if (permissionGroupId <= 0)
            {
                throw new ArgumentException("Mã nhóm quyền không hợp lệ!");
            }

            if (permissions == null)
            {
                throw new ArgumentNullException(nameof(permissions));
            }

            // Kiểm tra danh sách quyền có hợp lệ không
            foreach (var permission in permissions)
            {
                if (permission.PermissionGroupID != permissionGroupId)
                {
                    throw new InvalidOperationException(
                        $"Quyền với FunctionID={permission.FunctionID} không thuộc nhóm quyền {permissionGroupId}"
                    );
                }
            }

            // Gọi DAO để lưu
            return _dao.SavePermissions(permissionGroupId, permissions);
        }

        /// <summary>
        /// Lấy tất cả quyền chi tiết (MỚI)
        /// </summary>
        public List<PermissionDetailDTO> GetAll()
        {
            return _dao.GetAll();
        }

        /// <summary>
        /// Thêm một quyền chi tiết (MỚI)
        /// </summary>
        public bool Insert(PermissionDetailDTO dto)
        {
            // Validation
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (dto.PermissionGroupID <= 0)
            {
                throw new ArgumentException("Mã nhóm quyền không hợp lệ!");
            }

            if (dto.FunctionID <= 0)
            {
                throw new ArgumentException("Mã chức năng không hợp lệ!");
            }

            // Kiểm tra ít nhất một quyền được cấp
            if (!dto.CanRead && !dto.CanCreate && !dto.CanUpdate && !dto.CanDelete)
            {
                throw new InvalidOperationException("Phải cấp ít nhất một quyền!");
            }

            return _dao.Insert(dto);
        }

        /// <summary>
        /// Cập nhật một quyền chi tiết (MỚI)
        /// </summary>
        public bool Update(PermissionDetailDTO dto)
        {
            // Validation
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (dto.PermissionGroupID <= 0 || dto.FunctionID <= 0)
            {
                throw new ArgumentException("Mã nhóm quyền hoặc mã chức năng không hợp lệ!");
            }

            return _dao.Update(dto);
        }

        /// <summary>
        /// Xóa một quyền chi tiết (MỚI)
        /// </summary>
        public bool Delete(int permissionGroupId, int functionId)
        {
            if (permissionGroupId <= 0 || functionId <= 0)
            {
                throw new ArgumentException("Mã nhóm quyền hoặc mã chức năng không hợp lệ!");
            }

            return _dao.Delete(permissionGroupId, functionId);
        }

        /// <summary>
        /// Kiểm tra một nhóm quyền có quyền trên một chức năng không (MỚI)
        /// </summary>
        public bool HasPermission(int permissionGroupId, int functionId, string permissionType)
        {
            var permissions = GetByGroupId(permissionGroupId);
            var permission = permissions.FirstOrDefault(p => p.FunctionID == functionId);

            if (permission == null)
            {
                return false;
            }

            switch (permissionType.ToLower())
            {
                case "read":
                case "view":
                    return permission.CanRead;
                case "create":
                case "add":
                    return permission.CanCreate;
                case "update":
                case "edit":
                    return permission.CanUpdate;
                case "delete":
                case "remove":
                    return permission.CanDelete;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Kiểm tra một nhóm quyền có ít nhất một quyền trên một chức năng không (MỚI)
        /// </summary>
        public bool HasAnyPermission(int permissionGroupId, int functionId)
        {
            var permissions = GetByGroupId(permissionGroupId);
            var permission = permissions.FirstOrDefault(p => p.FunctionID == functionId);

            if (permission == null)
            {
                return false;
            }

            return permission.CanRead || permission.CanCreate ||
                   permission.CanUpdate || permission.CanDelete;
        }

        /// <summary>
        /// Lấy danh sách chức năng mà nhóm quyền có quyền truy cập (MỚI)
        /// </summary>
        public List<int> GetAccessibleFunctions(int permissionGroupId)
        {
            var permissions = GetByGroupId(permissionGroupId);
            return permissions
                .Where(p => p.CanRead || p.CanCreate || p.CanUpdate || p.CanDelete)
                .Select(p => p.FunctionID)
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Copy quyền từ nhóm quyền này sang nhóm quyền khác (MỚI)
        /// </summary>
        public bool CopyPermissions(int sourceGroupId, int targetGroupId)
        {
            if (sourceGroupId <= 0 || targetGroupId <= 0)
            {
                throw new ArgumentException("Mã nhóm quyền không hợp lệ!");
            }

            if (sourceGroupId == targetGroupId)
            {
                throw new InvalidOperationException("Không thể copy quyền sang chính nhóm quyền đó!");
            }

            try
            {
                // Lấy quyền từ nhóm nguồn
                var sourcePermissions = GetByGroupId(sourceGroupId);

                // Tạo danh sách quyền mới cho nhóm đích
                var targetPermissions = sourcePermissions.Select(p => new PermissionDetailDTO
                {
                    PermissionGroupID = targetGroupId,
                    FunctionID = p.FunctionID,
                    CanRead = p.CanRead,
                    CanCreate = p.CanCreate,
                    CanUpdate = p.CanUpdate,
                    CanDelete = p.CanDelete
                }).ToList();

                // Lưu quyền mới
                return SavePermissions(targetGroupId, targetPermissions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying permissions: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Tạo bộ quyền mặc định cho nhóm quyền mới (MỚI)
        /// </summary>
        public bool CreateDefaultPermissions(int permissionGroupId, string groupType = "user")
        {
            if (permissionGroupId <= 0)
            {
                throw new ArgumentException("Mã nhóm quyền không hợp lệ!");
            }

            try
            {
                var functionBLL = new FunctionBLL();
                var allFunctions = functionBLL.GetActive();
                var permissions = new List<PermissionDetailDTO>();

                foreach (var function in allFunctions)
                {
                    var permission = new PermissionDetailDTO
                    {
                        PermissionGroupID = permissionGroupId,
                        FunctionID = function.MaChucNang,
                        CanRead = false,
                        CanCreate = false,
                        CanUpdate = false,
                        CanDelete = false
                    };

                    // Cấp quyền mặc định dựa trên loại nhóm
                    switch (groupType.ToLower())
                    {
                        case "admin":
                            // Admin có toàn quyền
                            permission.CanRead = true;
                            permission.CanCreate = true;
                            permission.CanUpdate = true;
                            permission.CanDelete = true;
                            break;

                        case "manager":
                            // Manager chỉ có quyền đọc, tạo, sửa
                            permission.CanRead = true;
                            permission.CanCreate = true;
                            permission.CanUpdate = true;
                            permission.CanDelete = false;
                            break;

                        case "user":
                        default:
                            // User chỉ có quyền đọc
                            permission.CanRead = true;
                            permission.CanCreate = false;
                            permission.CanUpdate = false;
                            permission.CanDelete = false;
                            break;
                    }

                    permissions.Add(permission);
                }

                return SavePermissions(permissionGroupId, permissions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating default permissions: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa tất cả quyền của một nhóm quyền (MỚI)
        /// </summary>
        public bool ClearPermissions(int permissionGroupId)
        {
            if (permissionGroupId <= 0)
            {
                throw new ArgumentException("Mã nhóm quyền không hợp lệ!");
            }

            return SavePermissions(permissionGroupId, new List<PermissionDetailDTO>());
        }

        /// <summary>
        /// Validate danh sách quyền trước khi lưu (MỚI)
        /// </summary>
        public List<string> ValidatePermissions(int permissionGroupId, List<PermissionDetailDTO> permissions)
        {
            var errors = new List<string>();

            if (permissionGroupId <= 0)
            {
                errors.Add("Mã nhóm quyền không hợp lệ");
            }

            if (permissions == null || permissions.Count == 0)
            {
                errors.Add("Danh sách quyền trống");
                return errors;
            }

            // Kiểm tra từng quyền
            var functionBLL = new FunctionBLL();
            var validFunctionIds = functionBLL.GetAll().Select(f => f.MaChucNang).ToList();

            foreach (var permission in permissions)
            {
                // Kiểm tra PermissionGroupID khớp
                if (permission.PermissionGroupID != permissionGroupId)
                {
                    errors.Add($"Quyền với FunctionID={permission.FunctionID} không thuộc nhóm quyền {permissionGroupId}");
                }

                // Kiểm tra FunctionID hợp lệ
                if (!validFunctionIds.Contains(permission.FunctionID))
                {
                    errors.Add($"Chức năng với ID={permission.FunctionID} không tồn tại");
                }
            }

            // Kiểm tra trùng lặp
            var duplicates = permissions
                .GroupBy(p => p.FunctionID)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicates.Any())
            {
                errors.Add($"Có {duplicates.Count} chức năng bị trùng lặp quyền");
            }

            return errors;
        }

        /// <summary>
        /// Lấy thống kê quyền của một nhóm quyền (MỚI - cho dashboard)
        /// </summary>
        public PermissionStatistics GetPermissionStatistics(int permissionGroupId)
        {
            var permissions = GetByGroupId(permissionGroupId);

            return new PermissionStatistics
            {
                TotalFunctions = permissions.Count,
                ReadableCount = permissions.Count(p => p.CanRead),
                CreatableCount = permissions.Count(p => p.CanCreate),
                UpdatableCount = permissions.Count(p => p.CanUpdate),
                DeletableCount = permissions.Count(p => p.CanDelete),
                FullAccessCount = permissions.Count(p => p.CanRead && p.CanCreate && p.CanUpdate && p.CanDelete),
                NoAccessCount = permissions.Count(p => !p.CanRead && !p.CanCreate && !p.CanUpdate && !p.CanDelete)
            };
        }
    }

    /// <summary>
    /// Class chứa thống kê quyền (MỚI)
    /// </summary>
    public class PermissionStatistics
    {
        public int TotalFunctions { get; set; }
        public int ReadableCount { get; set; }
        public int CreatableCount { get; set; }
        public int UpdatableCount { get; set; }
        public int DeletableCount { get; set; }
        public int FullAccessCount { get; set; }
        public int NoAccessCount { get; set; }
    }
}