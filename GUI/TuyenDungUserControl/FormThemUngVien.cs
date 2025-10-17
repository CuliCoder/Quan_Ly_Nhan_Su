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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl
{
    
    public partial class FormThemUngVien : Form
    {
        private PersonalProfileBLL busPerson = new PersonalProfileBLL();
        private CandidateBLL busCadi = new CandidateBLL();
        public event EventHandler luuThongTinForm;
        public FormThemUngVien()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool kiemTraThognTin()
        {
            // Kiểm tra mã ứng viên
            if (string.IsNullOrWhiteSpace(maUngVienTb.Text))
            {
                MessageBox.Show("Mã ứng viên không được để trống!");
                maUngVienTb.Focus();
                return false;
            }

            // Kiểm tra mã tuyển dụng
            if (string.IsNullOrWhiteSpace(maTuyenDungTb.Text))
            {
                MessageBox.Show("Mã tuyển dụng không được để trống!");
                maTuyenDungTb.Focus();
                return false;
            }

            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(hoTenTb.Text))
            {
                MessageBox.Show("Họ tên không được để trống!");
                hoTenTb.Focus();
                return false;
            }

            // Kiểm tra ngày sinh (nếu có dạng TextBox nhập tay)
            if (string.IsNullOrWhiteSpace(ngaySinhTb.Text))
            {
                MessageBox.Show("Ngày sinh không được để trống!");
                ngaySinhTb.Focus();
                return false;
            }
            else if (!DateTime.TryParse(ngaySinhTb.Text, out _))
            {
                MessageBox.Show("Ngày sinh không hợp lệ (định dạng phải là dd/MM/yyyy)!");
                ngaySinhTb.Focus();
                return false;
            }

            // Kiểm tra CCCD
            if (string.IsNullOrWhiteSpace(cccdTb.Text))
            {
                MessageBox.Show("Số CCCD không được để trống!");
                cccdTb.Focus();
                return false;
            }
            else if (cccdTb.Text.Length != 12 || !cccdTb.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số CCCD phải gồm 12 chữ số!");
                cccdTb.Focus();
                return false;
            }

            if (!busPerson.checkID(cccdTb.Text))
            {
                MessageBox.Show("Lỗi nhập liệu cccd");
                cccdTb.Focus();
                return false;
            }else 

            // Kiểm tra nơi cấp
            if (string.IsNullOrWhiteSpace(noiCapTb.Text))
            {
                MessageBox.Show("Nơi cấp CCCD không được để trống!");
                noiCapTb.Focus();
                return false;
            }

            // Kiểm tra ngày cấp
            if (ngayCapDate.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày cấp CCCD không được lớn hơn ngày hiện tại!");
                ngayCapDate.Focus();
                return false;
            }

            // Kiểm tra giới tính
            if (string.IsNullOrWhiteSpace(gioiTinhTb.Text))
            {
                MessageBox.Show("Giới tính không được để trống!");
                gioiTinhTb.Focus();
                return false;
            }

            // Kiểm tra dân tộc
            if (string.IsNullOrWhiteSpace(danTocTb.Text))
            {
                MessageBox.Show("Dân tộc không được để trống!");
                danTocTb.Focus();
                return false;
            }

            // Kiểm tra hôn nhân
            if (string.IsNullOrWhiteSpace(honNhanTb.Text))
            {
                MessageBox.Show("Tình trạng hôn nhân không được để trống!");
                honNhanTb.Focus();
                return false;
            }

            // Kiểm tra tôn giáo
            if (string.IsNullOrWhiteSpace(tonGiaoTb.Text))
            {
                MessageBox.Show("Tôn giáo không được để trống!");
                tonGiaoTb.Focus();
                return false;
            }

            // Kiểm tra email
            if (string.IsNullOrWhiteSpace(emailTb.Text))
            {
                MessageBox.Show("Email không được để trống!");
                emailTb.Focus();
                return false;
            }
            else if (!emailTb.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!");
                emailTb.Focus();
                return false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(soDienThoaiTb.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!");
                soDienThoaiTb.Focus();
                return false;
            }
            else if (!soDienThoaiTb.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số!");
                soDienThoaiTb.Focus();
                return false;
            }

            // Kiểm tra địa chỉ
            if (string.IsNullOrWhiteSpace(tTpTb.Text) ||
                string.IsNullOrWhiteSpace(qhTb.Text) ||
                string.IsNullOrWhiteSpace(phxaTb.Text) ||
                string.IsNullOrWhiteSpace(duongTb.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ địa chỉ (Tỉnh/TP, Quận/Huyện, Phường/Xã, Đường)!");
                return false;
            }

            // Kiểm tra học vấn
            if (string.IsNullOrWhiteSpace(hocVanTb.Text))
            {
                MessageBox.Show("Học vấn không được để trống!");
                hocVanTb.Focus();
                return false;
            }

            // Kiểm tra chuyên ngành
            if (string.IsNullOrWhiteSpace(chuyenNganhTb.Text))
            {
                MessageBox.Show("Chuyên ngành không được để trống!");
                chuyenNganhTb.Focus();
                return false;
            }

            // Kiểm tra mức lương
            if (!decimal.TryParse(mucLuongTb.Text, out _))
            {
                MessageBox.Show("Mức lương phải là số hợp lệ!");
                mucLuongTb.Focus();
                return false;
            }

            return true;
        }

        public CandidateDTO LayDuLieuUngVien()
        {
            // Gộp địa chỉ lại
            
            RecruitmentBatchBLL busRe = new RecruitmentBatchBLL();

            String chucVu = busRe.GetById(maTuyenDungTb.Text).ChucVu;
            if(chucVu == null)
            {
                MessageBox.Show("Mã Tuyển dụng không tồn tại");
                maTuyenDungTb.Focus();
                return null;
            }

            return new CandidateDTO
            {
                MaUngVien = maUngVienTb.Text.Trim(),
                MaTuyenDung = maTuyenDungTb.Text.Trim(),
                SoCmnd = cccdTb.Text.Trim(),
                MucLuongDeal = decimal.Parse(mucLuongTb.Text),
                TrangThai = "Chưa Tuyển",
                ChucVu = chucVu
            };
        }

        public PersonalProfileDTO LayDuLieuHoSoCaNhan()
        {
            string diaChi = $"{duongTb.Text.Trim()}, {phxaTb.Text.Trim()}, {qhTb.Text.Trim()}, {tTpTb.Text.Trim()}";
            return new PersonalProfileDTO
            {
                SoCmnd = cccdTb.Text.Trim(),
                HoTen = hoTenTb.Text.Trim(),
                NgaySinh = DateTime.Parse(ngaySinhTb.Text),
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
                HinhAnh = ""
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kiemTraThognTin())
            {
                PersonalProfileDTO personalProfile = LayDuLieuHoSoCaNhan();
                if (busPerson.Create(personalProfile))
                {
                    CandidateDTO candidate = LayDuLieuUngVien();
                    if (busCadi.Create(candidate))
                    {
                        luuThongTinForm?.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }          
                }
            }
        }
    }
}
