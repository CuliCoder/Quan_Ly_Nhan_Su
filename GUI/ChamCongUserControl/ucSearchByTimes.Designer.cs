namespace Quan_Ly_Nhan_Su.GUI.ChamCongUserControl
{
    partial class ucSearchByTimes
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.flMonths = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnApplyRange = new System.Windows.Forms.Button();
            this.dtpRangeTo = new System.Windows.Forms.DateTimePicker();
            this.dtpRangeFrom = new System.Windows.Forms.DateTimePicker();
            this.btnReload = new System.Windows.Forms.Button();
            this.lblRange = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.flMonths);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(999, 596);
            this.pnlMain.TabIndex = 0;
            // 
            // flMonths
            // 
            this.flMonths.AutoScroll = true;
            this.flMonths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flMonths.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flMonths.Location = new System.Drawing.Point(0, 86);
            this.flMonths.Name = "flMonths";
            this.flMonths.Padding = new System.Windows.Forms.Padding(12);
            this.flMonths.Size = new System.Drawing.Size(999, 510);
            this.flMonths.TabIndex = 2;
            this.flMonths.WrapContents = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHeader.Controls.Add(this.btnApplyRange);
            this.pnlHeader.Controls.Add(this.dtpRangeTo);
            this.pnlHeader.Controls.Add(this.dtpRangeFrom);
            this.pnlHeader.Controls.Add(this.btnReload);
            this.pnlHeader.Controls.Add(this.lblRange);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(999, 86);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnApplyRange
            // 
            this.btnApplyRange.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnApplyRange.Location = new System.Drawing.Point(663, 36);
            this.btnApplyRange.Name = "btnApplyRange";
            this.btnApplyRange.Size = new System.Drawing.Size(120, 28);
            this.btnApplyRange.TabIndex = 5;
            this.btnApplyRange.Text = "Áp dụng khoảng";
            this.btnApplyRange.UseVisualStyleBackColor = true;
            this.btnApplyRange.Click += new System.EventHandler(this.btnApplyRange_Click);
            // 
            // dtpRangeTo
            // 
            this.dtpRangeTo.CustomFormat = "dd/MM/yyyy";
            this.dtpRangeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRangeTo.Location = new System.Drawing.Point(488, 36);
            this.dtpRangeTo.Name = "dtpRangeTo";
            this.dtpRangeTo.Size = new System.Drawing.Size(160, 20);
            this.dtpRangeTo.TabIndex = 4;
            // 
            // dtpRangeFrom
            // 
            this.dtpRangeFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpRangeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRangeFrom.Location = new System.Drawing.Point(304, 36);
            this.dtpRangeFrom.Name = "dtpRangeFrom";
            this.dtpRangeFrom.Size = new System.Drawing.Size(160, 20);
            this.dtpRangeFrom.TabIndex = 3;
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReload.Location = new System.Drawing.Point(800, 36);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(90, 28);
            this.btnReload.TabIndex = 2;
            this.btnReload.Text = "Tải lại";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblRange
            // 
            this.lblRange.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRange.Location = new System.Drawing.Point(304, 16);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(344, 17);
            this.lblRange.TabIndex = 1;
            this.lblRange.Text = "Khoảng thời gian: Từ                Đến";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTitle.Location = new System.Drawing.Point(8, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(290, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dòng thời gian chấm công (range)";
            // 
            // ucSearchByTimes
            // 
            this.Controls.Add(this.pnlMain);
            this.Name = "ucSearchByTimes";
            this.Size = new System.Drawing.Size(999, 596);
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flMonths;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.DateTimePicker dtpRangeFrom;
        private System.Windows.Forms.DateTimePicker dtpRangeTo;
        private System.Windows.Forms.Button btnApplyRange;
    }
}