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
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.GUI; // for BillFormGUI
using System.Globalization;

namespace Quan_Ly_Nhan_Su.GUI.LuongThuongUserControl
{
    public partial class LuongThuong : UserControl
    {
        private SalaryFullBLL salaryFullBLL = new SalaryFullBLL();
        private List<SalaryFullDTO> listSalaryFull;
        private EmployeeBLL employeeBLL = new EmployeeBLL();
        private List<EmployeeDTO> listEmployee;
        private BonusBLL bonusBLL = new BonusBLL();
        private List<BonusDTO> listBonus;
        private AllowanceDeductionBLL allowanceDeductionBLL = new AllowanceDeductionBLL();
        private List<AllowanceDeductionDTO> listAllowanceDeduction;

        // Keep cached salary lists by month/year
        private List<SalaryFullDTO> currentMonthSalaries = new List<SalaryFullDTO>();

        public LuongThuong()
        {
            InitializeComponent();
            LoadEmployeeComboBox();
            ShowDataToTable();

            // Wire print/export button
            this.btnTinhLuong.Click += BtnTinhLuong_Click;

            // Fill monthly summary after loading data
            PopulateMonthlySummary();
        }

        private void BtnTinhLuong_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                DataGridViewRow row = null;
                if (dataBangLuong.SelectedRows != null && dataBangLuong.SelectedRows.Count > 0)
                {
                    row = dataBangLuong.SelectedRows[0];
                }
                else if (dataBangLuong.CurrentRow != null)
                {
                    row = dataBangLuong.CurrentRow;
                }

                if (row == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xuất phiếu lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string maNhanVien = null;
                // Prefer column with Name or DataPropertyName 'MaNhanVien'
                var colByName = dataBangLuong.Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => string.Equals(c.Name, "MaNhanVien", StringComparison.OrdinalIgnoreCase) ||
                                         string.Equals(c.DataPropertyName, "MaNhanVien", StringComparison.OrdinalIgnoreCase) ||
                                         string.Equals(c.HeaderText, "Mã Nhân Viên", StringComparison.OrdinalIgnoreCase));

                if (colByName != null)
                {
                    maNhanVien = row.Cells[colByName.Index].Value?.ToString();
                }
                else if (row.Cells.Count > 1)
                {
                    // fallback to second cell which typically holds MaNhanVien in the grid screenshot
                    maNhanVien = row.Cells[1]?.Value?.ToString();
                }

