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
using System.Windows.Forms.DataVisualization.Charting;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class btnThongKe : UserControl
    {
        CT_LaborContractBLL laborContract = new CT_LaborContractBLL();
        private DepartmentBLL department = new DepartmentBLL();
        private EmployeeFullBLL employee = new EmployeeFullBLL();
        public btnThongKe()
        {
            InitializeComponent();
            load_cbbListNVinPhongBan();
            LoadchartLuong_NV(cbbListNVinPhongBan.SelectedItem.ToString());
            load_chartLuong(cbbListNVinPhongBan.SelectedItem?.ToString());
            load_tableTongQuan(cbbListNVinPhongBan.SelectedItem?.ToString());
        }
        private void load_cbbListNVinPhongBan()
        {
            cbbListNVinPhongBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbListNVinPhongBan.Font = new Font("Montserrat", 12, FontStyle.Bold);
            cbbListNVinPhongBan.BackColor = Color.White;
            cbbListNVinPhongBan.ForeColor = Color.Black;
            cbbListNVinPhongBan.FlatStyle = FlatStyle.Flat;
            foreach (var pb in department.GetAllDepartments())
            {
                cbbListNVinPhongBan.Items.Add(pb.TenPhong);
            }
            cbbListNVinPhongBan.SelectedIndex = 0;
        }
        private List<LaborContractDTO> GetLaborContractsByPhongBan(string phongBan)
        {
            return laborContract.GetAllContracts().
                Where(e => !string.IsNullOrEmpty(e.PhongBan) && !string.IsNullOrEmpty(phongBan) &&
                e.PhongBan.Trim().Equals(phongBan.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        private void LoadchartLuong_NV(string value)
        {
            chartNVien_Luong.Series.Clear(); // xóa tất cả các series hiện có
            Series seriesLuongAVG = new Series("Lương trung bình");
            seriesLuongAVG.ChartType = SeriesChartType.Column; // Kiểu cột
            Series seriesNhanVien = new Series("Số lượng nhân viên");
            seriesNhanVien.ChartType = SeriesChartType.Column; // Kiểu cột

            int namHienTai = DateTime.Now.Year;
            var listLaborContract = GetLaborContractsByPhongBan(cbbListNVinPhongBan.SelectedItem?.ToString());
            var nhanVienTheoNam = new Dictionary<int, Tuple<int, double>>();
            for (int year = namHienTai - 3; year <= namHienTai; year++)
            {
                var listNV = listLaborContract
                    .Where(c => c.TuNgay.HasValue && c.DenNgay.HasValue &&
                            c.TuNgay.Value.Year <= year && c.DenNgay.Value.Year >= year);
                var maNhanVienList = listNV?
                    .Where(c => c != null && c.MaNhanVien != null)
                    .Select(c => c.MaNhanVien.ToString())
                    .Distinct()
                    .ToList(); 
                var listEmployee = employee.GetAllEmployees()
                    .Where(e => maNhanVienList.Any(mnv =>
                    !string.IsNullOrEmpty(mnv) &&
                    !string.IsNullOrEmpty(e.MaNhanVien) &&
                    mnv.ToString().Trim().Equals(e.MaNhanVien.ToString().Trim(), StringComparison.OrdinalIgnoreCase)))
                    .ToList();
                var countNV = listEmployee.Count();
                //double avgLuong = listEmployee.Any()
                //    ? listEmployee.Average(e => (double)e.MucLuong)
                //    : 0;
                nhanVienTheoNam[year] = new Tuple<int, double>(countNV, 10);
            }
            foreach (var kvp in nhanVienTheoNam)
            {
                seriesNhanVien.Points.AddXY(kvp.Key.ToString(), kvp.Value.Item1);
                seriesLuongAVG.Points.AddXY(kvp.Key.ToString(), kvp.Value.Item2);
            }
            seriesLuongAVG["PointWidth"] = "0.5"; // Giá trị từ 0 đến 1
            seriesNhanVien["PointWidth"] = "0.5"; // Giá trị từ 0 đến 1
            chartNVien_Luong.Series.Add(seriesLuongAVG);
            chartNVien_Luong.Series.Add(seriesNhanVien);
            chartNVien_Luong.Legends[0].Docking = Docking.Top;
            chartNVien_Luong.Legends[0].Alignment = StringAlignment.Far;
            chartNVien_Luong.Legends[0].Font = new Font("Montserrat", 12, FontStyle.Bold);
            seriesLuongAVG.Font = new Font("Montserrat", 12, FontStyle.Bold);
            seriesNhanVien.Font = new Font("Montserrat", 12, FontStyle.Bold);
            // Định dạng font cho các giá trị năm (trục X) và giá trị số (trục Y)
            chartNVien_Luong.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Montserrat", 12, FontStyle.Bold);
            chartNVien_Luong.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Montserrat", 12, FontStyle.Bold);
            chartNVien_Luong.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        }
        private void load_chartLuong(string value)
        {
            chart_QuantityNV.Series.Clear();
            Series seriesNhanVien = new Series("Nhân Viên Phòng")
            {
                ChartType = SeriesChartType.Pie
            };
            var chucVu = new Dictionary<string, int>();
            var listNV = employee.GetAllEmployees().Where(e => e.PhongBan.ToString().Trim().Equals(value));
            foreach (var nv in listNV)
            {
                if (chucVu.ContainsKey(nv.ChucVu))
                    chucVu[nv.ChucVu]++;
                else
                    chucVu[nv.ChucVu] = 1;
            }
            foreach (var item in chucVu)
            {
                string tenChucVu = item.Key;
                int soLuong = item.Value;
                seriesNhanVien.Points.AddXY(tenChucVu, soLuong);
            }
            // Thêm dữ liệu mẫu
            chart_QuantityNV.Series.Add(seriesNhanVien);
            seriesNhanVien.Label = "#PERCENT{P2}";
            seriesNhanVien.LegendText = "#VALX";
            seriesNhanVien.Font = new Font("Montserrat", 12, FontStyle.Bold);
            Legend legend = chart_QuantityNV.Legends[0];
            legend.Font = new Font("Montserrat", 12, FontStyle.Bold);
            // Tắt các đường thẳng đứng (vertical grid lines)
            chart_QuantityNV.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            // Làm mờ các đường ngang (horizontal grid lines)
            chart_QuantityNV.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }
        private void load_tableTongQuan(string value)
        {
            tableTongQuan.BackgroundColor = Color.White;
            tableTongQuan.Rows.Clear();
            tableTongQuan.Columns.Clear();
            tableTongQuan.Font = new Font("Montserrat", 12, FontStyle.Regular);

            // Thêm các cột vào DataGridView
            tableTongQuan.Columns.Add("MNV", "MNV");
            tableTongQuan.Columns.Add("HoTen", "Họ tên");
            tableTongQuan.Columns.Add("GioiTinh", "Giới tính");
            tableTongQuan.Columns.Add("Email", "Email");
            tableTongQuan.Columns.Add("Sdt", "Sdt");
            tableTongQuan.Columns.Add("Cmnd", "Cmnd");
            tableTongQuan.Columns.Add("ChucVu", "Chức vụ");
            tableTongQuan.Columns.Add("Luong", "Lương");

            tableTongQuan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableTongQuan.ColumnHeadersHeight = 40;
            // set chiều cao của các row
            tableTongQuan.RowTemplate.Height = 36;

            // xóa tất cả các border mặc định
            tableTongQuan.BorderStyle = BorderStyle.None;
            tableTongQuan.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tableTongQuan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tableTongQuan.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Định dạng cột để set %
            tableTongQuan.Columns["MNV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["GioiTinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["Sdt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["Cmnd"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["ChucVu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["Luong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // set % cột
            tableTongQuan.Columns["MNV"].FillWeight = 8;           // Mã nhân viên: ngắn, chiếm ít
            tableTongQuan.Columns["HoTen"].FillWeight = 18;        // Họ tên: dài, ưu tiên nhiều hơn
            tableTongQuan.Columns["GioiTinh"].FillWeight = 7;      // Giới tính: ngắn
            tableTongQuan.Columns["Email"].FillWeight = 20;        // Email: vừa
            tableTongQuan.Columns["Sdt"].FillWeight = 10;          // Số điện thoại: vừa
            tableTongQuan.Columns["Cmnd"].FillWeight = 12;         // CMND: vừa
            tableTongQuan.Columns["ChucVu"].FillWeight = 10;       // Chức vụ: vừa
            tableTongQuan.Columns["Luong"].FillWeight = 15;  // Lương thưởng: vừa

            var listNV = employee.GetAllEmployees().Where(e => e.PhongBan.ToString().Trim().Equals(value));
            foreach (var nv in listNV)
            {
                if(nv != null)
                {
                    tableTongQuan.Rows.Add(nv.MaNhanVien,
                    nv.HoTen,
                    nv.GioiTinh,
                    nv.Email,
                    nv.Sdt,
                    nv.SoCmnd,
                    nv.ChucVu,
                    //nv.MucLuong.ToString("N0") + " VNĐ")
                    "không có");
                }
            }
      
            // Vẽ border dưới cho từng hàng
            tableTongQuan.CellPainting += TableTongQuan_CellPainting;

            // chọn cả 1 hàng và chỉ 1 hàng được chọn
            tableTongQuan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableTongQuan.MultiSelect = false;

            // xóa cột xám đứng trước stt
            tableTongQuan.RowHeadersVisible = false;
        }
        private void TableTongQuan_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                e.Graphics.FillRectangle(new SolidBrush(tableTongQuan.ColumnHeadersDefaultCellStyle.BackColor), e.CellBounds);
                TextRenderer.DrawText(e.Graphics, e.FormattedValue?.ToString() ?? "",
                    tableTongQuan.ColumnHeadersDefaultCellStyle.Font,
                    e.CellBounds,
                    tableTongQuan.ColumnHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                e.Handled = true;
            }
        }
        private void cbbListNVinPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPhongBan = cbbListNVinPhongBan.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedPhongBan))
            {
                LoadchartLuong_NV(selectedPhongBan);
                load_chartLuong(selectedPhongBan);
                load_tableTongQuan(selectedPhongBan);
            }
        }
    }
}
