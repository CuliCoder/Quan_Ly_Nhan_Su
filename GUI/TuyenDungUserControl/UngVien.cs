using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl
{
    public partial class UngVien : UserControl
    {
        private readonly CandidateFullBLL busFullData;
        private readonly RecruitmentBatchBLL busBatch;
        private List<CandidateFullDTO> list;

        public UngVien()
        {
            InitializeComponent();

            // Khởi tạo các BLL
            busFullData = new CandidateFullBLL();
            busBatch = new RecruitmentBatchBLL();

            // Lấy dữ liệu
            list = busFullData.GetAll();

            // Gán event handler cho tableData
            tableData.CellClick += tableData_CellClick;
            tableData.DataBindingComplete += dataTable_DataBindingComplete;

            // Hiển thị dữ liệu
            fillDataToTable(list);
        }

        private void dataTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            tableData.ClearSelection();
            tableData.CurrentCell = null;
        }


        private void luuThanhcong(object sender, EventArgs e, string message)
        {
            MessageBox.Show(message);
            busFullData.GetAll();
            list = busFullData.GetAll();
            fillDataToTable(list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormThemUngVien themUngVienForm = new FormThemUngVien();
            themUngVienForm.luuThongTinForm += (s, ev) => luuThanhcong(s, ev, "Lưu thành công!"); 
            themUngVienForm.StartPosition = FormStartPosition.CenterScreen;
            themUngVienForm.ShowDialog();
        }
  
        private void fillDataToTable(List<CandidateFullDTO> list)
        {
            tableData.DataSource = null;
            tableData.DataSource = list;
            //ẩn các bảng cột không cần thiêt
          
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
            tableData.Columns["SoLuongCanTuyen"].Visible = false;

            //đổi tên các bảng
            tableData.Columns["MaUngVien"].HeaderText = "Mã Ứng Viên";
            tableData.Columns["MaTuyenDung"].HeaderText = "Mã Tuyển Dụng";
            tableData.Columns["SoCmnd"].HeaderText = "Số căn cước";
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
            tableData.Columns["SoCmnd"].DisplayIndex = 2;


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
            try
            {   
                string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string imagePath = Path.Combine(projectPath, candidate.HinhAnh ?? "");
                string defaultImagePath = Path.Combine(projectPath, @"GUI\assets\img\images.png");

                string finalPath = "";

                if (!string.IsNullOrEmpty(candidate.HinhAnh) && File.Exists(imagePath))
                    finalPath = imagePath;
                else if (File.Exists(defaultImagePath))
                    finalPath = defaultImagePath;
                else
                    finalPath = "";
                if (!string.IsNullOrEmpty(finalPath))
                    pictureBox1.Image = Image.FromFile(finalPath);
                else
                    pictureBox1.Image = null;
            }
            catch (Exception ex)
            {
                pictureBox1.Image = null;
                MessageBox.Show("Lỗi tải ảnh: " + ex.Message);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (tableData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa");
                return;
            }

            DataGridViewRow selectedRow = tableData.CurrentRow;
            string maUngVien = selectedRow.Cells["MaUngVien"].Value.ToString();
            string soCccd = selectedRow.Cells["SoCmnd"].Value.ToString();
            string maTuyenDung = selectedRow.Cells["MaTuyenDung"].Value.ToString();
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa ứng viên '{maUngVien}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                bool isDeleted = busFullData.DeleteCadidateWithProfile(soCccd, maUngVien);
                if (isDeleted)
                {
                    if(busBatch.UpdateProfileDelete(maTuyenDung))
                    {
                        MessageBox.Show("Xóa thành công!");
                        busFullData.GetAll();
                        list = busFullData.GetAll();
                        fillDataToTable(list);
                    }else
                    {
                        MessageBox.Show("Cập nhật số lượng thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }


        private List<CandidateFullDTO> handledSearch ()
        {
            string keyWord = tbSearch.Text.Trim();
            return busFullData.Search(keyWord);
        }
        private void label3_Click(object sender, EventArgs e)
        {

            fillDataToTable(handledSearch());
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillDataToTable(handledSearch());
                e.SuppressKeyPress = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            list = busFullData.GetAll();
            fillDataToTable(list);
        }

        private CandidateFullDTO getDataGirdview()
        {
            DataGridViewRow currentRow = tableData.CurrentRow;
            if (currentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một ứng viên trong danh sách!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return null;
            }

            var cellMaUngVien = currentRow.Cells["MaUngVien"]?.Value;
            var cellTrangThai = currentRow.Cells["TrangThai"]?.Value;


            if (cellMaUngVien == null || cellTrangThai == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu ứng viên. Vui lòng thử lại!",
                                "Lỗi dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return null;
            }

            string maUngVien = cellMaUngVien.ToString();
            string trangThai = cellTrangThai.ToString();

            if (trangThai.Equals("Đã Tuyển", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Ứng viên này đã được tuyển!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return null;
            }
            return busFullData.GetById(maUngVien);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            CandidateFullDTO candidate = getDataGirdview();
            if(candidate != null)
            {
                if(candidate.SoLuongDaTuyen == candidate.SoLuongCanTuyen)
                {
                    MessageBox.Show("Tuyển dụng này đã tuyển đủ số lượng ứng viên");
                    return;
                }
                FormTuyenUngVien tuyenUngVienForm = new FormTuyenUngVien(candidate);
                tuyenUngVienForm.luuThongTinForm += (s, ev) => luuThanhcong(s, ev, "Thêm nhân viên thành công");
                tuyenUngVienForm.StartPosition = FormStartPosition.CenterScreen;
                tuyenUngVienForm.ShowDialog();
            }
        }
    }
}
