namespace Quan_Ly_Nhan_Su.GUI
{
    partial class ContractGUI
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.columnSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMaTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTuNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDenNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLoaiHopDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLuongCoBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Controls.Add(this.panelSearch);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1349, 715);
            this.panelMain.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnSTT,
            this.columnMaTenNhanVien,
            this.columnPhongBan,
            this.columnTuNgay,
            this.columnDenNgay,
            this.columnLoaiHopDong,
            this.columnLuongCoBan});
            this.dataGridView1.Location = new System.Drawing.Point(10, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 120;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1336, 616);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // columnSTT
            // 
            this.columnSTT.HeaderText = "STT";
            this.columnSTT.MinimumWidth = 8;
            this.columnSTT.Name = "columnSTT";
            this.columnSTT.Width = 50;
            // 
            // columnMaTenNhanVien
            // 
            this.columnMaTenNhanVien.HeaderText = "Mã - Tên nhân viên";
            this.columnMaTenNhanVien.MinimumWidth = 8;
            this.columnMaTenNhanVien.Name = "columnMaTenNhanVien";
            this.columnMaTenNhanVien.Width = 500;
            // 
            // columnPhongBan
            // 
            this.columnPhongBan.HeaderText = "Phòng ban";
            this.columnPhongBan.MinimumWidth = 8;
            this.columnPhongBan.Name = "columnPhongBan";
            this.columnPhongBan.Width = 170;
            // 
            // columnTuNgay
            // 
            this.columnTuNgay.HeaderText = "Từ ngày";
            this.columnTuNgay.MinimumWidth = 8;
            this.columnTuNgay.Name = "columnTuNgay";
            this.columnTuNgay.Width = 150;
            // 
            // columnDenNgay
            // 
            this.columnDenNgay.HeaderText = "Đến ngày";
            this.columnDenNgay.MinimumWidth = 8;
            this.columnDenNgay.Name = "columnDenNgay";
            this.columnDenNgay.Width = 150;
            // 
            // columnLoaiHopDong
            // 
            this.columnLoaiHopDong.HeaderText = "Loại hợp đồng";
            this.columnLoaiHopDong.MinimumWidth = 8;
            this.columnLoaiHopDong.Name = "columnLoaiHopDong";
            this.columnLoaiHopDong.Width = 150;
            // 
            // columnLuongCoBan
            // 
            this.columnLuongCoBan.HeaderText = "Lương cơ bản";
            this.columnLuongCoBan.MinimumWidth = 8;
            this.columnLuongCoBan.Name = "columnLuongCoBan";
            this.columnLuongCoBan.Width = 200;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelSearch.Controls.Add(this.button1);
            this.panelSearch.Controls.Add(this.buttonSearch);
            this.panelSearch.Controls.Add(this.textBoxSearch);
            this.panelSearch.Location = new System.Drawing.Point(10, 10);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1220, 80);
            this.panelSearch.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Quay Lại";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(331, 37);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(120, 40);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Tìm kiếm";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxSearch.ForeColor = System.Drawing.Color.Black;
            this.textBoxSearch.Location = new System.Drawing.Point(12, 44);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSearch.Size = new System.Drawing.Size(300, 26);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.Text = "tìm kiếm nhân viên";
            // 
            // ContractGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.panelMain);
            this.Name = "ContractGUI";
            this.Size = new System.Drawing.Size(1352, 747);
            this.Load += new System.EventHandler(this.ContractGUI_Load);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMaTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTuNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDenNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLoaiHopDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLuongCoBan;
    }
}