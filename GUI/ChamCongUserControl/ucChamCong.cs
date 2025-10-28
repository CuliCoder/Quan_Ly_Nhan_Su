using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.ChamCong
{
    public partial class ucChamCong : UserControl
    {
        public event Action<string> EmployeeSelected;
        private readonly EmployeeFullBLL employeeBLL = new EmployeeFullBLL();
        private AttendanceBLL attendanceBLL = new AttendanceBLL();
        public ucChamCong()
        {
            InitializeComponent();
        }

        private void ucChamCong_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dgvNhanVien.AutoGenerateColumns = false;
        }

        private void LoadEmployees()
        {
            try
            {
                List<EmployeeFullDTO> employeeList = employeeBLL.GetAllEmployees();
                dgvNhanVien.DataSource = employeeList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNhanVien.Rows[e.RowIndex].DataBoundItem is EmployeeFullDTO selectedEmployee)
            {
                EmployeeSelected?.Invoke(selectedEmployee.MaNhanVien);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng tìm kiếm đang được phát triển.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + attendanceBLL.addAttendance("NV003"));
        }
    }
}
