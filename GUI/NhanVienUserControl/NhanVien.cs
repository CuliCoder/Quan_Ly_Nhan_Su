using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;

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

        private void ExportExcel(List<EmployeeFullDTO> list, string filePath)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Danh_Sach_Nhan_Vien");
                var props = typeof(EmployeeFullDTO).GetProperties();

                for (int i = 0; i < props.Length; i++)
                {
                    ws.Cells[1, i + 1].Value = props[i].Name;
                    ws.Cells[1, i + 1].Style.Font.Bold = true;
                    ws.Cells[1, i + 1].Style.Font.Size = 13;

                    ws.Column(i + 1).Style.Numberformat.Format = "@";
                }

                for (int row = 0; row < list.Count; row++)
                {
                    for (int col = 0; col < props.Length; col++)
                    {
                        ws.Cells[row + 2, col + 1].Value = props[col].GetValue(list[row]);
                    }
                }

                ws.Cells.AutoFitColumns();
                package.SaveAs(new FileInfo(filePath));
            }
        }


        private void exportBtn_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();
            save.Filter = "Excel Files|*.xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                ExportExcel(listEmployyeFull, save.FileName);
                MessageBox.Show("Xuất Excel thành công!");
            }

        }
    }
}
