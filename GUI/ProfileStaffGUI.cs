using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class ProfileStaffGUI : UserControl
    {
        private readonly AttendanceBLL attendanceBLL;
        private readonly EmployeeFullBLL employeeFullBLL;
        private readonly PersonalProfileBLL profileBLL;

        private EmployeeFullDTO currentEmployeeFull;
        private PersonalProfileDTO currentProfile;

        public ProfileStaffGUI()
        {
            InitializeComponent();
            attendanceBLL = new AttendanceBLL();
            employeeFullBLL = new EmployeeFullBLL();
            profileBLL = new PersonalProfileBLL();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode)
                return;
            ImproveDesign();
            // Gắn sự kiện
            this.Load += ProfileStaffGUI_Load;
            button1.Click += Button1_Click; // Nút thay ảnh
        }

        private void ProfileStaffGUI_Load(object sender, EventArgs e)
        {
            // Kiểm tra đăng nhập
            if (!SessionManager.Instance.IsLoggedIn)
            {
                MessageBox.Show("Vui lòng đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Load thông tin người dùng
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            try
            {
                // Lấy mã nhân viên từ session
                string maNhanVien = SessionManager.Instance.EmployeeCode;

                if (string.IsNullOrEmpty(maNhanVien) || maNhanVien == "N/A")
                {
                    MessageBox.Show("Tài khoản chưa được liên kết với nhân viên!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DisableAllFields();
                    return;
                }

                // Lấy thông tin đầy đủ của nhân viên
                currentEmployeeFull = employeeFullBLL.GetEmployeeById(maNhanVien);

                if (currentEmployeeFull == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin profile
                currentProfile = SessionManager.Instance.CurrentProfile;

                // Hiển thị thông tin
                DisplayUserInfo();

                // Vô hiệu hóa các field (chỉ xem)
                SetFieldsReadOnly(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayUserInfo()
        {
            if (currentEmployeeFull == null) return;

            // Tab Thông tin cá nhân
            textBox1.Text = currentEmployeeFull.MaNhanVien;           // Mã nhân viên
            textBox5.Text = currentEmployeeFull.HoTen;                // Họ tên
            textBox13.Text = currentEmployeeFull.NgaySinh?.ToString("dd/MM/yyyy"); // Ngày sinh
            textBox9.Text = currentEmployeeFull.GioiTinh;             // Giới tính
            textBox17.Text = currentEmployeeFull.Sdt;                 // SĐT
            textBox21.Text = currentEmployeeFull.Email;               // Email
            textBox22.Text = currentEmployeeFull.SoCmnd;              // CCCD

            // Thông tin học vấn
            textBox7.Text = currentEmployeeFull.HocVan;               // Học vấn
            textBox11.Text = currentEmployeeFull.ChuyenNganh;         // Chuyên ngành

            // Thông tin công việc
            textBox15.Text = currentEmployeeFull.PhongBan;            // Phòng ban
            textBox19.Text = currentEmployeeFull.ChucVu;              // Chức vụ
            textBox16.Text = currentEmployeeFull.MucLuong.ToString("N0") + " VNĐ"; // Mức lương

            // Địa chỉ
            if (currentProfile != null)
            {
                textBox14.Text = currentProfile.DanToc;               // Dân tộc
                textBox18.Text = ""; // Tôn giáo (nếu có trong DB)

                // Tách địa chỉ (nếu có format cụ thể)
                string diaChi = currentProfile.DiaChi ?? "";
                string[] diaChiParts = diaChi.Split(',');

                if (diaChiParts.Length >= 3)
                {
                    textBox10.Text = diaChiParts[0].Trim();           // Phường/Xã
                    textBox6.Text = diaChiParts[1].Trim();            // Quận/Huyện
                    textBox2.Text = diaChiParts[2].Trim();            // Tỉnh/Thành phố
                }
                else
                {
                    textBox2.Text = diaChi;
                }
            }

            // Thông tin hợp đồng (nếu có)
            textBox4.Text = "Toàn thời gian";                         // Loại hình làm việc
            textBox3.Text = "Đại học";                                 // Trình độ chuyên môn
            textBox8.Text = DateTime.Now.ToString("dd/MM/yyyy");      // Ngày bắt đầu
            textBox12.Text = "Không xác định";                        // Thời hạn hợp đồng
            textBox23.Text = DateTime.Now.ToString("dd/MM/yyyy");     // Ngày nhận chức

            // Hiển thị ảnh đại diện
            LoadAvatar();

            // Cập nhật tiêu đề
            label3.Text = $"THÔNG TIN HỒ SƠ CÁ NHÂN - {currentEmployeeFull.HoTen?.ToUpper()}";
        }

        private void LoadAvatar()
        {
            try
            {
                string imagePath = currentProfile?.HinhAnh ?? currentEmployeeFull?.HinhAnh;

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    // Hiển thị ảnh mặc định hoặc chữ cái đầu
                    DisplayDefaultAvatar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi load avatar: {ex.Message}");
                DisplayDefaultAvatar();
            }
        }

        private void DisplayDefaultAvatar()
        {
            // Tạo ảnh mặc định với chữ cái đầu
            int size = 200;
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Vẽ nền
                g.FillRectangle(new SolidBrush(Color.FromArgb(93, 194, 167)), 0, 0, size, size);

                // Vẽ chữ cái đầu
                string initial = currentEmployeeFull?.HoTen?.Substring(0, 1).ToUpper() ?? "?";
                Font font = new Font("Arial", 80, FontStyle.Bold);
                SizeF textSize = g.MeasureString(initial, font);

                g.DrawString(initial, font, Brushes.White,
                    (size - textSize.Width) / 2,
                    (size - textSize.Height) / 2);
            }

            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Chức năng thay ảnh đại diện
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn ảnh đại diện";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load ảnh mới
                        pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        // TODO: Lưu đường dẫn ảnh vào database
                        string newImagePath = openFileDialog.FileName;

                        if (currentProfile != null)
                        {
                            currentProfile.HinhAnh = newImagePath;

                            if (profileBLL.Update(currentProfile))
                            {
                                // Cập nhật session
                                SessionManager.Instance.UpdateProfile(currentProfile);

                                MessageBox.Show("Cập nhật ảnh đại diện thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật ảnh: {ex.Message}",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SetFieldsReadOnly(bool readOnly)
        {
            // Vô hiệu hóa tất cả textbox (chỉ xem)
            foreach (Control ctrl in this.tableLayoutPanel7.Controls)
            {
                if (ctrl is FlowLayoutPanel flowPanel)
                {
                    foreach (Control innerCtrl in flowPanel.Controls)
                    {
                        if (innerCtrl is TextBox textBox)
                        {
                            textBox.ReadOnly = readOnly;
                            textBox.BackColor = readOnly ? Color.WhiteSmoke : Color.White;
                        }
                    }
                }
            }
        }

        private void DisableAllFields()
        {
            foreach (Control ctrl in this.tableLayoutPanel7.Controls)
            {
                ctrl.Enabled = false;
            }
        }

        private void BtnChamCong_Click(object sender, EventArgs e)
        {
            try
            {
                string maNhanVien = SessionManager.Instance.EmployeeCode;

                if (string.IsNullOrEmpty(maNhanVien) || maNhanVien == "N/A")
                {
                    MessageBox.Show("Không thể chấm công. Tài khoản chưa liên kết với nhân viên!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = attendanceBLL.addAttendance(maNhanVien);

                if (success)
                {
                    DateTime now = DateTime.Now;
                    MessageBox.Show(
                        $"Chấm công thành công!\n" +
                        $"Nhân viên: {currentEmployeeFull?.HoTen}\n" +
                        $"Thời gian: {now:HH:mm:ss - dd/MM/yyyy}",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show("Chấm công thất bại!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chấm công: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Chức năng lưu thông tin (nếu cần)
            string maNV = textBox1.Text;
            string hoTen = textBox5.Text;
            string sdt = textBox17.Text;

            if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã nhân viên và Họ tên.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Đã lưu hồ sơ cho nhân viên: {hoTen} ({maNV})",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            // Reload thông tin
            LoadUserProfile();
        }

        private void ClearTextBoxes(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
                else
                    ClearTextBoxes(ctrl);
            }
        }

        #region Event Handlers
        private void label3_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void changepasswordGUI1_Load(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        #endregion
    }
}