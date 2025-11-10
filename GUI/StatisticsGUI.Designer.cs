namespace Quan_Ly_Nhan_Su.GUI
{
    partial class StatisticsGUI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelStatCard3 = new System.Windows.Forms.Panel();
            this.labelAvgSalaryValue = new System.Windows.Forms.Label();
            this.labelAvgSalary = new System.Windows.Forms.Label();
            this.panelStatCard2 = new System.Windows.Forms.Panel();
            this.labelTotalValue = new System.Windows.Forms.Label();
            this.labelTotalSalary = new System.Windows.Forms.Label();
            this.panelStatCard1 = new System.Windows.Forms.Panel();
            this.labelTotalContractsValue = new System.Windows.Forms.Label();
            this.labelTotalContracts = new System.Windows.Forms.Label();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.comboBoxContractType = new System.Windows.Forms.ComboBox();
            this.labelContractType = new System.Windows.Forms.Label();
            this.panelCharts = new System.Windows.Forms.Panel();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dataGridViewStats = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelGridTitle = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelStatCard3.SuspendLayout();
            this.panelStatCard2.SuspendLayout();
            this.panelStatCard1.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.panelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelHeader.Size = new System.Drawing.Size(1087, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(15, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(506, 41);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "THỐNG KÊ HỢP ĐỒNG LAO ĐỘNG";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelStats.Controls.Add(this.panelStatCard3);
            this.panelStats.Controls.Add(this.panelStatCard2);
            this.panelStats.Controls.Add(this.panelStatCard1);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 60);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(15, 15, 15, 10);
            this.panelStats.Size = new System.Drawing.Size(1087, 114);
            this.panelStats.TabIndex = 1;
            // 
            // panelStatCard3
            // 
            this.panelStatCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panelStatCard3.Controls.Add(this.labelAvgSalaryValue);
            this.panelStatCard3.Controls.Add(this.labelAvgSalary);
            this.panelStatCard3.Location = new System.Drawing.Point(733, 15);
            this.panelStatCard3.Name = "panelStatCard3";
            this.panelStatCard3.Size = new System.Drawing.Size(330, 95);
            this.panelStatCard3.TabIndex = 2;
            // 
            // labelAvgSalaryValue
            // 
            this.labelAvgSalaryValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelAvgSalaryValue.ForeColor = System.Drawing.Color.White;
            this.labelAvgSalaryValue.Location = new System.Drawing.Point(10, 45);
            this.labelAvgSalaryValue.Name = "labelAvgSalaryValue";
            this.labelAvgSalaryValue.Size = new System.Drawing.Size(310, 40);
            this.labelAvgSalaryValue.TabIndex = 1;
            this.labelAvgSalaryValue.Text = "0 VNĐ";
            this.labelAvgSalaryValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAvgSalary
            // 
            this.labelAvgSalary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelAvgSalary.ForeColor = System.Drawing.Color.White;
            this.labelAvgSalary.Location = new System.Drawing.Point(10, 10);
            this.labelAvgSalary.Name = "labelAvgSalary";
            this.labelAvgSalary.Size = new System.Drawing.Size(310, 25);
            this.labelAvgSalary.TabIndex = 0;
            this.labelAvgSalary.Text = "LƯƠNG TRUNG BÌNH";
            this.labelAvgSalary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStatCard2
            // 
            this.panelStatCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelStatCard2.Controls.Add(this.labelTotalValue);
            this.panelStatCard2.Controls.Add(this.labelTotalSalary);
            this.panelStatCard2.Location = new System.Drawing.Point(377, 15);
            this.panelStatCard2.Name = "panelStatCard2";
            this.panelStatCard2.Size = new System.Drawing.Size(330, 95);
            this.panelStatCard2.TabIndex = 1;
            // 
            // labelTotalValue
            // 
            this.labelTotalValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTotalValue.ForeColor = System.Drawing.Color.White;
            this.labelTotalValue.Location = new System.Drawing.Point(10, 45);
            this.labelTotalValue.Name = "labelTotalValue";
            this.labelTotalValue.Size = new System.Drawing.Size(310, 40);
            this.labelTotalValue.TabIndex = 1;
            this.labelTotalValue.Text = "0 VNĐ";
            this.labelTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalSalary
            // 
            this.labelTotalSalary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelTotalSalary.ForeColor = System.Drawing.Color.White;
            this.labelTotalSalary.Location = new System.Drawing.Point(10, 10);
            this.labelTotalSalary.Name = "labelTotalSalary";
            this.labelTotalSalary.Size = new System.Drawing.Size(310, 25);
            this.labelTotalSalary.TabIndex = 0;
            this.labelTotalSalary.Text = "TỔNG LƯƠNG";
            this.labelTotalSalary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStatCard1
            // 
            this.panelStatCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelStatCard1.Controls.Add(this.labelTotalContractsValue);
            this.panelStatCard1.Controls.Add(this.labelTotalContracts);
            this.panelStatCard1.Location = new System.Drawing.Point(18, 15);
            this.panelStatCard1.Name = "panelStatCard1";
            this.panelStatCard1.Size = new System.Drawing.Size(330, 95);
            this.panelStatCard1.TabIndex = 0;
            // 
            // labelTotalContractsValue
            // 
            this.labelTotalContractsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTotalContractsValue.ForeColor = System.Drawing.Color.White;
            this.labelTotalContractsValue.Location = new System.Drawing.Point(10, 45);
            this.labelTotalContractsValue.Name = "labelTotalContractsValue";
            this.labelTotalContractsValue.Size = new System.Drawing.Size(310, 40);
            this.labelTotalContractsValue.TabIndex = 1;
            this.labelTotalContractsValue.Text = "0";
            this.labelTotalContractsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalContracts
            // 
            this.labelTotalContracts.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelTotalContracts.ForeColor = System.Drawing.Color.White;
            this.labelTotalContracts.Location = new System.Drawing.Point(10, 10);
            this.labelTotalContracts.Name = "labelTotalContracts";
            this.labelTotalContracts.Size = new System.Drawing.Size(310, 25);
            this.labelTotalContracts.TabIndex = 0;
            this.labelTotalContracts.Text = "TỔNG HỢP ĐỒNG";
            this.labelTotalContracts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilters.Controls.Add(this.comboBoxYear);
            this.panelFilters.Controls.Add(this.labelYear);
            this.panelFilters.Controls.Add(this.comboBoxContractType);
            this.panelFilters.Controls.Add(this.labelContractType);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 174);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelFilters.Size = new System.Drawing.Size(1087, 54);
            this.panelFilters.TabIndex = 2;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(610, 13);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(150, 31);
            this.comboBoxYear.TabIndex = 3;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelYear.Location = new System.Drawing.Point(560, 16);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(53, 23);
            this.labelYear.TabIndex = 2;
            this.labelYear.Text = "Năm:";
            // 
            // comboBoxContractType
            // 
            this.comboBoxContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContractType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxContractType.FormattingEnabled = true;
            this.comboBoxContractType.Location = new System.Drawing.Point(170, 13);
            this.comboBoxContractType.Name = "comboBoxContractType";
            this.comboBoxContractType.Size = new System.Drawing.Size(250, 31);
            this.comboBoxContractType.TabIndex = 1;
            // 
            // labelContractType
            // 
            this.labelContractType.AutoSize = true;
            this.labelContractType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelContractType.Location = new System.Drawing.Point(18, 16);
            this.labelContractType.Name = "labelContractType";
            this.labelContractType.Size = new System.Drawing.Size(132, 23);
            this.labelContractType.TabIndex = 0;
            this.labelContractType.Text = "Loại hợp đồng:";
            // 
            // panelCharts
            // 
            this.panelCharts.BackColor = System.Drawing.Color.White;
            this.panelCharts.Controls.Add(this.chartPie);
            this.panelCharts.Controls.Add(this.chartBar);
            this.panelCharts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCharts.Location = new System.Drawing.Point(0, 228);
            this.panelCharts.Name = "panelCharts";
            this.panelCharts.Padding = new System.Windows.Forms.Padding(15, 15, 15, 10);
            this.panelCharts.Size = new System.Drawing.Size(1087, 183);
            this.panelCharts.TabIndex = 3;
            this.panelCharts.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCharts_Paint);
            // 
            // chartPie
            // 
            this.chartPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            chartArea1.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartPie.Legends.Add(legend1);
            this.chartPie.Location = new System.Drawing.Point(555, 15);
            this.chartPie.Name = "chartPie";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Segoe UI", 9F);
            series1.Legend = "Legend1";
            series1.Name = "Phân bổ phòng ban";
            this.chartPie.Series.Add(series1);
            this.chartPie.Size = new System.Drawing.Size(515, 164);
            this.chartPie.TabIndex = 1;
            this.chartPie.Text = "chartPie";
            // 
            // chartBar
            // 
            this.chartBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            chartArea2.Name = "ChartArea1";
            this.chartBar.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            legend2.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartBar.Legends.Add(legend2);
            this.chartBar.Location = new System.Drawing.Point(18, 15);
            this.chartBar.Name = "chartBar";
            series2.ChartArea = "ChartArea1";
            series2.Font = new System.Drawing.Font("Segoe UI", 9F);
            series2.Legend = "Legend1";
            series2.Name = "Nhân viên";
            series3.ChartArea = "ChartArea1";
            series3.Font = new System.Drawing.Font("Segoe UI", 9F);
            series3.Legend = "Legend1";
            series3.Name = "Lương (Triệu)";
            this.chartBar.Series.Add(series2);
            this.chartBar.Series.Add(series3);
            this.chartBar.Size = new System.Drawing.Size(520, 164);
            this.chartBar.TabIndex = 0;
            this.chartBar.Text = "chartBar";
            // 
            // panelGrid
            // 
            this.panelGrid.BackColor = System.Drawing.Color.White;
            this.panelGrid.Controls.Add(this.dataGridViewStats);
            this.panelGrid.Controls.Add(this.labelGridTitle);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 411);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.panelGrid.Size = new System.Drawing.Size(1087, 577);
            this.panelGrid.TabIndex = 4;
            // 
            // dataGridViewStats
            // 
            this.dataGridViewStats.AllowUserToAddRows = false;
            this.dataGridViewStats.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewStats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStats.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewStats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStats.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewStats.ColumnHeadersHeight = 40;
            this.dataGridViewStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewStats.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStats.EnableHeadersVisualStyles = false;
            this.dataGridViewStats.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.dataGridViewStats.Location = new System.Drawing.Point(15, 45);
            this.dataGridViewStats.Name = "dataGridViewStats";
            this.dataGridViewStats.ReadOnly = true;
            this.dataGridViewStats.RowHeadersVisible = false;
            this.dataGridViewStats.RowHeadersWidth = 51;
            this.dataGridViewStats.RowTemplate.Height = 35;
            this.dataGridViewStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStats.Size = new System.Drawing.Size(1057, 517);
            this.dataGridViewStats.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã - Tên nhân viên";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Phòng ban";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Từ ngày";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Đến ngày";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Loại hợp đồng";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Lương cơ bản";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // labelGridTitle
            // 
            this.labelGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGridTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelGridTitle.Location = new System.Drawing.Point(15, 10);
            this.labelGridTitle.Name = "labelGridTitle";
            this.labelGridTitle.Size = new System.Drawing.Size(1057, 35);
            this.labelGridTitle.TabIndex = 0;
            this.labelGridTitle.Text = "CHI TIẾT HỢP ĐỒNG";
            this.labelGridTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatisticsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelCharts);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.Name = "StatisticsGUI";
            this.Size = new System.Drawing.Size(1087, 988);
            this.Load += new System.EventHandler(this.StatisticsGUI_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelStatCard3.ResumeLayout(false);
            this.panelStatCard2.ResumeLayout(false);
            this.panelStatCard1.ResumeLayout(false);
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelStatCard1;
        private System.Windows.Forms.Label labelTotalContracts;
        private System.Windows.Forms.Label labelTotalContractsValue;
        private System.Windows.Forms.Panel panelStatCard2;
        private System.Windows.Forms.Label labelTotalValue;
        private System.Windows.Forms.Label labelTotalSalary;
        private System.Windows.Forms.Panel panelStatCard3;
        private System.Windows.Forms.Label labelAvgSalaryValue;
        private System.Windows.Forms.Label labelAvgSalary;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.ComboBox comboBoxContractType;
        private System.Windows.Forms.Label labelContractType;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Panel panelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dataGridViewStats;
        private System.Windows.Forms.Label labelGridTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}