using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; 

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class StatisticsGUI : UserControl
    {
        public StatisticsGUI()
        {
            InitializeComponent();
        }

        private void StatisticsGUI_Load(object sender, EventArgs e)
        {
            // Cấu hình biểu đồ cột (Bar Chart)
            chartBar.Series["Nhan vien"].Points.AddXY("2020", 10);
            chartBar.Series["Nhan vien"].Points.AddXY("2021", 30);
            chartBar.Series["Nhan vien"].Points.AddXY("2022", 40);
            chartBar.Series["Nhan vien"].Points.AddXY("2023", 35);
            chartBar.Series["Luong"].Points.AddXY("2020", 5);
            chartBar.Series["Luong"].Points.AddXY("2021", 15);
            chartBar.Series["Luong"].Points.AddXY("2022", 20);
            chartBar.Series["Luong"].Points.AddXY("2023", 25);

            // Cấu hình biểu đồ tròn (Pie Chart)
            chartPie.Series["Thống kê chung"].Points.AddXY("Trương phong", 25);
            chartPie.Series["Thống kê chung"].Points[0].Color = System.Drawing.Color.Blue;
            chartPie.Series["Thống kê chung"].Points.AddXY("Phó phòng", 18.6);
            chartPie.Series["Thống kê chung"].Points[1].Color = System.Drawing.Color.Green;
            chartPie.Series["Thống kê chung"].Points.AddXY("Kỹ sư phần mềm", 6.2);
            chartPie.Series["Thống kê chung"].Points[2].Color = System.Drawing.Color.Yellow;
            chartPie.Series["Thống kê chung"].Points.AddXY("PR Media", 43.8);
            chartPie.Series["Thống kê chung"].Points[3].Color = System.Drawing.Color.Orange;
            chartPie.Series["Thống kê chung"].Points.AddXY("Phát triển sản phẩm", 6.4);
            chartPie.Series["Thống kê chung"].Points[4].Color = System.Drawing.Color.Red;

            // Thêm dữ liệu mẫu cho DataGridView
            dataGridViewStats.Rows.Add("NV001", "Phòng KTCN", "2025-01-01", "2025-12-31", "Hợp đồng toàn thời gian", "15,000,000");
            dataGridViewStats.Rows.Add("NV002", "Phòng KTCN", "2025-02-01", "2025-11-30", "Hợp đồng bán thời gian", "8,000,000");
        }

        private void labelTotalContracts_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelTotalValue_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}