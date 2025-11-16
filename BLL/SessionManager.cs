using Quan_Ly_Nhan_Su.DTO;
using System;

namespace Quan_Ly_Nhan_Su.BLL
{
    /// <summary>
    /// Quản lý thông tin phiên đăng nhập của người dùng hiện tại.
    /// Phiên bản hợp nhất hỗ trợ cả API cũ và mới với PermissionManager.
    /// </summary>
    public sealed class SessionManager
    {
        private static SessionManager _instance;
        private static readonly object _lock = new object();

        // Thông tin người dùng đang đăng nhập
        private AccountDTO _currentAccount;
        private EmployeeDTO _currentEmployee;
        private PersonalProfileDTO _currentProfile;
        private string _permissionGroupName;

        /// <summary>
        /// Private constructor để ngăn tạo instance từ bên ngoài
        /// </summary>
        private SessionManager() { }

        /// <summary>
        /// Lấy instance duy nhất của SessionManager (Thread-safe)
        /// </summary>
        public static SessionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SessionManager();
                        }
                    }
                }
                return _instance;
            }
        }

        #region Properties - API Cũ (Backward Compatibility)

        /// <summary>
        /// Thông tin tài khoản hiện tại
        /// </summary>
        public AccountDTO CurrentAccount
        {
            get => _currentAccount;
            private set => _currentAccount = value;
        }

        /// <summary>
        /// Thông tin nhân viên hiện tại
        /// </summary>
        public EmployeeDTO CurrentEmployee
        {
            get => _currentEmployee;
            private set => _currentEmployee = value;
        }

        /// <summary>
        /// Thông tin hồ sơ cá nhân hiện tại
        /// </summary>
        public PersonalProfileDTO CurrentProfile
        {
            get => _currentProfile;
            private set => _currentProfile = value;
        }

        /// <summary>
        /// Tên nhóm quyền hiện tại
        /// </summary>
        public string PermissionGroupName
        {
            get => _permissionGroupName;
            private set => _permissionGroupName = value;
        }

        #endregion

        #region Properties - API Mới

        /// <summary>
        /// Kiểm tra xem có người dùng đang đăng nhập hay không
        /// </summary>
        public bool IsLoggedIn => _currentAccount != null;

        /// <summary>
        /// Lấy mã tài khoản của người dùng hiện tại
        /// </summary>
        public string AccountId => _currentAccount?.MaTaiKhoan ?? null;

        /// <summary>
        /// Lấy tên đăng nhập của người dùng hiện tại
        /// </summary>
        public string Username => _currentAccount?.TenDangNhap ?? "Guest";

        /// <summary>
        /// Lấy họ tên của người dùng hiện tại
        /// </summary>
        public string FullName => _currentProfile?.HoTen ?? "Chưa xác định";

        /// <summary>
        /// Lấy mã nhân viên của người dùng hiện tại
        /// </summary>
        public string EmployeeCode => _currentEmployee?.MaNhanVien ?? "N/A";

        /// <summary>
        /// Lấy mã nhóm quyền của người dùng hiện tại
        /// </summary>
        public int? PermissionGroupId => _currentAccount?.MaNhomQuyen;

        /// <summary>
        /// Kiểm tra xem có phải là admin không
        /// </summary>
        public bool IsAdmin => _permissionGroupName?.ToLower().Contains("admin") ??
                               _currentAccount?.MaNhomQuyen == 1;

        #endregion

        #region Login Methods

        /// <summary>
        /// Đăng nhập - API cũ (backward compatibility)
        /// </summary>
        /// <param name="account">Thông tin tài khoản</param>
        /// <param name="employee">Thông tin nhân viên (có thể null)</param>
        /// <param name="profile">Thông tin hồ sơ cá nhân (có thể null)</param>
        /// <param name="permissionGroupName">Tên nhóm quyền (có thể null)</param>
        public void Login(AccountDTO account, EmployeeDTO employee,
                         PersonalProfileDTO profile, string permissionGroupName)
        {
            _currentAccount = account;
            _currentEmployee = employee;
            _currentProfile = profile;
            _permissionGroupName = permissionGroupName ?? "Chưa xác định";

            // Tự động load quyền nếu có PermissionManager
            LoadPermissionsIfAvailable();
        }

        /// <summary>
        /// Đăng nhập - API mới với PermissionManager
        /// </summary>
        /// <param name="account">Thông tin tài khoản</param>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="fullName">Họ tên</param>
        /// <param name="permissionGroupName">Tên nhóm quyền</param>
        public void Login(AccountDTO account, string employeeCode, string fullName,
                         string permissionGroupName)
        {
            _currentAccount = account;
            _permissionGroupName = permissionGroupName;

            // Load thông tin nhân viên và profile
            LoadEmployeeAndProfile(employeeCode, fullName);

            // Load quyền vào PermissionManager
            LoadPermissionsIfAvailable();
        }

        /// <summary>
        /// Helper method: Load thông tin nhân viên và profile
        /// </summary>
        private void LoadEmployeeAndProfile(string employeeCode, string fullName)
        {
            try
            {
                if (!string.IsNullOrEmpty(employeeCode) && employeeCode != "N/A")
                {
                    var employeeBLL = new EmployeeBLL();
                    _currentEmployee = employeeBLL.GetByAccountId(employeeCode);

                    if (_currentEmployee != null && !string.IsNullOrEmpty(_currentEmployee.SoCmnd))
                    {
                        var profileBLL = new PersonalProfileBLL();
                        _currentProfile = profileBLL.GetById(_currentEmployee.SoCmnd);
                    }
                }

                // Nếu không load được profile, tạo một profile tạm với tên
                if (_currentProfile == null && !string.IsNullOrEmpty(fullName))
                {
                    _currentProfile = new PersonalProfileDTO { HoTen = fullName };
                }
            }
            catch (Exception ex)
            {
                // Log error nếu cần
                Console.WriteLine($"Error loading employee/profile: {ex.Message}");
            }
        }

        /// <summary>
        /// Helper method: Load quyền nếu PermissionManager tồn tại
        /// </summary>
        private void LoadPermissionsIfAvailable()
        {
            try
            {
                if (_currentAccount?.MaNhomQuyen.HasValue == true)
                {
                    // Kiểm tra xem PermissionManager có tồn tại không
                    var permissionManager = PermissionManager.Instance;
                    permissionManager?.LoadUserPermissions(_currentAccount.MaNhomQuyen.Value);
                }
            }
            catch (Exception ex)
            {
                // Nếu PermissionManager chưa được implement, bỏ qua
                Console.WriteLine($"PermissionManager not available: {ex.Message}");
            }
        }

        #endregion

        #region Logout & Update Methods

        /// <summary>
        /// Đăng xuất và xóa thông tin người dùng
        /// </summary>
        public void Logout()
        {
            _currentAccount = null;
            _currentEmployee = null;
            _currentProfile = null;
            _permissionGroupName = null;

            // Xóa cache quyền nếu có PermissionManager
            try
            {
                PermissionManager.Instance?.ClearPermissions();
            }
            catch
            {
                // PermissionManager chưa có, bỏ qua
            }
        }

        /// <summary>
        /// Cập nhật thông tin profile (khi user cập nhật thông tin cá nhân)
        /// </summary>
        public void UpdateProfile(PersonalProfileDTO profile)
        {
            _currentProfile = profile;
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        public void UpdateEmployee(EmployeeDTO employee)
        {
            _currentEmployee = employee;
        }

        #endregion

        #region Permission Methods

        /// <summary>
        /// Kiểm tra quyền dựa trên mã nhóm quyền - API cũ
        /// </summary>
        /// <param name="requiredGroupId">Mã nhóm quyền yêu cầu</param>
        /// <returns>True nếu có quyền</returns>
        public bool HasPermission(int requiredGroupId)
        {
            return _currentAccount?.MaNhomQuyen == requiredGroupId;
        }

        /// <summary>
        /// Kiểm tra quyền đọc theo tên chức năng - API mới
        /// </summary>
        public bool CanRead(string functionName)
        {
            if (IsAdmin) return true;

            try
            {
                return PermissionManager.Instance?.CanRead(functionName) ?? false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra quyền tạo theo tên chức năng - API mới
        /// </summary>
        public bool CanCreate(string functionName)
        {
            if (IsAdmin) return true;

            try
            {
                return PermissionManager.Instance?.CanCreate(functionName) ?? false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra quyền cập nhật theo tên chức năng - API mới
        /// </summary>
        public bool CanUpdate(string functionName)
        {
            if (IsAdmin) return true;

            try
            {
                return PermissionManager.Instance?.CanUpdate(functionName) ?? false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra quyền xóa theo tên chức năng - API mới
        /// </summary>
        public bool CanDelete(string functionName)
        {
            if (IsAdmin) return true;

            try
            {
                return PermissionManager.Instance?.CanDelete(functionName) ?? false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra có ít nhất một quyền trên chức năng - API mới
        /// </summary>
        public bool HasAnyPermission(string functionName)
        {
            if (IsAdmin) return true;

            try
            {
                return PermissionManager.Instance?.HasAnyPermission(functionName) ?? false;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}