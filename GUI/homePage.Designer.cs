namespace Quan_Ly_Nhan_Su.GUI
{
    partial class homePage
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
            this.bodyChart = new System.Windows.Forms.Panel();
            this.chartNhanVien = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLuong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableTongQuan = new System.Windows.Forms.DataGridView();
            this.tittleTable = new System.Windows.Forms.Label();
            this.bodyChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLuong)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableTongQuan)).BeginInit();
            this.SuspendLayout();
            // 
            // bodyChart
            // 
            this.bodyChart.Controls.Add(this.chartNhanVien);
            this.bodyChart.Controls.Add(this.chartLuong);
            this.bodyChart.Location = new System.Drawing.Point(0, 0);
            this.bodyChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bodyChart.Name = "bodyChart";
            this.bodyChart.Size = new System.Drawing.Size(1660, 494);
            this.bodyChart.TabIndex = 0;
            this.bodyChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chartNhanVien
            // 
            chartArea1.Name = "ChartArea1";
            this.chartNhanVien.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartNhanVien.Legends.Add(legend1);
            this.chartNhanVien.Location = new System.Drawing.Point(838, 0);
            this.chartNhanVien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartNhanVien.Name = "chartNhanVien";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartNhanVien.Series.Add(series1);
            this.chartNhanVien.Size = new System.Drawing.Size(818, 494);
            this.chartNhanVien.TabIndex = 1;
            this.chartNhanVien.Text = "chart1";
            // 
            // chartLuong
            // 
            chartArea2.Name = "ChartArea1";
            this.chartLuong.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartLuong.Legends.Add(legend2);
            this.chartLuong.Location = new System.Drawing.Point(10, 0);
            this.chartLuong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartLuong.Name = "chartLuong";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Lương trung bình";
            this.chartLuong.Series.Add(series2);
            this.chartLuong.Size = new System.Drawing.Size(819, 494);
            this.chartLuong.TabIndex = 0;
            this.chartLuong.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tableTongQuan);
            this.panel1.Controls.Add(this.tittleTable);
            this.panel1.Location = new System.Drawing.Point(10, 505);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1650, 623);
            this.panel1.TabIndex = 1;
            // 
            // tableTongQuan
            // 
            this.tableTongQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableTongQuan.Location = new System.Drawing.Point(10, 58);
            this.tableTongQuan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableTongQuan.Name = "tableTongQuan";
            this.tableTongQuan.RowHeadersWidth = 62;
            this.tableTongQuan.Size = new System.Drawing.Size(1629, 525);
            this.tableTongQuan.TabIndex = 1;
            // 
            // tittleTable
            // 
            this.tittleTable.AutoSize = true;
            this.tittleTable.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tittleTable.ForeColor = System.Drawing.Color.Gray;
            this.tittleTable.Location = new System.Drawing.Point(45, 18);
            this.tittleTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tittleTable.Name = "tittleTable";
            this.tittleTable.Size = new System.Drawing.Size(263, 36);
            this.tittleTable.TabIndex = 0;
            this.tittleTable.Text = "Thông tin tổng quan";
            // 
            // homePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bodyChart);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "homePage";
            this.Size = new System.Drawing.Size(1660, 1128);
            this.Load += new System.EventHandler(this.homePage_Load);
            this.bodyChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLuong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableTongQuan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bodyChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLuong;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNhanVien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label tittleTable;
        private System.Windows.Forms.DataGridView tableTongQuan;
    }
}
