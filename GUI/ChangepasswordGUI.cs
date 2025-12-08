using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class ChangepasswordGUI : UserControl
    {
        private readonly AccountBLL accountBLL;

        public ChangepasswordGUI()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode)
                return;
            accountBLL = new AccountBLL();
            // Gán sự kiện
            this.Load += ChangepasswordGUI_Load;
            // Thêm sự kiện Resize cho UserControl
            this.Resize += new System.EventHandler(this.ChangepasswordGUI_Resize);

            this.btnSave.Click += BtnSave_Click;
            this.btnShowOld.Click += (s, e) => TogglePassword(txtOldPassword, btnShowOld);
            this.btnShowNew.Click += (s, e) => TogglePassword(txtNewPassword, btnShowNew);
            this.btnShowConfirm.Click += (s, e) => TogglePassword(txtConfirmPassword, btnShowConfirm);

            // Cải thiện giao diện
            ImproveDesign();
        }

        private void ChangepasswordGUI_Load(object sender, EventArgs e)
        {
            // Căn giữa panel khi load
            CenterPanel();

            // Kiểm tra đăng nhập
            if (!SessionManager.Instance.IsLoggedIn)
            {
                MessageBox.Show(
                    "Vui lòng đăng nhập để sử dụng chức năng này!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                btnSave.Enabled = false;
                return;
            }

            // Load thông tin người dùng
            LoadUserInfo();
        }

        #region UI Centering

        // Sự kiện xảy ra khi UserControl thay đổi kích thước (ví dụ: khi form chính resize)
        private void ChangepasswordGUI_Resize(object sender, EventArgs e)
        {
            CenterPanel();
        }

        // Hàm tính toán và set vị trí cho panelContainer
        private void CenterPanel()
        {
            // panelContainer là panel "card" trắng
            // this.Width/Height là kích thước của UserControl (đã được fill đầy panel6)
            int newX = (this.Width - this.panelContainer.Width) / 2;
            int newY = (this.Height - this.panelContainer.Height) / 2;

            // Đảm bảo panel không bị đẩy ra ngoài nếu form quá nhỏ
            this.panelContainer.Location = new Point(Math.Max(20, newX), Math.Max(20, newY));
        }

        #endregion

        private void LoadUserInfo()
        {
            try
            {
                // Hiển thị thông tin từ Session
                txtUsername.Text = SessionManager.Instance.Username;

                // Cập nhật title (Canh giữa đã được set trong Designer)
                lblTitle.Text = $"🔐 Thay Đổi Mật Khẩu";

                // Disable textbox username (không cho sửa)
                txtUsername.ReadOnly = true;
                txtUsername.BackColor = Color.LightGray;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải thông tin: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                string username = txtUsername.Text.Trim();
                string oldPassword = txtOldPassword.Text.Trim();
                string newPassword = txtNewPassword.Text.Trim();
                string confirmPassword = txtConfirmPassword.Text.Trim();

                // VALIDATION 1: Kiểm tra trống
                if (string.IsNullOrEmpty(oldPassword))
                {
                    MessageBox.Show(
                        "Vui lòng nhập mật khẩu hiện tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtOldPassword.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(newPassword))
                {
                    MessageBox.Show(
                        "Vui lòng nhập mật khẩu mới!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtNewPassword.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show(
                        "Vui lòng xác nhận mật khẩu mới!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtConfirmPassword.Focus();
                    return;
                }

                // VALIDATION 2: Độ dài tối thiểu
                if (newPassword.Length < 6)
                {
                    MessageBox.Show(
                        "Mật khẩu mới phải có ít nhất 6 ký tự!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    txtNewPassword.Focus();
                    txtNewPassword.SelectAll();
                    return;
                }

                // VALIDATION 3: Độ phức tạp (tùy chọn)
                if (!ValidatePasswordStrength(newPassword))
                {
                    DialogResult result = MessageBox.Show(
                        "Mật khẩu nên chứa:\n" +
                        "- Ít nhất 1 chữ hoa\n" +
                        "- Ít nhất 1 số\n" +
                        "- Ít nhất 1 ký tự đặc biệt (!@#$%^&*)\n\n" +
                        "Bạn có muốn tiếp tục với mật khẩu này?",
                        "Cảnh báo bảo mật",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No)
                    {
                        txtNewPassword.Focus();
                        txtNewPassword.SelectAll();
                        return;
                    }
                }

                // VALIDATION 4: Khớp mật khẩu
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show(
                        "Mật khẩu xác nhận không khớp!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    txtConfirmPassword.Focus();
                    txtConfirmPassword.SelectAll();
                    return;
                }

                // VALIDATION 5: Không được giống mật khẩu cũ
                if (oldPassword == newPassword)
                {
                    MessageBox.Show(
                        "Mật khẩu mới phải khác mật khẩu hiện tại!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    txtNewPassword.Focus();
                    txtNewPassword.SelectAll();
                    return;
                }

                // VALIDATION 6: Xác thực mật khẩu hiện tại
                AccountDTO currentAccount = accountBLL.Login(username, oldPassword);

                if (currentAccount == null)
                {
                    MessageBox.Show(
                        "Mật khẩu hiện tại không chính xác!",
                        "Lỗi xác thực",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    txtOldPassword.Focus();
                    txtOldPassword.SelectAll();
                    return;
                }

                // XÁC NHẬN THAY ĐỔI
                DialogResult confirmResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn đổi mật khẩu?\n\n" +
                    "Sau khi đổi, bạn sẽ cần sử dụng mật khẩu mới để đăng nhập.",
                    "Xác nhận đổi mật khẩu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.No)
                    return;

                // CẬP NHẬT MẬT KHẨU
                currentAccount.MatKhau = newPassword; // AccountBLL.Update sẽ tự động hash
                bool success = accountBLL.Update(currentAccount);

                if (success)
                {
                    MessageBox.Show(
                        "✓ Đổi mật khẩu thành công!\n\n" +
                        "Mật khẩu mới của bạn đã được lưu an toàn.\n" +
                        "Vui lòng sử dụng mật khẩu mới cho lần đăng nhập tiếp theo.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Clear form
                    ClearFields();
                }
                else
                {
                    MessageBox.Show(
                        "Đổi mật khẩu thất bại!\n\n" +
                        "Vui lòng thử lại hoặc liên hệ quản trị viên.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã xảy ra lỗi không mong muốn:\n{ex.Message}\n\n" +
                    "Vui lòng thử lại hoặc liên hệ bộ phận kỹ thuật.",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidatePasswordStrength(string password)
        {
            // Kiểm tra độ mạnh của mật khẩu
            bool hasUpper = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(ch => "!@#$%^&*()_+-=[]{}|;:,.<>?".Contains(ch));

            return hasUpper && hasDigit && hasSpecial;
        }

        private void TogglePassword(TextBox textBox, Button button)
        {
            if (textBox.PasswordChar == '•')
            {
                // Hiện mật khẩu
                textBox.PasswordChar = '\0';
                button.Text = "🙈";
                button.BackColor = Color.FromArgb(220, 220, 220);
            }
            else
            {
                // Ẩn mật khẩu
                textBox.PasswordChar = '•';
                button.Text = "👁";
                button.BackColor = Color.White;
            }
        }

        private void ClearFields()
        {
            txtOldPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            txtOldPassword.Focus();
        }

        private void ImproveDesign()
        {
            // Set màu nền chính và màu card
            this.BackColor = Color.WhiteSmoke;
            panelContainer.BackColor = Color.White;

            // Cải thiện title
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(93, 194, 167);

            // Cải thiện labels
            Font labelFont = new Font("Segoe UI", 11F, FontStyle.Bold);
            Color labelColor = Color.FromArgb(52, 73, 94);

            lblUsername.Font = labelFont;
            lblUsername.ForeColor = labelColor;
            lblOldPassword.Font = labelFont;
            lblOldPassword.ForeColor = labelColor;
            lblNewPassword.Font = labelFont;
            lblNewPassword.ForeColor = labelColor;
            lblConfirmPassword.Font = labelFont;
            lblConfirmPassword.ForeColor = labelColor;

            // Cải thiện textboxes
            Font textBoxFont = new Font("Segoe UI", 11F);
            TextBox[] textBoxes = { txtUsername, txtOldPassword, txtNewPassword, txtConfirmPassword };

            foreach (var txt in textBoxes)
            {
                txt.Font = textBoxFont;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Height = 32;
            }

            // Tinh chỉnh txtUsername
            txtUsername.BackColor = Color.FromArgb(236, 240, 241); // Màu xám nhạt hơn
            txtUsername.ForeColor = Color.FromArgb(44, 62, 80);

            // Cải thiện nút lưu
            btnSave.BackColor = Color.FromArgb(93, 194, 167);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Height = 50;

            // Hover effect cho nút lưu
            btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(72, 174, 147);
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = Color.FromArgb(93, 194, 167);

            // Cải thiện các nút show/hide password
            Button[] showButtons = { btnShowOld, btnShowNew, btnShowConfirm };

            foreach (var btn in showButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.LightGray;
                btn.BackColor = Color.White;
                btn.Cursor = Cursors.Hand;
                btn.Font = new Font("Segoe UI", 10F);
                btn.Height = 32; // Khớp với textbox
            }

            // Thêm tooltips
            AddTooltips();
        }

        private void AddTooltips()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;

            toolTip.SetToolTip(txtOldPassword, "Nhập mật khẩu hiện tại của bạn");
            toolTip.SetToolTip(txtNewPassword, "Mật khẩu mới (tối thiểu 6 ký tự)");
            toolTip.SetToolTip(txtConfirmPassword, "Nhập lại mật khẩu mới để xác nhận");
            toolTip.SetToolTip(btnShowOld, "Click để hiện/ẩn mật khẩu");
            toolTip.SetToolTip(btnShowNew, "Click để hiện/ẩn mật khẩu");
            toolTip.SetToolTip(btnShowConfirm, "Click để hiện/ẩn mật khẩu");
            toolTip.SetToolTip(btnSave, "Lưu mật khẩu mới");
        }

        // Dọn dẹp các sự kiện rỗng
        private void lblPasswordHint_Click(object sender, EventArgs e) { }
        private void txtOldPassword_TextChanged(object sender, EventArgs e) { }

        private void ChangepasswordGUI_Load_1(object sender, EventArgs e)
        {

        }
    }
}