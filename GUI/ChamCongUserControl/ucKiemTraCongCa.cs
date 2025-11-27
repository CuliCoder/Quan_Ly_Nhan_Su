using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.ChamCongUserControl
{
    public partial class ucKiemTraCongCa : UserControl
    {
        public event EventHandler BackButtonClicked;
        private AttendanceBLL AttendanceBLL;
        private readonly EmployeeFullBLL employeeBLL;
        private List<AttendanceDTO> attendanceRecords;
        private EmployeeFullDTO currentEmployee;

        public ucKiemTraCongCa()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode)
                return;
            AttendanceBLL = new AttendanceBLL();
            employeeBLL = new EmployeeFullBLL();
            attendanceRecords = new List<AttendanceDTO>();
            btnBack.Visible = false;
            loadCmb();
            LoadEmployeeData(SessionManager.Instance.CurrentEmployee?.MaNhanVien, (int)cboThang.SelectedValue, (int)cboNam.SelectedValue);
        }
        public void checkCongCaByIDNV(string maNhanVien)
        {
            btnBack.Visible = true;
            LoadEmployeeData(maNhanVien, (int)cboThang.SelectedValue, (int)cboNam.SelectedValue);
        }
        public void LoadEmployeeData(string maNhanVien, int thang, int nam)
        {
            try
            {
                currentEmployee = employeeBLL.GetEmployeeById(maNhanVien);
                if (currentEmployee == null)
                {
                    MessageBox.Show("Nhân viên không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lbInfo.Text = $"Mã NV: {currentEmployee.MaNhanVien} | Họ Tên: {currentEmployee.HoTen} | Email: {currentEmployee.Email}";
                attendanceRecords = AttendanceBLL.filterByTime(maNhanVien, thang, nam);
                dgvCheckCongCa.Rows.Clear();
                if (attendanceRecords == null || attendanceRecords.Count == 0)
                {
                    return;
                }
                foreach (var record in attendanceRecords)
                {
                    dgvCheckCongCa.Rows.Add(
                        record.NgayChamCong.ToString("dd/MM/yyyy"),
                        record.CheckInTime?.ToString("HH:mm") ?? "Chưa chấm",
                        record.CheckOutTime?.ToString("HH:mm") ?? "Chưa chấm",
                        record.Go_late,
                        record.Leave_early,
                        record.Sogiolamviec
                    );
                }
                AttendanceTotalOfMonthDTO totalOfMonth = AttendanceBLL.calculateTotalOfMonth(maNhanVien, DateTime.Now.Month, DateTime.Now.Year);
                dgvCheckCongCa.Rows.Add(
                    "Tổng tháng",
                    "",
                    "",
                    totalOfMonth.GoLate,
                    totalOfMonth.LeaveEarly,
                    totalOfMonth.TotalHours + "/" + AttendanceBLL.TinhTongGioLam(DateTime.Now.Month, DateTime.Now.Year)
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin nhân viên: {ex.Message}");
            }
        }
        private void loadCmb()
        {
            // Load combobox Tháng
            DataTable dtcboThang = new DataTable();
            dtcboThang.Columns.Add("key", typeof(int));
            dtcboThang.Columns.Add("value", typeof(string));
            for (int i = 1; i <= 12; i++)
            {
                dtcboThang.Rows.Add(i, "Tháng " + i);
            }
            cboThang.DataSource = dtcboThang;
            cboThang.DisplayMember = "value";
            cboThang.ValueMember = "key";
            cboThang.SelectedValue = DateTime.Now.Month;
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            // Load combobox Năm
            DataTable dtcboNam = new DataTable();
            dtcboNam.Columns.Add("key", typeof(int));
            dtcboNam.Columns.Add("value", typeof(string));
            for (int i = 2020; i <= DateTime.Now.Year; i++)
            {
                dtcboNam.Rows.Add(i, "Năm " + i);
            }
            cboNam.DataSource = dtcboNam;
            cboNam.DisplayMember = "value";
            cboNam.ValueMember = "key";
            cboNam.SelectedValue = DateTime.Now.Year;
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentEmployee == null)
            {
                return;
            }
            LoadEmployeeData(currentEmployee.MaNhanVien, (int)cboThang.SelectedValue, (int)cboNam.SelectedValue);
        }
        private void CboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentEmployee == null)
            {
                return;
            }
            LoadEmployeeData(currentEmployee.MaNhanVien, (int)cboThang.SelectedValue, (int)cboNam.SelectedValue);
        }
        private List<AttendanceDTO> filterDataByTime(string maNV, int thang, int nam)
        {
            return AttendanceBLL.filterByTime(maNV, thang, nam);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void lblDraftHeader_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadEmployeeData(currentEmployee.MaNhanVien, (int)cboThang.SelectedValue, (int)cboNam.SelectedValue);
        }
        public int getSelectedMonth()
        {
            return (int)cboThang.SelectedValue;
        }
        public int getSelectedYear()
        {
            return (int)cboNam.SelectedValue;
        }
    }
}