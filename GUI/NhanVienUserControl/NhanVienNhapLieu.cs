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
        private readonly EmployeeBLL employee;
        private readonly PositionBLL positionBLL;
        public event EventHandler suKienLuu;
        private readonly ErrorProvider errorProvider;
        private EmployeeFullDTO employeeFullDTO;
        private string HanhDong;
        public NhanVienNhapLieu(EmployeeFullDTO employeeFul, string hanhDong)
        {
            InitializeComponent();
            employee = new EmployeeBLL();
            positionBLL = new PositionBLL();
            employeeFullDTO = new EmployeeFullDTO();
            HanhDong = hanhDong;
            errorProvider = new ErrorProvider 
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };
            loadDataToCombobox();
            ClearForm();
            if (employeeFul != null && hanhDong.Equals("Sua"))
            {
                employeeFullDTO = employeeFul;
                fillDataToTextBox(employeeFullDTO);
                cccdTb.Enabled = false;     
                mucLuongTb.Enabled = false;
            }          
        }

        private void loadDataToCombobox()
        {
            //Load data chuc vu
            chucvuCbb.DataSource = positionBLL.GetAll();
            
            chucvuCbb.DisplayMember = "Display";
            chucvuCbb.ValueMember = "MaChucVu";
            chucvuCbb.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e) 
        {
            QuayLaiClicked?.Invoke(this, EventArgs.Empty);
        }


        public void ClearForm()
        {
            if(!HanhDong.Equals("Sua"))
            {
                mucLuongTb.Text = "";
                cccdTb.Text = "";
            }
            hoTenTb.Text = "";       
            namBt.Checked = false;
            nuBt.Checked = false;
            emailTb.Text = "";
            soDienThoaiTb.Text = "";
            danTocTb.Text = "";
            noiCapTb.Text = "";
            hocVanTb.Text = "";
            chuyenNganhTb.Text = "";
            honNhanTb.Text = "";
            chucvuCbb.SelectedIndex = -1;

            duongTb.Text = "";
            phxaTb.Text = "";
            TpTb.Text = "";
            tTpTb.Text = "";



            ngaySinhDate.Value = DateTime.Today;
            ngayCapDate.Value = DateTime.Today;

            string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
            string defaultImagePath = Path.Combine(projectPath, @"GUI\assets\img\images.png");
            showHinh.Image = Image.FromFile(defaultImagePath);
        }

        private bool ValidateInputs()
        {
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
                    string imageFolder = Path.Combine(projectFolder, "Images", "Avatars");

                    if (!Directory.Exists(imageFolder))
                        Directory.CreateDirectory(imageFolder);

                    string destPath = Path.Combine(imageFolder, fileName);
                    if (!File.Exists(destPath))
                        File.Copy(fullPath, destPath, true);

                    string relativePath = Path.Combine("Images", "Avatars", fileName);
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

        private void fillDataToTextBox(EmployeeFullDTO emp)
        {
            cccdTb.Text = emp.SoCmnd;
            hoTenTb.Text = emp.HoTen;
            if (emp.GioiTinh.Equals("Nam"))
                namBt.Checked = true;
            else
                nuBt.Checked = true;
            ngaySinhDate.Value = emp.NgaySinh ?? DateTime.Today;
   
            if(!string.IsNullOrEmpty(emp.DiaChi))
            {
                string[] addressParts = emp.DiaChi.Split(',');
                if (addressParts.Length >= 4)
                {
                    duongTb.Text = addressParts[0].Trim();
                    phxaTb.Text = addressParts[1].Trim();
                    TpTb.Text = addressParts[2].Trim();
                    tTpTb.Text = addressParts[3].Trim();
                }
            }
            emailTb.Text = emp.Email;
            soDienThoaiTb.Text = emp.Sdt;
            noiCapTb.Text = emp.NoiCap;
            ngayCapDate.Value = emp.NgayCap ?? DateTime.Today;  
            danTocTb.Text = emp.DanToc;
            honNhanTb.Text = emp.TinhTranHonNhan;
            hocVanTb.Text = emp.HocVan;
            chuyenNganhTb.Text = emp.ChuyenNganh;
            mucLuongTb.Text = emp.MucLuong.ToString();
            chucvuCbb.SelectedValue = emp.MaChucVu;
            //Hình ảnh
            try
            {
                string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string imagePath = Path.Combine(projectPath, emp.HinhAnh ?? "");
                string defaultImagePath = Path.Combine(projectPath, @"GUI\assets\img\images.png");

                string finalPath = "";

                if (!string.IsNullOrEmpty(emp.HinhAnh) && File.Exists(imagePath))
                    finalPath = imagePath;
                else if (File.Exists(defaultImagePath))
                    finalPath = defaultImagePath;
                else
                    finalPath = "";
                if (!string.IsNullOrEmpty(finalPath))
                    showHinh.Image = Image.FromFile(finalPath);
                else
                    showHinh.Image = null;
            }
            catch (Exception ex)
            {
                showHinh.Image = null;
                MessageBox.Show("Lỗi tải ảnh: " + ex.Message);
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            //validate inputs
            if (!ValidateInputs())
                return;
            //Hồ sơ cá nhân
            PersonalProfileDTO personalProfileDTO = LayDuLieuHoSoCaNhan();
         

            if (HanhDong.Equals("Them"))
            {          
                //nhân viên
                EmployeeDTO employeeDTO = new EmployeeDTO(
                    null,
                    cccdTb.Text,
                    chucvuCbb.SelectedValue.ToString(),
                    null, // mã tài khoản sẽ được gán sau
                    null, //mã phòng ban sẽ được tạo sau khi tạo hợp đồng
                    Convert.ToDecimal(mucLuongTb.Text)
                );
                bool insertSuccess = employee.InsertNoCandiDate(employeeDTO, personalProfileDTO);
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
            else if (HanhDong.Equals("Sua"))
            {
                EmployeeFullDTO employeeFullDTOUpdate = new EmployeeFullDTO
                {
                    MaNhanVien = employeeFullDTO.MaNhanVien,
                    HoTen = hoTenTb.Text.Trim(),
                    NgaySinh = ngaySinhDate.Value,
                    GioiTinh = namBt.Checked ? "Nam" : "Nữ",
                    Email = emailTb.Text.Trim(),
                    Sdt = soDienThoaiTb.Text.Trim(),
                    SoCmnd = cccdTb.Text.Trim(),
                    NoiCap = noiCapTb.Text.Trim(),
                    NgayCap = ngayCapDate.Value,
                    DanToc = danTocTb.Text.Trim(),
                    TinhTranHonNhan = honNhanTb.Text.Trim(),
                    HocVan = hocVanTb.Text.Trim(),
                    ChuyenNganh = chuyenNganhTb.Text.Trim(),
                    MaChucVu = chucvuCbb.SelectedValue.ToString(),
                    MucLuong = Convert.ToDecimal(mucLuongTb.Text),
                    DiaChi = $"{duongTb.Text.Trim()}, {phxaTb.Text.Trim()}, {TpTb.Text.Trim()}, {tTpTb.Text.Trim()}",
                    HinhAnh = txtPath.Text.Trim() != null ? txtPath.Text.Trim() : "",
                };

                bool insertSuccess = employee.UpdateNoCandiDate(employeeFullDTOUpdate);
                if (insertSuccess)
                {
                    MessageBox.Show("Cập nhật thành công");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
