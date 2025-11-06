using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.GUI.ChamCong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.ChamCongUserControl
{
    public partial class AttendanceGUI : UserControl
    {
        private AttendanceBLL attendanceBLL = new AttendanceBLL();
        public AttendanceGUI()
        {
            InitializeComponent();
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
                ucChiTietChamCong1.LoadEmployeeData(SessionManager.Instance.CurrentEmployee.MaNhanVien);
            }
            else
            {
                MessageBox.Show("Chấm công thất bại!");
            }
        }
    }
}
