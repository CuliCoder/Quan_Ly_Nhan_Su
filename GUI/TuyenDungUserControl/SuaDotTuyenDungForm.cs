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
    public partial class SuaDotTuyenDungForm : Form 
    {
        public event EventHandler luuThongTinForm;
        private static readonly RecruitmentBatchBLL bus = new RecruitmentBatchBLL();
        private RecruitmentBatchDTO batchDTO;
        private ErrorProvider errorProvider = new ErrorProvider();
        public SuaDotTuyenDungForm(RecruitmentBatchDTO dto)
        {
            InitializeComponent();
            batchDTO = dto;
        }

        private bool ValidateInputs()
        {
            // Mã tuyển dụng
            if (!GUIValidator.NotEmpty(maTuyenDungTb, "Mã tuyển dụng không được để trống!", errorProvider))
                return false;


            // Chức vụ
            if (!GUIValidator.NotEmpty(chuVuTb, "Chức vụ không được để trống!", errorProvider))
                return false;

            //Số lượng tuyển
            if (!GUIValidator.NotEmpty(soLuongTuyentb, "Số lượng tuyển không được để trống", errorProvider))
                return false;

            // Học vấn
            if (!GUIValidator.NotEmpty(hocVanToiThieu, "Học vấn không được để trống!", errorProvider))
                return false;

            // Độ tuổi
            if (!GUIValidator.NotEmpty(doTuoiTb, "Độ tuổi không được để trống!", errorProvider))
                return false;

            // Số lượng tuyển
            if (!GUIValidator.NotEmpty(soLuongTuyentb, "Số lượng tuyển không được để trống!", errorProvider))
                return false;
            else if (!GUIValidator.IsNumber(soLuongTuyentb, "Số lượng tuyển phải là số hợp lệ!", errorProvider))
                return false;

            // Hạn nộp hồ sơ
            if (hanNopDate.Value < DateTime.Today)
            {
                MessageBox.Show("Hạn nộp hồ sơ không được nhỏ hơn ngày hiện tại!");
                hanNopDate.Focus();
                return false;
            }

            // Mức lương tối thiểu
            if (!GUIValidator.NotEmpty(luongToiThieutb, "Mức lương tối thiểu không được để trống!", errorProvider))
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void setDataInToTextBox()
        {

            maTuyenDungTb.Text = batchDTO.MaTuyenDung;
            chuVuTb.Text = batchDTO.ChucVu;
            soLuongTuyentb.Text = batchDTO.SoLuongCanTuyen.ToString();
            hocVanToiThieu.Text = batchDTO.HocVan.ToString();
            doTuoiTb.Text = batchDTO.DoTuoi.ToString();
            luongToiThieutb.Text = batchDTO.MucLuongToiThieu.ToString();
            luongToiDaTb.Text = batchDTO.MucLuongToiDa.ToString();
            hanNopDate.Value = batchDTO.HanNopHoSo;
            if (batchDTO.GioiTinh.Equals("Nam"))
                namBt.Checked = true;
            else if (batchDTO.GioiTinh.Equals("Nữ"))
                nuBt.Checked = true;
            else
                khongBT.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(ValidateInputs())
            {
                batchDTO.MaTuyenDung = maTuyenDungTb.Text;
                batchDTO.ChucVu = chuVuTb.Text;
                batchDTO.HocVan = hocVanToiThieu.Text;
                batchDTO.DoTuoi = doTuoiTb.Text;
                batchDTO.MucLuongToiThieu = decimal.TryParse(luongToiThieutb.Text, out decimal luongMin) ? luongMin : 0;
                batchDTO.HanNopHoSo = hanNopDate.Value.Date;
                batchDTO.SoLuongCanTuyen = int.TryParse(soLuongTuyentb.Text, out int soLuong) ? soLuong : 0;
                batchDTO.MucLuongToiDa = decimal.TryParse(luongToiDaTb.Text, out decimal luongMax) ? luongMax : 0;

                if (namBt.Checked)
                    batchDTO.GioiTinh = "Nam";
                else if (nuBt.Checked)
                    batchDTO.GioiTinh = "Nữ";
                else
                    batchDTO.GioiTinh = "Không";

                bus.Update(batchDTO);
                luuThongTinForm?.Invoke(this, EventArgs.Empty);
                this.Close();
            }  
        }
    }
}
