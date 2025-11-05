using Org.BouncyCastle.Math.Field;
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

namespace Quan_Ly_Nhan_Su.GUI.PhongBanUserControl
{
    public partial class editDepartment : Form
    {
        EmployeeBLL employeeBLL = new EmployeeBLL();
        EmployeeFullBLL employeeFullBLL = new EmployeeFullBLL();
        DepartmentBLL departmentBLL = new DepartmentBLL();
        DepartmentDTO beforDepartment = null;
        public editDepartment(DepartmentDTO department)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            beforDepartment = department;
            loadDate(department);
        }
        public void loadDate(DepartmentDTO department)
        {
            textTPB.Font = new Font("Montserrat", 12, FontStyle.Bold);
            textTPB.Text = department.TenPhong;
            cbbTP.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTP.Font = new Font("Montserrat", 12, FontStyle.Bold);
            cbbTP.BackColor = Color.White;
            cbbTP.ForeColor = Color.Black;
            cbbTP.FlatStyle = FlatStyle.Flat;
            var listNV = new EmployeeBLL().GetAll().
                Where(e => !string.IsNullOrWhiteSpace(e.MaPhong) &&
                !string.IsNullOrWhiteSpace(department.MaPhong) &&
                e.MaPhong.Trim().Equals(department.MaPhong.Trim(), StringComparison.OrdinalIgnoreCase));
            int count = 0;
            foreach (var nv in listNV)
            {
                var temp = employeeFullBLL.GetEmployeeById(nv.MaNhanVien.Trim());
                cbbTP.Items.Add(nv.MaNhanVien + " - " + temp.HoTen);
                if (!string.IsNullOrWhiteSpace(department.MaTruongPhong) &&
                    !string.IsNullOrWhiteSpace(nv.MaNhanVien) &&
                    department.MaTruongPhong.Trim().Equals(nv.MaNhanVien.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    cbbTP.SelectedIndex = count;
                }
                count++;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textTPB.Text.Trim() == null || cbbTP.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }    
            string selected = cbbTP.SelectedItem.ToString();
            string[] parts = selected.Split(new[] { " - " }, StringSplitOptions.None);
            string maNhanVien = parts.Length > 0 ? parts[0].Trim() : "";
            if (beforDepartment.TenPhong.Trim().Equals(textTPB.Text.Trim()) &&
                beforDepartment.MaTruongPhong.Trim().Equals(maNhanVien.Trim()))
            {
                MessageBox.Show("Không có thay đổi để cập nhật!");
                return;
            }
            else
            {
                var checkUpdate_Department = departmentBLL.UpdateDepartment(new DepartmentDTO(
                    beforDepartment.MaPhong,
                    beforDepartment.TenPhong.Trim().Equals(textTPB.Text.Trim()) ? beforDepartment.TenPhong : textTPB.Text.Trim(),
                    beforDepartment.NgayThanhLap,
                    beforDepartment.MaTruongPhong.Trim().Equals(maNhanVien.Trim()) ? beforDepartment.MaTruongPhong : maNhanVien));
                if (!checkUpdate_Department)
                {
                    MessageBox.Show("Cập nhật phòng ban thất bại!");
                    return;
                }
                if (!beforDepartment.MaTruongPhong.Trim().Equals(maNhanVien.Trim()))
                {
                    Console.WriteLine(maNhanVien);
                    if (!employeeBLL.UpdateChucVu(beforDepartment.MaTruongPhong, "CV003") ||
                        !employeeBLL.UpdateChucVu(maNhanVien, "CV001"))
                    {
                        MessageBox.Show("Cập nhật chức vụ trưởng phòng thất bại!");
                        return;
                    }
                }
                MessageBox.Show("Cập nhật phòng ban thành công!");
                this.Close();
            }
        }
    }
}
