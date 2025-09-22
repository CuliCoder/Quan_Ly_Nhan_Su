using Quan_Ly_Nhan_Su.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YourNamespace.DTO;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class ContractGUI : UserControl
    {
        private readonly LaborContractBLL _bll;

        public ContractGUI()
        {
            InitializeComponent();
            _bll = new LaborContractBLL();
            this.dataGridViewContracts.CellPainting += dataGridViewContracts_CellPainting;
            LoadContracts();
        }

        private void ContractGUI_Load(object sender, EventArgs e)
        {
            // Cấu hình cột cho DataGridView (đã được thiết kế trong Designer)
            // Không cần thêm thủ công nữa vì đã có trong Designer
        }

        private void LoadContracts()
        {
            try
            {
                dataGridViewContracts.Rows.Clear();
                List<LaborContractDTO> contracts = _bll.GetAllContracts();
                int stt = 1;
                foreach (var contract in contracts)
                {
                    dataGridViewContracts.Rows.Add(
                        stt++,
                        contract.TenNhanVien,
                        contract.PhongBan,
                        contract.TuNgay?.ToString("dd/MM/yyyy") ?? "",
                        contract.DenNgay?.ToString("dd/MM/yyyy") ?? "",
                        contract.LoaiHopDong,
                        contract.LuongCoBan.ToString("N0") + " VND"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu hợp đồng: {ex.Message}");
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text.Trim();
            dataGridViewContracts.Rows.Clear();
            List<LaborContractDTO> contracts = _bll.SearchContracts(keyword);
            int stt = 1;
            foreach (var contract in contracts)
            {
                dataGridViewContracts.Rows.Add(
                    stt++,
                    contract.TenNhanVien,
                    contract.PhongBan,
                    contract.TuNgay?.ToString("dd/MM/yyyy") ?? "",
                    contract.DenNgay?.ToString("dd/MM/yyyy") ?? "",
                    contract.LoaiHopDong,
                    contract.LuongCoBan.ToString("N0") + " VND"
                );
            }
        }

        private void dataGridViewContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện nhấp chuột (nếu cần, ví dụ: chỉnh sửa hoặc xóa)
            if (e.RowIndex >= 0)
            {
                string maHopDong = dataGridViewContracts.Rows[e.RowIndex].Cells["Ma_TenNhanVien"].Value.ToString().Split('-')[0].Trim();
                if (e.ColumnIndex == dataGridViewContracts.Columns["LoaiHopDong"].Index) // Giả sử cột LoaiHopDong là nơi nhấp để xóa
                {
                    if (MessageBox.Show("Bạn có muốn xóa hợp đồng này không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (_bll.DeleteContract(maHopDong))
                        {
                            MessageBox.Show("Xóa hợp đồng thành công!");
                            LoadContracts();
                        }
                        else
                        {
                            MessageBox.Show("Xóa hợp đồng thất bại!");
                        }
                    }
                }
            }
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

        private void dataGridViewContracts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
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
        // Add this method to handle the DataGridView CellContentClick event
        private void dataGridViewContracts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // You can implement your logic here or leave it empty if not needed
            // Example: Do nothing
        }
    }
}