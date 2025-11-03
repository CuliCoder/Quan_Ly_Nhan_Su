using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using BCrypt.Net;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class AccountBLL
    {
        private readonly AccountDAO _accountDAO = new AccountDAO();
        // Giả định bạn đã có các BLL này và chúng hoạt động đúng
        private readonly EmployeeBLL _employeeBLL = new EmployeeBLL();
        private readonly PersonalProfileBLL _profileBLL = new PersonalProfileBLL();
        private readonly PermissionGroupBLL _permissionGroupBLL = new PermissionGroupBLL();

        /// <summary>
        /// Lấy danh sách ViewModel để hiển thị trên giao diện.
        /// </summary>
        public List<AccountViewModel> GetAccountViewModels()
        {
            // 1. Lấy dữ liệu thô từ các nguồn
            var allAccounts = _accountDAO.GetAll(); // Yêu cầu: AccountDAO.GetAll()
            var allEmployees = _employeeBLL.GetAll(); // Yêu cầu: EmployeeBLL.GetAllEmployees()
            var allProfiles = _profileBLL.GetAll();
            var allGroups = _permissionGroupBLL.GetAll();

            // 2. Tối ưu hóa việc tra cứu bằng Dictionary
            var employeeDict = allEmployees.Where(e => !string.IsNullOrEmpty(e.MaTaiKhoan))
                                           .ToDictionary(e => e.MaTaiKhoan);
            var profileDict = allProfiles.ToDictionary(p => p.SoCmnd);
            var groupDict = allGroups.ToDictionary(g => g.MaNhomQuyen);

            var viewModelList = new List<AccountViewModel>();

            foreach (var account in allAccounts)
            {
                var viewModel = new AccountViewModel
                {
                    MaTaiKhoan = account.MaTaiKhoan,
                    TenDangNhap = account.TenDangNhap,
                    TinhTrang = account.TinhTrang,
                    HoTen = "Chưa liên kết NV",
                    MaNhanVien = "N/A",
                    TenNhomQuyen = "Chưa gán quyền"
                };

                // 3. Ghép nối thông tin Nhân viên và Hồ sơ
                if (employeeDict.TryGetValue(account.MaTaiKhoan, out var employee))
                {
                    viewModel.MaNhanVien = employee.MaNhanVien;
                    if (profileDict.TryGetValue(employee.SoCmnd, out var profile))
                    {
                        viewModel.HoTen = profile.HoTen;
                    }
                }

                // 4. Ghép nối thông tin Nhóm quyền
                if (account.MaNhomQuyen.HasValue && groupDict.TryGetValue(account.MaNhomQuyen.Value, out var group))
                {
                    viewModel.TenNhomQuyen = group.TenNhomQuyen;
                }

                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }

        /// <summary>
        ///     Đăng nhập
        /// </summary>
        public AccountDTO Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            List<AccountDTO> accounts = _accountDAO.Search(username);
            AccountDTO account = accounts.FirstOrDefault(acc => acc.TenDangNhap == username);

            if (account == null)
                return null;

            // First try: normal bcrypt verify
            try
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.MatKhau))
                {
                    return account;
                }
            }
            catch (Exception)
            {
                // Verify can throw for non-bcrypt stored values (invalid salt/version)
                // Fall through to legacy/plaintext handling below
            }

            // Fallback: stored value may be plaintext (legacy). Compare directly.
            // If it matches, re-hash the password and update the DB so subsequent logins use bcrypt.
            try
            {
                if (account.MatKhau == password)
                {
                    // Re-hash and persist
                    account.MatKhau = BCrypt.Net.BCrypt.HashPassword(password);
                    // Update will keep other fields; AccountDAO.Update expects MaTaiKhoan present
                    _accountDAO.Update(account);
                    return account;
                }
            }
            catch (Exception ex)
            {
                // Log and return null (do not expose details to UI)
                Console.WriteLine($"Error during plaintext fallback login: {ex.Message}");
            }

            return null;
        }

        public AccountDTO GetAccountById(string maTaiKhoan)
        {
            return _accountDAO.GetById(maTaiKhoan); // Yêu cầu: AccountDAO.GetById()
        }

        public bool Insert(AccountDTO newAccount, string maNhanVien)
        {
            if (string.IsNullOrWhiteSpace(newAccount.TenDangNhap) || string.IsNullOrWhiteSpace(newAccount.MatKhau))
                throw new ArgumentException("Tên đăng nhập và mật khẩu không được trống.");

            if (_accountDAO.GetByUsername(newAccount.TenDangNhap) != null) // Yêu cầu: AccountDAO.GetByUsername()
                throw new InvalidOperationException("Tên đăng nhập đã tồn tại.");

            newAccount.MaTaiKhoan = Guid.NewGuid().ToString();
            newAccount.MatKhau = BCrypt.Net.BCrypt.HashPassword(newAccount.MatKhau);

            // Yêu cầu: AccountDAO.InsertForEmployee() thực hiện INSERT và UPDATE trong một transaction.
            return _accountDAO.InsertForEmployee(newAccount, maNhanVien);
        }

        public bool Update(AccountDTO accountToUpdate)
        {
            var existingAccount = _accountDAO.GetById(accountToUpdate.MaTaiKhoan);
            if (existingAccount == null)
                throw new KeyNotFoundException("Không tìm thấy tài khoản để cập nhật.");

            if (!string.IsNullOrWhiteSpace(accountToUpdate.MatKhau))
            {
                accountToUpdate.MatKhau = BCrypt.Net.BCrypt.HashPassword(accountToUpdate.MatKhau);
            }
            else
            {
                accountToUpdate.MatKhau = existingAccount.MatKhau; // Giữ lại mật khẩu cũ nếu không nhập mới
            }

            return _accountDAO.Update(accountToUpdate); // Yêu cầu: AccountDAO.Update()
        }

        public bool ToggleStatus(string maTaiKhoan)
        {
            var account = _accountDAO.GetById(maTaiKhoan);
            if (account == null)
                throw new KeyNotFoundException("Không tìm thấy tài khoản.");

            bool newStatus = !account.TinhTrang;
            // Yêu cầu: AccountDAO.UpdateStatus()
            return _accountDAO.UpdateStatus(maTaiKhoan, newStatus);
        }
    }
}