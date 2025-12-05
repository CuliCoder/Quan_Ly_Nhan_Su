



using Google.Protobuf.WellKnownTypes;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.GUI.PhongBanUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class btnQuanLy : UserControl
    {
        private DepartmentBLL departmentBLL = new DepartmentBLL();
        private EmployeeFullBLL employeeFull = new EmployeeFullBLL();
        private EmployeeBLL employee = new EmployeeBLL();
        private SalaryFullBLL salaryFull = new SalaryFullBLL();
        public btnQuanLy()
        {
            InitializeComponent();
            loadColorbtn();
            load_tbPB();
            load_tbNV();
        }
        private void load_tbPB()
        {
            tbPB.BackgroundColor = Color.White;
            tbPB.Rows.Clear();
            tbPB.Columns.Clear();
            tbPB.Font = new Font("Montserrat", 12, FontStyle.Regular);

            // Thêm các cột vào DataGridView
            tbPB.Columns.Add("MaPB", "Mã PB");
            tbPB.Columns.Add("PhongBan", "Phòng ban");
            tbPB.Columns.Add("NgayThanhLap", "Ngày thành lập");
            tbPB.Columns.Add("QuanLy", "Quản lý");
            tbPB.Columns.Add("NhanVien", "Nhân viên");
            tbPB.Columns.Add("LuongTrungBinh", "Lương trung bình");


            tbPB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tbPB.ColumnHeadersHeight = 40;
            // set chiều cao của các row
            tbPB.RowTemplate.Height = 36;


            // xóa tất cả các border mặc định
            tbPB.BorderStyle = BorderStyle.None;
            tbPB.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tbPB.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tbPB.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Định dạng cột để set %
            tbPB.Columns["MaPB"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbPB.Columns["PhongBan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbPB.Columns["NgayThanhLap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbPB.Columns["QuanLy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbPB.Columns["NhanVien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbPB.Columns["LuongTrungBinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // set % cột
            tbPB.Columns["MaPB"].FillWeight = 8;               // 8%
            tbPB.Columns["PhongBan"].FillWeight = 18;         // 23%
            tbPB.Columns["NgayThanhLap"].FillWeight = 15;     // 15%
            tbPB.Columns["QuanLy"].FillWeight = 18;           // 18%
            tbPB.Columns["NhanVien"].FillWeight = 10;         // 15%
            tbPB.Columns["LuongTrungBinh"].FillWeight = 16;   // 21%

            var phongBanCount = new Dictionary<string, int>();
            var listPB = departmentBLL.GetAllDepartments();
            var listNV = employee.GetAll();
            var listNVFull = employeeFull.GetAllEmployees();
            foreach (var nv in listNV)
            {
                // Tìm tên phòng ban từ listPB
                var pb = listPB.FirstOrDefault(x => x.MaPhong.Trim().Equals(nv.MaPhong.Trim(), StringComparison.OrdinalIgnoreCase));
                if (pb != null)
                {
                    if (phongBanCount.ContainsKey(pb.MaPhong))
                        phongBanCount[pb.MaPhong]++;
                    else
                        phongBanCount[pb.MaPhong] = 1;
                }
            }
            int countTemp = 1;
            foreach (var pb in listPB)
            {
                var stt = pb.MaPhong;
                var tenPB = pb.TenPhong;
                var NgayThanhLap = pb.NgayThanhLap;
                var tenQuanLy = pb.MaTruongPhong != null ? listNVFull.FirstOrDefault(nv => nv.MaNhanVien == pb.MaTruongPhong)?.HoTen : "Chưa có";
                var soNV = phongBanCount.ContainsKey(pb.MaPhong) ? phongBanCount[pb.MaPhong] : 0;
                var maNhanVienList = listNV?
                    .Where(c => c != null && c.MaPhong != null && c.MaPhong.Trim().Equals(pb.MaPhong.Trim(), StringComparison.OrdinalIgnoreCase))
                    .Select(c => c.MaNhanVien.ToString());
                var SLL = salaryFull.GetAllSalaryFull()
                   .Where(s => maNhanVienList.Any(mnv =>
                   !string.IsNullOrEmpty(mnv) &&
                   !string.IsNullOrEmpty(s.MaNhanVien) &&
                   mnv.ToString().Trim().Equals(s.MaNhanVien.ToString().Trim(), StringComparison.OrdinalIgnoreCase)))
                   .ToList();
                var avgLuong = SLL.Any() ? SLL.Average(s => (double)s.LuongThucLanh) : 0;
                tbPB.Rows.Add(stt,
                    tenPB,
                    NgayThanhLap != null ? NgayThanhLap.Value.ToString("dd/MM/yyyy") : "chưa có",
                    tenQuanLy,
                    soNV,
                    avgLuong.ToString("N0") + " VNĐ"
                    );
                countTemp++;
            }
            // Vẽ border dưới cho từng hàng
            tbPB.CellPainting += Table_CellPainting;

            // chọn cả 1 hàng và chỉ 1 hàng được chọn
            tbPB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tbPB.MultiSelect = false;

            // xóa cột xám đứng trước stt
            tbPB.RowHeadersVisible = false;
            tbPB.CellClick += tbPB_CellClick;
            tbPB.ReadOnly = true;
            tbPB.AllowUserToResizeColumns = false;
            tbPB.AllowUserToResizeRows = false;

        }
        private void Table_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.PaintContent(e.ClipBounds);

                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    // Vẽ border dưới
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top - 1, e.CellBounds.Right, e.CellBounds.Top - 1);
                }
                e.Handled = true;
            }
            else if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                // Vẽ lại header với màu nền mặc định
                e.Graphics.FillRectangle(new SolidBrush(tbPB.ColumnHeadersDefaultCellStyle.BackColor), e.CellBounds);
                TextRenderer.DrawText(e.Graphics, e.FormattedValue?.ToString() ?? "",
                    tbPB.ColumnHeadersDefaultCellStyle.Font,
                    e.CellBounds,
                    tbPB.ColumnHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                e.Handled = true;
            }
        }
        private void load_tbNV()
        {
            tbNV.BackgroundColor = Color.White;
            tbNV.Rows.Clear();
            tbNV.Columns.Clear();
            tbNV.Font = new Font("Montserrat", 12, FontStyle.Regular);
            // Thêm các cột vào DataGridView
            tbNV.Columns.Add("MaNV", "Mã NV");
            tbNV.Columns.Add("HoTen", "Họ tên");
            tbNV.Columns.Add("GioiTinh", "Giới tính");
            tbNV.Columns.Add("ChucVu", "Chức vụ");
            tbNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tbNV.ColumnHeadersHeight = 40;
            // set chiều cao của các row
            tbNV.RowTemplate.Height = 36;
            // xóa tất cả các border mặc định
            tbNV.BorderStyle = BorderStyle.None;
            tbNV.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tbNV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tbNV.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            // Định dạng cột để set %
            tbNV.Columns["MaNV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbNV.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbNV.Columns["GioiTinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbNV.Columns["ChucVu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // set % cột
            tbNV.Columns["MaNV"].FillWeight = 20;     // 20%
            tbNV.Columns["HoTen"].FillWeight = 35;    // 40%
            tbNV.Columns["GioiTinh"].FillWeight = 15;       // 10%
            tbNV.Columns["ChucVu"].FillWeight = 30;   // 30%
                                                      // Vẽ border dưới cho từng hàng
            tbNV.CellPainting += Table_CellPainting;

            // chọn cả 1 hàng và chỉ 1 hàng được chọn
            tbNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tbNV.MultiSelect = false;

            // xóa cột xám đứng trước stt
            tbNV.RowHeadersVisible = false;
            tbNV.CellClick += tbNV_CellClick;
            tbNV.ReadOnly = true;
            tbNV.AllowUserToResizeColumns = false;
            tbNV.AllowUserToResizeRows = false;
        }
        private void tbPB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tbNV.Rows.Clear();
                DataGridViewRow selectedRow = tbPB.Rows[e.RowIndex];
                string maPhongBan = selectedRow.Cells["MaPB"].Value?.ToString();
                var listNV = employee.GetAll().Where(nv => nv.MaPhong.ToString().Trim().Equals(maPhongBan));
                var listMaNV = listNV.Select(nv => nv.MaNhanVien).ToList();
                var listNVFull = employeeFull.GetAllEmployees().Where(nv => listMaNV.Contains(nv.MaNhanVien)).ToList();
                foreach (var nv in listNVFull)
                {
                    if (nv != null)
                    {
                        tbNV.Rows.Add(nv.MaNhanVien,
                        nv.HoTen,
                        nv.GioiTinh,
                        nv.ChucVu);
                    }
                }
            }
            tbNV.ClearSelection();
        }
        private void tbNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = tbNV.Rows[e.RowIndex];
                string maNV = selectedRow.Cells["MaNV"].Value?.ToString();
                var NV = employeeFull.GetAllEmployees().FirstOrDefault(nv => nv.MaNhanVien.ToString().Trim().Equals(maNV));
                if (NV != null)
                {
                    lbMNV2.Text = NV.MaNhanVien;
                    lbHT2.Text = NV.HoTen;
                    lbGT2.Text = NV.GioiTinh;
                    lbCV2.Text = NV.ChucVu;
                    lbNS2.Text = NV.NgaySinh != null ? NV.NgaySinh.Value.ToString("dd/MM/yyyy") : "chưa có";
                    lbDT2.Text = NV.Sdt;
                    lbDC2.Text = NV.DiaChi;
                    lbHV2.Text = NV.HocVan;
                }
            }
        }
        private void boxdelete_Click(object sender, EventArgs e)
        {
            if (tbPB.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên được chọn
                DataGridViewRow selectedRow = tbPB.SelectedRows[0];
                string maPhongBan = selectedRow.Cells["MaPB"].Value?.ToString();
                // Tìm phòng ban theo tên (hoặc mã nếu có)
                var pb = departmentBLL.GetAllDepartments()
                    .FirstOrDefault(x => x.MaPhong.Trim().Equals(maPhongBan, StringComparison.OrdinalIgnoreCase));
                var listNV = employee.GetAll().Where(nv => nv.MaPhong.ToString().Trim().Equals(pb.MaPhong)).ToList();
                if (pb != null)
                {
                    if (listNV.Count == 0)
                    {
                        bool result = departmentBLL.DeleteDepartment(pb.MaPhong);
                        if (result)
                        {
                            MessageBox.Show("Xóa phòng ban thành công!");
                            tbPB.Rows.Remove(tbPB.SelectedRows[0]);
                        }
                        else
                        {
                            MessageBox.Show("Xóa phòng ban thất bại!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phòng ban có nhân viên, không thể xóa!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phòng ban để xóa!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phòng ban để xóa!");
            }
        }
        private void Label_MouseEnter(object sender, EventArgs e)
        {
            if (sender == boxdelete || sender == label2 || sender == delete)
            {
                boxdelete.BackColor = ColorTranslator.FromHtml("#4A9B85");
            }
            if (sender == boxEdit || sender == pictureBox1 || sender == label3)
            {
                boxEdit.BackColor = ColorTranslator.FromHtml("#4A9B85");
            }
            if (sender == boxAdd || sender == icAdd || sender == label4)
            {
                boxAdd.BackColor = ColorTranslator.FromHtml("#4A9B85");
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            if (sender == boxdelete || sender == label2 || sender == delete)
            {
                loadColorbtn();
            }
            if (sender == boxEdit || sender == pictureBox1 || sender == label3)
            {
                loadColorbtn();
            }
            if (sender == boxAdd || sender == icAdd || sender == label4)
            {
                loadColorbtn();
            }
        }
        private void lb_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {
                using (Pen pen = new Pen(Color.Gray, 2))
                {
                    Rectangle rect = lbl.ClientRectangle;
                    rect.Width -= 1;
                    rect.Height -= 1;
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
        private void boxAdd_Click(object sender, EventArgs e)
        {
            var frm = new addDepartment();
            frm.ShowDialog();
            load_tbPB();
        }
        private void boxEdit_Click(object sender, EventArgs e)
        {
            if (tbPB.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên được chọn
                DataGridViewRow selectedRow = tbPB.SelectedRows[0];
                string maPhongBan = selectedRow.Cells["MaPB"].Value?.ToString();
                var pb = departmentBLL.GetDepartmentById(maPhongBan);
                var frm = new editDepartment(pb);
                frm.ShowDialog();
                load_tbPB();
            }

        }

        private void loadColorbtn()
        {
            Color customColor = ColorTranslator.FromHtml("#5DC2A7");
            boxAdd.BackColor = customColor;
            boxEdit.BackColor = customColor;
            boxdelete.BackColor = customColor;
            // Có thể set cho các panel khác nếu muốn
        }

        private void lbHT2_Click(object sender, EventArgs e)
        {

        }

        private void lbMNV2_Click(object sender, EventArgs e)
        {

        }

        private void lbGT2_Click(object sender, EventArgs e)
        {

        }

        private void lbNS2_Click(object sender, EventArgs e)
        {

        }
    }
}