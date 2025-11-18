using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class LaborContractGUI : UserControl
    {
        private LaborContractBLL _bll = new LaborContractBLL();

        public LaborContractGUI()
        {
            InitializeComponent();

            // Thêm cột DenNgay nếu chưa có
            if (dataGridView1.Columns["DenNgay"] == null)
            {
                DataGridViewTextBoxColumn denNgayCol = new DataGridViewTextBoxColumn();
                denNgayCol.HeaderText = "Đến Ngày";
                denNgayCol.Name = "DenNgay";
                dataGridView1.Columns.Add(denNgayCol);
            }
            LoadDataToGrid();

            // Gắn sự kiện cho nút tìm kiếm và textbox
            this.buttonSearch.Click += buttonSearch_Click;
            this.textBoxSearch.KeyDown += textBoxSearch_KeyDown;
        }
        private void LoadDataToGrid()
        {
            List<LaborContractDTO> list = _bll.GetAllContracts();
            dataGridView1.Rows.Clear();
            foreach (var item in list)
            {
                dataGridView1.Rows.Add(
                    item.STT,
                    item.TenNhanVien,
                    item.PhongBan,
                    item.TuNgay.HasValue ? item.TuNgay.Value.ToString("dd/MM/yyyy") : "",
                    item.DenNgay.HasValue ? item.DenNgay.Value.ToString("dd/MM/yyyy") : ""
                );
            }
        }

        // Search helper
        private void PerformSearch(string keyword)
        {
            DateTime? from = null, to = null;
            if (dateTimePickerFrom != null && dateTimePickerFrom.Checked)
                from = dateTimePickerFrom.Value.Date;
            if (dateTimePickerTo != null && dateTimePickerTo.Checked)
                to = dateTimePickerTo.Value.Date;

            // If no keyword provided but date range specified, use GetContracts with date filter
            if (string.IsNullOrWhiteSpace(keyword))
            {
                // If date filters specified, call BLL with those filters, otherwise load all
                var contracts = _bll.GetContracts(from, to, null, null);
                dataGridView1.Rows.Clear();
                foreach (var item in contracts)
                {
                    dataGridView1.Rows.Add(
                        item.STT,
                        item.TenNhanVien,
                        item.PhongBan,
                        item.TuNgay.HasValue ? item.TuNgay.Value.ToString("dd/MM/yyyy") : "",
                        item.DenNgay.HasValue ? item.DenNgay.Value.ToString("dd/MM/yyyy") : ""
                    );
                }
                return;
            }

            // Perform accent-insensitive client-side search over all contracts (more reliable regardless of DB collation)
            var allContracts = _bll.GetAllContracts() ?? new List<LaborContractDTO>();
            string q = RemoveDiacritics(keyword).ToLowerInvariant();
            List<LaborContractDTO> results = allContracts.Where(c =>
                (!string.IsNullOrEmpty(c.TenNhanVien) && RemoveDiacritics(c.TenNhanVien).ToLowerInvariant().Contains(q)) ||
                (!string.IsNullOrEmpty(c.MaHopDong) && RemoveDiacritics(c.MaHopDong).ToLowerInvariant().Contains(q)) ||
                (!string.IsNullOrEmpty(c.PhongBan) && RemoveDiacritics(c.PhongBan).ToLowerInvariant().Contains(q))
            ).ToList();

             // If date range provided, filter results further by overlap
             if (from.HasValue || to.HasValue)
             {
                 results = results.Where(c =>
                     // contract starts inside range
                     (from.HasValue && c.TuNgay.HasValue && c.TuNgay.Value.Date >= from.Value.Date && (!to.HasValue || c.TuNgay.Value.Date <= (to.Value.Date))) ||
                     // contract ends inside range
                     (to.HasValue && c.DenNgay.HasValue && c.DenNgay.Value.Date <= to.Value.Date && (!from.HasValue || c.DenNgay.Value.Date >= from.Value.Date)) ||
                     // contract overlaps range
                     (from.HasValue && to.HasValue && c.TuNgay.HasValue && c.DenNgay.HasValue && !(c.DenNgay.Value.Date < from.Value.Date || c.TuNgay.Value.Date > to.Value.Date))
                 ).ToList();
             }

             dataGridView1.Rows.Clear();
             foreach (var item in results)
             {
                 dataGridView1.Rows.Add(
                     item.STT,
                     item.TenNhanVien,
                     item.PhongBan,
                     item.TuNgay.HasValue ? item.TuNgay.Value.ToString("dd/MM/yyyy") : "",
                     item.DenNgay.HasValue ? item.DenNgay.Value.ToString("dd/MM/yyyy") : ""
                 );
             }
         }

        // Remove diacritics helper to support searching without accents
        private static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            var normalized = text.Normalize(System.Text.NormalizationForm.FormD);
            var sb = new System.Text.StringBuilder();
            foreach (var ch in normalized)
            {
                var uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PerformSearch(textBoxSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PerformSearch(textBoxSearch.Text);
            }
        }

        private void labelDanhSach_Click(object sender, EventArgs e)
        {

        }

        private void labelGioiTinh_Click(object sender, EventArgs e)
        {

        }

        private void labelPhongBan_Click(object sender, EventArgs e)
        {

        }



        private void buttonTaoHopDong_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo form với kích thước CHÍNH XÁC
                Form createContractForm = new Form
                {
                    Text = "Tạo Hợp Đồng Lao Động",
                    ClientSize = new Size(920, 750),  // QUAN TRỌNG: Dùng ClientSize thay vì Size
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedSingle,  // Cố định size
                    MaximizeBox = false,
                    MinimizeBox = false,
                    AutoScaleMode = AutoScaleMode.None,  // TẮT AutoScale để không bị méo
                    BackColor = Color.FromArgb(236, 240, 241)
                };

                // Tạo instance của CT_ContractGUI
                CT_ContractGUI contractGui = new CT_ContractGUI
                {
                    Dock = DockStyle.Fill  // Fill toàn bộ form
                };

                // Thêm vào form
                createContractForm.Controls.Add(contractGui);

                // Hiển thị form
                DialogResult result = createContractForm.ShowDialog(this);
                
                // Reload lại danh sách nếu tạo thành công
                if (result == DialogResult.OK)
                {
                    LoadDataToGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form tạo hợp đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contractGUI2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
            try
            {
                // Kiểm tra dòng được chọn hợp lệ
                if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
                {
                    MessageBox.Show("Vui lòng chọn một dòng hợp lệ.");
                    return;
                }

                // Lấy giá trị từ cột "Nhanvien"
                string nhanVienText = dataGridView1.Rows[e.RowIndex].Cells["Nhanvien"].Value?.ToString();
                if (string.IsNullOrEmpty(nhanVienText))
                {
                    MessageBox.Show("Dữ liệu nhân viên trống!");
                    return;
                }

                // Trích xuất maNhanVien bằng biểu thức chính quy
                string maNhanVien = System.Text.RegularExpressions.Regex.Match(nhanVienText, @"\((.*?)\)").Groups[1].Value;
                if (string.IsNullOrEmpty(maNhanVien))
                {
                    MessageBox.Show("Không thể lấy mã nhân viên từ: " + nhanVienText);
                    return;
                }

                // Lấy thông tin nhân viên
                var bll = new EmployeeFullBLL();
                EmployeeFullDTO employee = bll.GetEmployeeById(maNhanVien);
                if (employee == null)
                {
                    MessageBox.Show($"Không tìm thấy nhân viên với mã: {maNhanVien}");
                    return;
                }

                // Chỉ cập nhật các label được liệt kê trong groupBoxThongTin
                labelLuong.Text = employee.MucLuong.ToString("N0");        // Mức lương
                labelcv.Text = employee.ChucVu ?? "";                     // Chức vụ
                labelpb.Text = employee.PhongBan ?? "";                  // Phòng ban
                labelcn.Text = employee.ChuyenNganh ?? "";               // Chuyên ngành
                labelhv.Text = employee.HocVan ?? "";                    // Học vấn
                labelcc.Text = employee.SoCmnd ?? "";                    // CCCD
                labelem.Text = employee.Email ?? "";                     // Email
                label7.Text = employee.Sdt ?? "";                        // Số điện thoại
                labeldc.Text = employee.DiaChi ?? "";                    // Địa chỉ
                labelhv.Text = employee.HocVan ?? "";                     // Học vấn (trùng lặp, có thể điều chỉnh)
                labelgt.Text = employee.GioiTinh ?? "";                  // Giới tính
                labelns.Text = employee.NgaySinh.HasValue ? employee.NgaySinh.Value.ToString("dd/MM/yyyy") : ""; // Ngày sinh
                labelId.Text = employee.MaNhanVien ?? "";                // Mã nhân viên

                // Cập nhật các trường ngày hợp đồng
                string tuNgayStr = dataGridView1.Rows[e.RowIndex].Cells["thuviectu"].Value?.ToString() ?? "";
                string denNgayStr = dataGridView1.Rows[e.RowIndex].Cells["DenNgay"].Value?.ToString() ?? "";
                textBoxBatDau.Text = tuNgayStr;
                textBoxKetThuc.Text = denNgayStr;

                // Debug: Kiểm tra giá trị ngày
                MessageBox.Show($"tuNgayStr: {tuNgayStr}, denNgayStr: {denNgayStr}");

                // Parse ngày với định dạng cụ thể dd/MM/yyyy
                if (DateTime.TryParseExact(tuNgayStr, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tuNgay) &&
                    DateTime.TryParseExact(denNgayStr, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime denNgay))
                {
                    if (tuNgay > denNgay)
                    {
                        textBoxThoiHan.Text = "Ngày kết thúc phải sau ngày bắt đầu!";
                    }
                    else
                    {
                        // Tính tổng thời hạn hợp đồng
                        TimeSpan thoiHan = denNgay - tuNgay;
                        long totalDays = (long)thoiHan.TotalDays; // Cast double to long

                        // Tính năm, tháng, ngày bằng toán tử nguyên
                        int nam = (int)(totalDays / 365);
                        long remainingAfterYears = totalDays % 365;
                        int thang = (int)(remainingAfterYears / 30);
                        int ngay = (int)(remainingAfterYears % 30);

                        // Định dạng kết quả
                        string ketQua = "";
                        if (nam > 0) ketQua += $"{nam} năm ";
                        if (thang > 0) ketQua += $"{thang} tháng ";
                        if (ngay > 0) ketQua += $"{ngay} ngày";

                        textBoxThoiHan.Text = ketQua.Trim() == "" ? "0 ngày" : ketQua.Trim();

                        // Kiểm tra trạng thái hợp đồng dựa trên ngày hiện tại
                        DateTime ngayHienTai = new DateTime(2025, 9, 26, 20, 53, 0); // 08:53 PM +07
                        if (ngayHienTai > denNgay)
                        {
                            textBoxThoiHan.Text += " (Hợp đồng đã hết hạn)";
                        }
                    }
                }
                else
                {
                    textBoxThoiHan.Text = "Dữ liệu ngày không hợp lệ";
                    MessageBox.Show("Không thể parse ngày. Vui lòng kiểm tra định dạng (dd/MM/yyyy).");
                }

                // Làm mới giao diện
                groupBoxThongTin.Refresh();
                groupBoxBoSung.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }

        private void labelhv_Click(object sender, EventArgs e)
        {

        }
        // Load danh sách phòng ban - comboBox1 đã bị loại bỏ, giữ method trống để tránh tham chiếu ngoài ý muốn
        private void LoadDepartments()
        {
            // comboBox1 removed per request. If department filtering is required later,
            // implement UI and logic accordingly.
        }

        // Load sắp xếp vào comboBox6
        private void LoadSortOptions()
        {
            // comboBox6 removed earlier — keep method to avoid breaking calls but do nothing
        }

        // Load data vào dataGridView1 với filter/sort (dành cho hợp đồng hiện có)
        private void LoadContractsGrid()
        {
            // Department filter removed (comboBox1). Use null to fetch all departments.
            string phongBan = null;

            string sortOption = null; // no sort UI present
            string sortKey = null;
            // default sortKey remains null (DAO uses default ORDER BY tuNgay DESC)

            DateTime? from = null, to = null;
            if (dateTimePickerFrom != null && dateTimePickerFrom.Checked)
                from = dateTimePickerFrom.Value.Date;
            if (dateTimePickerTo != null && dateTimePickerTo.Checked)
                to = dateTimePickerTo.Value.Date;

            var contracts = _bll.GetContracts(from, to, phongBan, sortKey);

            dataGridView1.Rows.Clear();
            foreach (var c in contracts)
            {
                dataGridView1.Rows.Add(
                    c.STT,
                    c.TenNhanVien,
                    c.PhongBan,
                    c.TuNgay.HasValue ? c.TuNgay.Value.ToString("dd/MM/yyyy") : "",
                    c.DenNgay.HasValue ? c.DenNgay.Value.ToString("dd/MM/yyyy") : ""
                );
            }
            dataGridView1.Refresh();
        }

        // Keep previous LoadUnsignedEmployees for unsigned employees list; call LoadContractsGrid when viewing contracts
        private void LoadUnsignedEmployees()
        {
            // Department filter removed (comboBox1)
            string phongBan = null;
            string sortOption = null; // no sort UI
            string sortKey = null;
            // keep default behavior

            List<EmployeeFullDTO> employees = _bll.GetUnsignedEmployees(phongBan, sortKey);

            dataGridView1.Rows.Clear();
            int stt = 1;
            foreach (var employee in employees)
            {
                dataGridView1.Rows.Add(
                    stt++,
                    $"{employee.HoTen} ({employee.MaNhanVien})",
                    employee.PhongBan,
                    employee.NgaySinh?.ToString("dd/MM/yyyy") ?? ""
                );
            }

            dataGridView1.Refresh();  // Update Grid nếu cần
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If user wants contracts list, call LoadContractsGrid(), otherwise unsigned employees
            // For simplicity, call LoadContractsGrid to show contracts when sort by TU or LUONG
            LoadContractsGrid();
        }

        // Wire date pickers changed event to reload
        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadContractsGrid();
        }
        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            LoadContractsGrid();
        }

        private void labelgt_Click(object sender, EventArgs e)
        {
            // placeholder for designer event
        }

        private void labelEmail_Click(object sender, EventArgs e)
        {
            // placeholder for designer event
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Some Designer buttons may be named button1 (magnifier). Forward to PerformSearch.
                PerformSearch(textBoxSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}