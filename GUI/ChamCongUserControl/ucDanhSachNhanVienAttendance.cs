using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Quan_Ly_Nhan_Su.GUI.ChamCongUserControl
{
    public partial class ucDanhSachNhanVienAttendance : UserControl
    {
        public event Action<string> EmployeeSelected;
        private readonly EmployeeFullBLL employeeBLL;
        public ucDanhSachNhanVienAttendance()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode)
                return;
            employeeBLL = new EmployeeFullBLL();
        }

        private void ucChamCong_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode)
                return;
            LoadEmployees();
            LoadCboSearch();
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dgvNhanVien.AutoGenerateColumns = false;
        }
        private void LoadCboSearch()
        {
            DataTable dtcboSearch = new DataTable();
            dtcboSearch.Columns.Add("key", typeof(int));
            dtcboSearch.Columns.Add("value", typeof(string));
            dtcboSearch.Rows.Add(0, "Tất cả");
            dtcboSearch.Rows.Add(1, "Mã nhân viên");
            dtcboSearch.Rows.Add(2, "Họ tên");
            dtcboSearch.Rows.Add(3, "Email");
            dtcboSearch.Rows.Add(4, "Phòng ban");
            dtcboSearch.Rows.Add(5, "Chức vụ");
            cboSearch.DataSource = dtcboSearch;
            cboSearch.DisplayMember = "value";
            cboSearch.ValueMember = "key";
            cboSearch.SelectedValue = "Tất cả";
            cboSearch.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void LoadEmployees()
        {
            try
            {
                dgvNhanVien.SuspendLayout();
                dgvNhanVien.Rows.Clear();
                List<EmployeeFullDTO> employeeList = employeeBLL.GetAllEmployees();
                foreach (var emp in employeeList)
                {
                    dgvNhanVien.Rows.Add(emp.MaNhanVien, emp.HoTen, emp.Email, emp.PhongBan, emp.ChucVu);
                }
                dgvNhanVien.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow selectedEmployee = dgvNhanVien.Rows[e.RowIndex];
            string id = selectedEmployee.Cells["colMaNV"].Value.ToString();
            if (id == null || id == "")
            {
                MessageBox.Show("Thiếu mã nhân viên");
                return;
            }
            EmployeeSelected?.Invoke(id);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng tìm kiếm đang được phát triển.");
        }
    }
}
