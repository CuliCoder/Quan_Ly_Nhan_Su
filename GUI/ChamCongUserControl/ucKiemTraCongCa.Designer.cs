namespace Quan_Ly_Nhan_Su.GUI.ChamCong
{
    partial class ucKiemTraCongCa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.dgvCheckCongCa = new System.Windows.Forms.DataGridView();
            this.colNgayChamCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckOutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGo_late = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeave_early = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbInfo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckCongCa)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlContainer);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1332, 734);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.dgvCheckCongCa);
            this.pnlContainer.Controls.Add(this.lbInfo);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 60);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.pnlContainer.Size = new System.Drawing.Size(1332, 674);
            this.pnlContainer.TabIndex = 2;
            // 
            // dgvCheckCongCa
            // 
            this.dgvCheckCongCa.AllowUserToAddRows = false;
            this.dgvCheckCongCa.AllowUserToDeleteRows = false;
            this.dgvCheckCongCa.AllowUserToResizeColumns = false;
            this.dgvCheckCongCa.AllowUserToResizeRows = false;
            this.dgvCheckCongCa.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCheckCongCa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCheckCongCa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCheckCongCa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCheckCongCa.ColumnHeadersHeight = 29;
            this.dgvCheckCongCa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCheckCongCa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNgayChamCong,
            this.colCheckInTime,
            this.colCheckOutTime,
            this.colGo_late,
            this.colLeave_early,
            this.colTotalHours});
            this.dgvCheckCongCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckCongCa.Location = new System.Drawing.Point(11, 53);
            this.dgvCheckCongCa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCheckCongCa.Name = "dgvCheckCongCa";
            this.dgvCheckCongCa.RowHeadersVisible = false;
            this.dgvCheckCongCa.RowHeadersWidth = 51;
            this.dgvCheckCongCa.RowTemplate.Height = 24;
            this.dgvCheckCongCa.Size = new System.Drawing.Size(1310, 611);
            this.dgvCheckCongCa.TabIndex = 0;
            this.dgvCheckCongCa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colNgayChamCong
            // 
            this.colNgayChamCong.HeaderText = "Ngày chấm công";
            this.colNgayChamCong.MinimumWidth = 6;
            this.colNgayChamCong.Name = "colNgayChamCong";
            this.colNgayChamCong.ReadOnly = true;
            this.colNgayChamCong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNgayChamCong.Width = 250;
            // 
            // colCheckInTime
            // 
            this.colCheckInTime.HeaderText = "Check In";
            this.colCheckInTime.MinimumWidth = 6;
            this.colCheckInTime.Name = "colCheckInTime";
            this.colCheckInTime.ReadOnly = true;
            this.colCheckInTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCheckInTime.Width = 170;
            // 
            // colCheckOutTime
            // 
            this.colCheckOutTime.HeaderText = "Check Out";
            this.colCheckOutTime.MinimumWidth = 6;
            this.colCheckOutTime.Name = "colCheckOutTime";
            this.colCheckOutTime.ReadOnly = true;
            this.colCheckOutTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCheckOutTime.Width = 170;
            // 
            // colGo_late
            // 
            this.colGo_late.HeaderText = "Đi muộn";
            this.colGo_late.MinimumWidth = 6;
            this.colGo_late.Name = "colGo_late";
            this.colGo_late.ReadOnly = true;
            this.colGo_late.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colGo_late.Width = 150;
            // 
            // colLeave_early
            // 
            this.colLeave_early.HeaderText = "Về sớm";
            this.colLeave_early.MinimumWidth = 6;
            this.colLeave_early.Name = "colLeave_early";
            this.colLeave_early.ReadOnly = true;
            this.colLeave_early.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colLeave_early.Width = 150;
            // 
            // colTotalHours
            // 
            this.colTotalHours.HeaderText = "Số giờ làm việc";
            this.colTotalHours.MinimumWidth = 6;
            this.colTotalHours.Name = "colTotalHours";
            this.colTotalHours.ReadOnly = true;
            this.colTotalHours.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTotalHours.Width = 190;
            // 
            // lbInfo
            // 
            this.lbInfo.AllowDrop = true;
            this.lbInfo.AutoSize = true;
            this.lbInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.Location = new System.Drawing.Point(11, 10);
            this.lbInfo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lbInfo.Size = new System.Drawing.Size(1203, 43);
            this.lbInfo.TabIndex = 1;
            this.lbInfo.Text = "Nguyễn Văn A - TE11520 - nguyencongtrung@gmail.commmmmmmmmmmmmm";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.cboNam);
            this.pnlHeader.Controls.Add(this.cboThang);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1332, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Quan_Ly_Nhan_Su.Properties.Resources.arrows_14074366;
            this.pictureBox1.Location = new System.Drawing.Point(325, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cboNam
            // 
            this.cboNam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(196, 15);
            this.cboNam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(121, 31);
            this.cboNam.TabIndex = 2;
            this.cboNam.SelectedIndexChanged += new System.EventHandler(this.CboNam_SelectedIndexChanged);
            // 
            // cboThang
            // 
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(69, 15);
            this.cboThang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(121, 31);
            this.cboThang.TabIndex = 1;
            this.cboThang.SelectedIndexChanged += new System.EventHandler(this.CboThang_SelectedIndexChanged);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.btnBack.Location = new System.Drawing.Point(11, 12);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 34);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "⬅️";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ucKiemTraCongCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucKiemTraCongCa";
            this.Size = new System.Drawing.Size(1332, 734);
            this.pnlMain.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckCongCa)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.DataGridView dgvCheckCongCa;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayChamCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckInTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckOutTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGo_late;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeave_early;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalHours;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}