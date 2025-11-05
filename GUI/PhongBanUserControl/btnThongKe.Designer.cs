namespace Quan_Ly_Nhan_Su.GUI
{
    partial class btnThongKe
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartNVien_Luong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_QuantityNV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbbListNVinPhongBan = new System.Windows.Forms.ComboBox();
            this.tableTongQuan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chartNVien_Luong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_QuantityNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTongQuan)).BeginInit();
            this.SuspendLayout();
            // 
            // chartNVien_Luong
            // 
            chartArea1.Name = "ChartArea1";
            this.chartNVien_Luong.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartNVien_Luong.Legends.Add(legend1);
            this.chartNVien_Luong.Location = new System.Drawing.Point(4, 47);
            this.chartNVien_Luong.Margin = new System.Windows.Forms.Padding(4);
            this.chartNVien_Luong.Name = "chartNVien_Luong";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartNVien_Luong.Series.Add(series1);
            this.chartNVien_Luong.Size = new System.Drawing.Size(725, 322);
            this.chartNVien_Luong.TabIndex = 1;
            this.chartNVien_Luong.Text = "chart2";
            // 
            // chart_QuantityNV
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_QuantityNV.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_QuantityNV.Legends.Add(legend2);
            this.chart_QuantityNV.Location = new System.Drawing.Point(729, 0);
            this.chart_QuantityNV.Margin = new System.Windows.Forms.Padding(4);
            this.chart_QuantityNV.Name = "chart_QuantityNV";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_QuantityNV.Series.Add(series2);
            this.chart_QuantityNV.Size = new System.Drawing.Size(735, 369);
            this.chart_QuantityNV.TabIndex = 2;
            this.chart_QuantityNV.Text = "chart1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 377);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1460, 422);
            this.dataGridView1.TabIndex = 3;
            // 
            // cbbListNVinPhongBan
            // 
            this.cbbListNVinPhongBan.FormattingEnabled = true;
            this.cbbListNVinPhongBan.Location = new System.Drawing.Point(76, 14);
            this.cbbListNVinPhongBan.Margin = new System.Windows.Forms.Padding(4);
            this.cbbListNVinPhongBan.Name = "cbbListNVinPhongBan";
            this.cbbListNVinPhongBan.Size = new System.Drawing.Size(496, 24);
            this.cbbListNVinPhongBan.TabIndex = 4;
            this.cbbListNVinPhongBan.SelectedIndexChanged += cbbListNVinPhongBan_SelectedIndexChanged;
            // 
            // tableTongQuan
            // 
            this.tableTongQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableTongQuan.Location = new System.Drawing.Point(4, 377);
            this.tableTongQuan.Margin = new System.Windows.Forms.Padding(4);
            this.tableTongQuan.Name = "tableTongQuan";
            this.tableTongQuan.RowHeadersWidth = 51;
            this.tableTongQuan.Size = new System.Drawing.Size(1460, 422);
            this.tableTongQuan.TabIndex = 5;
            // 
            // btnThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableTongQuan);
            this.Controls.Add(this.cbbListNVinPhongBan);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart_QuantityNV);
            this.Controls.Add(this.chartNVien_Luong);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "btnThongKe";
            this.Size = new System.Drawing.Size(1468, 818);
            ((System.ComponentModel.ISupportInitialize)(this.chartNVien_Luong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_QuantityNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTongQuan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartNVien_Luong;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_QuantityNV;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbbListNVinPhongBan;
        private System.Windows.Forms.DataGridView tableTongQuan;
    }
}
