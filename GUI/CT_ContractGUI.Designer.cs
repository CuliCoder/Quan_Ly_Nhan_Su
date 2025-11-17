namespace Quan_Ly_Nhan_Su.GUI
{
    partial class CT_ContractGUI
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.buttonTaoHopDong = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelMaHopDong = new System.Windows.Forms.Label();
            this.textBoxMaHopDong = new System.Windows.Forms.TextBox();
            this.labelNhanVien = new System.Windows.Forms.Label();
            this.comboBoxNhanVien = new System.Windows.Forms.ComboBox();
            this.labelPhongBan = new System.Windows.Forms.Label();
            this.comboBoxPhongBan = new System.Windows.Forms.ComboBox();
            this.labelLoaiHopDong = new System.Windows.Forms.Label();
            this.comboBoxLoaiHopDong = new System.Windows.Forms.ComboBox();
            this.labelTuNgay = new System.Windows.Forms.Label();
            this.dateTimePickerTuNgay = new System.Windows.Forms.DateTimePicker();
            this.labelDenNgay = new System.Windows.Forms.Label();
            this.dateTimePickerDenNgay = new System.Windows.Forms.DateTimePicker();
            this.labelMucLuong = new System.Windows.Forms.Label();
            this.textBoxMucLuong = new System.Windows.Forms.TextBox();
            this.labelLuongTheoGio = new System.Windows.Forms.Label();
            this.textBoxLuongTheoGio = new System.Windows.Forms.TextBox();
            this.panelMain.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelFooter);
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(920, 750);
            this.panelMain.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(20, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(880, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(880, 80);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "📋 TẠO HỢP ĐỒNG LAO ĐỘNG";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.buttonHuy);
            this.panelFooter.Controls.Add(this.buttonTaoHopDong);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(20, 640);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(40, 15, 40, 15);
            this.panelFooter.Size = new System.Drawing.Size(880, 90);
            this.panelFooter.TabIndex = 1;
            // 
            // buttonHuy
            // 
            this.buttonHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.buttonHuy.FlatAppearance.BorderSize = 0;
            this.buttonHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonHuy.ForeColor = System.Drawing.Color.White;
            this.buttonHuy.Location = new System.Drawing.Point(40, 20);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(200, 45);
            this.buttonHuy.TabIndex = 0;
            this.buttonHuy.Text = "✖ Hủy bỏ";
            this.buttonHuy.UseVisualStyleBackColor = false;
            this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // buttonTaoHopDong
            // 
            this.buttonTaoHopDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.buttonTaoHopDong.FlatAppearance.BorderSize = 0;
            this.buttonTaoHopDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTaoHopDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonTaoHopDong.ForeColor = System.Drawing.Color.White;
            this.buttonTaoHopDong.Location = new System.Drawing.Point(620, 20);
            this.buttonTaoHopDong.Name = "buttonTaoHopDong";
            this.buttonTaoHopDong.Size = new System.Drawing.Size(250, 45);
            this.buttonTaoHopDong.TabIndex = 1;
            this.buttonTaoHopDong.Text = "✔ Tạo hợp đồng";
            this.buttonTaoHopDong.UseVisualStyleBackColor = false;
            this.buttonTaoHopDong.Click += new System.EventHandler(this.buttonTaoHopDong_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.tableLayoutPanel1);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(20, 20);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(880, 710);
            this.panelContent.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.labelMaHopDong, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMaHopDong, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelNhanVien, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxNhanVien, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelPhongBan, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPhongBan, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelLoaiHopDong, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxLoaiHopDong, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelTuNgay, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerTuNgay, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelDenNgay, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerDenNgay, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelMucLuong, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMucLuong, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelLuongTheoGio, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBoxLuongTheoGio, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(820, 650);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelMaHopDong
            // 
            this.labelMaHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMaHopDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelMaHopDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelMaHopDong.Location = new System.Drawing.Point(13, 10);
            this.labelMaHopDong.Name = "labelMaHopDong";
            this.labelMaHopDong.Size = new System.Drawing.Size(314, 55);
            this.labelMaHopDong.TabIndex = 0;
            this.labelMaHopDong.Text = "Mã hợp đồng (Tự động):";
            // 
            // textBoxMaHopDong
            // 
            this.textBoxMaHopDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.textBoxMaHopDong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMaHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMaHopDong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxMaHopDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.textBoxMaHopDong.Location = new System.Drawing.Point(333, 13);
            this.textBoxMaHopDong.Name = "textBoxMaHopDong";
            this.textBoxMaHopDong.ReadOnly = true;
            this.textBoxMaHopDong.Size = new System.Drawing.Size(474, 34);
            this.textBoxMaHopDong.TabIndex = 1;
            this.textBoxMaHopDong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNhanVien
            // 
            this.labelNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelNhanVien.Location = new System.Drawing.Point(13, 65);
            this.labelNhanVien.Name = "labelNhanVien";
            this.labelNhanVien.Size = new System.Drawing.Size(314, 55);
            this.labelNhanVien.TabIndex = 2;
            this.labelNhanVien.Text = "Mã nhân viên: *";
            // 
            // comboBoxNhanVien
            // 
            this.comboBoxNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxNhanVien.Location = new System.Drawing.Point(333, 68);
            this.comboBoxNhanVien.Name = "comboBoxNhanVien";
            this.comboBoxNhanVien.Size = new System.Drawing.Size(474, 36);
            this.comboBoxNhanVien.TabIndex = 3;
            // 
            // labelPhongBan
            // 
            this.labelPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPhongBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelPhongBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelPhongBan.Location = new System.Drawing.Point(13, 120);
            this.labelPhongBan.Name = "labelPhongBan";
            this.labelPhongBan.Size = new System.Drawing.Size(314, 55);
            this.labelPhongBan.TabIndex = 4;
            this.labelPhongBan.Text = "Phòng ban: *";
            // 
            // comboBoxPhongBan
            // 
            this.comboBoxPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPhongBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxPhongBan.Location = new System.Drawing.Point(333, 123);
            this.comboBoxPhongBan.Name = "comboBoxPhongBan";
            this.comboBoxPhongBan.Size = new System.Drawing.Size(474, 36);
            this.comboBoxPhongBan.TabIndex = 5;
            // 
            // labelLoaiHopDong
            // 
            this.labelLoaiHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLoaiHopDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelLoaiHopDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelLoaiHopDong.Location = new System.Drawing.Point(13, 175);
            this.labelLoaiHopDong.Name = "labelLoaiHopDong";
            this.labelLoaiHopDong.Size = new System.Drawing.Size(314, 55);
            this.labelLoaiHopDong.TabIndex = 6;
            this.labelLoaiHopDong.Text = "Loại hợp đồng: *";
            // 
            // comboBoxLoaiHopDong
            // 
            this.comboBoxLoaiHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxLoaiHopDong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoaiHopDong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxLoaiHopDong.Location = new System.Drawing.Point(333, 178);
            this.comboBoxLoaiHopDong.Name = "comboBoxLoaiHopDong";
            this.comboBoxLoaiHopDong.Size = new System.Drawing.Size(474, 36);
            this.comboBoxLoaiHopDong.TabIndex = 7;
            // 
            // labelTuNgay
            // 
            this.labelTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelTuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelTuNgay.Location = new System.Drawing.Point(13, 230);
            this.labelTuNgay.Name = "labelTuNgay";
            this.labelTuNgay.Size = new System.Drawing.Size(314, 55);
            this.labelTuNgay.TabIndex = 8;
            this.labelTuNgay.Text = "Từ ngày: *";
            // 
            // dateTimePickerTuNgay
            // 
            this.dateTimePickerTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTuNgay.Location = new System.Drawing.Point(333, 233);
            this.dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            this.dateTimePickerTuNgay.Size = new System.Drawing.Size(474, 34);
            this.dateTimePickerTuNgay.TabIndex = 9;
            // 
            // labelDenNgay
            // 
            this.labelDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelDenNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelDenNgay.Location = new System.Drawing.Point(13, 285);
            this.labelDenNgay.Name = "labelDenNgay";
            this.labelDenNgay.Size = new System.Drawing.Size(314, 55);
            this.labelDenNgay.TabIndex = 10;
            this.labelDenNgay.Text = "Đến ngày:";
            // 
            // dateTimePickerDenNgay
            // 
            this.dateTimePickerDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDenNgay.Location = new System.Drawing.Point(333, 288);
            this.dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            this.dateTimePickerDenNgay.ShowCheckBox = true;
            this.dateTimePickerDenNgay.Size = new System.Drawing.Size(474, 34);
            this.dateTimePickerDenNgay.TabIndex = 11;
            // 
            // labelMucLuong
            // 
            this.labelMucLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMucLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelMucLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelMucLuong.Location = new System.Drawing.Point(13, 340);
            this.labelMucLuong.Name = "labelMucLuong";
            this.labelMucLuong.Size = new System.Drawing.Size(314, 55);
            this.labelMucLuong.TabIndex = 12;
            this.labelMucLuong.Text = "Lương cơ bản (VNĐ): *";
            // 
            // textBoxMucLuong
            // 
            this.textBoxMucLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMucLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMucLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxMucLuong.Location = new System.Drawing.Point(333, 343);
            this.textBoxMucLuong.Name = "textBoxMucLuong";
            this.textBoxMucLuong.Size = new System.Drawing.Size(474, 34);
            this.textBoxMucLuong.TabIndex = 13;
            // 
            // labelLuongTheoGio
            // 
            this.labelLuongTheoGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLuongTheoGio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelLuongTheoGio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelLuongTheoGio.Location = new System.Drawing.Point(13, 395);
            this.labelLuongTheoGio.Name = "labelLuongTheoGio";
            this.labelLuongTheoGio.Size = new System.Drawing.Size(314, 245);
            this.labelLuongTheoGio.TabIndex = 14;
            this.labelLuongTheoGio.Text = "Lương theo giờ (VNĐ):";
            // 
            // textBoxLuongTheoGio
            // 
            this.textBoxLuongTheoGio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLuongTheoGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLuongTheoGio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxLuongTheoGio.Location = new System.Drawing.Point(333, 398);
            this.textBoxLuongTheoGio.Name = "textBoxLuongTheoGio";
            this.textBoxLuongTheoGio.Size = new System.Drawing.Size(474, 34);
            this.textBoxLuongTheoGio.TabIndex = 15;
            // 
            // CT_ContractGUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelMain);
            this.Name = "CT_ContractGUI";
            this.Size = new System.Drawing.Size(920, 750);
            this.panelMain.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelMaHopDong;
        private System.Windows.Forms.TextBox textBoxMaHopDong;
        private System.Windows.Forms.Label labelNhanVien;
        private System.Windows.Forms.ComboBox comboBoxNhanVien;
        private System.Windows.Forms.Label labelPhongBan;
        private System.Windows.Forms.ComboBox comboBoxPhongBan;
        private System.Windows.Forms.Label labelLoaiHopDong;
        private System.Windows.Forms.ComboBox comboBoxLoaiHopDong;
        private System.Windows.Forms.Label labelTuNgay;
        private System.Windows.Forms.DateTimePicker dateTimePickerTuNgay;
        private System.Windows.Forms.Label labelDenNgay;
        private System.Windows.Forms.DateTimePicker dateTimePickerDenNgay;
        private System.Windows.Forms.Label labelMucLuong;
        private System.Windows.Forms.TextBox textBoxMucLuong;
        private System.Windows.Forms.Label labelLuongTheoGio;
        private System.Windows.Forms.TextBox textBoxLuongTheoGio;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button buttonHuy;
        private System.Windows.Forms.Button buttonTaoHopDong;
    }
}
