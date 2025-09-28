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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            chartArea3.Name = "ChartArea1";
            this.chartNVien_Luong.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartNVien_Luong.Legends.Add(legend3);
            this.chartNVien_Luong.Location = new System.Drawing.Point(3, 38);
            this.chartNVien_Luong.Name = "chartNVien_Luong";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartNVien_Luong.Series.Add(series3);
            this.chartNVien_Luong.Size = new System.Drawing.Size(544, 262);
            this.chartNVien_Luong.TabIndex = 1;
            this.chartNVien_Luong.Text = "chart2";
            // 
            // chart_QuantityNV
            // 
            chartArea4.Name = "ChartArea1";
            this.chart_QuantityNV.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart_QuantityNV.Legends.Add(legend4);
            this.chart_QuantityNV.Location = new System.Drawing.Point(547, 0);
            this.chart_QuantityNV.Name = "chart_QuantityNV";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart_QuantityNV.Series.Add(series4);
            this.chart_QuantityNV.Size = new System.Drawing.Size(551, 300);
            this.chart_QuantityNV.TabIndex = 2;
            this.chart_QuantityNV.Text = "chart1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 306);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1095, 343);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cbbListNVinPhongBan
            // 
            this.cbbListNVinPhongBan.FormattingEnabled = true;
            this.cbbListNVinPhongBan.Location = new System.Drawing.Point(57, 11);
            this.cbbListNVinPhongBan.Name = "cbbListNVinPhongBan";
            this.cbbListNVinPhongBan.Size = new System.Drawing.Size(121, 21);
            this.cbbListNVinPhongBan.TabIndex = 4;
            // 
            // tableTongQuan
            // 
            this.tableTongQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableTongQuan.Location = new System.Drawing.Point(3, 306);
            this.tableTongQuan.Name = "tableTongQuan";
            this.tableTongQuan.Size = new System.Drawing.Size(1095, 343);
            this.tableTongQuan.TabIndex = 5;
            // 
            // btnThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableTongQuan);
            this.Controls.Add(this.cbbListNVinPhongBan);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart_QuantityNV);
            this.Controls.Add(this.chartNVien_Luong);
            this.Name = "btnThongKe";
            this.Size = new System.Drawing.Size(1101, 665);
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
