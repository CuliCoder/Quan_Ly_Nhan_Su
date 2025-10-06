using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
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
        private static readonly RecruitmentBatchBLL  bus = new RecruitmentBatchBLL();
        private static List<RecruitmentBatchDTO> list;

        public TuyenDung()
        {
            InitializeComponent();
            list = bus.getAll();
            fillDataToTable();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ThemTuyenDungForm ttd = new ThemTuyenDungForm();
            ttd.StartPosition = FormStartPosition.CenterScreen;
            ttd.ShowDialog();
        }
        private void fillDataToTable()
        {
            tableTuyenDung.AutoGenerateColumns = false;
            tableTuyenDung.DataSource = null;
            tableTuyenDung.DataSource = list;
            tableTuyenDung.ClearSelection();
        }

    }
}
