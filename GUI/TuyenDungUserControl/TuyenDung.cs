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
    public partial class TuyenDung : UserControl
    {
        public TuyenDung()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ThemTuyenDungForm ttd = new ThemTuyenDungForm();
            ttd.StartPosition = FormStartPosition.CenterScreen;
            ttd.ShowDialog();
        }
    }
}
