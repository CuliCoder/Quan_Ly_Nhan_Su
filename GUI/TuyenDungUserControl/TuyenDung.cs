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
            fillDataToTable(list);
        }

        public void fillDataToTable(List<RecruitmentBatchDTO> listData)
        {
            tableTuyenDung.AutoGenerateColumns = false;
            tableTuyenDung.DataSource = null;
            tableTuyenDung.DataSource = listData;
            tableTuyenDung.ClearSelection();
        }

        private void luuThanhcong(object sender, EventArgs e)
        {
            MessageBox.Show("Thêm mới thành công");
            list = bus.GetAll();
            fillDataToTable(list); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThemTuyenDungForm form = new ThemTuyenDungForm();
            form.luuThongTinForm += luuThanhcong;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog(); 
        }

        private void getDataSearch()
        {
            string keyWord = tbSearch.Text.Trim();
            List<RecruitmentBatchDTO> listSearch = bus.Search(keyWord);
            fillDataToTable(listSearch);
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
                    fillDataToTable(list);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            getDataSearch();
        }

        private void tbSearch_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getDataSearch();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            fillDataToTable(list);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuaDotTuyenDungForm form = new SuaDotTuyenDungForm();
            //form.luuThongTinForm += luuThanhcong;

            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
