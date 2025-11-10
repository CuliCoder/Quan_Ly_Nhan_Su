using Quan_Ly_Nhan_Su.BLL;
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

namespace Quan_Ly_Nhan_Su.GUI.NhanVienUserControl
{
    public partial class NhanVien : UserControl
    {
        //phần này chưa được validate
        NhanVienNhapLieu nhanVienNhapLieu = new NhanVienNhapLieu();
        private EmployeeFullBLL employeeFullBLL = new EmployeeFullBLL();
        private List<EmployeeFullDTO> listEmployyeFull = new List<EmployeeFullDTO>();
        public NhanVien()
        {
            InitializeComponent();
            showDataToTable();
            nhanVienNhapLieu.QuayLaiClicked += (s, e) =>
            {
                chuyenMan.Controls.Clear();
                chuyenMan.Controls.Add(danhSachNhanVienPanel);
                danhSachNhanVienPanel.Dock = DockStyle.Fill;
                showDataToTable();
            };
        }

        private void fillDataToTable(List<EmployeeFullDTO> listEmployyeFull)
        {
            tableData.DataSource = null;
            tableData.DataSource = listEmployyeFull;
            tableData.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            tableData.Columns["HoTen"].HeaderText = "Họ Tên";
            tableData.Columns["GioiTinh"].HeaderText = "Giới Tính";
            tableData.Columns["Sdt"].HeaderText = "SĐT";
            tableData.Columns["Email"].HeaderText = "Email";
            tableData.Columns["PhongBan"].HeaderText = "Phòng Ban";
            tableData.Columns["ChucVu"].HeaderText = "Chức Vụ";
            tableData.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";

            tableData.Columns["HocVan"].Visible = false;
            tableData.Columns["ChuyenNganh"].Visible = false;
            tableData.Columns["MucLuong"].Visible = false;
            tableData.Columns["SoCmnd"].Visible = false;
            tableData.Columns["DiaChi"].Visible = false;

            if (tableData.Columns.Contains("HinhAnh"))
            {
                tableData.Columns["HinhAnh"].Visible = false;
            }
            tableData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

        }
        private void showDataToTable()
        {
            listEmployyeFull = employeeFullBLL.GetAllEmployees();
            fillDataToTable(listEmployyeFull);
        }

        private void addUserControl(UserControl userControl)
        {
            if (userControl == null) return;

            userControl.Dock = DockStyle.Fill;
            chuyenMan.Controls.Clear();
            chuyenMan.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            addUserControl(nhanVienNhapLieu);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            showDataToTable();
        }

        private void searchEmployee()
        {
            List< EmployeeFullDTO> filteredList = new List<EmployeeFullDTO>();
            string keyword = tbSearch.Text.Trim().ToLower();
            filteredList = employeeFullBLL.SearchEmployeesLINQ(keyword);
            fillDataToTable(filteredList);
        }
        private void tbSearch_TextChanged(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchEmployee();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            searchEmployee();
        }

        private void btnSearchDay_Click(object sender, EventArgs e)
        {

        }
    }
}
