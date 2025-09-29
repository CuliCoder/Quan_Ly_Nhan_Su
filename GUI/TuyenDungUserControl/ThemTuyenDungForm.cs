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
    public partial class ThemTuyenDungForm : Form
    {
        public ThemTuyenDungForm()
        {
            InitializeComponent();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
