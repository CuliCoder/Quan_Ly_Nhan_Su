using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DAO;
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

namespace Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl
{
    public partial class FormTuyenUngVien : Form
    {
        private CandidateFullDTO dtoFull;
        private EmployeeBLL bus = new EmployeeBLL();
        private CandidateBLL busCandi = new CandidateBLL();
        public event EventHandler luuThongTinForm;
        public FormTuyenUngVien(CandidateFullDTO dtoFullDato)
        {
            InitializeComponent();
            dtoFull = dtoFullDato;
            DisplayCandidateDetails(dtoFull);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string ExtractAddressPart(string diaChi, int index)
        {
            if (string.IsNullOrWhiteSpace(diaChi))
                return "";

            string[] parts = diaChi.Split(',');
            return parts.Length > index ? parts[index].Trim() : "";
        }

        private void DisplayCandidateDetails(CandidateFullDTO candidate)
        {
            if (candidate == null)
            {
                MessageBox.Show("Không có dữ liệu ứng viên để hiển thị.");
                return;
            }

            try
            {
                //hồ sơ cá nhân
                showTenUV.Text = candidate.HoTen;
                showCCCDUV.Text = candidate.SoCmnd;
                showNgaySinhUV.Text = candidate.NgaySinh.ToString("dd/MM/yyyy");
                showGioTinhUV.Text = candidate.GioiTinh;
                showDanTocUV.Text = candidate.DanToc;
                showHocVanUV.Text = candidate.TrinhDoHocVan;
                showChuyenNganhUV.Text = candidate.ChuyenNganh;
                showLuongDealUV.Text = candidate.MucLuongDeal?.ToString("N0") + " VNĐ";
                showNoiCapUV.Text = candidate.NoiCap;
                showNgayCapUV.Text = candidate.NgayCap.ToString("dd/MM/yyyy");        
                showEm.Text = candidate.Email;
                showSDTUV.Text = candidate.SoDienThoai;
                showHonNhan.Text = candidate.HonNhan;
                showDuongUV.Text = ExtractAddressPart(candidate.DiaChi, 0);
                showPhuongXaUV.Text = ExtractAddressPart(candidate.DiaChi, 1);
                showQuanHuyenUV.Text = ExtractAddressPart(candidate.DiaChi, 2);          
                SoTinhTPUV.Text = ExtractAddressPart(candidate.DiaChi, 3);
                

                // 🖼Hiển thị ảnh ứng viên
                string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string imagePath = Path.Combine(projectPath, candidate.HinhAnh ?? "");
                string defaultImagePath = Path.Combine(projectPath, @"GUI\assets\img\images.png");

                string finalPath = "";
                if (!string.IsNullOrEmpty(candidate.HinhAnh) && File.Exists(imagePath))
                    finalPath = imagePath;
                else if (File.Exists(defaultImagePath))
                    finalPath = defaultImagePath;

                pictureBox1.Image = !string.IsNullOrEmpty(finalPath) ? Image.FromFile(finalPath) : null;
            }
            catch (Exception ex)
            {
                pictureBox1.Image = null;
                MessageBox.Show("Lỗi khi hiển thị dữ liệu ứng viên: " + ex.Message);
            }
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
                     
            EmployeeDTO employeeDTO = new EmployeeDTO(
                    tbMaNhanVien.Text,
                    showCCCDUV.Text,
                    null,          
                    null,         
                    tbChucVu.Text,
                    null,         
                    tbPhongBan.Text,
                    Convert.ToDecimal(tbLuong.Text)
                );

            PositionDTO positionDTO = new PositionDTO(
                tbChucVu.Text,
                "Nhân viên",
                0,
                DateTime.Today.Date
            );


            bool insertSuccess = bus.Insert(employeeDTO, dtoFull.MaTuyenDung, positionDTO);
            if (insertSuccess)
            {
                busCandi.UpdateStatus(dtoFull.MaUngVien, "Đã Tuyển");
                luuThongTinForm?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Lưu dữ liệu và cập nhật trạng thái ứng viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể lưu dữ liệu. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
        }

    }
}
