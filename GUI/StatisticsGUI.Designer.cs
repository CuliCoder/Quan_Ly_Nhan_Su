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
            this.labelTitle = new System.Windows.Forms.Label();
            this.comboBoxContractType = new System.Windows.Forms.ComboBox();
            this.labelTotalContracts = new System.Windows.Forms.Label();
            this.labelTotalValue = new System.Windows.Forms.Label();
            this.chartBar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewStats = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(10, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(200, 20);
            this.labelTitle.Text = "KTCN - Phóng kỳ thuật công nghệ";
            // 
            // comboBoxContractType
            // 
            this.comboBoxContractType.FormattingEnabled = true;
            this.comboBoxContractType.Location = new System.Drawing.Point(600, 10);
            this.comboBoxContractType.Name = "comboBoxContractType";
            this.comboBoxContractType.Size = new System.Drawing.Size(150, 21);
            this.comboBoxContractType.Items.AddRange(new object[] { "Chưa xử lý", "Đã xử lý" });
            this.comboBoxContractType.SelectedIndex = 0;
            // 
            // labelTotalContracts
            // 
            this.labelTotalContracts.AutoSize = true;
            this.labelTotalContracts.Location = new System.Drawing.Point(10, 40);
            this.labelTotalContracts.Name = "labelTotalContracts";
            this.labelTotalContracts.Size = new System.Drawing.Size(80, 13);
            this.labelTotalContracts.Text = "Tổng hợp đồng:";
            // 
            // labelTotalValue
            // 
            this.labelTotalValue.AutoSize = true;
            this.labelTotalValue.Location = new System.Drawing.Point(100, 40);
            this.labelTotalValue.Name = "labelTotalValue";
            this.labelTotalValue.Size = new System.Drawing.Size(50, 13);
            this.labelTotalValue.Text = "Số lượng: 99";
            // 
            // chartBar
            // 
            this.chartBar.Location = new System.Drawing.Point(10, 60);
            this.chartBar.Name = "chartBar";
            this.chartBar.Size = new System.Drawing.Size(400, 300);
            this.chartBar.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());
            this.chartBar.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Nhan viên"));
            this.chartBar.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Luong"));
            // 
            // chartPie
            // 
            this.chartPie.Location = new System.Drawing.Point(420, 60);
            this.chartPie.Name = "chartPie";
            this.chartPie.Size = new System.Drawing.Size(370, 300);
            this.chartPie.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());
            this.chartPie.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Thống kê chung"));
            this.chartPie.Series["Thống kê chung"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            // 
            // dataGridViewStats
            // 
            this.dataGridViewStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStats.Columns.Add("Ma", "Mã - Tên nhân viên");
            this.dataGridViewStats.Columns.Add("PhongBan", "Phòng ban");
            this.dataGridViewStats.Columns.Add("TuNgay", "Từ ngày");
            this.dataGridViewStats.Columns.Add("DenNgay", "Đến ngày");
            this.dataGridViewStats.Columns.Add("LoaiHopDong", "Loại hợp đồng");
            this.dataGridViewStats.Columns.Add("LuongCoBan", "Lương cơ bản");
            this.dataGridViewStats.Location = new System.Drawing.Point(10, 370);
            this.dataGridViewStats.Name = "dataGridViewStats";
            this.dataGridViewStats.Size = new System.Drawing.Size(780, 400);
            this.dataGridViewStats.RowTemplate.Height = 24;
            // 
            // StatisticsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewStats);
            this.Controls.Add(this.chartPie);
            this.Controls.Add(this.chartBar);
            this.Controls.Add(this.labelTotalValue);
            this.Controls.Add(this.labelTotalContracts);
            this.Controls.Add(this.comboBoxContractType);
            this.Controls.Add(this.labelTitle);
            this.Name = "StatisticsGUI";
            this.Size = new System.Drawing.Size(800, 791);
            this.Load += new System.EventHandler(this.StatisticsGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ComboBox comboBoxContractType;
        private System.Windows.Forms.Label labelTotalContracts;
        private System.Windows.Forms.Label labelTotalValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.DataGridView dataGridViewStats;
    }
}