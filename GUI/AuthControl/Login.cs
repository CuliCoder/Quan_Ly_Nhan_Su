using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.BUS;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.AuthControl
{
    public partial class Login : Form
    {
        private readonly AccountBUS _accountBUS;

        public Login()
        {
            InitializeComponent();
            _accountBUS = new AccountBUS();
            // Add event handler for the login button
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AccountDTO loggedInAccount = _accountBUS.Login(username, password);

            if (loggedInAccount != null)
            {
                MessageBox.Show($"Đăng nhập thành công! Chào mừng {loggedInAccount.TenDangNhap}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // BÁO HIỆU ĐĂNG NHẬP THÀNH CÔNG VÀ ĐÓNG FORM
                this.DialogResult = DialogResult.OK; // <-- Dòng quan trọng nhất
                this.Close(); // Đóng form Login
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblAppName_Click(object sender, EventArgs e)
        {
            // Existing code
        }
    }
}