using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.GUI;

namespace Quan_Ly_Nhan_Su.GUI.LuongThuongUserControl
{
    public partial class LuongThuong : UserControl
    {
        private readonly SalaryBLL _salaryBLL = new SalaryBLL();

        public LuongThuong()
        {
            InitializeComponent();

            ConfigureDataGridViewAppearance();

            // Load salary table after InitializeComponent so designer objects exist
            LoadSalaryTable();

            // wire export bill button
            try
            {
                this.billluong.Click += Billluong_Click;
            }
            catch { }

            // open bill on double-click row
            this.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void ConfigureDataGridViewAppearance()
        {
            // safer runtime adjustments for designer-friendly grid
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = false;

            // ensure there is a hidden column to carry MaNhanVien so we can always resolve when printing
            if (!dataGridView1.Columns.Contains("colMaNhanVien"))
            {
                var hidden = new DataGridViewTextBoxColumn
                {
                    Name = "colMaNhanVien",
                    HeaderText = "MaNhanVien",
                    Visible = false
                };
                dataGridView1.Columns.Add(hidden);
            }

            // set nicer header texts if columns exist
            if (dataGridView1.Columns.Count >= 10)
            {
                dataGridView1.Columns[0].HeaderText = "STT";
                dataGridView1.Columns[1].HeaderText = "Nhân viên";
                dataGridView1.Columns[2].HeaderText = "Thời gian";
                dataGridView1.Columns[3].HeaderText = "Phụ cấp";
                dataGridView1.Columns[4].HeaderText = "Lương thưởng";
                dataGridView1.Columns[5].HeaderText = "Các khoản trừ";
                dataGridView1.Columns[6].HeaderText = "Lương cơ bản";
                dataGridView1.Columns[7].HeaderText = "Lương thực tế";
                dataGridView1.Columns[8].HeaderText = "Thuế";
                dataGridView1.Columns[9].HeaderText = "Thực lãnh";

                // align numeric columns to right
                for (int i = 3; i <= 9; i++)
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void LoadSalaryTable()
        {
            try
            {
                dataGridView1.Rows.Clear();
                var list = _salaryBLL.GetAll();
                if (list == null) return;

                int stt = 1;
                foreach (var s in list)
                {
                    // Thời gian: dùng tháng/năm hiện tại (có thể thay đổi theo dữ liệu thực tế)
                    string thoiGian = DateTime.Now.ToString("MM/yyyy");

                    // Các khoản trừ và phụ cấp chồng lên nhau (hiện DTO có các trường này)
                    decimal phuCap = s.PhuCapChucVu + s.PhuCapKhac;
                    decimal khoanTru = s.KhoanTruBaoHiem + s.KhoanTruKhac;

                    // append hidden MaNhanVien as last cell so we can resolve later if Tag is lost
                    object[] row = new object[]
                    {
                        stt++,
                        // Hiển thị tên nhân viên nếu có, fallback MaNhanVien
                        string.IsNullOrWhiteSpace(s.HoTen) ? (s.MaNhanVien ?? s.MaLuong) : s.HoTen,
                        thoiGian,
                        phuCap.ToString("N0"),
                        s.LuongThuong.ToString("N0"),
                        khoanTru.ToString("N0"),
                        s.LuongCoBan.ToString("N0"),
                        s.LuongThucTe.HasValue ? s.LuongThucTe.Value.ToString("N0") : "",
                        s.Thue.ToString("N0"),
                        s.ThucLanh.HasValue ? s.ThucLanh.Value.ToString("N0") : "",
                        s.MaNhanVien ?? s.MaLuong // hidden column value
                    };

                    int rowIndex = dataGridView1.Rows.Add(row);
                    // store SalaryDTO in the row Tag so we can open BillForm later with full data
                    if (rowIndex >= 0)
                    {
                        var dgRow = dataGridView1.Rows[rowIndex];
                        dgRow.Tag = s; // store full DTO
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                OpenBillForRow(row);
            }
        }

        private void Billluong_Click(object sender, EventArgs e)
        {
            try
            {
                // prefer selected rows, otherwise use current row
                DataGridViewRow selectedRow = null;
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                    selectedRow = dataGridView1.SelectedRows[0];
                else if (dataGridView1.CurrentRow != null)
                    selectedRow = dataGridView1.CurrentRow;

                if (selectedRow == null)
                {
                    MessageBox.Show("Vui lòng chọn 1 hàng nhân viên trong bảng trước khi xuất bill.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                OpenBillForRow(selectedRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở phiếu lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenBillForRow(DataGridViewRow row)
        {
            if (row == null) return;

            // row.Tag expected to be SalaryDTO (set in LoadSalaryTable)
            var dto = row.Tag as SalaryDTO;
            string maNhanVien = null;

            if (dto != null)
            {
                maNhanVien = dto.MaNhanVien;
                // if MaNhanVien is empty but we have MaLuong, try resolve via BLL
                if (string.IsNullOrWhiteSpace(maNhanVien) && !string.IsNullOrWhiteSpace(dto.MaLuong))
                {
                    maNhanVien = _salaryBLL.GetMaNhanVienByMaLuong(dto.MaLuong);
                }
            }

            // Fallback: try to read hidden cell that carries MaNhanVien
            if (string.IsNullOrWhiteSpace(maNhanVien))
            {
                try
                {
                    if (dataGridView1.Columns.Contains("colMaNhanVien"))
                    {
                        var v = row.Cells["colMaNhanVien"].Value;
                        if (v != null) maNhanVien = v.ToString();
                    }
                }
                catch { /* ignore */ }
            }

            if (string.IsNullOrWhiteSpace(maNhanVien))
            {
                MessageBox.Show("Không xác định được mã nhân viên để in phiếu. Hãy đảm bảo dữ liệu đầy đủ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            maNhanVien = maNhanVien.Trim();

            // Debug: verify BLL returns salary data for this MaNhanVien
            try
            {
                var salary = _salaryBLL.GetSalaryByEmployee(maNhanVien);
                if (salary == null)
                {
                    MessageBox.Show($"Không tìm thấy dữ liệu lương cho MaNhanVien='{maNhanVien}'.\nHãy kiểm tra bảng 'luong' và các bảng liên quan (thuong, phucapkhoantru).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi truy vấn dữ liệu lương cho MaNhanVien='{maNhanVien}': {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // open BillForm and pass maNhanVien
            var bill = new BillFormGUI(maNhanVien);
            bill.StartPosition = FormStartPosition.CenterParent;
            bill.ShowDialog(this);
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
