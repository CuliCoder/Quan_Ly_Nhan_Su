using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Quan_Ly_Nhan_Su.BLL;
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
    public partial class homePage : UserControl
    {
        CT_LaborContractBLL laborContract = new CT_LaborContractBLL();
        DepartmentBLL department = new DepartmentBLL();
        EmployeeFullBLL employeeFull= new EmployeeFullBLL();
        EmployeeBLL employee = new EmployeeBLL();

        public homePage()
        {
            InitializeComponent();
            LoadchartLuong();
            LoadchartNhanVien();
            LoadTable();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homePage_Load(object sender, EventArgs e)
        {

        }
        private void LoadchartLuong()
        {
            chartLuong.Series.Clear(); // xóa tất cả các series hiện có
            Series seriesLuongAVG = new Series("Lương trung bình");
            seriesLuongAVG.ChartType = SeriesChartType.Column; // Kiểu cột
            Series seriesNhanVien = new Series("Số lượng nhân viên");
            seriesNhanVien.ChartType = SeriesChartType.Column; // Kiểu cột

            int namHienTai = DateTime.Now.Year;
            var listLaborContract = laborContract.GetAllContracts();
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
                var listEmployee = employeeFull.GetAllEmployees()
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
            chartLuong.Series.Add(seriesLuongAVG);
            chartLuong.Series.Add(seriesNhanVien);
            chartLuong.Legends[0].Docking = Docking.Top;
            chartLuong.Legends[0].Alignment = StringAlignment.Far;
            chartLuong.Legends[0].Font = new Font("Montserrat", 12, FontStyle.Bold);
            seriesLuongAVG.Font = new Font("Montserrat", 12, FontStyle.Bold);
            seriesNhanVien.Font = new Font("Montserrat", 12, FontStyle.Bold);
            // Định dạng font cho các giá trị năm (trục X) và giá trị số (trục Y)
            chartLuong.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Montserrat", 12, FontStyle.Bold);
            chartLuong.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Montserrat", 12, FontStyle.Bold);
            chartLuong.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        }
        private void LoadchartNhanVien()
        {
            chartNhanVien.Series.Clear();
            Series seriesNhanVien = new Series("chartPB");
            seriesNhanVien.ChartType = SeriesChartType.Pie;

            var listPB = department.GetAllDepartments();
            var listNV = employee.GetAll();
            var listNVFull = employeeFull.GetAllEmployees();
            var phongBanCount = new Dictionary<string, int>();
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
            // Thêm dữ liệu vào series
            foreach (var kvp in phongBanCount)
            {
                seriesNhanVien.Points.AddXY(kvp.Key, kvp.Value);
            }

            chartNhanVien.Series.Add(seriesNhanVien);
            seriesNhanVien.Label = "#PERCENT{P2}";
            seriesNhanVien.LegendText = "#VALX";
            seriesNhanVien.Font = new Font("Montserrat", 12, FontStyle.Bold);
            Legend legend = chartNhanVien.Legends[0];
            legend.Font = new Font("Montserrat", 12, FontStyle.Bold);
            // Tắt các đường thẳng đứng
            chartNhanVien.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            // Làm mờ các đường ngang
            chartNhanVien.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }
        private void LoadTable()
        {
            tableTongQuan.BackgroundColor = Color.White;
            tableTongQuan.Rows.Clear();
            tableTongQuan.Columns.Clear();
            tableTongQuan.Font = new Font("Montserrat", 12, FontStyle.Regular);
            // Thêm các cột vào DataGridView
            tableTongQuan.Columns.Add("STT", "STT");
            tableTongQuan.Columns.Add("PhongBan", "Phòng ban");
            tableTongQuan.Columns.Add("NgayThanhLap", "Ngày thành lập");
            tableTongQuan.Columns.Add("QuanLy", "Quản lý");
            tableTongQuan.Columns.Add("NhanVien", "Nhân viên");
            tableTongQuan.Columns.Add("LuongTrungBinh", "Lương trung bình");
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
            tableTongQuan.Columns["STT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["PhongBan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["NgayThanhLap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["QuanLy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["NhanVien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["LuongTrungBinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // set % cột
            tableTongQuan.Columns["STT"].FillWeight = 8;               // 8%
            tableTongQuan.Columns["PhongBan"].FillWeight = 18;         // 23%
            tableTongQuan.Columns["NgayThanhLap"].FillWeight = 15;     // 15%
            tableTongQuan.Columns["QuanLy"].FillWeight = 18;           // 18%
            tableTongQuan.Columns["NhanVien"].FillWeight = 10;         // 15%
            tableTongQuan.Columns["LuongTrungBinh"].FillWeight = 16;   // 21%

            var phongBanCount = new Dictionary<string, int>();
            var listPB = department.GetAllDepartments();
            var listNVFull = employeeFull.GetAllEmployees();
            var listNV = employee.GetAll();
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
                var stt = countTemp;
                var tenPB = pb.TenPhong;
                var NgayThanhLap = pb.NgayThanhLap;
                var tenQuanLy = pb.MaTruongPhong != null ? listNVFull.FirstOrDefault(nv => nv.MaNhanVien == pb.MaTruongPhong)?.HoTen : "Chưa có";
                var soNV = phongBanCount.ContainsKey(pb.MaPhong) ? phongBanCount[pb.MaPhong] : 0;
                //double avgLuong = listNV
                //.Where(nv => nv.PhongBan.Equals(tenPB, StringComparison.OrdinalIgnoreCase))
                //.Select(nv => (double)nv.MucLuong)
                //.DefaultIfEmpty(0)
                //.Average();
                tableTongQuan.Rows.Add(stt,
                    tenPB,
                    NgayThanhLap != null ? NgayThanhLap.Value.ToString("dd/MM/yyyy") : "chưa có",
                    tenQuanLy, 
                    soNV,
                    "không có");
                countTemp++;
            }
            // Vẽ border dưới cho từng hàng
            tableTongQuan.CellPainting += TableTongQuan_CellPainting;
            // chọn cả 1 hàng và chỉ 1 hàng được chọn
            tableTongQuan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableTongQuan.MultiSelect = false;
            // xóa cột xám đứng trước stt
            tableTongQuan.RowHeadersVisible = false;
        }
        // function vẽ border trên cho từng hàng
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

    }
}
