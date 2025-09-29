using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl
{
    public partial class TuyenDungMain : UserControl
    {
        public TuyenDungMain()
        {
            InitializeComponent();
            UngVien uv = new UngVien();
            addUserControl(uv, ungVienChecked);
        }
        private void clearColorChecked()
        {
            tuyenDungChecked.BackColor = SystemColors.ControlLightLight;
            ungVienChecked.BackColor = SystemColors.ControlLightLight;
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
            
            UngVien uv = new UngVien();
            addUserControl(uv, ungVienChecked);
        }


        private void label1_Click(object sender, EventArgs e)
        {
            TuyenDung tdc = new TuyenDung();
            addUserControl(tdc, tuyenDungChecked);
        }
    }
}
