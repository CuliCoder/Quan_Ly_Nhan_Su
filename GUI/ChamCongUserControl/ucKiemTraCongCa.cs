using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.ChamCong
{
    public partial class ucKiemTraCongCa : UserControl
    {
        public event EventHandler BackButtonClicked;
        private AttendanceBLL AttendanceBLL = new AttendanceBLL();
        private readonly EmployeeFullBLL employeeBLL = new EmployeeFullBLL();
        private List<AttendanceDTO> attendanceRecords = new List<AttendanceDTO>();
        // Giả định bạn có BLL cho việc lấy dữ liệu Yêu cầu
        // private readonly YeuCauBLL yeuCauBLL = new YeuCauBLL(); 
        private EmployeeFullDTO currentEmployee;

        public ucKiemTraCongCa()
        {
            if (SessionManager.Instance.CurrentEmployee == null)
            {
                return;
            }
            InitializeComponent();
            btnBack.Visible = false;
            LoadEmployeeData(SessionManager.Instance.CurrentEmployee?.MaNhanVien);
        }
        public void checkCongCaByIDNV(string maNhanVien)
        {
            btnBack.Visible = true;
            LoadEmployeeData(maNhanVien);
        }
        public void LoadEmployeeData(string maNhanVien)
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
                attendanceRecords = AttendanceBLL.getAttendanceByEmployeeId(maNhanVien);
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
            LoadEmployeeData(currentEmployee.MaNhanVien);
        }

    }
}