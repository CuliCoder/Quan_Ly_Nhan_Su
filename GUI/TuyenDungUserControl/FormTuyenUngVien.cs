using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.GUI;
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

        private readonly EmployeeBLL bus;
        private readonly CandidateBLL busCandi;

        private readonly PositionBLL positionBLL;
        private readonly RecruitmentBatchBLL batchBLL;

        public event EventHandler luuThongTinForm;

        private ErrorProvider errorProvider;

        public FormTuyenUngVien(CandidateFullDTO dtoFullDato)
        {
            InitializeComponent();

            dtoFull = dtoFullDato;

            // Khởi tạo các class
            bus = new EmployeeBLL();
            busCandi = new CandidateBLL();
            positionBLL = new PositionBLL();
            batchBLL = new RecruitmentBatchBLL();

            // Khởi tạo ErrorProvider
            errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };
            loadDataToCombobox();
            // Load dữ liệu form
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


                // Hiển thị ảnh ứng viên
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


        private void loadDataToCombobox()
        {
            //Load data chuc vu
            chucvuCbb.DataSource = positionBLL.GetAll();    
            chucvuCbb.DisplayMember = "Display";
            chucvuCbb.ValueMember = "MaChucVu";
            chucvuCbb.SelectedIndex = -1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!GUIValidator.NotEmpty(tbLuong, "Lương không được để trống!", errorProvider))
            {
                return;
            }

            if (!GUIValidator.IsDecimal(tbLuong, "Lương không hợp lệ!", errorProvider))
            {
                return;
            }

            if(!GUIValidator.IsGreaterThanZero(tbLuong, "Lương phải lớn hơn 0!", errorProvider))
            {
                return;
            }

            if(!GUIValidator.IsSelected(chucvuCbb, "Vui lòng chọn chức vụ"))
            {
                return;
            }
           
            PositionDTO positionDTO = new PositionDTO(
               null, 
               dtoFull.ChucVu,
               0,
               DateTime.Today.Date
            );
            MessageBox.Show(chucvuCbb.SelectedValue.ToString());
            EmployeeDTO employeeDTO = new EmployeeDTO(
                null, // mã nhân viên sẽ tự động kiểm tra và tạo trong DAO
                dtoFull.SoCmnd,
                chucvuCbb.SelectedValue.ToString(), // mã chức vụ sẽ được tạo tự động trong DAO
                null, // mã tài khoản sẽ được gán sau được cấp tài khoản
                null, //mã phòng ban sẽ được tạo sau khi tạo hợp đồng
                Convert.ToDecimal(tbLuong.Text)
            ); 
          
            bool insertSuccess = bus.Insert(employeeDTO, dtoFull.MaTuyenDung);
            if (insertSuccess)
            {
                busCandi.UpdateStatus(dtoFull.MaUngVien, "Đã Tuyển");
                batchBLL.updateNumberOfRecruited(dtoFull.MaTuyenDung);

                luuThongTinForm?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể lưu dữ liệu. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

    }
}
