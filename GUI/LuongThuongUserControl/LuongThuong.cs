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

        public LuongThuong()
        {
            InitializeComponent();
            LoadEmployeeComboBox();
            ShowDataToTable();
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

        private void ShowDataToTable()
        {
            listSalaryFull = salaryFullBLL.GetAllSalaryFull();
            FillDataToBangLuongTable(listSalaryFull);
            listBonus = bonusBLL.GetAllBonuses();
            FillDataToThuongTable(listBonus);
        }

        private void LoadEmployeeComboBox()
        {
            try
            {
                listEmployee = employeeBLL.GetAll();
                var list = listEmployee;
                cbThuong.DataSource = list;
                cbThuong.DisplayMember = "maNhanVien";
                cbThuong.ValueMember = "maNhanVien";
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
    }
}
