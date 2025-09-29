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
            chartLuong.Series.Clear();

            Series seriesLuongAVG = new Series("Lương trung bình");
            seriesLuongAVG.ChartType = SeriesChartType.Column; // Kiểu cột
            Series seriesNhanVien = new Series("Số lượng nhân viên");
            seriesNhanVien.ChartType = SeriesChartType.Column; // Kiểu cột

            seriesLuongAVG.Points.AddXY("2021", 10);
            seriesLuongAVG.Points.AddXY("2022", 20);
            seriesLuongAVG.Points.AddXY("2023", 15);

            seriesNhanVien.Points.AddXY("2021", 10);
            seriesNhanVien.Points.AddXY("2022", 20);
            seriesNhanVien.Points.AddXY("2023", 15);

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

            Series seriesNhanVien = new Series("Nhân Viên Phòng 1");
            seriesNhanVien.ChartType = SeriesChartType.Pie;

            // Thêm dữ liệu mẫu
            seriesNhanVien.Points.AddXY("Nhân viên phòng A", 10);
            seriesNhanVien.Points.AddXY("Nhân viên phòng B", 20);
            seriesNhanVien.Points.AddXY("Nhân viên phòng C", 15);

            chartNhanVien.Series.Add(seriesNhanVien);
            seriesNhanVien.Label = "#PERCENT{P2}";
            seriesNhanVien.LegendText = "#VALX";
            seriesNhanVien.Font = new Font("Montserrat", 12, FontStyle.Bold);
            Legend legend = chartNhanVien.Legends[0];
            legend.Font = new Font("Montserrat", 12, FontStyle.Bold);

            // Tắt các đường thẳng đứng (vertical grid lines)
            chartNhanVien.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            // Làm mờ các đường ngang (horizontal grid lines)
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
            tableTongQuan.Columns.Add("NgayNhanChuc", "Ngày nhận chức");
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
            tableTongQuan.Columns["NgayNhanChuc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["NhanVien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTongQuan.Columns["LuongTrungBinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // set % cột
            tableTongQuan.Columns["STT"].FillWeight = 8;               // 8%
            tableTongQuan.Columns["PhongBan"].FillWeight = 18;         // 18%
            tableTongQuan.Columns["NgayThanhLap"].FillWeight = 15;     // 15%
            tableTongQuan.Columns["QuanLy"].FillWeight = 18;           // 18%
            tableTongQuan.Columns["NgayNhanChuc"].FillWeight = 15;     // 15%
            tableTongQuan.Columns["NhanVien"].FillWeight = 10;         // 10%
            tableTongQuan.Columns["LuongTrungBinh"].FillWeight = 16;   // 16%


            tableTongQuan.Rows.Add("1", "Phòng A", "01/01/2020", "Nguyễn Văn A", "01/02/2021", "10", "15,000,000");
            tableTongQuan.Rows.Add("2", "Phòng B", "15/03/2019", "Trần Thị B", "10/04/2020", "8", "13,500,000");
            tableTongQuan.Rows.Add("3", "Phòng C", "20/06/2018", "Lê Văn C", "05/07/2019", "12", "16,200,000");
            tableTongQuan.Rows.Add("1", "Phòng A", "01/01/2020", "Nguyễn Văn A", "01/02/2021", "10", "15,000,000");
            tableTongQuan.Rows.Add("2", "Phòng B", "15/03/2019", "Trần Thị B", "10/04/2020", "8", "13,500,000");
            tableTongQuan.Rows.Add("3", "Phòng C", "20/06/2018", "Lê Văn C", "05/07/2019", "12", "16,200,000");
            tableTongQuan.Rows.Add("1", "Phòng A", "01/01/2020", "Nguyễn Văn A", "01/02/2021", "10", "15,000,000");
            tableTongQuan.Rows.Add("2", "Phòng B", "15/03/2019", "Trần Thị B", "10/04/2020", "8", "13,500,000");
            tableTongQuan.Rows.Add("3", "Phòng C", "20/06/2018", "Lê Văn C", "05/07/2019", "12", "16,200,000");
            tableTongQuan.Rows.Add("1", "Phòng A", "01/01/2020", "Nguyễn Văn A", "01/02/2021", "10", "15,000,000");
            tableTongQuan.Rows.Add("2", "Phòng B", "15/03/2019", "Trần Thị B", "10/04/2020", "8", "13,500,000");
            tableTongQuan.Rows.Add("3", "Phòng C", "20/06/2018", "Lê Văn C", "05/07/2019", "12", "16,200,000");

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
