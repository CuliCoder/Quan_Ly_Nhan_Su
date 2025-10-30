using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.AuthControl
{
    public partial class Login : Form
    {
        private readonly AccountBLL accountBLL;
        private readonly EmployeeBLL employeeBLL;        
        private readonly PersonalProfileBLL profileBLL;

        public Login()
        {
            InitializeComponent();
            accountBLL = new AccountBLL();
            employeeBLL = new EmployeeBLL();
            profileBLL = new PersonalProfileBLL();   
            // Add event handler for the login button
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đăng nhập
            AccountDTO loggedInAccount = accountBLL.Login(username, password);

            if (loggedInAccount == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.",
                    "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra trạng thái tài khoản
            if (!loggedInAccount.TinhTrang)
            {
                MessageBox.Show("Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ===== THÊM MỚI: LẤY THÔNG TIN NHÂN VIÊN VÀ PROFILE =====
            EmployeeDTO employee = null;
            PersonalProfileDTO profile = null;
            string permissionGroupName = "Chưa xác định";

            try
            {
                // Lấy thông tin nhân viên từ mã tài khoản
                employee = employeeBLL.GetByAccountId(loggedInAccount.MaTaiKhoan);

                // Nếu có nhân viên, lấy thông tin profile
                if (employee != null && !string.IsNullOrEmpty(employee.SoCmnd))
                {
                    profile = profileBLL.GetById(employee.SoCmnd);
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi khi lấy thông tin bổ sung, vẫn cho đăng nhập
                // nhưng ghi log lỗi
                Console.WriteLine($"Lỗi khi lấy thông tin bổ sung: {ex.Message}");
            }

            // ===== LƯU THÔNG TIN VÀO SESSION =====
            SessionManager.Instance.Login(
                loggedInAccount,
                employee,
                profile,
                permissionGroupName
            );

            // Hiển thị thông báo với tên người dùng
            string displayName = profile?.HoTen ?? loggedInAccount.TenDangNhap;
            MessageBox.Show(
                $"Đăng nhập thành công!\nXin chào {displayName}",
                "Thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // BÁO HIỆU ĐĂNG NHẬP THÀNH CÔNG VÀ ĐÓNG FORM
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lblAppName_Click(object sender, EventArgs e)
        {
            // Existing code
        }
    }
}