                if (string.IsNullOrWhiteSpace(maNhanVien))
                {
                    MessageBox.Show("Không lấy được mã nhân viên từ dòng đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Open BillFormGUI with the selected employee code
                using (var form = new BillFormGUI(maNhanVien))
                {
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất phiếu lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillDataToBangLuongTable(List<SalaryFullDTO> listSalaryFull)
        {
            dataBangLuong.DataSource = null;
            dataBangLuong.DataSource = listSalaryFull;

            dataBangLuong.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dataBangLuong.Columns["MaLuong"].HeaderText = "Mã Lương";
            dataBangLuong.Columns["LuongCoBan"].HeaderText = "Lương Cơ Bản";
            dataBangLuong.Columns["LuongTheoGio"].HeaderText = "Lương Theo Giờ";
            dataBangLuong.Columns["TongPhuCap"].HeaderText = "Tổng Phụ Cấp";
            dataBangLuong.Columns["TongKhoanTru"].HeaderText = "Tổng Khoản Trừ";
            dataBangLuong.Columns["TongThuong"].HeaderText = "Tổng Thưởng(%)";
            dataBangLuong.Columns["TongGioLam"].HeaderText = "Tổng Giờ Làm";
            dataBangLuong.Columns["LuongThucLanh"].HeaderText = "Lương Thực Lãnh";

            dataBangLuong.Columns["LuongCoBan"].DefaultCellStyle.Format = "N0";
            dataBangLuong.Columns["LuongTheoGio"].DefaultCellStyle.Format = "N0";
            dataBangLuong.Columns["TongPhuCap"].DefaultCellStyle.Format = "N0";
            dataBangLuong.Columns["TongKhoanTru"].DefaultCellStyle.Format = "N0";
            dataBangLuong.Columns["TongThuong"].DefaultCellStyle.Format = "N0";
            dataBangLuong.Columns["LuongThucLanh"].DefaultCellStyle.Format = "N0";

            dataBangLuong.Columns["TongGioLam"].DefaultCellStyle.Format = "N2";

            dataBangLuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataBangLuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FillDataToThuongTable(List<BonusDTO> listBonus)
        {
            dataThuong.DataSource = null;
            dataThuong.DataSource = listBonus;
            dataThuong.Columns["MaThuong"].HeaderText = "Mã Thưởng";
            dataThuong.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dataThuong.Columns["TenThuong"].HeaderText = "Tên Thưởng";
            dataThuong.Columns["PhanTramThuong"].HeaderText = "Phần trăm thưởng";
            dataThuong.Columns["ThangApDung"].HeaderText = "ThanhApDung";
            dataThuong.Columns["NamApDung"].HeaderText = "NamApDung";

            dataThuong.Columns["PhanTramThuong"].DefaultCellStyle.Format = "N0";

            dataThuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataThuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FillDataToPCKTTable(List<AllowanceDeductionDTO> listAllowanceDeduction)
        {
            dataPCKT.DataSource = null;
            dataPCKT.DataSource = listAllowanceDeduction;
            dataPCKT.Columns["MaPhuCapKhoanTru"].HeaderText = "Mã PCKT";
            dataPCKT.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dataPCKT.Columns["MoTa"].HeaderText = "Mô Tả";
            dataPCKT.Columns["SoTien"].HeaderText = "Số Tiền";
            dataPCKT.Columns["ThangApDung"].HeaderText = "ThanhApDung";
            dataPCKT.Columns["NamApDung"].HeaderText = "NamApDung";

            dataPCKT.Columns["SoTien"].DefaultCellStyle.Format = "N0";

            dataPCKT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataPCKT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ShowDataToTable()
        {
            listSalaryFull = salaryFullBLL.GetAllSalaryFull();
            FillDataToBangLuongTable(listSalaryFull);
            listBonus = bonusBLL.GetAllBonuses();
            FillDataToThuongTable(listBonus);
            listAllowanceDeduction = allowanceDeductionBLL.GetAll(); 
            FillDataToPCKTTable(listAllowanceDeduction);
        }

        private void LoadEmployeeComboBox()
        {
            try
            {
                listEmployee = employeeBLL.GetAll();
                var list = listEmployee;
                cbThuong.DataSource = list;
                cbThuong.DisplayMember = "MaNhanVien";
                cbThuong.ValueMember = "MaNhanVien";
                cbThuong.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void SearchData()
        {
            if(tbSearch.Text == null)
            {
                dataBangLuong.DataSource = null;
                dataBangLuong.DataSource = listSalaryFull;
            } else
            {
                string keyword = tbSearch.Text.Trim().ToLower();
                int thang = dateFilterThuong.Value.Month;
                int nam = dateFilterThuong.Value.Year;

                var filteredList = salaryFullBLL.GetSalaryFullByMonthYear(thang, nam)
                    .Where(s =>
                        (s.MaNhanVien.ToLower().Contains(keyword) ||
                         s.MaLuong.ToLower().Contains(keyword)))
                    .ToList();

                dataBangLuong.DataSource = null;
                dataBangLuong.DataSource = filteredList;
            }
        }

        private void SearchThuongData()
        {
            if (tbSearch2.Text == null)
            {
                dataThuong.DataSource = null;
                dataThuong.DataSource = listBonus;
            }
            else
            {
                string keyword = tbSearch2.Text.Trim().ToLower();
                int thang = dateTimePicker2.Value.Month;
                int nam = dateTimePicker2.Value.Year;

                var filteredList = listBonus
                    .Where(s =>
                        (s.ThangApDung == thang && s.NamApDung == nam) &&
                        (s.MaNhanVien.ToLower().Contains(keyword) ||
                        s.MaThuong.ToString().Contains(keyword) ||
                        s.TenThuong.ToLower().Contains(keyword)))
                    .ToList();

                dataThuong.DataSource = null;
                dataThuong.DataSource = filteredList;
            }
        }

        private void SearchPCKTData()
        {
            if (tbLocPCKT.Text == null)
            {
                dataPCKT.DataSource = null;
                dataPCKT.DataSource = listAllowanceDeduction;
            }
            else
            {
                string keyword = tbLocPCKT.Text.Trim().ToLower();
                int thang = dateLocPCKT.Value.Month;
                int nam = dateLocPCKT.Value.Year;

                var filteredList = listAllowanceDeduction
                    .Where(s =>
                        (s.ThangApDung == thang && s.NamApDung == nam) &&
                        (s.MaNhanVien.ToLower().Contains(keyword) ||
                        s.MaPhuCapKhoanTru.ToString().Contains(keyword) ||
                        s.MoTa.ToLower().Contains(keyword)))
                    .ToList();

                dataPCKT.DataSource = null;
                dataPCKT.DataSource = filteredList;
            }
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void btnLoc1_Click(object sender, EventArgs e)
        {
            int thang = dateFilterThuong.Value.Month;
            int nam = dateFilterThuong.Value.Year;

            var filteredList = salaryFullBLL.GetSalaryFullByMonthYear(thang, nam);
            dataBangLuong.DataSource = null;
            dataBangLuong.DataSource = filteredList;
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void btnLocThuong_Click(object sender, EventArgs e)
        {
            int thang = dateTimePicker2.Value.Month;
            int nam = dateTimePicker2.Value.Year;

            var filteredList = listBonus
                .Where(s => s.ThangApDung == thang && s.NamApDung == nam)
                .ToList();

            dataThuong.DataSource = null;
            dataThuong.DataSource = filteredList;
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            SearchThuongData();
        }

        private void btnThemThuong_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = "1";
                string tenThuong = tbThuong.Text.Trim();
                decimal phanTram = decimal.Parse(tbMucThuong.Text.Trim());

                int thang = dateTimePicker2.Value.Month;
                int nam = dateTimePicker2.Value.Year;

                if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenThuong))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                BonusDTO bonus= new BonusDTO(maNV, tenThuong, phanTram, thang, nam);
                bool result = bonusBLL.AddBonus(bonus);

                if (result)
                {
                    MessageBox.Show("Thêm thưởng thành công!");
                    listBonus = bonusBLL.GetAllBonuses();
                    dataThuong.DataSource = null;
                    dataThuong.DataSource = listBonus;
                }    

                else
                    MessageBox.Show("Không thể thêm thưởng!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Phần trăm thưởng phải là số hợp lệ!");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnLocPCKT_Click(object sender, EventArgs e)
        {
            SearchPCKTData();
        }

        private void btnSearchPCKT_Click(object sender, EventArgs e)
        {
            int thang = dateLocPCKT.Value.Month;
            int nam = dateLocPCKT.Value.Year;

            var filteredList = listAllowanceDeduction
                .Where(s => s.ThangApDung == thang && s.NamApDung == nam)
                .ToList();

            dataPCKT.DataSource = null;
            dataPCKT.DataSource = filteredList;
        }

        private void btnPC_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = "1";
                string moTa = tbNotePC.Text.Trim();
                decimal soTien = decimal.Parse(tbSoTienPC.Text.Trim());

                int thang = datePC.Value.Month;
                int nam = datePC.Value.Year;
                string loai = "PhuCap";

                if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(moTa))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                AllowanceDeductionDTO pCKT = new AllowanceDeductionDTO(maNV, loai, moTa, soTien, thang, nam);
                bool result = allowanceDeductionBLL.Insert(pCKT);

                if (result)
                {
                    MessageBox.Show("Thêm phụ cấp thành công!");
                    listAllowanceDeduction = allowanceDeductionBLL.GetAll();
                    dataPCKT.DataSource = null;
                    dataPCKT.DataSource = listAllowanceDeduction;
                }

                else
                    MessageBox.Show("Không thể thêm phụ cấp!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Số tiền phải là số hợp lệ!");
            }
        }

        private void btnKT_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = "1";
                string moTa = tbNotePC.Text.Trim();
                decimal soTien = decimal.Parse(tbSoTienPC.Text.Trim());

                int thang = datePC.Value.Month;
                int nam = datePC.Value.Year;
                string loai = "KhoanTru";

                if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(moTa))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                AllowanceDeductionDTO pCKT = new AllowanceDeductionDTO(maNV, loai, moTa, soTien, thang, nam);
                bool result = allowanceDeductionBLL.Insert(pCKT);

                if (result)
                {
                    MessageBox.Show("Thêm khoản trừ thành công!");
                    listAllowanceDeduction = allowanceDeductionBLL.GetAll();
                    dataPCKT.DataSource = null;
                    dataPCKT.DataSource = listAllowanceDeduction;
                }

                else
                    MessageBox.Show("Không thể thêm khoản trừ!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Số tiền phải là số hợp lệ!");
            }
        }

        private void PopulateMonthlySummary()
        {
            try
            {
                // We'll show 12 months for current year (could be adjusted)
                int year = DateTime.Now.Year;
                var summary = new List<dynamic>();

                for (int m = 1; m <= 12; m++)
                {
                    var salaries = salaryFullBLL.GetSalaryFullByMonthYear(m, year);
                    decimal total = salaries.Sum(s => s.LuongThucLanh);
                    summary.Add(new { Thang = m, Nam = year, TongLuong = total, Xem = "Xem chi tiết" });
                }

                dataMonthlySummary.DataSource = null;
                dataMonthlySummary.DataSource = summary;

                // Format headers
                dataMonthlySummary.Columns["Thang"].HeaderText = "Tháng";
                dataMonthlySummary.Columns["Nam"].Visible = false;
                dataMonthlySummary.Columns["TongLuong"].HeaderText = "Tổng Lương nhân viên trong tháng";
                dataMonthlySummary.Columns["TongLuong"].DefaultCellStyle.Format = "N0";
                dataMonthlySummary.Columns["Xem"].HeaderText = " ";

                // Make Xem column look like link
                if (!dataMonthlySummary.Columns.Contains("XemLink"))
                {
                    var linkCol = new DataGridViewButtonColumn();
                    linkCol.Name = "XemLink";
                    linkCol.HeaderText = " ";
                    linkCol.Text = "Xem chi tiết";
                    linkCol.UseColumnTextForButtonValue = true;
                    dataMonthlySummary.Columns.Add(linkCol);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo bảng tổng hợp tháng: " + ex.Message);
            }
        }

        private void dataMonthlySummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // If clicked the button column we added
            if (dataMonthlySummary.Columns[e.ColumnIndex] is DataGridViewButtonColumn || dataMonthlySummary.Columns[e.ColumnIndex].Name == "XemLink")
            {
                var row = dataMonthlySummary.Rows[e.RowIndex];
                int thang = Convert.ToInt32(row.Cells["Thang"].Value);
                int nam = DateTime.Now.Year;
                // If Nam column exists, use it
                if (dataMonthlySummary.Columns.Contains("Nam"))
                {
                    int.TryParse(row.Cells["Nam"].Value?.ToString(), out nam);
                }

                // Load salaries for that month and show in dataBangLuong
                currentMonthSalaries = salaryFullBLL.GetSalaryFullByMonthYear(thang, nam);
                dataBangLuong.DataSource = null;
                dataBangLuong.DataSource = currentMonthSalaries;
                // Apply same formatting
                FillDataToBangLuongTable(currentMonthSalaries);
            }
        }
    }
}
