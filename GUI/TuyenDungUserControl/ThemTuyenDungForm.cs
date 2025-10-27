
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
        public ThemTuyenDungForm()
        {
            InitializeComponent();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private bool ValidateInputs()
        {
            // Mã tuyển dụng
            if (string.IsNullOrWhiteSpace(maTuyenDungTb.Text))
            {
                MessageBox.Show("Mã tuyển dụng không được để trống!");
                maTuyenDungTb.Focus();
                return false;
            }

            var existing = bus.checkedId(maTuyenDungTb.Text);
            MessageBox.Show(existing.ToString());
            if (existing)
            {
                MessageBox.Show("Mã tuyển dụng đã tồn tại. Vui lòng nhập mã khác!");
                maTuyenDungTb.Focus();
                return false;
            }

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

            // Hạn nộp hồ sơ
            if (hanNopDate.Value < DateTime.Today)
            {
                MessageBox.Show("Hạn nộp hồ sơ không được nhỏ hơn ngày hiện tại!");
                hanNopDate.Focus();
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
