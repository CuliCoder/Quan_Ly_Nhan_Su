using System.Windows.Forms;

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
            this.panelSearch = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.columnLuongCoBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLoaiHopDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDenNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTuNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMaTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelSearch.Controls.Add(this.button1);
            this.panelSearch.Controls.Add(this.buttonSearch);
            this.panelSearch.Controls.Add(this.textBoxSearch);
            this.panelSearch.Location = new System.Drawing.Point(11, 12);
            this.panelSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1372, 100);
            this.panelSearch.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = global::Quan_Ly_Nhan_Su.Properties.Resources._return;
            this.button1.Location = new System.Drawing.Point(3, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 43);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonSearch.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Image = global::Quan_Ly_Nhan_Su.Properties.Resources._211817_search_strong_icon1;
            this.buttonSearch.Location = new System.Drawing.Point(357, 49);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(142, 36);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSearch.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.textBoxSearch.ForeColor = System.Drawing.Color.Black;
            this.textBoxSearch.Location = new System.Drawing.Point(14, 55);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSearch.Size = new System.Drawing.Size(337, 30);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.Text = "tìm kiếm nhân viên";
            // 
            // columnLuongCoBan
            // 
            this.columnLuongCoBan.HeaderText = "Lương cơ bản";
            this.columnLuongCoBan.MinimumWidth = 8;
            this.columnLuongCoBan.Name = "columnLuongCoBan";
            // 
            // columnLoaiHopDong
            // 
            this.columnLoaiHopDong.HeaderText = "Loại hợp đồng";
            this.columnLoaiHopDong.MinimumWidth = 8;
            this.columnLoaiHopDong.Name = "columnLoaiHopDong";
            // 
            // columnDenNgay
            // 
            this.columnDenNgay.HeaderText = "Đến ngày";
            this.columnDenNgay.MinimumWidth = 8;
            this.columnDenNgay.Name = "columnDenNgay";
            // 
            // columnTuNgay
            // 
            this.columnTuNgay.HeaderText = "Từ ngày";
            this.columnTuNgay.MinimumWidth = 8;
            this.columnTuNgay.Name = "columnTuNgay";
            // 
            // columnPhongBan
            // 
            this.columnPhongBan.HeaderText = "Phòng ban";
            this.columnPhongBan.MinimumWidth = 8;
            this.columnPhongBan.Name = "columnPhongBan";
            // 
            // columnMaTenNhanVien
            // 
            this.columnMaTenNhanVien.HeaderText = "Mã - Tên nhân viên";
            this.columnMaTenNhanVien.MinimumWidth = 8;
            this.columnMaTenNhanVien.Name = "columnMaTenNhanVien";
            // 
            // columnSTT
            // 
            this.columnSTT.HeaderText = "STT";
            this.columnSTT.MinimumWidth = 8;
            this.columnSTT.Name = "columnSTT";
            // 
            // dataGridView1
            // 
            // Cấu hình DataGridView với style đẹp hơn: Font thống nhất, header bold với nền xám nhạt, 
            // alternating rows cho dễ đọc, border mỏng, selection màu xanh dương nhạt, và grid lines mỏng.

            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;  // Nền trắng sạch sẽ
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;  // Khung viền đơn giản
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;  // Đường kẻ ngang mỏng
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.LightGray;  // Màu lưới xám nhạt
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
    this.columnSTT,
    this.columnMaTenNhanVien,
    this.columnPhongBan,
    this.columnTuNgay,
    this.columnDenNgay,
    this.columnLoaiHopDong,
    this.columnLuongCoBan
});

            // Style cho Header (bold, nền xám nhạt, chữ đen)
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);  // Xám nhạt
            headerStyle.ForeColor = System.Drawing.Color.Black;
            headerStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;

            // Style mặc định cho Cells (font thường, wrap false)
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = System.Drawing.SystemColors.Window;
            cellStyle.Font = new System.Drawing.Font("Times New Roman", 12F);
            cellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            cellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = cellStyle;

            // Alternating Rows (hàng chẵn/lẻ nền khác nhau để dễ đọc)
            this.dataGridView1.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle();
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 248, 255);  // Xanh nhạt rất nhạt
            this.dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;

            // Selection Style (nền xanh dương nhạt, chữ đen, toàn row highlight)
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(173, 216, 230);  // Light Blue nhạt hơn DodgerBlue
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            this.dataGridView1.Location = new System.Drawing.Point(0, 120);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;  // Không cho edit trực tiếp
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.RowHeadersWidth = 51;  // Giảm width vì ẩn header
            this.dataGridView1.RowTemplate.Height = 35;  // Tăng chiều cao row cho dễ đọc (từ 30 lên 35)
            this.dataGridView1.Size = new System.Drawing.Size(1515, 770);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Controls.Add(this.panelSearch);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1518, 894);
            this.panelMain.TabIndex = 0;
            // 
            // ContractGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ContractGUI";
            this.Size = new System.Drawing.Size(1521, 934);
            this.Load += new System.EventHandler(this.ContractGUI_Load);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMaTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTuNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDenNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLoaiHopDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLuongCoBan;
        private System.Windows.Forms.Panel panelMain;
    }
}