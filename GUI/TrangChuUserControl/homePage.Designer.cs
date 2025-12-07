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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.bodyChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bodyChart.Name = "bodyChart";
            this.bodyChart.Size = new System.Drawing.Size(1476, 395);
            this.bodyChart.TabIndex = 0;
            this.bodyChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chartNhanVien
            // 
            chartArea3.Name = "ChartArea1";
            this.chartNhanVien.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartNhanVien.Legends.Add(legend3);
            this.chartNhanVien.Location = new System.Drawing.Point(745, 0);
            this.chartNhanVien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartNhanVien.Name = "chartNhanVien";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartNhanVien.Series.Add(series3);
            this.chartNhanVien.Size = new System.Drawing.Size(727, 395);
            this.chartNhanVien.TabIndex = 1;
            this.chartNhanVien.Text = "chart1";
            // 
            // chartLuong
            // 
            chartArea4.Name = "ChartArea1";
            this.chartLuong.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartLuong.Legends.Add(legend4);
            this.chartLuong.Location = new System.Drawing.Point(9, 0);
            this.chartLuong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartLuong.Name = "chartLuong";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Lương trung bình";
            this.chartLuong.Series.Add(series4);
            this.chartLuong.Size = new System.Drawing.Size(728, 395);
            this.chartLuong.TabIndex = 0;
            this.chartLuong.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tableTongQuan);
            this.panel1.Controls.Add(this.tittleTable);
            this.panel1.Location = new System.Drawing.Point(9, 404);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1467, 498);
            this.panel1.TabIndex = 1;
            // 
            // tableTongQuan
            // 
            this.tableTongQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableTongQuan.Location = new System.Drawing.Point(9, 46);
            this.tableTongQuan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableTongQuan.Name = "tableTongQuan";
            this.tableTongQuan.RowHeadersWidth = 62;
            this.tableTongQuan.Size = new System.Drawing.Size(1448, 420);
            this.tableTongQuan.TabIndex = 1;
            // 
            // tittleTable
            // 
            this.tittleTable.AutoSize = true;
            this.tittleTable.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tittleTable.ForeColor = System.Drawing.Color.Gray;
            this.tittleTable.Location = new System.Drawing.Point(2, 4);
            this.tittleTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tittleTable.Name = "tittleTable";
            this.tittleTable.Size = new System.Drawing.Size(264, 32);
            this.tittleTable.TabIndex = 0;
            this.tittleTable.Text = "Thông tin tổng quan";
            // 
            // homePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bodyChart);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "homePage";
            this.Size = new System.Drawing.Size(1476, 902);
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
