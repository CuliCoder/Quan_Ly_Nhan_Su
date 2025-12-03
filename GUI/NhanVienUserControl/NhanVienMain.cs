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
    public partial class NhanVienMain : UserControl
    {
        public NhanVienMain()
        {
            InitializeComponent();
            NhanVien nv = new NhanVien();
            addUserControl(nv, nhanVienChecked);
        }
        private void clearColorChecked()
        {
            chucVuChecked.BackColor = SystemColors.ControlLightLight;
            nhanVienChecked.BackColor = SystemColors.ControlLightLight;
        }
        private void addUserControl(UserControl userControl, Panel colorChecked)
        {
            clearColorChecked();
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Margin = new Padding(0);
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
            colorChecked.BackColor = SystemColors.ActiveCaption;
        }



        private void label2_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            addUserControl(nv, nhanVienChecked);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ChucVu chucVu = new ChucVu();
            addUserControl(chucVu, chucVuChecked);
        }
    }
}
