using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class ContractGUI : UserControl
    {
        private readonly LaborContractBLL _bll;

        public ContractGUI()
        {
            InitializeComponent();
            _bll = new LaborContractBLL(); // Khởi tạo BLL
            InitializeDataGridViewColumns(); // Khởi tạo cột trước khi tải dữ liệu
            LoadDataToGrid(); // Tải dữ liệu vào DataGridView
        }

        private void InitializeDataGridViewColumns()
        {
            // Xóa cột cũ (nếu có)
            dataGridView1.Columns.Clear();

            // Thêm cột với tiêu đề rõ ràng
            dataGridView1.Columns.Add("STT", "STT");
            dataGridView1.Columns.Add("MaTenNhanVien", "Mã - Tên nhân viên");
            dataGridView1.Columns.Add("PhongBan", "Phòng ban");
            dataGridView1.Columns.Add("TuNgay", "Từ ngày");
            dataGridView1.Columns.Add("DenNgay", "Đến ngày");
            dataGridView1.Columns.Add("LoaiHopDong", "Loại hợp đồng");
            dataGridView1.Columns.Add("LuongCoBan", "Lương cơ bản");

            // Đảm bảo tiêu đề cột luôn hiển thị
            dataGridView1.ColumnHeadersVisible = true;
        }

        private void LoadDataToGrid()
        {
            // Xóa dữ liệu cũ (nếu có)
            dataGridView1.Rows.Clear();

            // Lấy dữ liệu từ BLL
            var contracts = _bll.GetAllContracts();

            // Thêm dữ liệu vào DataGridView
            foreach (var contract in contracts)
            {
                dataGridView1.Rows.Add(
                    contract.STT,
                    $"{contract.MaHopDong} - {contract.TenNhanVien}", // Định dạng Mã - Tên nhân viên
                    contract.PhongBan,
                    contract.TuNgay?.ToString("dd/MM/yyyy"), // Định dạng ngày
                    contract.DenNgay?.ToString("dd/MM/yyyy"), // Định dạng ngày
                    contract.LoaiHopDong,
                    contract.LuongCoBan.ToString("#,##0") // Định dạng tiền tệ
                );
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim().ToLower();
            dataGridView1.Rows.Clear();

            // Lấy dữ liệu đã lọc từ BLL
            var contracts = _bll.SearchContracts(searchText);

            foreach (var contract in contracts)
            {
                dataGridView1.Rows.Add(
                    contract.STT,
                    $"{contract.MaHopDong} - {contract.TenNhanVien}",
                    contract.PhongBan,
                    contract.TuNgay?.ToString("dd/MM/yyyy"),
                    contract.DenNgay?.ToString("dd/MM/yyyy"),
                    contract.LoaiHopDong,
                    contract.LuongCoBan.ToString("#,##0")
                );
            }

            if (contracts.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.");
            }
        }

        // Tùy chọn: Thêm event KeyDown cho textBoxSearch để tìm kiếm khi nhấn Enter
        // Trong constructor hoặc InitializeComponent, thêm:
        // textBoxSearch.KeyDown += new KeyEventHandler(textBoxSearch_KeyDown);

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearch_Click(sender, e);
                e.SuppressKeyPress = true; // Ngăn tiếng beep
            }
        }

        // Để reset tìm kiếm (load all), có thể sử dụng button1 (Quay Lại) hoặc thêm button mới
        // Giả sử button1 là "Quay Lại" hoặc "Load All", cập nhật:
        private void button1_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = ""; // Xóa keyword
            LoadDataToGrid(); // Load tất cả dữ liệu
        }

        private void ContractGUI_Load(object sender, EventArgs e)
        {
            // Không cần thêm dữ liệu ở đây vì đã xử lý trong LoadDataToGrid
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)  // Đảm bảo click vào row hợp lệ
            {
                try
                {
                    // Lấy giá trị cột 1: "{MaHopDong} - {TenNhanVien}"
                    string maTenNhanVien = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString();
                    if (string.IsNullOrEmpty(maTenNhanVien))
                    {
                        MessageBox.Show("Dòng dữ liệu không hợp lệ.");
                        return;
                    }

                    // Parse maHopDong (phần trước dấu "-")
                    string maHopDong = maTenNhanVien.Split('-')[0].Trim();

                    // Tạo instance CT_LaborContractGUI và set contractId (maHopDong)
                    CT_LaborContractGUI detailGUI = new CT_LaborContractGUI();
                    detailGUI.SetContractId(maHopDong);

                    // Thay thế UserControl hiện tại bằng detailGUI trong Parent (giả sử là Panel trong MainForm)
                    if (this.Parent is Panel panelContent)
                    {
                        panelContent.Controls.Clear();  // Xóa control cũ (ContractGUI)
                        panelContent.Controls.Add(detailGUI);  // Thêm control mới
                        detailGUI.Dock = DockStyle.Fill;  // Fill toàn panel
                    }
                    else
                    {
                        // Nếu không phải Panel, show như Form mới (tùy chỉnh nếu cần)
                        Form detailForm = new Form { Text = "Chi tiết hợp đồng" };
                        detailForm.Controls.Add(detailGUI);
                        detailForm.Size = new Size(1000, 600);  // Kích thước tùy chỉnh
                        detailForm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi load chi tiết: {ex.Message}");
                }
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}