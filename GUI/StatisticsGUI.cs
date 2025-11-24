using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class StatisticsGUI : UserControl
    {
        private readonly LaborContractBLL _laborContractBLL;
        private readonly EmployeeFullBLL _employeeBLL;

        public StatisticsGUI()
        {
            InitializeComponent();
            _laborContractBLL = new LaborContractBLL();
            _employeeBLL = new EmployeeFullBLL();
        }

        private void StatisticsGUI_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeComboBoxes();
                SetupChartStyle();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo giao diện thống kê:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", 
                    "Lỗi khởi tạo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Khởi tạo dữ liệu cho ComboBox
        /// </summary>
        private void InitializeComboBoxes()
        {
            try
            {
                // ComboBox loại hợp đồng
                comboBoxContractType.Items.Clear();
                comboBoxContractType.Items.Add("Tất cả hợp đồng");
                comboBoxContractType.Items.Add("Hợp đồng thử việc");
                comboBoxContractType.Items.Add("Hợp đồng có thời hạn");
                comboBoxContractType.Items.Add("Hợp đồng không thời hạn");
                comboBoxContractType.Items.Add("Xác định thời hạn");
                comboBoxContractType.SelectedIndex = 0;
                
                // Gỡ bỏ event cũ nếu có để tránh duplicate
                comboBoxContractType.SelectedIndexChanged -= ComboBoxContractType_SelectedIndexChanged;
                comboBoxContractType.SelectedIndexChanged += ComboBoxContractType_SelectedIndexChanged;

                // ComboBox năm
                comboBoxYear.Items.Clear();
                comboBoxYear.Items.Add("Tất cả");
                int currentYear = DateTime.Now.Year;
                for (int year = currentYear; year >= currentYear - 10; year--)
                {
                    comboBoxYear.Items.Add(year.ToString());
                }
                comboBoxYear.SelectedIndex = 0;
                
                // Gỡ bỏ event cũ nếu có để tránh duplicate
                comboBoxYear.SelectedIndexChanged -= ComboBoxYear_SelectedIndexChanged;
                comboBoxYear.SelectedIndexChanged += ComboBoxYear_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo ComboBox: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ComboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Thiết lập style cho biểu đồ
        /// </summary>
        private void SetupChartStyle()
        {
            try
            {
                // Style cho Chart Bar
                if (chartBar.ChartAreas.Count > 0)
                {
                    chartBar.ChartAreas[0].BackColor = Color.FromArgb(236, 240, 241);
                    chartBar.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                    chartBar.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                    chartBar.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
                    chartBar.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
                    chartBar.ChartAreas[0].AxisX.Interval = 1; // Hiển thị tất cả năm
                }

                chartBar.Titles.Clear();
                var titleBar = chartBar.Titles.Add("Thống kê nhân viên và lương theo năm");
                titleBar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                titleBar.ForeColor = Color.FromArgb(52, 73, 94);

                // Style cho Chart Pie
                if (chartPie.ChartAreas.Count > 0)
                {
                    chartPie.ChartAreas[0].BackColor = Color.FromArgb(236, 240, 241);
                }

                chartPie.Titles.Clear();
                var titlePie = chartPie.Titles.Add("Phân bổ hợp đồng theo phòng ban");
                titlePie.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                titlePie.ForeColor = Color.FromArgb(52, 73, 94);

                // Xóa series cũ nếu có
                chartBar.Series.Clear();
                chartPie.Series.Clear();

                // Series cho biểu đồ Bar
                var seriesEmployee = chartBar.Series.Add("Nhân viên");
                seriesEmployee.ChartType = SeriesChartType.Column;
                seriesEmployee.Color = Color.FromArgb(52, 152, 219);
                seriesEmployee.BorderWidth = 0;
                seriesEmployee.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột
                seriesEmployee.Font = new Font("Segoe UI", 8F, FontStyle.Bold);

                var seriesSalary = chartBar.Series.Add("Lương (Triệu)");
                seriesSalary.ChartType = SeriesChartType.Column;
                seriesSalary.Color = Color.FromArgb(241, 196, 15);
                seriesSalary.BorderWidth = 0;
                seriesSalary.IsValueShownAsLabel = true;
                seriesSalary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);

                // Series cho biểu đồ Pie
                var seriesPie = chartPie.Series.Add("Phân bổ phòng ban");
                seriesPie.ChartType = SeriesChartType.Pie;
                seriesPie["PieLabelStyle"] = "Outside";
                seriesPie.BorderWidth = 2;
                seriesPie.BorderColor = Color.White;
                seriesPie.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thiết lập biểu đồ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải dữ liệu hợp đồng và thống kê
        /// </summary>
        private void LoadData()
        {
            try
            {
                // Hiển thị loading indicator nếu cần
                this.Cursor = Cursors.WaitCursor;

                // Lấy tất cả hợp đồng từ BLL
                List<LaborContractDTO> contracts = _laborContractBLL.GetAllContracts();

                if (contracts == null || contracts.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu hợp đồng trong hệ thống.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllData();
                    return;
                }

                // Lọc theo loại hợp đồng
                string selectedType = comboBoxContractType.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedType) && selectedType != "Tất cả hợp đồng")
                {
                    contracts = contracts.Where(c => 
                        !string.IsNullOrEmpty(c.LoaiHopDong) && 
                        c.LoaiHopDong.Equals(selectedType, StringComparison.OrdinalIgnoreCase)
                    ).ToList();
                }

                // Lọc theo năm
                string selectedYear = comboBoxYear.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedYear) && selectedYear != "Tất cả")
                {
                    int year = int.Parse(selectedYear);
                    contracts = contracts.Where(c => 
                        (c.TuNgay.HasValue && c.TuNgay.Value.Year == year) || 
                        (c.DenNgay.HasValue && c.DenNgay.Value.Year == year)
                    ).ToList();
                }

                // Hiển thị trong DataGridView
                DisplayDataInGrid(contracts);

                // Cập nhật thống kê
                UpdateStatistics(contracts);

                // Cập nhật biểu đồ
                UpdateCharts(contracts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu:\n{ex.Message}\n\nChi tiết:\n{ex.StackTrace}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Xóa tất cả dữ liệu khi không có hợp đồng
        /// </summary>
        private void ClearAllData()
        {
            dataGridViewStats.Rows.Clear();
            labelTotalContractsValue.Text = "0";
            labelTotalValue.Text = "0 VNĐ";
            labelAvgSalaryValue.Text = "0 VNĐ";
            chartBar.Series["Nhân viên"].Points.Clear();
            chartBar.Series["Lương (Triệu)"].Points.Clear();
            chartPie.Series["Phân bổ phòng ban"].Points.Clear();
        }

        /// <summary>
        /// Hiển thị dữ liệu trong DataGridView
        /// </summary>
        private void DisplayDataInGrid(List<LaborContractDTO> contracts)
        {
            try
            {
                dataGridViewStats.Rows.Clear();
                
                foreach (var contract in contracts)
                {
                    dataGridViewStats.Rows.Add(
                        contract.TenNhanVien ?? contract.MaNhanVien ?? "N/A",
                        contract.PhongBan ?? "Chưa phân công",
                        contract.TuNgay?.ToString("dd/MM/yyyy") ?? "N/A",
                        contract.DenNgay?.ToString("dd/MM/yyyy") ?? "N/A",
                        contract.LoaiHopDong ?? "N/A",
                        contract.LuongCoBan.ToString("N0") + " VNĐ"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị dữ liệu trong bảng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật các số liệu thống kê
        /// </summary>
        private void UpdateStatistics(List<LaborContractDTO> contracts)
        {
            try
            {
                int totalContracts = contracts.Count;
                decimal totalSalary = contracts.Sum(c => c.LuongCoBan);
                decimal avgSalary = totalContracts > 0 ? totalSalary / totalContracts : 0;

                labelTotalContractsValue.Text = totalContracts.ToString("N0");
                labelTotalValue.Text = totalSalary.ToString("N0") + " VNĐ";
                labelAvgSalaryValue.Text = avgSalary.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật thống kê: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu cho biểu đồ
        /// </summary>
        private void UpdateCharts(List<LaborContractDTO> contracts)
        {
            try
            {
                // Xóa dữ liệu cũ
                chartBar.Series["Nhân viên"].Points.Clear();
                chartBar.Series["Lương (Triệu)"].Points.Clear();
                chartPie.Series["Phân bổ phòng ban"].Points.Clear();

                if (contracts == null || contracts.Count == 0)
                {
                    return;
                }

                // Thống kê theo năm cho chartBar
                var yearlyStats = contracts
                    .Where(c => c.TuNgay.HasValue)
                    .GroupBy(c => c.TuNgay.Value.Year)
                    .OrderBy(g => g.Key)
                    .Select(g => new
                    {
                        Year = g.Key,
                        EmployeeCount = g.Count(),
                        TotalSalary = g.Sum(c => c.LuongCoBan)
                    })
                    .ToList();

                if (yearlyStats.Any())
                {
                    foreach (var stat in yearlyStats)
                    {
                        chartBar.Series["Nhân viên"].Points.AddXY(stat.Year.ToString(), stat.EmployeeCount);
                        chartBar.Series["Lương (Triệu)"].Points.AddXY(stat.Year.ToString(), 
                            Math.Round(stat.TotalSalary / 1000000, 1));
                    }
                }

                // Thống kê phân bố theo phòng ban cho chartPie
                var departmentStats = contracts
                    .GroupBy(c => string.IsNullOrEmpty(c.PhongBan) ? "Chưa phân công" : c.PhongBan)
                    .OrderByDescending(g => g.Count())
                    .Select(g => new
                    {
                        Department = g.Key,
                        Count = g.Count(),
                        Percentage = (double)g.Count() / contracts.Count * 100
                    })
                    .ToList();

                Color[] pieColors = {
                    Color.FromArgb(52, 152, 219),   // Blue
                    Color.FromArgb(46, 204, 113),   // Green
                    Color.FromArgb(155, 89, 182),   // Purple
                    Color.FromArgb(241, 196, 15),   // Yellow
                    Color.FromArgb(230, 126, 34),   // Orange
                    Color.FromArgb(231, 76, 60),    // Red
                    Color.FromArgb(149, 165, 166),  // Gray
                    Color.FromArgb(26, 188, 156)    // Turquoise
                };

                int colorIndex = 0;
                foreach (var dept in departmentStats)
                {
                    var point = chartPie.Series["Phân bổ phòng ban"].Points.AddXY(
                        dept.Department, 
                        dept.Percentage
                    );
                    
                    chartPie.Series["Phân bổ phòng ban"].Points[point].Color = 
                        pieColors[colorIndex % pieColors.Length];
                    chartPie.Series["Phân bổ phòng ban"].Points[point].Label = 
                        $"{dept.Percentage:0.1}%";
                    chartPie.Series["Phân bổ phòng ban"].Points[point].LegendText = 
                        $"{dept.Department} ({dept.Count})";
                    chartPie.Series["Phân bổ phòng ban"].Points[point].Font = 
                        new Font("Segoe UI", 9F, FontStyle.Bold);
                    
                    colorIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật biểu đồ: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelCharts_Paint(object sender, PaintEventArgs e)
        {
            // Event handler trống - giữ nguyên nếu Designer cần                
        }
    }
}