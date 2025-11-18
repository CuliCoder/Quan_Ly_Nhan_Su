namespace Quan_Ly_Nhan_Su.GUI.DanhGiaUserControl
{
    partial class frmEvaluationCU
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

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.txtChiTiet = new System.Windows.Forms.TextBox();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.txtXepLoai = new System.Windows.Forms.TextBox();
            this.lblDiem = new System.Windows.Forms.Label();
            this.numDiem = new System.Windows.Forms.NumericUpDown();
            this.lblNgayDanhGia = new System.Windows.Forms.Label();
            this.dtpNgayDanhGia = new System.Windows.Forms.DateTimePicker();
            this.lblNguoiDanhGia = new System.Windows.Forms.Label();
            this.cboNguoiDanhGia = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblMaDanhGia = new System.Windows.Forms.Label();
            this.txtMaDanhGia = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.grpInfo);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(700, 650);
            this.pnlMain.TabIndex = 0;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblGhiChu);
            this.grpInfo.Controls.Add(this.txtGhiChu);
            this.grpInfo.Controls.Add(this.lblChiTiet);
            this.grpInfo.Controls.Add(this.txtChiTiet);
            this.grpInfo.Controls.Add(this.lblXepLoai);
            this.grpInfo.Controls.Add(this.txtXepLoai);
            this.grpInfo.Controls.Add(this.lblDiem);
            this.grpInfo.Controls.Add(this.numDiem);
            this.grpInfo.Controls.Add(this.lblNgayDanhGia);
            this.grpInfo.Controls.Add(this.dtpNgayDanhGia);
            this.grpInfo.Controls.Add(this.lblNguoiDanhGia);
            this.grpInfo.Controls.Add(this.cboNguoiDanhGia);
            this.grpInfo.Controls.Add(this.lblNhanVien);
            this.grpInfo.Controls.Add(this.cboNhanVien);
            this.grpInfo.Controls.Add(this.lblMaDanhGia);
            this.grpInfo.Controls.Add(this.txtMaDanhGia);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.grpInfo.Location = new System.Drawing.Point(20, 70);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(15);
            this.grpInfo.Size = new System.Drawing.Size(660, 490);
            this.grpInfo.TabIndex = 2;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Thông tin đánh giá";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblGhiChu.Location = new System.Drawing.Point(18, 420);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(72, 22);
            this.lblGhiChu.TabIndex = 15;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtGhiChu.Location = new System.Drawing.Point(180, 417);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(462, 50);
            this.txtGhiChu.TabIndex = 7;
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblChiTiet.Location = new System.Drawing.Point(18, 310);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(142, 22);
            this.lblChiTiet.TabIndex = 13;
            this.lblChiTiet.Text = "Chi tiết đánh giá";
            // 
            // txtChiTiet
            // 
            this.txtChiTiet.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtChiTiet.Location = new System.Drawing.Point(180, 307);
            this.txtChiTiet.Multiline = true;
            this.txtChiTiet.Name = "txtChiTiet";
            this.txtChiTiet.Size = new System.Drawing.Size(462, 90);
            this.txtChiTiet.TabIndex = 6;
            // 
            // lblXepLoai
            // 
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblXepLoai.Location = new System.Drawing.Point(18, 265);
            this.lblXepLoai.Name = "lblXepLoai";
            this.lblXepLoai.Size = new System.Drawing.Size(76, 22);
            this.lblXepLoai.TabIndex = 11;
            this.lblXepLoai.Text = "Xếp loại";
            // 
            // txtXepLoai
            // 
            this.txtXepLoai.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtXepLoai.Location = new System.Drawing.Point(180, 262);
            this.txtXepLoai.Name = "txtXepLoai";
            this.txtXepLoai.ReadOnly = true;
            this.txtXepLoai.Size = new System.Drawing.Size(462, 30);
            this.txtXepLoai.TabIndex = 10;
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblDiem.Location = new System.Drawing.Point(18, 220);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(120, 22);
            this.lblDiem.TabIndex = 9;
            this.lblDiem.Text = "Điểm đánh giá";
            // 
            // numDiem
            // 
            this.numDiem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.numDiem.Location = new System.Drawing.Point(180, 217);
            this.numDiem.Name = "numDiem";
            this.numDiem.Size = new System.Drawing.Size(462, 30);
            this.numDiem.TabIndex = 4;
            this.numDiem.ValueChanged += new System.EventHandler(this.numDiem_ValueChanged);
            // 
            // lblNgayDanhGia
            // 
            this.lblNgayDanhGia.AutoSize = true;
            this.lblNgayDanhGia.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblNgayDanhGia.Location = new System.Drawing.Point(18, 175);
            this.lblNgayDanhGia.Name = "lblNgayDanhGia";
            this.lblNgayDanhGia.Size = new System.Drawing.Size(125, 22);
            this.lblNgayDanhGia.TabIndex = 7;
            this.lblNgayDanhGia.Text = "Ngày đánh giá";
            // 
            // dtpNgayDanhGia
            // 
            this.dtpNgayDanhGia.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpNgayDanhGia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDanhGia.Location = new System.Drawing.Point(180, 172);
            this.dtpNgayDanhGia.Name = "dtpNgayDanhGia";
            this.dtpNgayDanhGia.Size = new System.Drawing.Size(462, 30);
            this.dtpNgayDanhGia.TabIndex = 3;
            // 
            // lblNguoiDanhGia
            // 
            this.lblNguoiDanhGia.AutoSize = true;
            this.lblNguoiDanhGia.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblNguoiDanhGia.Location = new System.Drawing.Point(18, 130);
            this.lblNguoiDanhGia.Name = "lblNguoiDanhGia";
            this.lblNguoiDanhGia.Size = new System.Drawing.Size(133, 22);
            this.lblNguoiDanhGia.TabIndex = 5;
            this.lblNguoiDanhGia.Text = "Người đánh giá";
            // 
            // cboNguoiDanhGia
            // 
            this.cboNguoiDanhGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguoiDanhGia.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboNguoiDanhGia.FormattingEnabled = true;
            this.cboNguoiDanhGia.Location = new System.Drawing.Point(180, 127);
            this.cboNguoiDanhGia.Name = "cboNguoiDanhGia";
            this.cboNguoiDanhGia.Size = new System.Drawing.Size(462, 30);
            this.cboNguoiDanhGia.TabIndex = 2;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblNhanVien.Location = new System.Drawing.Point(18, 85);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(92, 22);
            this.lblNhanVien.TabIndex = 3;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(180, 82);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(462, 30);
            this.cboNhanVien.TabIndex = 1;
            // 
            // lblMaDanhGia
            // 
            this.lblMaDanhGia.AutoSize = true;
            this.lblMaDanhGia.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblMaDanhGia.Location = new System.Drawing.Point(18, 40);
            this.lblMaDanhGia.Name = "lblMaDanhGia";
            this.lblMaDanhGia.Size = new System.Drawing.Size(115, 22);
            this.lblMaDanhGia.TabIndex = 1;
            this.lblMaDanhGia.Text = "Mã đánh giá";
            // 
            // txtMaDanhGia
            // 
            this.txtMaDanhGia.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtMaDanhGia.Location = new System.Drawing.Point(180, 37);
            this.txtMaDanhGia.Name = "txtMaDanhGia";
            this.txtMaDanhGia.ReadOnly = true;
            this.txtMaDanhGia.Size = new System.Drawing.Size(462, 30);
            this.txtMaDanhGia.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(20, 560);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(660, 70);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(350, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(190, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(660, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÊM ĐÁNH GIÁ MỚI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEvaluationCU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 650);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEvaluationCU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đánh giá";
            this.Load += new System.EventHandler(this.frmEvaluationCU_Load);
            this.pnlMain.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblMaDanhGia;
        private System.Windows.Forms.TextBox txtMaDanhGia;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblNguoiDanhGia;
        private System.Windows.Forms.ComboBox cboNguoiDanhGia;
        private System.Windows.Forms.Label lblNgayDanhGia;
        private System.Windows.Forms.DateTimePicker dtpNgayDanhGia;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.NumericUpDown numDiem;
        private System.Windows.Forms.Label lblXepLoai;
        private System.Windows.Forms.TextBox txtXepLoai;
        private System.Windows.Forms.Label lblChiTiet;
        private System.Windows.Forms.TextBox txtChiTiet;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
    }
}