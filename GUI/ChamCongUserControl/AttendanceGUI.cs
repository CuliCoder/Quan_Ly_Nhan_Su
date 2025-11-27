using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.Constants;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.ChamCongUserControl
{
    public partial class AttendanceGUI : UserControl
    {
        private AttendanceBLL attendanceBLL;
        public AttendanceGUI()
        {
            InitializeComponent();
            attendanceBLL = new AttendanceBLL();
            // Runtime: ẩn/hiện tab theo quyền
            bool canRead = SessionManager.Instance != null && SessionManager.Instance.CanRead(FunctionNames.CHAM_CONG);
            if (canRead)
            {
                if (!this.tabControl1.Controls.Contains(this.tabctDanhSachNhanVien))
                    this.tabControl1.Controls.Add(this.tabctDanhSachNhanVien);
            }
            else
            {
                if (this.tabControl1.Controls.Contains(this.tabctDanhSachNhanVien))
                    this.tabControl1.Controls.Remove(this.tabctDanhSachNhanVien);
            }
            addEventPanel();
        }
        public ucDanhSachNhanVienAttendance getDanhSachNhanVienGUI()
        {
            return ucChamCong1;
        }
        public void backDanhSachNhanVien()
        {
            tabControl1.SelectedTab = tabctDanhSachNhanVien;
        }
        private void addEventPanel()
        {
            pnlbAttendance.Click += new EventHandler(addAttendannce);
            foreach (Control control in pnlbAttendance.Controls)
            {
                control.Click += new EventHandler(addAttendannce);
            }
        }
        private void addAttendannce(object sender, EventArgs e)
        {
            if (attendanceBLL.addAttendance(SessionManager.Instance.CurrentEmployee.MaNhanVien))
            {
                MessageBox.Show("Chấm công thành công!");
                ucChiTietChamCong1.LoadEmployeeData(SessionManager.Instance.CurrentEmployee.MaNhanVien, ucChiTietChamCong1.getSelectedMonth(), ucChiTietChamCong1.getSelectedYear());
            }
            else
            {
                MessageBox.Show("Chấm công thất bại!");
            }
        }
    }
}
