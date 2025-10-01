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
        private readonly AccountDAO _accountDAO;

        public AccountBLL()
        {
            _accountDAO = new AccountDAO();
        }

        /// <summary>
        ///     Đăng nhập
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AccountDTO Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            List<AccountDTO> accounts = _accountDAO.Search(username);
            AccountDTO account = accounts.FirstOrDefault(acc => acc.TenDangNhap == username);

            // Cần sửa lại logic Login để dùng BCrypt.Verify
            if (account != null && BCrypt.Net.BCrypt.Verify(password, account.MatKhau))
            {
                return account;
            }

            return null;
        }

        public void EnsureDevAccountExists()
        {
            var accounts = _accountDAO.Search("dev");
            bool devExists = accounts.Any(acc => acc.TenDangNhap == "dev");

            if (!devExists)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword("123");
                var devAccount = new AccountDTO
                {
                    MaTaiKhoan = Guid.NewGuid().ToString(),
                    TenDangNhap = "dev",
                    MatKhau = hashedPassword,
                    MaNhomQuyen = null
                };
                _accountDAO.Create(devAccount);
            }
        }

        /// <summary>
        /// Lấy tất cả tài khoản.
        /// </summary>
        /// <returns>Danh sách các tài khoản.</returns>
        public List<AccountDTO> GetAllAccounts()
        {
            // Gọi Search với chuỗi rỗng để lấy tất cả
            return _accountDAO.Search("");
        }

        /// <summary>
        /// Thêm một tài khoản mới với các quy tắc nghiệp vụ.
        /// </summary>
        /// <param name="newAccount">Thông tin tài khoản mới.</param>
        /// <returns>True nếu thành công, False nếu thất bại.</returns>
        public bool ThemTaiKhoan(AccountDTO newAccount)
        {
            // Validation: Kiểm tra xem tên đăng nhập đã tồn tại chưa
            var existingAccount = _accountDAO.Search(newAccount.TenDangNhap)
                                             .FirstOrDefault(a => a.TenDangNhap == newAccount.TenDangNhap);
            if (existingAccount != null)
            {
                // Tên đăng nhập đã tồn tại
                throw new Exception("Tên đăng nhập đã tồn tại.");
            }

            // Validation: Các trường thông tin không được để trống
            if (string.IsNullOrWhiteSpace(newAccount.TenDangNhap) || string.IsNullOrWhiteSpace(newAccount.MatKhau))
            {
                throw new Exception("Tên đăng nhập và mật khẩu không được để trống.");
            }

            // Băm mật khẩu trước khi lưu
            newAccount.MatKhau = BCrypt.Net.BCrypt.HashPassword(newAccount.MatKhau);

            // Tạo MaTaiKhoan mới
            newAccount.MaTaiKhoan = Guid.NewGuid().ToString();

            return _accountDAO.Create(newAccount);
        }

        /// <summary>
        /// Cập nhật thông tin tài khoản.
        /// </summary>
        /// <param name="accountToUpdate">Tài khoản cần cập nhật.</param>
        /// <returns>True nếu thành công.</returns>
        public bool SuaTaiKhoan(AccountDTO accountToUpdate)
        {
            // Validation: Các trường thông tin không được để trống
            if (string.IsNullOrWhiteSpace(accountToUpdate.TenDangNhap))
            {
                throw new Exception("Tên đăng nhập không được để trống.");
            }

            // Nếu người dùng nhập mật khẩu mới, thì ta băm và cập nhật nó
            if (!string.IsNullOrWhiteSpace(accountToUpdate.MatKhau))
            {
                accountToUpdate.MatKhau = BCrypt.Net.BCrypt.HashPassword(accountToUpdate.MatKhau);
            }
            else
            {
                // Nếu không, ta giữ lại mật khẩu cũ.
                // Lấy lại mật khẩu cũ từ DB để không ghi đè bằng chuỗi rỗng.
                var currentAccount = _accountDAO.Search(accountToUpdate.MaTaiKhoan).FirstOrDefault();
                if (currentAccount != null)
                {
                    accountToUpdate.MatKhau = currentAccount.MatKhau;
                }
            }

            return _accountDAO.Update(accountToUpdate);
        }

        /// <summary>
        /// Xóa một tài khoản.
        /// </summary>
        /// <param name="maTaiKhoan">Mã tài khoản cần xóa.</param>
        /// <returns>True nếu thành công.</returns>
        public bool XoaTaiKhoan(string maTaiKhoan)
        {
            // Validation: Không cho phép xóa tài khoản 'dev'
            var accountToDelete = _accountDAO.Search(maTaiKhoan).FirstOrDefault();
            if (accountToDelete != null && accountToDelete.TenDangNhap == "dev")
            {
                throw new Exception("Không thể xóa tài khoản phát triển (dev).");
            }

            return _accountDAO.Delete(maTaiKhoan);
        }
    }
}