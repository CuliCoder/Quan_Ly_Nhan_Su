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
        public SuaDotTuyenDungForm(RecruitmentBatchDTO dto)
        {
            InitializeComponent();
            batchDTO = dto;
        }

        private bool ValidateInputs()
        {
            // Chức vụ
            if (string.IsNullOrWhiteSpace(chuVuTb.Text))
            {
                MessageBox.Show("Chức vụ không được để trống!");
                chuVuTb.Focus();
                return false;
            }

            // Học vấn
            if (string.IsNullOrWhiteSpace(hocVanToiThieu.Text))
            {
                MessageBox.Show("Học vấn tối thiểu không được để trống!");
                hocVanToiThieu.Focus();
                return false;
            }

            // Độ tuổi
            if (string.IsNullOrWhiteSpace(doTuoiTb.Text))
            {
                MessageBox.Show("Độ tuổi không được để trống!");
                doTuoiTb.Focus();
                return false;
            }

            // Số lượng tuyển
            if (!int.TryParse(soLuongTuyentb.Text, out _))
            {
                MessageBox.Show("Số lượng cần tuyển phải là số hợp lệ!");
                soLuongTuyentb.Focus();
                return false;
            }


            // Mức lương tối thiểu
            if (string.IsNullOrWhiteSpace(luongToiThieutb.Text))
            {
                MessageBox.Show("Mức lương tối thiểu không được để trống!");
                luongToiThieutb.Focus();
                return false;
            }
            else if (!decimal.TryParse(luongToiThieutb.Text, out _))
            {
                MessageBox.Show("Mức lương tối thiểu phải là số hợp lệ!");
                luongToiThieutb.Focus();
                return false;
            }

            // Mức lương tối đa
            if (string.IsNullOrWhiteSpace(luongToiDaTb.Text))
            {
                MessageBox.Show("Mức lương tối đa không được để trống!");
                luongToiDaTb.Focus();
                return false;
            }
            else if (!decimal.TryParse(luongToiDaTb.Text, out _))
            {
                MessageBox.Show("Mức lương tối đa phải là số hợp lệ!");
                luongToiDaTb.Focus();
                return false;
            }
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
