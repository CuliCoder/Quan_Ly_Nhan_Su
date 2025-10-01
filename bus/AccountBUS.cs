using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BUS
{
    public class AccountBUS
    {
        private readonly AccountBLL _accountBLL;

        public AccountBUS()
        {
            _accountBLL = new AccountBLL();
        }

        // Các hàm cũ
        public AccountDTO Login(string username, string password)
        {
            return _accountBLL.Login(username, password);
        }

        public void EnsureDevAccountExists()
        {
            _accountBLL.EnsureDevAccountExists();
        }

        public List<AccountDTO> GetAllAccounts()
        {
            return _accountBLL.GetAllAccounts();
        }

        public bool ThemTaiKhoan(AccountDTO newAccount)
        {
            try
            {
                return _accountBLL.ThemTaiKhoan(newAccount);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc hiển thị thông báo
                Console.WriteLine(ex.Message);
                throw; // Ném lại lỗi để lớp GUI có thể bắt và hiển thị
            }
        }

        public bool SuaTaiKhoan(AccountDTO accountToUpdate)
        {
            try
            {
                return _accountBLL.SuaTaiKhoan(accountToUpdate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public bool XoaTaiKhoan(string maTaiKhoan)
        {
            try
            {
                return _accountBLL.XoaTaiKhoan(maTaiKhoan);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}