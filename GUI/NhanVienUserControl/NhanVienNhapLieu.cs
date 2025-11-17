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
        private ErrorProvider errorProvider = new ErrorProvider();
        public NhanVienNhapLieu()
        {
            InitializeComponent();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
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
            namBt.Checked = false;
            nuBt.Checked = false;
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

        private bool ValidateInputs()
        {
            //Validate ma phong ban
            if (maPhongBanCbb.SelectedIndex == -1)
            {
                errorProvider.SetError(maPhongBanCbb, "Vui lòng chọn phòng ban!");
                return false;
            }
            //hoten

            if(!GUIValidator.NotEmpty(hoTenTb, "Họ tên không được để trống!", errorProvider))
                return false;
            if(!GUIValidator.NotContainNumber(hoTenTb, "Họ tên không được chứa số!", errorProvider))
                return false;

            //gioitinh
            if (!GUIValidator.IsChecked(namBt, nuBt, "Vui lòng chọn giới tính!", errorProvider))
                return false;

            //ngay sinh
            if (ngaySinhDate.Value >= DateTime.Today)
            {
                errorProvider.SetError(ngaySinhDate, "Ngày sinh phải nhỏ hơn ngày hiện tại!");
                return false;
            }

            //sodienthoai
            if (!GUIValidator.NotEmpty(soDienThoaiTb, "Số điện thoại không được để trống!", errorProvider))
                return false;
            else if (!GUIValidator.IsOnlyNumberWithString(soDienThoaiTb, "Số điện thoại chỉ được chứa số", errorProvider))
                return false;
            else if (!GUIValidator.EqualNumber(soDienThoaiTb, 10, "Số điện thoại phải gồm 10 chữ số!", errorProvider))
                return false;

            //email
            if (!GUIValidator.NotEmpty(emailTb, "Email không được để trống!", errorProvider))
                return false;

            if (!emailTb.Text.Contains("@"))
            {
                errorProvider.SetError(emailTb, "Email không hợp lệ!");
                emailTb.Focus();
                return false;
            }
            //dia chỉ
            if (string.IsNullOrWhiteSpace(tTpTb.Text) ||
                string.IsNullOrWhiteSpace(TpTb.Text) ||
                string.IsNullOrWhiteSpace(phxaTb.Text) ||
                string.IsNullOrWhiteSpace(duongTb.Text))
            {
                errorProvider.SetError(tTpTb, "Vui lòng nhập đầy đủ địa chỉ (Tỉnh/TP, Quận/Huyện, Phường/Xã, Đường)!");
                return false;
            }else
            {
                errorProvider.SetError(tTpTb, "");
            }

            //Ton giao
            if (!GUIValidator.NotEmpty(tonGiaoTb, "Tôn giáo không được để trống!", errorProvider))
                return false;

            //danTocTb 
            if(!GUIValidator.NotEmpty(danTocTb, "Dân tộc không được để trống!", errorProvider))
                return false;

            //cccd
            if(!GUIValidator.NotEmpty(cccdTb, "Số CMND/CCCD không được để trống!", errorProvider))
                return false;
            else if(!GUIValidator.IsOnlyNumberWithString(cccdTb, "Số CMND/CCCD chỉ được chứa số!", errorProvider))
                return false;
            else if(!GUIValidator.EqualNumber(cccdTb, 12, "Số CMND/CCCD phải 12 chữ số!", errorProvider))
                return false;


            //noi cap
            if(!GUIValidator.NotEmpty(noiCapTb, "Nơi cấp không được để trống!", errorProvider))
                return false;

            //ngay caop

            if(ngayCapDate.Value > DateTime.Today)
            {
                errorProvider.SetError(ngayCapDate, "Ngày cấp không được lớn hơn ngày hiện tại!");
                return false;
            }


            //chuyen nghanh 
            if(!GUIValidator.NotEmpty(chuyenNganhTb, "Chuyên ngành không được để trống!", errorProvider))
                return false;

            //tinh trang hon nhan
            if(!GUIValidator.NotEmpty(honNhanTb, "Tình trạng hôn nhân không được để trống!", errorProvider))
                return false;

            //học vấn
            if(!GUIValidator.NotEmpty(hocVanTb, "Học vấn không được để trống!", errorProvider))
                return false;

            //muc luong
            if(!GUIValidator.NotEmpty(mucLuongTb, "Mức lương không được để trống!", errorProvider))
                return false;
            else if(!GUIValidator.IsDecimal(mucLuongTb, "Mức lương phải là số!", errorProvider))
                return false;
            else if(!GUIValidator.IsGreaterThanZero(mucLuongTb, "Mức lương phải lớn hơn 0!", errorProvider))
                return false;
            return true;
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
            string gioiTinh = "";
            if(namBt.Checked)
            {
                gioiTinh = "Nam";
            }
            else if(nuBt.Checked)
            {
                gioiTinh = "Nữ";
            }

            return new PersonalProfileDTO
            {
                SoCmnd = cccdTb.Text.Trim(),
                HoTen = hoTenTb.Text.Trim(),
                NgaySinh = ngaySinhDate.Value,
                GioiTinh = gioiTinh,
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
            //validate inputs
            if (!ValidateInputs())
                return;


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
