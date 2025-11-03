using System;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class ChangepasswordGUI : UserControl
    {
        public ChangepasswordGUI()
        {
            InitializeComponent();
            // Gán sự kiện toggle mật khẩu
            this.btnShowOld.Click += (s, e) => TogglePassword(txtOldPassword, btnShowOld);
            this.btnShowNew.Click += (s, e) => TogglePassword(txtNewPassword, btnShowNew);
            this.btnShowConfirm.Click += (s, e) => TogglePassword(txtConfirmPassword, btnShowConfirm);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string oldPass = txtOldPassword.Text.Trim();
                string newPass = txtNewPassword.Text.Trim();
                string confirm = txtConfirmPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirm))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newPass.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!newPass.Any(char.IsUpper) || !newPass.Any(char.IsDigit) || !newPass.Any(ch => "!@#$%^&*()".Contains(ch)))
                {
                    MessageBox.Show("Mật khẩu phải chứa ít nhất 1 chữ hoa, 1 số và 1 ký tự đặc biệt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (newPass != confirm)
                {
                    MessageBox.Show("Xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!ValidateOldPassword(username, oldPass))
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateOldPassword(string username, string oldPass)
        {
            return username == "admin" && oldPass == "123456"; // Thay bằng logic thực tế
        }

        private void TogglePassword(TextBox txt, Button btn)
        {
            bool isVisible = txt.PasswordChar == '\0';
            txt.PasswordChar = isVisible ? '•' : '\0';
            btn.Text = isVisible ? "👁" : "👁‍🗨";
        }

        private void ClearFields()
        {
            txtOldPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblOldPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblConfirmPassword_Click(object sender, EventArgs e)
        {

        }
    }
}