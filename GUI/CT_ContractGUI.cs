using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class CT_ContractGUI : UserControl
    {
        // ====== LỚP THÀNH PHẦN ======
        private readonly EmployeeFullBLL employeeBLL;
        private readonly DepartmentBLL departmentBLL;
        private readonly LaborContractBLL contractBLL;

        // ====== KHỞI TẠO ======
        public CT_ContractGUI()
        {
            InitializeComponent();

            // Cấu hình hiển thị tránh lỗi DPI
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.BackColor = Color.White;

            employeeBLL = new EmployeeFullBLL();
            departmentBLL = new DepartmentBLL();
            contractBLL = new LaborContractBLL();

            InitializeForm();
        }

        // ====== KHỞI TẠO FORM ======
        private void InitializeForm()
        {
            GenerateContractId();
            LoadEmployees();
            LoadDepartments();

            comboBoxLoaiHopDong.Items.AddRange(new object[]
            {
                "Xác định thời hạn",
                "Không thời hạn",
                "Thử việc"
            });
            comboBoxLoaiHopDong.SelectedIndex = 0;
            comboBoxLoaiHopDong.SelectedIndexChanged += (s, e) => ToggleDateToField();

            // Cấu hình ngày hiển thị dd/MM/yyyy
            dateTimePickerTuNgay.Format = DateTimePickerFormat.Custom;
            dateTimePickerTuNgay.CustomFormat = "dd/MM/yyyy";
            dateTimePickerDenNgay.Format = DateTimePickerFormat.Custom;
            dateTimePickerDenNgay.CustomFormat = "dd/MM/yyyy";
            dateTimePickerDenNgay.ShowCheckBox = true;

            // Ẩn trường "Đến ngày" ban đầu
            ToggleDateToField();
        }

        // ====== ẨN/HIỆN TRƯỜNG "ĐẾN NGÀY" ======
        private void ToggleDateToField()
        {
            bool showDenNgay = comboBoxLoaiHopDong.SelectedItem?.ToString() == "Xác định thời hạn";
            labelDenNgay.Visible = dateTimePickerDenNgay.Visible = showDenNgay;
        }

        // ====== TẠO MÃ HỢP ĐỒNG ======
        private void GenerateContractId()
        {
            string dateBase = DateTime.Now.ToString("yyyyMMdd");
            string prefix = $"HD{dateBase}";
            int suffix = 1;
            string candidate;

            while (true)
            {
                candidate = $"{prefix}{suffix:D3}";
                if (contractBLL.GetContractById(candidate) == null)
                    break;
                suffix++;
                if (suffix > 999)
                {
                    candidate = $"{prefix}_ERR";
                    break;
                }
            }

            textBoxMaHopDong.Text = candidate;
            textBoxMaHopDong.ReadOnly = true;
        }

        // ====== LOAD DANH SÁCH NHÂN VIÊN ======
        private void LoadEmployees()
        {
            try
            {
                var emps = contractBLL.GetUnsignedEmployees() ?? new System.Collections.Generic.List<EmployeeFullDTO>();

                var data = emps.Select(e => new
                {
                    MaNhanVien = e.MaNhanVien,
                    Display = $"{e.MaNhanVien} - {e.HoTen}"
                }).ToList();

                comboBoxNhanVien.DataSource = data;
                comboBoxNhanVien.DisplayMember = "Display";
                comboBoxNhanVien.ValueMember = "MaNhanVien";
                comboBoxNhanVien.SelectedIndex = data.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== LOAD PHÒNG BAN ======
        private void LoadDepartments()
        {
            try
            {
                var departments = departmentBLL.GetAllDepartments() ?? new System.Collections.Generic.List<DepartmentDTO>();
                comboBoxPhongBan.DataSource = departments;
                comboBoxPhongBan.DisplayMember = "TenPhong";
                comboBoxPhongBan.ValueMember = "MaPhong";
                comboBoxPhongBan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng ban: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== VALIDATE DỮ LIỆU ======
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxMaHopDong.Text))
            {
                ShowWarning("Mã hợp đồng không được để trống."); return false;
            }
            if (comboBoxNhanVien.SelectedIndex == -1)
            {
                ShowWarning("Vui lòng chọn nhân viên."); return false;
            }
            if (comboBoxPhongBan.SelectedIndex == -1)
            {
                ShowWarning("Vui lòng chọn phòng ban."); return false;
            }
            if (comboBoxLoaiHopDong.SelectedIndex == -1)
            {
                ShowWarning("Vui lòng chọn loại hợp đồng."); return false;
            }

            bool isXacDinh = comboBoxLoaiHopDong.Text == "Xác định thời hạn";
            if (isXacDinh && !dateTimePickerDenNgay.Checked)
            {
                ShowWarning("Vui lòng chọn đến ngày cho hợp đồng xác định thời hạn."); return false;
            }

            if (isXacDinh && dateTimePickerDenNgay.Value <= dateTimePickerTuNgay.Value)
            {
                ShowWarning("Đến ngày phải lớn hơn từ ngày."); return false;
            }

            if (!decimal.TryParse(textBoxMucLuong.Text, out decimal luong) || luong <= 0)
            {
                ShowWarning("Mức lương phải là số hợp lệ và lớn hơn 0."); return false;
            }

            return true;
        }

        private void ShowWarning(string msg) =>
            MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        // ====== NÚT TẠO HỢP ĐỒNG ======
        private void buttonTaoHopDong_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                // Lấy mã phòng ban an toàn
                string maPhongBan = "";
                var selected = comboBoxPhongBan.SelectedItem;
                if (selected is DepartmentDTO dto)
                    maPhongBan = dto.MaPhong;
                else
                    maPhongBan = selected?.ToString() ?? "";

                // Chuẩn bị DTO
                var contract = new LaborContractDTO
                {
                    MaHopDong = textBoxMaHopDong.Text,
                    MaNhanVien = comboBoxNhanVien.SelectedValue?.ToString() ?? "",
                    PhongBan = maPhongBan,
                    LoaiHopDong = comboBoxLoaiHopDong.Text,
                    TuNgay = dateTimePickerTuNgay.Value,
                    DenNgay = comboBoxLoaiHopDong.Text == "Không thời hạn" ? (DateTime?)null : dateTimePickerDenNgay.Value,
                    LuongCoBan = decimal.Parse(textBoxMucLuong.Text)
                };

                // Check trùng mã
                if (contractBLL.GetContractById(contract.MaHopDong) != null)
                {
                    MessageBox.Show("Mã hợp đồng đã tồn tại, hệ thống sẽ tự tạo mã mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GenerateContractId();
                    return;
                }

                decimal.TryParse(textBoxLuongTheoGio.Text, out decimal luongTheoGio);
                bool success = contractBLL.CreateContractWithSalary(contract, luongTheoGio);

                if (success)
                {
                    MessageBox.Show("Tạo hợp đồng và lương thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadEmployees();
                }
                else
                {
                    MessageBox.Show("Tạo hợp đồng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo hợp đồng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== NÚT HỦY ======
        private void buttonHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        // ====== RESET FORM ======
        private void ResetForm()
        {
            GenerateContractId();
            comboBoxNhanVien.SelectedIndex = -1;
            comboBoxPhongBan.SelectedIndex = -1;
            comboBoxLoaiHopDong.SelectedIndex = 0;
            textBoxMucLuong.Clear();
            textBoxLuongTheoGio.Clear();
            dateTimePickerTuNgay.Value = DateTime.Now;
            dateTimePickerDenNgay.Value = DateTime.Now;
            dateTimePickerDenNgay.Checked = false;
            ToggleDateToField();
        }
    }
}
