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
        private PositionBLL positionBLL; // NEW

        // Navigation order for Up/Down arrow key handling
        private List<Control> navigationOrder;

        // Dynamic combo for chức vụ -> lương theo giờ
        private ComboBox comboBoxChucVu; // NEW

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
            positionBLL = new PositionBLL(); // NEW
        }

        private void InitializeForm()
        {
            // Tự động sinh mã hợp đồng
            GenerateContractId();

            // Load danh sách nhân viên chưa ký hợp đồng và phòng ban
            LoadEmployees();
            LoadDepartments();

            // Load positions for luong theo gio
            LoadPositions(); // NEW

            // Thiết lập combobox loại hợp đồng (tĩnh, không load từ DB)
            comboBoxLoaiHopDong.Items.AddRange(new object[] { "Xác định thời hạn", "Không thời hạn" });
            comboBoxLoaiHopDong.SelectedIndex = 0;

            // Không set ngày mặc định, user tự chọn
            // Không load lương, để user nhập

            // Ẩn trường "Đến ngày" ban đầu
            ToggleDateToField();

            // Wire event cho combo loại hợp đồng để toggle DenNgay
            comboBoxLoaiHopDong.SelectedIndexChanged += ComboBoxLoaiHopDong_SelectedIndexChanged;

            // Thiết lập thứ tự điều khiển cho phím mũi tên
            navigationOrder = new List<Control>
            {
                comboBoxNhanVien,
                comboBoxPhongBan,
                comboBoxLoaiHopDong,
                dateTimePickerTuNgay,
                dateTimePickerDenNgay,
                textBoxMucLuong,
                textBoxLuongTheoGio,
                buttonTaoHopDong,
                buttonHuy
            };

            // If we created dynamic combo, replace textbox entry
            if (comboBoxChucVu != null)
            {
                int idx = navigationOrder.IndexOf(textBoxLuongTheoGio);
                if (idx >= 0)
                {
                    navigationOrder[idx] = comboBoxChucVu;
                }
            }

            AttachNavigationHandlers();

            // Clear highlights when user edits fields
            AttachClearHighlightHandlers();
        }

        // NEW: Load chuc vu into combobox and wire selection changed to set luong theo gio
        private void LoadPositions()
        {
            try
            {
                var positions = positionBLL.GetAllPositions();
                if (positions == null || positions.Count == 0)
                {
                    // hide combo and show textbox as fallback
                    comboBoxChucVu = null;
                    textBoxLuongTheoGio.Visible = true;
                    return;
                }

                // create combobox dynamically and insert into panelLuongTheoGio below label
                comboBoxChucVu = new ComboBox();
                comboBoxChucVu.Name = "comboBoxChucVu";
                comboBoxChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxChucVu.Font = textBoxLuongTheoGio.Font;
                comboBoxChucVu.Dock = DockStyle.Top;
                comboBoxChucVu.DisplayMember = "Display";
                comboBoxChucVu.ValueMember = "MaChucVu";

                var data = positions.Select(p => new
                {
                    MaChucVu = p.MaChucVu,
                    Display = string.IsNullOrEmpty(p.TenChucVu) ? p.MaChucVu : $"{p.TenChucVu} ({p.MaChucVu})"
                }).ToList();

                comboBoxChucVu.DataSource = data;
                comboBoxChucVu.SelectedIndex = -1;
                comboBoxChucVu.SelectedIndexChanged += ComboBoxChucVu_SelectedIndexChanged;

                // hide the plain textbox and add combo
                textBoxLuongTheoGio.Visible = false;
                // ensure combo is above/have same padding
                panelLuongTheoGio.Controls.Add(comboBoxChucVu);
                panelLuongTheoGio.Controls.SetChildIndex(comboBoxChucVu, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("LoadPositions error: " + ex.Message);
                // fallback keep textbox visible
                textBoxLuongTheoGio.Visible = true;
            }
        }

        private void ComboBoxChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxChucVu == null) return;
                var ma = comboBoxChucVu.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(ma))
                {
                    textBoxLuongTheoGio.Text = "0";
                    return;
                }
                decimal luong = positionBLL.GetLuongTheoGio(ma);
                // display formatted value in textbox (hidden) so existing logic works
                textBoxLuongTheoGio.Text = luong.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error selecting chuc vu: " + ex.Message);
            }
        }

        private void ComboBoxLoaiHopDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleDateToField();
        }

        private void ToggleDateToField()
        {
            bool isXacDinh = comboBoxLoaiHopDong.SelectedItem?.ToString() == "Xác định thời hạn";
            labelDenNgay.Visible = dateTimePickerDenNgay.Visible = isXacDinh;

            // If hidden, ensure any previous highlight is cleared
            if (!isXacDinh)
            {
                ClearHighlight(dateTimePickerDenNgay);
                ResetLabelColor(labelDenNgay);
            }
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
            // Clear previous highlights
            ClearAllHighlights();

            List<Control> invalids = new List<Control>();

            if (string.IsNullOrWhiteSpace(textBoxMaHopDong.Text))
            {
                invalids.Add(textBoxMaHopDong);
                HighlightLabel(labelMaHopDong);
            }

            if (comboBoxNhanVien.SelectedIndex == -1)
            {
                invalids.Add(comboBoxNhanVien);
                HighlightLabel(labelNhanVien);
            }

            if (comboBoxPhongBan.SelectedIndex == -1)
            {
                invalids.Add(comboBoxPhongBan);
                HighlightLabel(labelPhongBan);
            }

            if (comboBoxLoaiHopDong.SelectedIndex == -1)
            {
                invalids.Add(comboBoxLoaiHopDong);
                HighlightLabel(labelLoaiHopDong);
            }

            if (dateTimePickerTuNgay.Value == default(DateTime))
            {
                invalids.Add(dateTimePickerTuNgay);
                HighlightLabel(labelTuNgay);
            }

            bool isXacDinh = comboBoxLoaiHopDong.Text == "Xác định thời hạn";
            if (isXacDinh && dateTimePickerDenNgay.Value == default(DateTime))
            {
                invalids.Add(dateTimePickerDenNgay);
                HighlightLabel(labelDenNgay);
            }

            if (isXacDinh && dateTimePickerDenNgay.Value <= dateTimePickerTuNgay.Value)
            {
                invalids.Add(dateTimePickerDenNgay);
                invalids.Add(dateTimePickerTuNgay);
                HighlightLabel(labelDenNgay);
                HighlightLabel(labelTuNgay);
            }

            if (string.IsNullOrWhiteSpace(textBoxMucLuong.Text) || !decimal.TryParse(textBoxMucLuong.Text, out decimal luong))
            {
                invalids.Add(textBoxMucLuong);
                HighlightLabel(labelMucLuong);
            }
            else if (luong <= 0)
            {
                invalids.Add(textBoxMucLuong);
                HighlightLabel(labelMucLuong);
            }

            // If position combo exists, require a selection (so we can determine LuongTheoGio)
            if (comboBoxChucVu != null)
            {
                if (comboBoxChucVu.SelectedIndex == -1)
                {
                    invalids.Add(comboBoxChucVu);
                    HighlightLabel(labelLuongTheoGio);
                }
            }

             // If there are invalid controls, visually mark them and focus the first one
             if (invalids.Count > 0)
             {
                 foreach (var ctl in invalids.Distinct())
                 {
                     HighlightControl(ctl);
                 }

                 // Focus first invalid control
                 var first = invalids.First();
                 try { first.Focus(); } catch { }

                 MessageBox.Show("Vui lòng hoàn thành các trường được đánh dấu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return false;
             }

             return true;
         }

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
                // If position combobox exists and is selected, use its luongTheoGio from DB
                if (comboBoxChucVu != null && comboBoxChucVu.SelectedIndex != -1)
                {
                    var maChucVu = comboBoxChucVu.SelectedValue?.ToString();
                    if (!string.IsNullOrEmpty(maChucVu)) luongTheoGio = positionBLL.GetLuongTheoGio(maChucVu);
                }
                else
                {
                    decimal.TryParse(textBoxLuongTheoGio.Text, out luongTheoGio);
                }

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

            // reset position combo
            if (comboBoxChucVu != null)
            {
                comboBoxChucVu.SelectedIndex = -1;
                textBoxLuongTheoGio.Clear();
            }

            ClearAllHighlights();
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

        #region Validation highlight helpers

        private void HighlightControl(Control ctl)
        {
            try
            {
                if (ctl is TextBox || ctl is ComboBox)
                {
                    ctl.BackColor = Color.FromArgb(255, 230, 230);
                }
                else if (ctl is DateTimePicker)
                {
                    // DateTimePicker does not expose BackColor easily in some themes; wrap in locating container
                    ctl.BackColor = Color.FromArgb(255, 230, 230);
                }

                // also highlight matching label if exists
                var lbl = GetLabelForControl(ctl);
                if (lbl != null) lbl.ForeColor = Color.Red;
            }
            catch { }
        }

        private void HighlightLabel(Label lbl)
        {
            if (lbl == null) return;
            lbl.ForeColor = Color.Red;
        }

        private void ClearHighlight(Control ctl)
        {
            try
            {
                if (ctl is TextBox || ctl is ComboBox)
                {
                    ctl.BackColor = Color.White;
                }
                else if (ctl is DateTimePicker)
                {
                    ctl.BackColor = SystemColors.Window;
                }

                var lbl = GetLabelForControl(ctl);
                if (lbl != null) ResetLabelColor(lbl);
            }
            catch { }
        }

        private void ResetLabelColor(Label lbl)
        {
            lbl.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void ClearAllHighlights()
        {
            var all = new Control[] {
                textBoxMaHopDong, comboBoxNhanVien, comboBoxPhongBan, comboBoxLoaiHopDong,
                dateTimePickerTuNgay, dateTimePickerDenNgay, textBoxMucLuong, textBoxLuongTheoGio
            };

            foreach (var ctl in all)
            {
                ClearHighlight(ctl);
            }
        }

        private Label GetLabelForControl(Control ctl)
        {
            if (ctl == textBoxMaHopDong) return labelMaHopDong;
            if (ctl == comboBoxNhanVien) return labelNhanVien;
            if (ctl == comboBoxPhongBan) return labelPhongBan;
            if (ctl == comboBoxLoaiHopDong) return labelLoaiHopDong;
            if (ctl == dateTimePickerTuNgay) return labelTuNgay;
            if (ctl == dateTimePickerDenNgay) return labelDenNgay;
            if (ctl == textBoxMucLuong) return labelMucLuong;
            if (ctl == textBoxLuongTheoGio) return labelLuongTheoGio;
            if (ctl == comboBoxChucVu) return labelLuongTheoGio; // map combo to same label
            return null;
        }

        #endregion

        #region Keyboard navigation helpers

        private void AttachNavigationHandlers()
        {
            foreach (var ctl in navigationOrder)
            {
                if (ctl == null) continue;
                ctl.KeyDown -= Control_KeyDown;
                ctl.KeyDown += Control_KeyDown;

                // PreviewKeyDown ensures arrow keys are captured for controls like ComboBox
                ctl.PreviewKeyDown -= Control_PreviewKeyDown;
                ctl.PreviewKeyDown += Control_PreviewKeyDown;
            }
        }

        private void AttachClearHighlightHandlers()
        {
            // Textboxes
            textBoxMucLuong.TextChanged -= AnyField_Changed; textBoxMucLuong.TextChanged += AnyField_Changed;
            textBoxLuongTheoGio.TextChanged -= AnyField_Changed; textBoxLuongTheoGio.TextChanged += AnyField_Changed;
            // Comboboxes
            comboBoxNhanVien.SelectedIndexChanged -= AnyField_Changed; comboBoxNhanVien.SelectedIndexChanged += AnyField_Changed;
            comboBoxPhongBan.SelectedIndexChanged -= AnyField_Changed; comboBoxPhongBan.SelectedIndexChanged += AnyField_Changed;
            comboBoxLoaiHopDong.SelectedIndexChanged -= AnyField_Changed; comboBoxLoaiHopDong.SelectedIndexChanged += AnyField_Changed;
            if (comboBoxChucVu != null) { comboBoxChucVu.SelectedIndexChanged -= AnyField_Changed; comboBoxChucVu.SelectedIndexChanged += AnyField_Changed; }
            // DateTimePickers
            dateTimePickerTuNgay.ValueChanged -= AnyField_Changed; dateTimePickerTuNgay.ValueChanged += AnyField_Changed;
            dateTimePickerDenNgay.ValueChanged -= AnyField_Changed; dateTimePickerDenNgay.ValueChanged += AnyField_Changed;
        }

        private void AnyField_Changed(object sender, EventArgs e)
        {
            var ctl = sender as Control;
            if (ctl != null) ClearHighlight(ctl);
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                MoveToNextControl(sender as Control, forward: true);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                MoveToNextControl(sender as Control, forward: false);
                e.Handled = true;
            }
        }

        private void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Some controls (ComboBox) won't raise KeyDown for arrow keys unless handled here
            if (e.KeyCode == Keys.Down)
            {
                MoveToNextControl(sender as Control, forward: true);
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                MoveToNextControl(sender as Control, forward: false);
                e.IsInputKey = true;
            }
        }

        private void MoveToNextControl(Control current, bool forward)
        {
            if (navigationOrder == null || navigationOrder.Count == 0) return;

            int idx = navigationOrder.IndexOf(current);
            if (idx == -1)
            {
                // try find by focus
                for (int i = 0; i < navigationOrder.Count; i++) if (navigationOrder[i].Focused) { idx = i; break; }
            }

            if (idx == -1)
            {
                // nothing focused, set first
                var first = navigationOrder.FirstOrDefault(c => c != null && c.Visible && c.Enabled);
                first?.Focus();
                return;
            }

            int start = idx;
            int next = idx;
            do
            {
                next = forward ? next + 1 : next - 1;
                if (next >= navigationOrder.Count) next = 0;
                if (next < 0) next = navigationOrder.Count - 1;

                var candidate = navigationOrder[next];
                if (candidate != null && candidate.Visible && candidate.Enabled)
                {
                    try
                    {
                        candidate.Focus();
                        // for textboxes select all text to ease editing
                        if (candidate is TextBox tb) tb.SelectAll();
                    }
                    catch { }
                    break;
                }
            } while (next != start);
        }

        #endregion
    }
}