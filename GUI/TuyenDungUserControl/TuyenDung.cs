using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl
{
    public partial class TuyenDung : UserControl
    {
        private static readonly RecruitmentBatchBLL bus = new RecruitmentBatchBLL();
        private static List<RecruitmentBatchDTO> list;

        public TuyenDung()
        {
            InitializeComponent();
            list = bus.GetAll();
            fillDataToTable();
        }

        public void fillDataToTable()
        {
            tableTuyenDung.AutoGenerateColumns = false;
            tableTuyenDung.DataSource = null;
            tableTuyenDung.DataSource = list;
            tableTuyenDung.ClearSelection();
        }

        private void luuThanhcong(object sender, EventArgs e)
        {
            MessageBox.Show("Thêm mới thành công");
            list = bus.GetAll();
            fillDataToTable(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThemTuyenDungForm form = new ThemTuyenDungForm();
            form.luuThongTinForm += luuThanhcong;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tableTuyenDung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa");
                return;
            }

            DataGridViewRow selectedRow = tableTuyenDung.CurrentRow;
            string maTuyenDung = selectedRow.Cells[0].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa mã tuyển dụng '{maTuyenDung}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                bool isDeleted = bus.Delete(maTuyenDung);
                if (isDeleted)
                {
                    MessageBox.Show("Xóa thành công!");
                    list = bus.GetAll();
                    fillDataToTable();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }
    }
}
