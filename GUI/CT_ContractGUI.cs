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
            
            // ĐẢM BẢO Dock được set sau khi InitializeComponent
            this.Dock = DockStyle.Fill;
            this.AutoScaleMode = AutoScaleMode.None;  // Tắt AutoScale
            this.AutoSize = false;  // Tắt AutoSize
            
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
            // Sinh mã hợp đồng tự động: HD + YYYYMMDD + số thứ tự (001..999)
            string dateBase = DateTime.Now.ToString("yyyyMMdd");
            string prefix = $"HD{dateBase}";
            int suffix = 1;
            string candidate;

            // Lặp tới khi mã chưa tồn tại trong DB
            do
            {
                candidate = $"{prefix}{suffix:D3}";
                // Nếu BLL trả null => chưa có hợp đồng đó
                if (contractBLL.GetContractById(candidate) == null) break;
                suffix++;
                if (suffix > 999) break; // bảo vệ khỏi loop vô hạn
            } while (true);

            textBoxMaHopDong.Text = candidate;
            textBoxMaHopDong.ReadOnly = true;
        }

        // CT_ContractGUI.cs
        // CT_ContractGUI.cs
        // CT_ContractGUI.cs
        private void LoadEmployees()
        {
            try
            {
                // Lấy danh sách nhân viên CHƯA có hợp đồng
                var emps = contractBLL.GetUnsignedEmployees();

                // Chỉ hiển thị MÃ NHÂN VIÊN
                var data = emps.Select(e => new
                {
                    MaNhanVien = e.MaNhanVien,
                    Display = e.MaNhanVien  // <--- THAY ĐỔI CHÍNH XÁC TẠI ĐÂY
                }).ToList();

                comboBoxNhanVien.DataSource = data;
                comboBoxNhanVien.DisplayMember = "Display";
                comboBoxNhanVien.ValueMember = "MaNhanVien";
                comboBoxNhanVien.SelectedIndex = data.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên chưa ký hợp đồng: " + ex.Message,
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
                // Lấy mã phòng ban an toàn: nếu item là string hoặc DTO đều xử lý được
                string maPhongBan = "";
                var selected = comboBoxPhongBan.SelectedItem;
                if (selected == null)
                {
                    maPhongBan = "";
                }
                else if (selected is string)
                {
                    maPhongBan = selected.ToString();
                }
                else
                {
                    // nếu là DTO
                    var dto = selected as DepartmentDTO;
                    maPhongBan = dto?.MaPhong ?? selected.ToString();
                }

                var contract = new LaborContractDTO
                {
                    MaHopDong = textBoxMaHopDong.Text,
                    MaNhanVien = comboBoxNhanVien.SelectedValue?.ToString() ?? comboBoxNhanVien.SelectedItem?.ToString() ?? "",
                    PhongBan = maPhongBan,
                    LoaiHopDong = comboBoxLoaiHopDong.Text,
                    TuNgay = dateTimePickerTuNgay.Value,
                    DenNgay = comboBoxLoaiHopDong.Text == "Không thời hạn" ? (DateTime?)null : dateTimePickerDenNgay.Value,
                    LuongCoBan = decimal.Parse(textBoxMucLuong.Text)
                };

                // Kiểm tra mã hợp đồng trùng trước khi gọi DAO
                if (contractBLL.GetContractById(contract.MaHopDong) != null)
                {
                    MessageBox.Show("Mã hợp đồng đã tồn tại. Vui lòng thử lại để tạo mã hợp đồng mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GenerateContractId();
                    return;
                }

                decimal luongTheoGio = 0;
                decimal.TryParse(textBoxLuongTheoGio.Text, out luongTheoGio);

                if (contractBLL.CreateContractWithSalary(contract, luongTheoGio))
                {
                    MessageBox.Show("Tạo hợp đồng và lương thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
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