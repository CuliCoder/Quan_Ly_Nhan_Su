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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.bodyChart = new System.Windows.Forms.Panel();
            this.chartNhanVien = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLuong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tittleTable = new System.Windows.Forms.Label();
            this.tableTongQuan = new System.Windows.Forms.DataGridView();
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
            this.bodyChart.Name = "bodyChart";
            this.bodyChart.Size = new System.Drawing.Size(1107, 321);
            this.bodyChart.TabIndex = 0;
            this.bodyChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chartNhanVien
            // 
            chartArea11.Name = "ChartArea1";
            this.chartNhanVien.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chartNhanVien.Legends.Add(legend11);
            this.chartNhanVien.Location = new System.Drawing.Point(559, 0);
            this.chartNhanVien.Name = "chartNhanVien";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chartNhanVien.Series.Add(series11);
            this.chartNhanVien.Size = new System.Drawing.Size(545, 321);
            this.chartNhanVien.TabIndex = 1;
            this.chartNhanVien.Text = "chart1";
            // 
            // chartLuong
            // 
            chartArea12.Name = "ChartArea1";
            this.chartLuong.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chartLuong.Legends.Add(legend12);
            this.chartLuong.Location = new System.Drawing.Point(7, 0);
            this.chartLuong.Name = "chartLuong";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Lương trung bình";
            this.chartLuong.Series.Add(series12);
            this.chartLuong.Size = new System.Drawing.Size(546, 321);
            this.chartLuong.TabIndex = 0;
            this.chartLuong.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tableTongQuan);
            this.panel1.Controls.Add(this.tittleTable);
            this.panel1.Location = new System.Drawing.Point(7, 328);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 405);
            this.panel1.TabIndex = 1;
            // 
            // tittleTable
            // 
            this.tittleTable.AutoSize = true;
            this.tittleTable.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tittleTable.ForeColor = System.Drawing.Color.Gray;
            this.tittleTable.Location = new System.Drawing.Point(30, 12);
            this.tittleTable.Name = "tittleTable";
            this.tittleTable.Size = new System.Drawing.Size(166, 23);
            this.tittleTable.TabIndex = 0;
            this.tittleTable.Text = "Thông tin tổng quan";
            // 
            // tableTongQuan
            // 
            this.tableTongQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableTongQuan.Location = new System.Drawing.Point(7, 38);
            this.tableTongQuan.Name = "tableTongQuan";
            this.tableTongQuan.Size = new System.Drawing.Size(1086, 341);
            this.tableTongQuan.TabIndex = 1;
            // 
            // homePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bodyChart);
            this.Name = "homePage";
            this.Size = new System.Drawing.Size(1107, 733);
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
