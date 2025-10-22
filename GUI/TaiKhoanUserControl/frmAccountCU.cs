using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.TaiKhoanUserControl
{
    public partial class frmAccountCU : Form
    {
        private readonly AccountBLL accountBLL = new AccountBLL();
        private readonly EmployeeBLL _employeeBLL = new EmployeeBLL(); 
        private readonly PersonalProfileBLL _profileBLL = new PersonalProfileBLL();
        private readonly EmployeeFullBLL employeeFullBLL = new EmployeeFullBLL();
        private readonly PermissionGroupBLL permissionGroupBLL = new PermissionGroupBLL();

        private bool isEditMode = false;
        private AccountDTO accountToEdit;

        public AccountDTO AccountData { get; private set; }
        public string SelectedMaNhanVien { get; private set; }
        public string SelectedHoTen { get; private set; }
        public string SelectedNhomQuyenText { get; private set; }

        public frmAccountCU()
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Thêm Tài Khoản Mới";
            LoadComboBoxData();
        }

        public frmAccountCU(string maTaiKhoan)
        {
            InitializeComponent();
            isEditMode = true;
            this.Text = "Cập Nhật Tài Khoản";

            accountToEdit = accountBLL.GetAccountById(maTaiKhoan);
            if (accountToEdit == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản để chỉnh sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Sử dụng BeginInvoke để đảm bảo form được load xong trước khi đóng
                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            LoadComboBoxData();
            PopulateDataForEdit();
        }

        private void LoadComboBoxData()
        {
            try
            {
                cboNhomQuyen.DataSource = permissionGroupBLL.GetAll();
                cboNhomQuyen.DisplayMember = "TenNhomQuyen";
                cboNhomQuyen.ValueMember = "MaNhomQuyen";

                if (isEditMode)
                {
                    // Yêu cầu: Bạn cần tạo phương thức EmployeeBLL.GetByAccountId()
                    var employee = _employeeBLL.GetByAccountId(accountToEdit.MaTaiKhoan);
                    if (employee != null)
                    {
                        var profile = _profileBLL.GetById(employee.SoCmnd);
                        var displayEmployee = new EmployeeFullDTO { MaNhanVien = employee.MaNhanVien, HoTen = profile.HoTen };
                        cboNhanVien.DataSource = new List<EmployeeFullDTO> { displayEmployee };
                        cboNhanVien.DisplayMember = "HoTen";
                        cboNhanVien.ValueMember = "MaNhanVien";
                    }
                    cboNhanVien.Enabled = false;
                }
                else
                {
                    // Yêu cầu: Bạn cần tạo phương thức EmployeeFullBLL.GetEmployeesWithoutAccount()
                    cboNhanVien.DataSource = employeeFullBLL.GetEmployeesWithoutAccount();
                    cboNhanVien.DisplayMember = "HoTen";
                    cboNhanVien.ValueMember = "MaNhanVien";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu phụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateDataForEdit()
        {
            if (accountToEdit != null)
            {
                txtTenDangNhap.Text = accountToEdit.TenDangNhap;
                //txtMatKhau.PlaceholderText = "Để trống nếu không muốn đổi mật khẩu";
                if (accountToEdit.MaNhomQuyen.HasValue)
                {
                    // === LỖI ĐÃ ĐƯỢC SỬA TẠI ĐÂY ===
                    cboNhomQuyen.SelectedValue = accountToEdit.MaNhomQuyen.Value;
                }
                chkTrangThai.Checked = accountToEdit.TinhTrang;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate input
            if (cboNhanVien.SelectedValue == null && !isEditMode)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isEditMode && string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống khi tạo mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboNhomQuyen.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gán dữ liệu vào property để form chính lấy về
            AccountData = isEditMode ? accountToEdit : new AccountDTO();
            AccountData.TenDangNhap = txtTenDangNhap.Text.Trim();
            SelectedNhomQuyenText = cboNhomQuyen.Text;

            // Chỉ gán mật khẩu nếu người dùng nhập
            if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                AccountData.MatKhau = txtMatKhau.Text;
            }
            else if (isEditMode)
            {
                AccountData.MatKhau = null; // Gửi tín hiệu cho BLL không cập nhật mật khẩu
            }

            AccountData.MaNhomQuyen = (int)cboNhomQuyen.SelectedValue;
            AccountData.TinhTrang = chkTrangThai.Checked;

            if (!isEditMode)
            {
                SelectedHoTen = cboNhanVien.Text;
                SelectedMaNhanVien = cboNhanVien.SelectedValue.ToString();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}