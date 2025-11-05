using Quan_Ly_Nhan_Su.DTO;
using System;

namespace Quan_Ly_Nhan_Su.BLL
{
    /// <summary>
    /// Quản lý thông tin phiên đăng nhập của người dùng hiện tại.
    /// Sử dụng Singleton pattern để đảm bảo chỉ có một instance duy nhất.
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

        /// <summary>
        /// Kiểm tra xem có người dùng đang đăng nhập hay không
        /// </summary>
        public bool IsLoggedIn => _currentAccount != null;

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
        /// Đăng nhập và lưu thông tin người dùng
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
        }

        /// <summary>
        /// Đăng xuất và xóa thông tin người dùng
        /// </summary>
        public void Logout()
        {
            _currentAccount = null;
            _currentEmployee = null;
            _currentProfile = null;
            _permissionGroupName = null;
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

        /// <summary>
        /// Kiểm tra quyền dựa trên mã nhóm quyền
        /// </summary>
        /// <param name="requiredGroupId">Mã nhóm quyền yêu cầu</param>
        /// <returns>True nếu có quyền</returns>
        public bool HasPermission(int requiredGroupId)
        {
            return _currentAccount?.MaNhomQuyen == requiredGroupId;
        }

        /// <summary>
        /// Kiểm tra xem có phải là admin không (giả sử mã nhóm quyền admin là 1)
        /// </summary>
        public bool IsAdmin => _currentAccount?.MaNhomQuyen == 1;
    }
}