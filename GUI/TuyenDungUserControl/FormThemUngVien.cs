using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.GUI;

namespace Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl
{
    
    public partial class FormThemUngVien : Form
    {
        public event EventHandler luuThongTinForm;
        private readonly CandidateFullBLL busFullCadi;
        private readonly RecruitmentBatchBLL busBatch;
        private readonly ErrorProvider errorProvider;

        public FormThemUngVien()
        {
            InitializeComponent();

            busFullCadi = new CandidateFullBLL();
            busBatch = new RecruitmentBatchBLL();
            errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };

            fillDataToCombobox();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void fillDataToCombobox()
        {
            maTuyenDungCbb.DataSource = busBatch.GetAll();
            
            maTuyenDungCbb.DisplayMember = "MaTuyenDung";
            maTuyenDungCbb.ValueMember = "MaTuyenDung";
            maTuyenDungCbb.SelectedIndex = -1;
        }

        private bool kiemTraThognTin()
        {

            if(!GUIValidator.IsSelected(maTuyenDungCbb, "Vui lòng chọn mã tuyển dụng"))
                return false;

            // Kiểm tra mã ứng viên
            if (!GUIValidator.NotEmpty(maUngVienTb, "Mã ứng viên không được để trống!", errorProvider))
                return false;


            // Kiểm tra CCCD
            if (!GUIValidator.NotEmpty(cccdTb, "Số CCCD không được để trống!", errorProvider))
                return false;
            else
            if (!GUIValidator.IsOnlyNumberWithString(cccdTb, "Số CCCD chỉ được chứa số", errorProvider))
                return false;
            else
            if (!GUIValidator.EqualNumber(cccdTb,12,"Số CCCD phải gồm 12 chữ số!", errorProvider))
                return false;

            // Kiểm tra họ tên
            if(!GUIValidator.NotEmpty(hoTenTb, "Họ tên không được để trống!", errorProvider))
                return false;
            else
            if (!GUIValidator.NotContainNumber(hoTenTb, "Họ tên không được chứa số!", errorProvider))
                return false;

            // Kiểm tra giới tính
            if (!GUIValidator.IsChecked(namBt, nuBt, "Vui lòng chọn giới tính!", errorProvider))
                return false;

            // Kiểm tra ngày sinh 
            if (ngaySinhDate.Value > DateTime.Now)
            {
                errorProvider.SetError(ngaySinhDate, "Ngày sinh không được lớn hơn ngày hiện tại!");
                ngaySinhDate.Focus();
                return false;
            }

            // Kiểm tra số điện thoại
            if(!GUIValidator.NotEmpty(soDienThoaiTb, "Số điện thoại không được để trống!", errorProvider))
                return false;
            else if (!GUIValidator.IsOnlyNumberWithString(soDienThoaiTb, "Số điện thoại phải là số", errorProvider))
                return false;
            else if(!GUIValidator.EqualNumber(soDienThoaiTb,10,"Số điện thoại phải gồm 10 chữ số!", errorProvider))
                return false;


            // Kiểm tra email
            if (!GUIValidator.NotEmpty(emailTb, "Email không được để trống!", errorProvider))
                return false;     
            
            if (!emailTb.Text.Contains("@"))
            {
                errorProvider.SetError(emailTb, "Email không hợp lệ!");
                emailTb.Focus();
                return false;
            }

            // Kiểm tra dân tộc
            if (!GUIValidator.NotEmpty(danTocTb, "Dân tộc không được để trống!", errorProvider))
                return false;

            // Kiểm tra địa chỉ
            if (string.IsNullOrWhiteSpace(tTpTb.Text) ||
                string.IsNullOrWhiteSpace(qhTb.Text) ||
                string.IsNullOrWhiteSpace(phxaTb.Text) ||
                string.IsNullOrWhiteSpace(duongTb.Text))
            {
                errorProvider.SetError(tTpTb, "Vui lòng nhập đầy đủ địa chỉ (Tỉnh/TP, Quận/Huyện, Phường/Xã, Đường)!");
                return false;
            }
            else
            {
                errorProvider.SetError(tTpTb, "");
            }


            // Kiểm tra nơi cấp
            if (!GUIValidator.NotEmpty(noiCapTb, "Nơi cấp CCCD không được để trống!", errorProvider))
                return false;

            // Kiểm tra ngày cấp
            if (ngayCapDate.Value > DateTime.Now)
            {
                errorProvider.SetError(ngayCapDate, "Ngày cấp CCCD không được lớn hơn ngày hiện tại!");
                ngayCapDate.Focus();
                return false;
            }

            // Kiểm tra chuyên ngành
            if(!GUIValidator.NotEmpty(chuyenNganhTb, "Chuyên ngành không được để trống!", errorProvider))
                return false;

            // Kiểm tra mức lương
            if(!GUIValidator.IsDecimal(mucLuongTb, "Mức lương phải là số hợp lệ", errorProvider))
                return false;


            // Kiểm tra hôn nhân
            if(!GUIValidator.NotEmpty(honNhanTb, "Tình trạng hôn nhân không được để trống!", errorProvider))
                return false;

            // Kiểm tra học vấn
            if(!GUIValidator.NotEmpty(hocVanTb, "Học vấn không được để trống!", errorProvider))
                return false;
            return true;
        }

        public CandidateDTO LayDuLieuUngVien()
        {   
            
            RecruitmentBatchBLL busRe = new RecruitmentBatchBLL();

            string maTuyenDung = maTuyenDungCbb.SelectedValue.ToString();
            if(maTuyenDungCbb != null)
            {
                String chucVu = busRe.GetById(maTuyenDung).ChucVu;

                return new CandidateDTO
                {
                    MaUngVien = maUngVienTb.Text.Trim(),
                    MaTuyenDung = maTuyenDung,
                    SoCmnd = cccdTb.Text.Trim(),
                    MucLuongDeal = decimal.Parse(mucLuongTb.Text),
                    TrangThai = "Chưa Tuyển",
                    ChucVu = chucVu
                };
            }
            return null;
        }

        public PersonalProfileDTO LayDuLieuHoSoCaNhan()
        {
            string diaChi = $"{duongTb.Text.Trim()}, {phxaTb.Text.Trim()}, {qhTb.Text.Trim()}, {tTpTb.Text.Trim()}";
            string gioiTinh = "";
            if(namBt.Checked)
                gioiTinh = "Nam";
            else if(nuBt.Checked)
                gioiTinh = "Nữ";
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
                HinhAnh = txtPath.Text.Trim() != null ? txtPath.Text.Trim(): "",
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(kiemTraThognTin())
            {
                PersonalProfileDTO personalProfile = LayDuLieuHoSoCaNhan();
                CandidateDTO candidate = LayDuLieuUngVien();

                if (busFullCadi.ORMCreateCadidateWPersonalProfile(personalProfile, candidate))
                {
                    busBatch.UpdateProfileCreate(candidate.MaTuyenDung);
                    luuThongTinForm?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }              
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

        private void label9_Click(object sender, EventArgs e)
        {
            
        }
    }
}
