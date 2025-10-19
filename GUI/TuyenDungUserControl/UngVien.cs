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

namespace Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl
{
    public partial class UngVien : UserControl
    {
        private CandidateFullBUS busFullData = new CandidateFullBUS();

        public UngVien()
        {        
            InitializeComponent();
            tableData.CellClick += tableData_CellClick;
            tableData.DataBindingComplete += dataTable_DataBindingComplete;
            hienThiData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormThemUngVien themUngVienForm = new FormThemUngVien();
            //themUngVienForm.luuThongTinForm += luuThanhcong;
            themUngVienForm.StartPosition = FormStartPosition.CenterScreen;
            themUngVienForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTuyenUngVien tuyenUngVienForm = new FormTuyenUngVien();
            tuyenUngVienForm.StartPosition = FormStartPosition.CenterScreen;
            tuyenUngVienForm.ShowDialog();
        }

       
        //private void luuThanhcong(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Thêm mới thành công");
        //    list = bus.GetAll();
        //    fillDataToTable();
        //} 

        private void hienThiData()
        {
            tableData.DataSource = busFullData.GetAll();
            //ẩn các bảng cột không cần thiêt
            tableData.Columns["SoCmnd"].Visible = false;
            tableData.Columns["DiaChi"].Visible = false;
            tableData.Columns["NgaySinh"].Visible = false;
            tableData.Columns["NoiCap"].Visible = false;
            tableData.Columns["NgayCap"].Visible = false;
            tableData.Columns["DanToc"].Visible = false;
            tableData.Columns["HonNhan"].Visible = false;
            tableData.Columns["ChuyenNganh"].Visible = false;
            tableData.Columns["HinhAnh"].Visible = false;
            tableData.Columns["GioiTinhTuyenDung"].Visible = false;
            tableData.Columns["DoTuoi"].Visible = false;
            tableData.Columns["HanNopHoSo"].Visible = false;
            tableData.Columns["MucLuongToiThieu"].Visible = false;
            tableData.Columns["MucLuongToiDa"].Visible = false;
            tableData.Columns["SoLuongNop"].Visible = false;
            tableData.Columns["SoLuongDaTuyen"].Visible = false;

            //đổi tên các bảng
            tableData.Columns["MaUngVien"].HeaderText = "Mã Ứng Viên";
            tableData.Columns["MaTuyenDung"].HeaderText = "Mã Tuyển Dụng";
            tableData.Columns["HoTen"].HeaderText = "Họ Tên";
            tableData.Columns["ChucVu"].HeaderText = "Chức Vụ";
            tableData.Columns["Email"].HeaderText = "Email";
            tableData.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            tableData.Columns["TrangThai"].HeaderText = "Trạng Thái";
            tableData.Columns["TrinhDoHocVan"].HeaderText = "Trình Dộ học vấn";
            tableData.Columns["MucLuongDeal"].HeaderText = "Mức lương Deal";
            // Đưa các cột cần lên đầu
            tableData.Columns["MaUngVien"].DisplayIndex = 0;
            tableData.Columns["MaTuyenDung"].DisplayIndex = 1;


        }
        private void dataTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            tableData.ClearSelection();
            tableData.CurrentCell = null;
        }
        private void DisplayCandidateDetails(CandidateFullDTO candidate)
        {
            // Thông tin cá nhân
            txtTenLb.Text = candidate.HoTen;
            txtGioiTinhLb.Text = candidate.GioiTinh;
            txtNgaySinhLB.Text = candidate.NgaySinh.ToString("dd/MM/yyyy");
            txtEmailLb.Text = candidate.Email;
            txtSDTLb.Text = candidate.SoDienThoai;
            txtHonNhanLB.Text = candidate.HonNhan;
            txtDanTocLb.Text = candidate.DanToc;
            txtTuoi.Text = candidate.DoTuoi;
            txtCcd.Text = candidate.SoCmnd;
            txtTrinhDoLB.Text = candidate.TrinhDoHocVan;
            txtChuyenNganhLb.Text = candidate.ChuyenNganh;

            if (!string.IsNullOrEmpty(candidate.DiaChi))
            {
                string[] parts = candidate.DiaChi.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = parts[i].Trim();
                }
                if (parts.Length > 0) txtDuongLB.Text = parts[0];
                if (parts.Length > 1) txtPhuongXaLb.Text = parts[1];
                if (parts.Length > 2) txtQuanHuyenLb.Text = parts[2];
                if (parts.Length > 3) txtTinhTpLb.Text = parts[3];
            }
            else
            {             
                txtDuongLB.Text = txtPhuongXaLb.Text = txtQuanHuyenLb.Text = txtTinhTpLb.Text = "";
            }

            txtChucVu.Text = candidate.ChucVu;
            txtLuongToiThieu.Text = candidate.MucLuongToiThieu + " VND";
            txtLuongToiDa.Text = candidate.MucLuongToiDa + " VND";
            txtHanNop.Text = candidate.HanNopHoSo.ToString("dd/MM/yyyy");
            txtHoSoNop.Text = candidate.SoLuongNop.ToString();
            txtHoSoTuyen.Text = candidate.SoLuongDaTuyen.ToString();
            txtTuoi.Text = candidate.DoTuoi;
            txtGoiTinhTuyenDung.Text = candidate.GioiTinhTuyenDung;
            // Ảnh
            //try
            //{
            //    string imagePath = Path.Combine(Application.StartupPath, "Images", candidate.Anh);
            //    if (File.Exists(imagePath))
            //        pictureBox1.Image = Image.FromFile(imagePath);
            //    else
            //        pictureBox1.Image = null;
            //}
            //catch
            //{
            //    pictureBox1.Image = null;
            //}
        }

        private void tableData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = tableData.Rows[e.RowIndex];
                string maUngVien = selectedRow.Cells["maUngVien"].Value.ToString();
                CandidateFullDTO candidateFullDTO = busFullData.GetById(maUngVien);
                DisplayCandidateDetails(candidateFullDTO);
                    
            }
        }

   
    }
}
