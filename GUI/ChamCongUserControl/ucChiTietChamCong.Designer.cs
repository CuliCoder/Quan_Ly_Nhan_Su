namespace Quan_Ly_Nhan_Su.GUI.ChamCong
{
    partial class ucChiTietChamCong
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlCalendarArea = new System.Windows.Forms.Panel();
            this.flpCalendar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDiTre = new System.Windows.Forms.Button();
            this.btnTangCa = new System.Windows.Forms.Button();
            this.btnNghi = new System.Windows.Forms.Button();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlCalendarArea.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlCalendarArea);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1100, 700);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlCalendarArea
            // 
            this.pnlCalendarArea.Controls.Add(this.flpCalendar);
            this.pnlCalendarArea.Controls.Add(this.pnlActions);
            this.pnlCalendarArea.Controls.Add(this.lblTenNhanVien);
            this.pnlCalendarArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCalendarArea.Location = new System.Drawing.Point(0, 60);
            this.pnlCalendarArea.Name = "pnlCalendarArea";
            this.pnlCalendarArea.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCalendarArea.Size = new System.Drawing.Size(1100, 640);
            this.pnlCalendarArea.TabIndex = 2;
            // 
            // flpCalendar
            // 
            this.flpCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCalendar.Location = new System.Drawing.Point(20, 60);
            this.flpCalendar.Name = "flpCalendar";
            this.flpCalendar.Size = new System.Drawing.Size(1060, 500);
            this.flpCalendar.TabIndex = 2;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnXoa);
            this.pnlActions.Controls.Add(this.btnDiTre);
            this.pnlActions.Controls.Add(this.btnTangCa);
            this.pnlActions.Controls.Add(this.btnNghi);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(20, 560);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(1060, 60);
            this.pnlActions.TabIndex = 1;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Gainsboro;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnXoa.Location = new System.Drawing.Point(340, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnDiTre
            // 
            this.btnDiTre.BackColor = System.Drawing.Color.Gold;
            this.btnDiTre.FlatAppearance.BorderSize = 0;
            this.btnDiTre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiTre.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnDiTre.Location = new System.Drawing.Point(230, 12);
            this.btnDiTre.Name = "btnDiTre";
            this.btnDiTre.Size = new System.Drawing.Size(100, 35);
            this.btnDiTre.TabIndex = 2;
            this.btnDiTre.Text = "Đi trễ";
            this.btnDiTre.UseVisualStyleBackColor = false;
            // 
            // btnTangCa
            // 
            this.btnTangCa.BackColor = System.Drawing.Color.LightGreen;
            this.btnTangCa.FlatAppearance.BorderSize = 0;
            this.btnTangCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTangCa.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnTangCa.Location = new System.Drawing.Point(120, 12);
            this.btnTangCa.Name = "btnTangCa";
            this.btnTangCa.Size = new System.Drawing.Size(100, 35);
            this.btnTangCa.TabIndex = 1;
            this.btnTangCa.Text = "Tăng ca";
            this.btnTangCa.UseVisualStyleBackColor = false;
            // 
            // btnNghi
            // 
            this.btnNghi.BackColor = System.Drawing.Color.Tomato;
            this.btnNghi.FlatAppearance.BorderSize = 0;
            this.btnNghi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNghi.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNghi.ForeColor = System.Drawing.Color.White;
            this.btnNghi.Location = new System.Drawing.Point(10, 12);
            this.btnNghi.Name = "btnNghi";
            this.btnNghi.Size = new System.Drawing.Size(100, 35);
            this.btnNghi.TabIndex = 0;
            this.btnNghi.Text = "Nghỉ";
            this.btnNghi.UseVisualStyleBackColor = false;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.lblTenNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenNhanVien.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenNhanVien.Location = new System.Drawing.Point(20, 20);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTenNhanVien.Size = new System.Drawing.Size(1060, 40);
            this.lblTenNhanVien.TabIndex = 0;
            this.lblTenNhanVien.Text = "NV001 - Nguyễn Văn A";
            this.lblTenNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHeader.Controls.Add(this.btnLuu);
            this.pnlHeader.Controls.Add(this.cboNam);
            this.pnlHeader.Controls.Add(this.cboThang);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(978, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 35);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // cboNam
            // 
            this.cboNam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(196, 15);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(121, 29);
            this.cboNam.TabIndex = 2;
            // 
            // cboThang
            // 
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(69, 15);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(121, 29);
            this.cboThang.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.btnBack.Location = new System.Drawing.Point(10, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 35);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "⬅️";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // ucChiTietChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "ucChiTietChamCong";
            this.Size = new System.Drawing.Size(1100, 700);
            this.pnlMain.ResumeLayout(false);
            this.pnlCalendarArea.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.Panel pnlCalendarArea;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDiTre;
        private System.Windows.Forms.Button btnTangCa;
        private System.Windows.Forms.Button btnNghi;
        private System.Windows.Forms.FlowLayoutPanel flpCalendar;
        private System.Windows.Forms.Button btnLuu;
    }
}