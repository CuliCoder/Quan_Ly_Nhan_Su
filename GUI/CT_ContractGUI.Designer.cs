namespace Quan_Ly_Nhan_Su.GUI
{
    partial class CT_ContractGUI
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelForm = new System.Windows.Forms.Panel();
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
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonTaoHopDong = new System.Windows.Forms.Button();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelForm);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(22, 20, 22, 20);
            this.panelMain.Size = new System.Drawing.Size(766, 629);
            this.panelMain.TabIndex = 0;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(22, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(722, 46);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(722, 46);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "TẠO HỢP ĐỒNG LAO ĐỘNG";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelForm.Controls.Add(this.labelMaHopDong);
            this.panelForm.Controls.Add(this.textBoxMaHopDong);
            this.panelForm.Controls.Add(this.labelNhanVien);
            this.panelForm.Controls.Add(this.comboBoxNhanVien);
            this.panelForm.Controls.Add(this.labelPhongBan);
            this.panelForm.Controls.Add(this.comboBoxPhongBan);
            this.panelForm.Controls.Add(this.labelLoaiHopDong);
            this.panelForm.Controls.Add(this.comboBoxLoaiHopDong);
            this.panelForm.Controls.Add(this.labelTuNgay);
            this.panelForm.Controls.Add(this.dateTimePickerTuNgay);
            this.panelForm.Controls.Add(this.labelDenNgay);
            this.panelForm.Controls.Add(this.dateTimePickerDenNgay);
            this.panelForm.Controls.Add(this.labelMucLuong);
            this.panelForm.Controls.Add(this.textBoxMucLuong);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(22, 20);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(34, 30, 34, 30);
            this.panelForm.Size = new System.Drawing.Size(722, 525);
            this.panelForm.TabIndex = 1;
            // 
            // labelMaHopDong
            // 
            this.labelMaHopDong.AutoSize = true;
            this.labelMaHopDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelMaHopDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelMaHopDong.Location = new System.Drawing.Point(3, 70);
            this.labelMaHopDong.Name = "labelMaHopDong";
            this.labelMaHopDong.Size = new System.Drawing.Size(145, 28);
            this.labelMaHopDong.TabIndex = 0;
            this.labelMaHopDong.Text = "Mã hợp đồng:";
            // 
            // textBoxMaHopDong
            // 
            this.textBoxMaHopDong.BackColor = System.Drawing.Color.White;
            this.textBoxMaHopDong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMaHopDong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxMaHopDong.Location = new System.Drawing.Point(159, 68);
            this.textBoxMaHopDong.Name = "textBoxMaHopDong";
            this.textBoxMaHopDong.Size = new System.Drawing.Size(469, 34);
            this.textBoxMaHopDong.TabIndex = 1;
            // 
            // labelNhanVien
            // 
            this.labelNhanVien.AutoSize = true;
            this.labelNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelNhanVien.Location = new System.Drawing.Point(13, 122);
            this.labelNhanVien.Name = "labelNhanVien";
            this.labelNhanVien.Size = new System.Drawing.Size(123, 26);
            this.labelNhanVien.TabIndex = 2;
            this.labelNhanVien.Text = "Nhân viên:";
            // 
            // comboBoxNhanVien
            // 
            this.comboBoxNhanVien.BackColor = System.Drawing.Color.White;
            this.comboBoxNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxNhanVien.FormattingEnabled = true;
            this.comboBoxNhanVien.Location = new System.Drawing.Point(159, 117);
            this.comboBoxNhanVien.Name = "comboBoxNhanVien";
            this.comboBoxNhanVien.Size = new System.Drawing.Size(481, 36);
            this.comboBoxNhanVien.TabIndex = 3;
            // 
            // labelPhongBan
            // 
            this.labelPhongBan.AutoSize = true;
            this.labelPhongBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelPhongBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelPhongBan.Location = new System.Drawing.Point(11, 178);
            this.labelPhongBan.Name = "labelPhongBan";
            this.labelPhongBan.Size = new System.Drawing.Size(129, 26);
            this.labelPhongBan.TabIndex = 4;
            this.labelPhongBan.Text = "Phòng ban:";
            // 
            // comboBoxPhongBan
            // 
            this.comboBoxPhongBan.BackColor = System.Drawing.Color.White;
            this.comboBoxPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPhongBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPhongBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxPhongBan.FormattingEnabled = true;
            this.comboBoxPhongBan.Location = new System.Drawing.Point(159, 173);
            this.comboBoxPhongBan.Name = "comboBoxPhongBan";
            this.comboBoxPhongBan.Size = new System.Drawing.Size(481, 36);
            this.comboBoxPhongBan.TabIndex = 5;
            // 
            // labelLoaiHopDong
            // 
            this.labelLoaiHopDong.AutoSize = true;
            this.labelLoaiHopDong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelLoaiHopDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelLoaiHopDong.Location = new System.Drawing.Point(11, 244);
            this.labelLoaiHopDong.Name = "labelLoaiHopDong";
            this.labelLoaiHopDong.Size = new System.Drawing.Size(168, 26);
            this.labelLoaiHopDong.TabIndex = 6;
            this.labelLoaiHopDong.Text = "Loại hợp đồng:";
            // 
            // comboBoxLoaiHopDong
            // 
            this.comboBoxLoaiHopDong.BackColor = System.Drawing.Color.White;
            this.comboBoxLoaiHopDong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoaiHopDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxLoaiHopDong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxLoaiHopDong.FormattingEnabled = true;
            this.comboBoxLoaiHopDong.Items.AddRange(new object[] {
            "Xác định thời hạn",
            "Không thời hạn"});
            this.comboBoxLoaiHopDong.Location = new System.Drawing.Point(175, 239);
            this.comboBoxLoaiHopDong.Name = "comboBoxLoaiHopDong";
            this.comboBoxLoaiHopDong.Size = new System.Drawing.Size(458, 36);
            this.comboBoxLoaiHopDong.TabIndex = 7;
            // 
            // labelTuNgay
            // 
            this.labelTuNgay.AutoSize = true;
            this.labelTuNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelTuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelTuNgay.Location = new System.Drawing.Point(9, 307);
            this.labelTuNgay.Name = "labelTuNgay";
            this.labelTuNgay.Size = new System.Drawing.Size(104, 26);
            this.labelTuNgay.TabIndex = 8;
            this.labelTuNgay.Text = "Từ ngày:";
            // 
            // dateTimePickerTuNgay
            // 
            this.dateTimePickerTuNgay.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePickerTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTuNgay.Location = new System.Drawing.Point(142, 299);
            this.dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            this.dateTimePickerTuNgay.Size = new System.Drawing.Size(498, 34);
            this.dateTimePickerTuNgay.TabIndex = 9;
            // 
            // labelDenNgay
            // 
            this.labelDenNgay.AutoSize = true;
            this.labelDenNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelDenNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelDenNgay.Location = new System.Drawing.Point(9, 374);
            this.labelDenNgay.Name = "labelDenNgay";
            this.labelDenNgay.Size = new System.Drawing.Size(116, 26);
            this.labelDenNgay.TabIndex = 10;
            this.labelDenNgay.Text = "Đến ngày:";
            // 
            // dateTimePickerDenNgay
            // 
            this.dateTimePickerDenNgay.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePickerDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDenNgay.Location = new System.Drawing.Point(142, 357);
            this.dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            this.dateTimePickerDenNgay.Size = new System.Drawing.Size(498, 34);
            this.dateTimePickerDenNgay.TabIndex = 11;
            // 
            // labelMucLuong
            // 
            this.labelMucLuong.AutoSize = true;
            this.labelMucLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelMucLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelMucLuong.Location = new System.Drawing.Point(3, 430);
            this.labelMucLuong.Name = "labelMucLuong";
            this.labelMucLuong.Size = new System.Drawing.Size(133, 26);
            this.labelMucLuong.TabIndex = 12;
            this.labelMucLuong.Text = "Mức lương:";
            // 
            // textBoxMucLuong
            // 
            this.textBoxMucLuong.BackColor = System.Drawing.Color.White;
            this.textBoxMucLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMucLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxMucLuong.Location = new System.Drawing.Point(142, 426);
            this.textBoxMucLuong.Name = "textBoxMucLuong";
            this.textBoxMucLuong.Size = new System.Drawing.Size(498, 34);
            this.textBoxMucLuong.TabIndex = 13;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.buttonTaoHopDong);
            this.panelButtons.Controls.Add(this.buttonHuy);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(22, 545);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(34, 20, 34, 20);
            this.panelButtons.Size = new System.Drawing.Size(722, 64);
            this.panelButtons.TabIndex = 2;
            this.panelButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.panelButtons_Paint);
            // 
            // buttonTaoHopDong
            // 
            this.buttonTaoHopDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.buttonTaoHopDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTaoHopDong.FlatAppearance.BorderSize = 0;
            this.buttonTaoHopDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTaoHopDong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonTaoHopDong.ForeColor = System.Drawing.Color.White;
            this.buttonTaoHopDong.Location = new System.Drawing.Point(465, 6);
            this.buttonTaoHopDong.Name = "buttonTaoHopDong";
            this.buttonTaoHopDong.Size = new System.Drawing.Size(215, 47);
            this.buttonTaoHopDong.TabIndex = 0;
            this.buttonTaoHopDong.Text = "Tạo hợp đồng";
            this.buttonTaoHopDong.UseVisualStyleBackColor = false;
            this.buttonTaoHopDong.Click += new System.EventHandler(this.buttonTaoHopDong_Click);
            // 
            // buttonHuy
            // 
            this.buttonHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.buttonHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHuy.FlatAppearance.BorderSize = 0;
            this.buttonHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonHuy.ForeColor = System.Drawing.Color.White;
            this.buttonHuy.Location = new System.Drawing.Point(21, 12);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(119, 49);
            this.buttonHuy.TabIndex = 1;
            this.buttonHuy.Text = "Hủy";
            this.buttonHuy.UseVisualStyleBackColor = false;
            this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // CT_ContractGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelMain);
            this.Name = "CT_ContractGUI";
            this.Size = new System.Drawing.Size(766, 629);
            this.panelMain.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label labelMaHopDong;
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
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonTaoHopDong;
        private System.Windows.Forms.Button buttonHuy;
        private System.Windows.Forms.TextBox textBoxMaHopDong;
    }
}