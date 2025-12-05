using OfficeOpenXml;
using Org.BouncyCastle.Asn1.X509;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.Constants;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.NhanVienUserControl
{
    public partial class NhanVien : UserControl
    {
        private readonly NhanVienNhapLieu nhanVienNhapLieu;

        private readonly EmployeeFullBLL employeeFullBLL;
        private readonly EmployeeBLL employeeBLL;
        private List<EmployeeFullDTO> listEmployyeFull;
        public NhanVien()
        {
            InitializeComponent();

            nhanVienNhapLieu = new NhanVienNhapLieu();
            employeeFullBLL = new EmployeeFullBLL();
            listEmployyeFull = new List<EmployeeFullDTO>();
            employeeBLL = new EmployeeBLL();

            showDataToTable();
            nhanVienNhapLieu.QuayLaiClicked += (s, e) =>
            {
                chuyenMan.Controls.Clear();
                chuyenMan.Controls.Add(danhSachNhanVienPanel);
                danhSachNhanVienPanel.Dock = DockStyle.Fill;
                showDataToTable();
            };
            tableData.CellClick += tableData_CellContentClick;
            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            bool canCreate = SessionManager.Instance.CanCreate(FunctionNames.NHAN_VIEN);

            layoutThem.Visible = canCreate;
            importBtn.Visible = canCreate;

            bool canRead = SessionManager.Instance.CanRead(FunctionNames.NHAN_VIEN);
            importBtn.Visible = canRead;
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

            tableData.Columns["NoiCap"].Visible = false;
            tableData.Columns["NgayCap"].Visible = false;
            tableData.Columns["DanToc"].Visible = false;
            tableData.Columns["TinhTranHonNhan"].Visible = false;
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
            try
            {
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add("Danh_Sach_Nhan_Vien");
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
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xuất file: " + ex.Message);
            }
        }

        public List<EmployeeFullDTO> ImportExcel(string filePath)
        {
            List<EmployeeFullDTO> listImport = new List<EmployeeFullDTO>();
            List<string> errors = new List<string>();

            try { 
            
                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    if (package.Workbook.Worksheets.Count == 0)
                        throw new Exception("File Excel không có Sheet nào!");
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

                    if (worksheet.Dimension == null) return listImport;

                    int rowCount = worksheet.Dimension.End.Row;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            EmployeeFullDTO emp = new EmployeeFullDTO();

                            emp.MaNhanVien = null;              
                            emp.HoTen = worksheet.Cells[row, 2].Text;
                            emp.NgaySinh = GetSafeDate(worksheet.Cells[row, 3], DateTime.Now);
                            emp.GioiTinh = worksheet.Cells[row, 4].Text;
                            emp.Email = worksheet.Cells[row, 5].Text;
                            emp.Sdt = worksheet.Cells[row, 6].Text;
                            emp.SoCmnd = worksheet.Cells[row, 7].Text;
                            emp.NoiCap = worksheet.Cells[row, 8].Text;
                            emp.NgayCap = GetSafeDate(worksheet.Cells[row, 9], DateTime.Now);
                            emp.DanToc = worksheet.Cells[row, 10].Text;
                            emp.TinhTranHonNhan = worksheet.Cells[row, 11].Text;
                            emp.HocVan = worksheet.Cells[row, 12].Text;
                            emp.ChuyenNganh = worksheet.Cells[row, 13].Text;
                            emp.PhongBan = worksheet.Cells[row, 14].Text;
                            emp.MaChucVu = worksheet.Cells[row, 15].Text; ;
                            emp.ChucVu = worksheet.Cells[row, 16].Text;
                            emp.MucLuong = GetSafeDecimal(worksheet.Cells[row, 17]);
                            emp.DiaChi = worksheet.Cells[row, 18].Text;
                            emp.HinhAnh = worksheet.Cells[row, 19].Text;
                            listImport.Add(emp);
                        }
                        catch (Exception ex)
                        {                       
                            errors.Add($"Dòng {row}: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đọc file: " + ex.Message);
            }

            if (listImport.Count == 0 && errors.Count > 0)
            {
                string msg = string.Join("\n", errors.Take(3));
                throw new Exception("Không import được dòng nào. Lỗi mẫu:\n" + msg);
            }

            return listImport;
        }

        private void displayEmployeeDetails(EmployeeFullDTO employee)
        {
            if (employee == null) return;

            txtTenLb.Text = employee.HoTen;
            txtGioiTinhLb.Text = employee.GioiTinh;
            txtNgaySinhLB.Text = employee.NgaySinh?.ToString("dd/MM/yyyy") ?? "";
            txtEmailLb.Text = employee.Email;
            txtSDTLb.Text = employee.Sdt;
            if (!string.IsNullOrEmpty(employee.DiaChi))
            {
                string[] parts = employee.DiaChi.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = parts[i].Trim();
                }
                if (parts.Length > 0) txtDuongLB.Text = parts[0];
                if (parts.Length > 1) txtPhuongXaLb.Text = parts[1];
                if (parts.Length > 2) txtQuanHuyenLb.Text = parts[2];
                if (parts.Length > 3) txtTinhTpLb.Text = parts[3];
            }
            else
            {
                txtDuongLB.Text = txtPhuongXaLb.Text = txtQuanHuyenLb.Text = txtTinhTpLb.Text = "";
            }
            txtCcd.Text = employee.SoCmnd;
            txtChuyenNganhLb .Text = employee.ChuyenNganh;
            txtDanTocLb.Text = employee.DanToc;
            txtHonNhanLB.Text = employee.TinhTranHonNhan;
            txtTrinhDoLB.Text = employee.HocVan;

            try
            {
                string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string imagePath = Path.Combine(projectPath, employee.HinhAnh ?? "");
                string defaultImagePath = Path.Combine(projectPath, @"GUI\assets\img\images.png");

                string finalPath = "";

                if (!string.IsNullOrEmpty(employee.HinhAnh) && File.Exists(imagePath))
                    finalPath = imagePath;
                else if (File.Exists(defaultImagePath))
                    finalPath = defaultImagePath;
                else
                    finalPath = "";
                if (!string.IsNullOrEmpty(finalPath))
                    pictureBox1.Image = Image.FromFile(finalPath);
                else
                    pictureBox1.Image = null;
            }
            catch (Exception ex)
            {
                pictureBox1.Image = null;
                MessageBox.Show("Lỗi tải ảnh: " + ex.Message);
            }
        }

        private DateTime GetSafeDate(ExcelRange cell, DateTime defaultValue)
        {
            if (cell.Value == null) return defaultValue;
            if (cell.Value is DateTime dt) return dt;
            if (cell.Value is double || cell.Value is int || cell.Value is decimal)
            {
                try { return DateTime.FromOADate(Convert.ToDouble(cell.Value)); }
                catch { return defaultValue; }
            }
            if (DateTime.TryParse(cell.Text, out DateTime parsedDate))
            {
                return parsedDate;
            }

            return defaultValue;
        }

        private decimal GetSafeDecimal(ExcelRange cell)
        {
            if (cell.Value == null) return 0;
            if (cell.Value is double || cell.Value is int || cell.Value is decimal)
            {
                return Convert.ToDecimal(cell.Value);
            }

            string cleanText = cell.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(cleanText, out decimal result))
            {
                return result;
            }
            return 0;
        }


        private void exportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Lưu file Excel";
            save.Filter = "Excel Files|*.xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {            
                ExportExcel(listEmployyeFull, save.FileName);
                MessageBox.Show("Xuất Excel thành công!");
            }
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn file excel";
                openFileDialog.Filter = "Excel Files|*.xlsx";
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    List<EmployeeFullDTO> importedEmployees =  ImportExcel(openFileDialog.FileName);
                    if (employeeBLL.ImportExcelEmployees(importedEmployees))
                    {                    
                        MessageBox.Show("Nhập Excel thành công!");
                        showDataToTable();
                    }
                    else
                        MessageBox.Show("Nhập Excel thất bại!");
                }
            }
        }

        private void tableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = tableData.Rows[e.RowIndex];
                string maNhanVien = selectedRow.Cells["MaNhanVien"].Value.ToString();
                EmployeeFullDTO employee = employeeFullBLL.GetEmployeeById(maNhanVien);
                displayEmployeeDetails(employee);
            }
        }
    }
}
