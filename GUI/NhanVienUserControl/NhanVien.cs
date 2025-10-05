using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.NhanVienUserControl
{
    public partial class NhanVien : UserControl
    {
        NhanVienNhapLieu nhanVienNhapLieu = new NhanVienNhapLieu();
        public NhanVien()
        {
            InitializeComponent();
            nhanVienNhapLieu.QuayLaiClicked += (s, e) =>
            {
                chuyenMan.Controls.Clear();
                chuyenMan.Controls.Add(danhSachNhanVienPanel);
                danhSachNhanVienPanel.Dock = DockStyle.Fill;
            };
        }

        private void addUserControl(UserControl userControl)
        {
            if (userControl == null) return;

            userControl.Dock = DockStyle.Fill;
            chuyenMan.Controls.Clear();
            chuyenMan.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            addUserControl(nhanVienNhapLieu);
        }
    }
}
