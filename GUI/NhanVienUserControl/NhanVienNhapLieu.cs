using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.NhanVienUserControl
{
    public partial class NhanVienNhapLieu : UserControl
    {
        public event EventHandler QuayLaiClicked;
        private DepartmentBLL department = new DepartmentBLL();
        private EmployeeBLL employee = new EmployeeBLL();
        public event EventHandler suKienLuu;
        public NhanVienNhapLieu()
        {
            InitializeComponent();
            fillDataToCombobox();
            ClearForm();
        }

        private void label1_Click(object sender, EventArgs e) 
        {
            QuayLaiClicked?.Invoke(this, EventArgs.Empty);
        }

        private void fillDataToCombobox()
        {
            maPhongBanCbb.DataSource = department.GetAllDepartments();
            maPhongBanCbb.DisplayMember = "TenPhong";
            maPhongBanCbb.ValueMember = "MaPhong";
            maPhongBanCbb.SelectedIndex = -1;
        }

        public void ClearForm()
        {
            hoTenTb.Text = "";
            cccdTb.Text = "";
            gioiTinhTb.Text = "";
            emailTb.Text = "";
            soDienThoaiTb.Text = "";
            danTocTb.Text = "";
            tonGiaoTb.Text = "";
            noiCapTb.Text = "";
            hocVanTb.Text = "";
            chuyenNganhTb.Text = "";
            honNhanTb.Text = "";
            mucLuongTb.Text = "";

            duongTb.Text = "";
            phxaTb.Text = "";
            TpTb.Text = "";
            tTpTb.Text = "";


            maPhongBanCbb.SelectedIndex = -1; 
            maPhongBanCbb.Text = "";

            ngaySinhDate.Value = DateTime.Today;
            ngayCapDate.Value = DateTime.Today;

            string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
            string defaultImagePath = Path.Combine(projectPath, @"GUI\assets\img\images.png");
            showHinh.Image = Image.FromFile(defaultImagePath);
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn hình ảnh";
                openFileDialog.Filter = "Ảnh (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(fullPath);
   
                    string projectFolder = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                    string imageFolder = Path.Combine(projectFolder, "Images", "Avatar");

                    if (!Directory.Exists(imageFolder))
                        Directory.CreateDirectory(imageFolder);

                    string destPath = Path.Combine(imageFolder, fileName);
                    if (!File.Exists(destPath))
                        File.Copy(fullPath, destPath, true);

                    string relativePath = Path.Combine("Images", "Avatar", fileName);
                    // Hiển thị ảnh
                    showHinh.Image = Image.FromFile(destPath);
                    showHinh.SizeMode = PictureBoxSizeMode.StretchImage;

                    txtPath.Text = relativePath;
                }
            }
        }

        public PersonalProfileDTO LayDuLieuHoSoCaNhan()
        {
            string diaChi = $"{duongTb.Text.Trim()}, {phxaTb.Text.Trim()}, {tTpTb.Text.Trim()}, {tTpTb.Text.Trim()}";
            return new PersonalProfileDTO
            {
                SoCmnd = cccdTb.Text.Trim(),
                HoTen = hoTenTb.Text.Trim(),
                NgaySinh = ngaySinhDate.Value,
                GioiTinh = gioiTinhTb.Text.Trim(),
                DiaChi = diaChi,
                Email = emailTb.Text.Trim(),
                SoDienThoai = soDienThoaiTb.Text.Trim(),
                NoiCap = noiCapTb.Text.Trim(),
                NgayCap = ngayCapDate.Value,
                DanToc = danTocTb.Text.Trim(),
                HocVan = hocVanTb.Text.Trim(),
                HonNhan = honNhanTb.Text.Trim(),
                ChuyenNganh = chuyenNganhTb.Text.Trim(),
                HinhAnh = txtPath.Text.Trim() != null ? txtPath.Text.Trim() : "",
            };
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            //Chức vụ
            PositionDTO positionDTO = new PositionDTO(
               null,
               "Nhân viên",
               0,
               DateTime.Today.Date
            );

            //Hồ sơ cá nhân

            PersonalProfileDTO personalProfileDTO = LayDuLieuHoSoCaNhan();

            //nhân viên
            EmployeeDTO employeeDTO = new EmployeeDTO(
                null,
                cccdTb.Text,
                null,
                null,
                maPhongBanCbb.SelectedValue.ToString(),
                Convert.ToDecimal(mucLuongTb.Text)
            );

            bool insertSuccess = employee.InsertNoCandiDate(employeeDTO, personalProfileDTO, positionDTO);
            if (insertSuccess)
            {
                MessageBox.Show("Lưu thành công");
                ClearForm();
            }
            else
            {
                MessageBox.Show("Lưu thất bại!");
            }
        }
    }
}
