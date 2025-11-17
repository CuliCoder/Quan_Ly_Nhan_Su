
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
namespace Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl
{
    public partial class ThemTuyenDungForm : Form
    {
        public event EventHandler luuThongTinForm;
        private static readonly RecruitmentBatchBLL bus = new RecruitmentBatchBLL();
        private ErrorProvider errorProvider = new ErrorProvider();
        public ThemTuyenDungForm()
        {
            InitializeComponent();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInputs()
        {
            // Mã tuyển dụng
            if(!GUIValidator.NotEmpty(maTuyenDungTb, "Mã tuyển dụng không được để trống!", errorProvider))
                return false;
            
            // Chức vụ
            if(!GUIValidator.NotEmpty(chuVuTb, "Chức vụ không được để trống!", errorProvider))
                return false;

            //Số lượng tuyển
            if(!GUIValidator.NotEmpty(soLuongTuyentb, "Số lượng tuyển không được để trống", errorProvider))  
                return false;

            else if(!GUIValidator.IsNumber(soLuongTuyentb, "Số lượng tuyển phải là số hợp lệ", errorProvider))
                return false;

            // Học vấn
            if (!GUIValidator.NotEmpty(hocVanToiThieu, "Học vấn không được để trống!", errorProvider))
                return false;

            // Độ tuổi
            if(!GUIValidator.NotEmpty(doTuoiTb, "Độ tuổi không được để trống!", errorProvider))
                return false;

            // Số lượng tuyển
            if(!GUIValidator.NotEmpty(soLuongTuyentb, "Số lượng tuyển không được để trống!", errorProvider))
                return false;
            else if(!GUIValidator.IsNumber(soLuongTuyentb, "Số lượng tuyển phải là số hợp lệ!", errorProvider))
                return false;

            // Hạn nộp hồ sơ
            if (hanNopDate.Value < DateTime.Today)
            {
                MessageBox.Show("Hạn nộp hồ sơ không được nhỏ hơn ngày hiện tại!");
                hanNopDate.Focus();
                return false;
            }

            // Mức lương tối thiểu
            if(!GUIValidator.NotEmpty(luongToiThieutb, "Mức lương tối thiểu không được để trống!", errorProvider))
                return false;
            else if (!GUIValidator.IsDecimal(luongToiThieutb, "Mức lương tối thiếu không hợp lệ", errorProvider))
                return false;


            // Mức lương tối đa
            if (!GUIValidator.NotEmpty(luongToiDaTb, "Mức lương tối đã không được để trống", errorProvider))
                return false;
            else if (!GUIValidator.IsDecimal(luongToiDaTb, "Mức lương tối đa không hợp lệ", errorProvider))
                return false;
            return true;
        }

        public RecruitmentBatchDTO layDuLieuTextBox()
        {
            string gioiTinh = namBt.Checked 
                                ? namBt.Text 
                                : nuBt.Checked 
                                ? nuBt.Text : khongBT.Text;

            decimal? luongToiThieu = null;
            decimal? luongToiDa = null;

            if (decimal.TryParse(luongToiThieutb.Text, out decimal tmpThieu))
                luongToiThieu = tmpThieu;

            if (decimal.TryParse(luongToiDaTb.Text, out decimal tmpDa))
                luongToiDa = tmpDa;

            return new RecruitmentBatchDTO(
                maTuyenDungTb.Text,
                chuVuTb.Text,
                hocVanToiThieu.Text,
                gioiTinh,
                doTuoiTb.Text,
                int.Parse(soLuongTuyentb.Text),           
                hanNopDate.Value,
                luongToiThieu,
                luongToiDa,
                0,
                0
            );
        }
        private void themTuyenDung(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            RecruitmentBatchDTO tuyenDungData = layDuLieuTextBox();

            if (bus.Create(tuyenDungData))
            {
                luuThongTinForm?.Invoke(this, EventArgs.Empty); 
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }


    }
}
