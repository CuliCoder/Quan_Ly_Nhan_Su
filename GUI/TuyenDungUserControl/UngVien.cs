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
    public partial class UngVien : UserControl
    {
        public UngVien()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormThemUngVien themUngVienForm = new FormThemUngVien();
            themUngVienForm.StartPosition = FormStartPosition.CenterScreen;
            themUngVienForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTuyenUngVien tuyenUngVienForm = new FormTuyenUngVien();
            tuyenUngVienForm.StartPosition = FormStartPosition.CenterScreen;
            tuyenUngVienForm.ShowDialog();
        }
    }
}
