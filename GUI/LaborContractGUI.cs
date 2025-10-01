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

            // Gắn sự kiện thủ công cho comboBox1 (phòng ban) và comboBox6 (sắp xếp)
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox6.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
        }
        private void LoadDataToGrid()
        {
            List<LaborContractDTO> list = _bll.GetAllContracts();
            MessageBox.Show("Dữ liệu hợp đồng: " + string.Join("\n", list.Select(x => $"STT: {x.STT}, Tên: {x.TenNhanVien}, Từ: {x.TuNgay}, Đến: {x.DenNgay}")));
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
            MessageBox.Show("Sự kiện CellClick đã chạy! RowIndex: " + e.RowIndex); // Kiểm tra
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
                var bll = new EmployeeBLL();
                EmployeeDTO employee = bll.GetEmployeeById(maNhanVien);
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
                label5.Text = employee.HocVan ?? "";                     // Học vấn (trùng lặp, có thể điều chỉnh)
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
        // Load danh sách phòng ban vào comboBox (ví dụ comboBox2)
        private void LoadDepartments()
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;

            List<string> departments = _bll.GetAllDepartments();
            MessageBox.Show("Số phòng ban: " + (departments?.Count ?? 0) + "\nDanh sách: " + string.Join(", ", departments ?? new List<string>()));

            comboBox1.Items.Add("Tất cả");
            if (departments != null)
            {
                comboBox1.Items.AddRange(departments.ToArray());
            }
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.ForeColor = System.Drawing.Color.Black;  // Đặt màu chữ đen
            comboBox1.BackColor = System.Drawing.Color.White;  // Đặt màu nền trắng
            comboBox1.DropDownHeight = 200;
            comboBox1.Refresh();
            MessageBox.Show("ComboBox1 Items count: " + comboBox1.Items.Count);
        }

        // Load sắp xếp vào comboBox6
        private void LoadSortOptions()
        {
            comboBox6.Items.Add("Tăng dần theo lương");
            comboBox6.Items.Add("Giảm dần theo lương");
            comboBox6.SelectedIndex = 0;
        }

        // Load data vào dataGridView1 với filter/sort
        private void LoadUnsignedEmployees()
        {
            string phongBan = comboBox1.SelectedItem?.ToString();
            string sortOption = comboBox6.SelectedItem?.ToString();
            string sortBySalary = null;

            if (sortOption == "Tăng dần theo lương") sortBySalary = "ASC";
            else if (sortOption == "Giảm dần theo lương") sortBySalary = "DESC";

            if (phongBan == "Tất cả") phongBan = null;

            List<EmployeeDTO> employees = _bll.GetUnsignedEmployees(phongBan, sortBySalary);
            MessageBox.Show("Số nhân viên chưa ký: " + employees.Count + "\nDanh sách (mẫu): " + (employees.Count > 0 ? employees[0].PhongBan : "Empty"));  // Debug thêm

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

            if (employees.Count == 0)
            {
                MessageBox.Show("Không có nhân viên chưa ký hợp đồng phù hợp.");
            }
            dataGridView1.Refresh();  // Update Grid nếu cần
        }

        // Sự kiện khi thay đổi comboBox


        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUnsignedEmployees();
        }

        // Gọi trong Initialize hoặc Load form
        private void LaborContractGUI_Load(object sender, EventArgs e)
        {
            LoadDepartments();  // Đảm bảo hàm này chạy
            LoadSortOptions();
            LoadUnsignedEmployees();
            MessageBox.Show("ComboBox1 Items count: " + comboBox1.Items.Count + "\nEnabled: " + comboBox1.Enabled + "\nVisible: " + comboBox1.Visible);  // Debug UI
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUnsignedEmployees(); // Lọc Grid theo phòng ban đã chọn
        }

    }
}
    