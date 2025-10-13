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

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class CT_ContractGUI : UserControl
    {
        private EmployeeFullBLL employeeBLL;
        private DepartmentBLL departmentBLL;
        private LaborContractBLL contractBLL;

        public CT_ContractGUI()
        {
            InitializeComponent();
            InitializeBLL();
            InitializeForm();
        }

        private void InitializeBLL()
        {
            employeeBLL = new EmployeeFullBLL();
            departmentBLL = new DepartmentBLL();
            contractBLL = new LaborContractBLL();
        }

        private void InitializeForm()
        {
            // Tự động sinh mã hợp đồng
            GenerateContractId();

            // Load danh sách nhân viên chưa ký hợp đồng và phòng ban
            LoadEmployees();
            LoadDepartments();

            // Thiết lập combobox loại hợp đồng (tĩnh, không load từ DB)
            comboBoxLoaiHopDong.Items.AddRange(new object[] { "Xác định thời hạn", "Không thời hạn" });
            comboBoxLoaiHopDong.SelectedIndex = 0;

            // Không set ngày mặc định, user tự chọn
            // Không load lương, để user nhập

            // Ẩn trường "Đến ngày" ban đầu
            ToggleDateToField();

            // Wire event cho combo loại hợp đồng để toggle DenNgay
            comboBoxLoaiHopDong.SelectedIndexChanged += ComboBoxLoaiHopDong_SelectedIndexChanged;
        }

        private void ComboBoxLoaiHopDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleDateToField();
        }

        private void ToggleDateToField()
        {
            bool isXacDinh = comboBoxLoaiHopDong.SelectedItem?.ToString() == "Xác định thời hạn";
            labelDenNgay.Visible = dateTimePickerDenNgay.Visible = isXacDinh;
        }

        private void GenerateContractId()
        {
            // Sinh mã hợp đồng tự động theo format: HD + YYYYMMDD + số thứ tự
            // Để đơn giản, dùng "001" - có thể cải thiện bằng query DB sau
            string dateStr = DateTime.Now.ToString("yyyyMMdd");
            textBoxMaHopDong.Text = $"HD{dateStr}001";
            textBoxMaHopDong.ReadOnly = true;
        }

        private void LoadEmployees()
        {
            try
            {
                // Chỉ load nhân viên chưa ký hợp đồng
                var employees = employeeBLL.GetEmployeesWithoutContract();
                comboBoxNhanVien.DataSource = employees;
                comboBoxNhanVien.DisplayMember = "HoTen";
                comboBoxNhanVien.ValueMember = "MaNhanVien";
                comboBoxNhanVien.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên chưa ký hợp đồng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDepartments()
        {
            try
            {
                var departments = departmentBLL.GetAllDepartments();
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

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxMaHopDong.Text))
            {
                MessageBox.Show("Mã hợp đồng không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxNhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxPhongBan.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng ban.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxLoaiHopDong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại hợp đồng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dateTimePickerTuNgay.Value == default(DateTime))
            {
                MessageBox.Show("Vui lòng chọn từ ngày.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool isXacDinh = comboBoxLoaiHopDong.Text == "Xác định thời hạn";
            if (isXacDinh && dateTimePickerDenNgay.Value == default(DateTime))
            {
                MessageBox.Show("Vui lòng chọn đến ngày cho hợp đồng xác định thời hạn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (isXacDinh && dateTimePickerDenNgay.Value <= dateTimePickerTuNgay.Value)
            {
                MessageBox.Show("Đến ngày phải lớn hơn từ ngày.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxMucLuong.Text) || !decimal.TryParse(textBoxMucLuong.Text, out decimal luong))
            {
                MessageBox.Show("Mức lương phải là số hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (luong <= 0)
            {
                MessageBox.Show("Mức lương phải lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Event cho buttonTaoHopDong
        private void buttonTaoHopDong_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                CreateContract();
            }
        }

        private void CreateContract()
        {
            try
            {
                // Lấy MaPhong từ SelectedItem (lưu maPhong thay vì tenPhong để JOIN đúng)
                string maPhongBan = ((DepartmentDTO)comboBoxPhongBan.SelectedItem)?.MaPhong ?? "";
                var contract = new LaborContractDTO
                {
                    MaHopDong = textBoxMaHopDong.Text,
                    MaNhanVien = comboBoxNhanVien.SelectedValue.ToString(),
                    PhongBan = maPhongBan,  // Lưu maPhong
                    LoaiHopDong = comboBoxLoaiHopDong.Text,
                    TuNgay = dateTimePickerTuNgay.Value,
                    DenNgay = comboBoxLoaiHopDong.Text == "Không thời hạn" ? (DateTime?)null : dateTimePickerDenNgay.Value,
                    LuongCoBan = decimal.Parse(textBoxMucLuong.Text)
                    // Không có ChiTiet
                };

                if (contractBLL.CreateContract(contract))
                {
                    MessageBox.Show("Tạo hợp đồng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    // Reload employees để loại bỏ NV vừa ký
                    LoadEmployees();
                }
                else
                {
                    MessageBox.Show("Tạo hợp đồng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo hợp đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            GenerateContractId();
            comboBoxNhanVien.SelectedIndex = -1;
            comboBoxPhongBan.SelectedIndex = -1;
            comboBoxLoaiHopDong.SelectedIndex = 0;
            // Không reset ngày, user tự set
            textBoxMucLuong.Clear();
            // Không có ChiTiet
            ToggleDateToField();
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        // Không cần labelChiTiet_Click nữa
    }
}