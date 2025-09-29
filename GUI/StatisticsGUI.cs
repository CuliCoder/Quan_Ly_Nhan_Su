using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Quan_Ly_Nhan_Su.BLL;  // Để sử dụng LaborContractBLL và EmployeeBLL
using Quan_Ly_Nhan_Su.DTO; // Để sử dụng DTO

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class StatisticsGUI : UserControl
    {
        private readonly LaborContractBLL _laborContractBLL;
        private readonly EmployeeBLL _employeeBLL;

        public StatisticsGUI()
        {
            InitializeComponent();
            _laborContractBLL = new LaborContractBLL();
            _employeeBLL = new EmployeeBLL();
        }

        private void StatisticsGUI_Load(object sender, EventArgs e)
        {
            LoadData();  // Tải dữ liệu ban đầu
            SetupChartSeries();  // Thiết lập series cho biểu đồ nếu chưa có
        }

        /// <summary>
        /// Tải dữ liệu hợp đồng và thống kê
        /// </summary>
        private void LoadData()
        {
            // Lấy tất cả hợp đồng từ BLL
            List<LaborContractDTO> contracts = _laborContractBLL.GetAllContracts();

            // Lọc nếu có lựa chọn từ comboBox (ví dụ: lọc theo loại hợp đồng)
            string selectedType = comboBox1.SelectedItem?.ToString() ?? comboBox1.Text;
            if (selectedType != "Tất cả hợp đồng")
            {
                contracts = contracts.Where(c => c.LoaiHopDong == selectedType).ToList();
            }

            // Hiển thị trong DataGridView
            dataGridViewStats.Rows.Clear();
            foreach (var contract in contracts)
            {
                dataGridViewStats.Rows.Add(
                    contract.MaNhanVien,
                    contract.PhongBan,
                    contract.TuNgay?.ToString("yyyy-MM-dd"),
                    contract.DenNgay?.ToString("yyyy-MM-dd"),
                    contract.LoaiHopDong,
                    contract.LuongCoBan.ToString("N0")  // Định dạng tiền tệ
                );
            }

            // Thống kê tổng
            int totalContracts = contracts.Count;
            decimal totalValue = contracts.Sum(c => c.LuongCoBan);

            labelTotalContracts.Text = $"Tổng hợp đồng: {totalContracts}";
            labelTotalValue.Text = $"Tổng lương: {totalValue:N0} VND";

            // Cập nhật biểu đồ
            UpdateCharts(contracts);
        }

        /// <summary>
        /// Thiết lập series cho biểu đồ nếu chưa có (dựa trên mã comment cũ)
        /// </summary>
        private void SetupChartSeries()
        {
            // Cho chartBar (biểu đồ cột)
            if (!chartBar.Series.Any(s => s.Name == "Nhan vien"))
            {
                chartBar.Series.Add(new Series("Nhan vien") { ChartType = SeriesChartType.Column });
            }
            if (!chartBar.Series.Any(s => s.Name == "Luong"))
            {
                chartBar.Series.Add(new Series("Luong") { ChartType = SeriesChartType.Column });
            }

            // Cho chartPie (biểu đồ tròn)
            if (!chartPie.Series.Any(s => s.Name == "Thống kê chung"))
            {
                chartPie.Series.Add(new Series("Thống kê chung") { ChartType = SeriesChartType.Pie });
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu cho biểu đồ
        /// </summary>
        private void UpdateCharts(List<LaborContractDTO> contracts)
        {
            // Xóa dữ liệu cũ
            chartBar.Series["Nhan vien"].Points.Clear();
            chartBar.Series["Luong"].Points.Clear();
            chartPie.Series["Thống kê chung"].Points.Clear();

            // Thống kê theo năm cho chartBar (số nhân viên và tổng lương)
            var yearlyStats = contracts.GroupBy(c => c.TuNgay?.Year ?? DateTime.Now.Year)
                                       .OrderBy(g => g.Key);

            foreach (var group in yearlyStats)
            {
                int year = group.Key;
                int employeeCount = group.Count();
                decimal totalSalary = group.Sum(c => c.LuongCoBan);

                chartBar.Series["Nhan vien"].Points.AddXY(year.ToString(), employeeCount);
                chartBar.Series["Luong"].Points.AddXY(year.ToString(), totalSalary / 1000000);  // Chia cho triệu để dễ xem
            }

            // Thống kê phân bố theo phòng ban cho chartPie
            var departmentStats = contracts.GroupBy(c => c.PhongBan)
                                           .OrderByDescending(g => g.Count());

            Color[] colors = { Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Red };  // Màu mẫu
            int colorIndex = 0;

            foreach (var group in departmentStats)
            {
                string department = group.Key ?? "Không xác định";
                double percentage = (double)group.Count() / contracts.Count * 100;

                var point = chartPie.Series["Thống kê chung"].Points.AddXY(department, percentage);
                chartPie.Series["Thống kê chung"].Points[point].Color = colors[colorIndex % colors.Length];
                colorIndex++;
            }

            // Cập nhật tiêu đề và legend
            chartBar.Titles.Add("Thống kê Nhân viên và Lương theo Năm");
            chartPie.Titles.Add("Phân bố theo Phòng Ban");
        }

        // Xử lý sự kiện thay đổi comboBox để lọc lại dữ liệu
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBoxContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu bạn muốn lọc thêm theo comboBoxContractType (ví dụ: theo trạng thái hoặc chức vụ)
            LoadData();
        }

        // Các event khác giữ nguyên
        private void labelTotalContracts_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void labelTotalValue_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}