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

        private void fillDataToTable(List<RecruitmentBatchDTO> listData)
        {
            tableTuyenDung.AutoGenerateColumns = false;
            tableTuyenDung.DataSource = null;
            tableTuyenDung.DataSource = listData;
            tableTuyenDung.ClearSelection();
        }

        private int TryParseInt(object value)
        {
            return int.TryParse(value?.ToString(), out int result) ? result : 0;
        }

        private decimal? TryParseDecimal(object value)
        {
            if (decimal.TryParse(value?.ToString(), out decimal result))
                return result;
            return null;
        }

        private DateTime TryParseDate(object value)
        {
            if (DateTime.TryParse(value?.ToString(), out DateTime date))
                return date;
            return DateTime.MinValue;
        }

        private RecruitmentBatchDTO getDataGirdview()
        {
            DataGridViewRow currentRow = tableTuyenDung.CurrentRow;

            if (currentRow != null)
            {
                return new RecruitmentBatchDTO
                {
                    MaTuyenDung = currentRow.Cells["maTuyenDung"].Value?.ToString(),
                    ChucVu = currentRow.Cells["chucVu"].Value?.ToString(),
                    HocVan = currentRow.Cells["hocVan"].Value?.ToString(),
                    GioiTinh = currentRow.Cells["gioiTinh"].Value?.ToString(),
                    DoTuoi = currentRow.Cells["doTuoi"].Value?.ToString(),

                    SoLuongCanTuyen = TryParseInt(currentRow.Cells["soLuongCanTuyen"].Value),
                    SoLuongNop = TryParseInt(currentRow.Cells["soLuongNop"].Value),
                    SoLuongDaTuyen = TryParseInt(currentRow.Cells["soLuongDaTuyen"].Value),

                    MucLuongToiThieu = TryParseDecimal(currentRow.Cells["mucLuongToiThieu"].Value),
                    MucLuongToiDa = TryParseDecimal(currentRow.Cells["mucLuongToiDa"].Value),

                    HanNopHoSo = TryParseDate(currentRow.Cells["hanNopHoSo"].Value)
                };
            }
            else
            {
                return null;
            }
        }

        private void notificationAndReset(object sender, EventArgs e, string m)
        {
            MessageBox.Show(m);
            list = bus.GetAll();
            fillDataToTable(list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThemTuyenDungForm form = new ThemTuyenDungForm();
            form.luuThongTinForm += (s, ev) => notificationAndReset(s, ev, "Lưu thành công");
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

        //private RecruitmentBatchDTO getDataby
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
            SuaDotTuyenDungForm form = new SuaDotTuyenDungForm(getDataGirdview());
            form.setDataInToTextBox();
            form.luuThongTinForm += (s, ev) => notificationAndReset(s, ev, "Sửa thành công");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void btnSearchDay_Click(object sender, EventArgs e)
        {
            DateTime startDay = startDaypicker.Value;
            DateTime endDay = endDayPicker.Value;

            if(startDay > endDay)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
                return;
            }
            fillDataToTable(bus.searchDay(startDay, endDay));
        }
    }
}
