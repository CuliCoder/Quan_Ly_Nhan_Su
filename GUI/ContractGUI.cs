using System;
using System.Windows.Forms;
using System.Drawing;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class ContractGUI : UserControl
    {
        public ContractGUI()
        {
            InitializeComponent();
            this.dataGridViewContracts.CellPainting += dataGridViewContracts_CellPainting;
        }

        private void ContractGUI_Load(object sender, EventArgs e)
        {
            // Cấu hình cột cho DataGridView
            dataGridViewContracts.Columns.Add("STT", "STT");
            dataGridViewContracts.Columns.Add("Ma_TenNhanVien", "Mã - Tên nhân viên");
            dataGridViewContracts.Columns.Add("PhongBan", "Phòng ban");
            dataGridViewContracts.Columns.Add("TuNgay", "Từ ngày");
            dataGridViewContracts.Columns.Add("DenNgay", "Đến ngày");
            dataGridViewContracts.Columns.Add("LoaiHopDong", "Loại hợp đồng");
            dataGridViewContracts.Columns.Add("LuongCoBan", "Lương cơ bản");

            // Thêm dữ liệu mẫu
            dataGridViewContracts.Rows.Add("1", "NV001 - Nguyen Van A", "Phòng Kế Toán", "01/09/2025", "01/03/2026", "Hợp đồng toàn thời gian", "15,000,000");
            dataGridViewContracts.Rows.Add("2", "NV002 - Tran Thi B", "Phòng Hành Chính", "15/09/2025", "15/03/2026", "Hợp đồng bán thời gian", "8,000,000");
        }

        private void dataGridViewContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tab = tabControl.TabPages[e.Index];
            bool isSelected = (e.Index == tabControl.SelectedIndex);
            Color color = isSelected ? Color.DeepSkyBlue : Color.Black;
            Font font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            SizeF textSize = e.Graphics.MeasureString(tab.Text, font);
            float x = e.Bounds.Left + (e.Bounds.Width - textSize.Width) / 2;
            float y = e.Bounds.Top + (e.Bounds.Height - textSize.Height) / 2;
            e.Graphics.DrawString(tab.Text, font, new SolidBrush(color), x, y);
        }

        private void dataGridViewContracts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewContracts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Chỉ custom header
            if (e.RowIndex == -1)
            {
                // STT (cột 0) hoặc Phòng ban (cột 2)
                if (e.ColumnIndex == 0 || e.ColumnIndex == 2)
                {
                    e.PaintBackground(e.ClipBounds, false);
                    using (SolidBrush brush = new SolidBrush(Color.White))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds);
                    }
                    e.PaintContent(e.ClipBounds);
                    e.Handled = true;
                }
            }
        }

        private void labelFrame_Click(object sender, EventArgs e)
        {

        }
    }
}