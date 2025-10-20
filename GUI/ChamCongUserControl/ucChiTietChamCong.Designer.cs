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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.tblMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlApproved = new System.Windows.Forms.Panel();
            this.flpApproved = new System.Windows.Forms.FlowLayoutPanel();
            this.lblApprovedHeader = new System.Windows.Forms.Label();
            this.pnlSubmitted = new System.Windows.Forms.Panel();
            this.flpSubmitted = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSubmittedHeader = new System.Windows.Forms.Label();
            this.pnlDraft = new System.Windows.Forms.Panel();
            this.flpDraft = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDraftHeader = new System.Windows.Forms.Label();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.tblMainLayout.SuspendLayout();
            this.pnlApproved.SuspendLayout();
            this.pnlSubmitted.SuspendLayout();
            this.pnlDraft.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlContainer);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1100, 700);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.tblMainLayout);
            this.pnlContainer.Controls.Add(this.lblTenNhanVien);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 60);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlContainer.Size = new System.Drawing.Size(1100, 640);
            this.pnlContainer.TabIndex = 2;
            // 
            // tblMainLayout
            // 
            this.tblMainLayout.ColumnCount = 3;
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMainLayout.Controls.Add(this.pnlApproved, 2, 0);
            this.tblMainLayout.Controls.Add(this.pnlSubmitted, 1, 0);
            this.tblMainLayout.Controls.Add(this.pnlDraft, 0, 0);
            this.tblMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainLayout.Location = new System.Drawing.Point(10, 50);
            this.tblMainLayout.Name = "tblMainLayout";
            this.tblMainLayout.RowCount = 1;
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainLayout.Size = new System.Drawing.Size(1080, 580);
            this.tblMainLayout.TabIndex = 1;
            // 
            // pnlApproved
            // 
            this.pnlApproved.Controls.Add(this.flpApproved);
            this.pnlApproved.Controls.Add(this.lblApprovedHeader);
            this.pnlApproved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlApproved.Location = new System.Drawing.Point(723, 3);
            this.pnlApproved.Name = "pnlApproved";
            this.pnlApproved.Padding = new System.Windows.Forms.Padding(5);
            this.pnlApproved.Size = new System.Drawing.Size(354, 574);
            this.pnlApproved.TabIndex = 2;
            // 
            // flpApproved
            // 
            this.flpApproved.AutoScroll = true;
            this.flpApproved.BackColor = System.Drawing.Color.White;
            this.flpApproved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpApproved.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpApproved.Location = new System.Drawing.Point(5, 35);
            this.flpApproved.Name = "flpApproved";
            this.flpApproved.Size = new System.Drawing.Size(344, 534);
            this.flpApproved.TabIndex = 1;
            this.flpApproved.WrapContents = false;
            // 
            // lblApprovedHeader
            // 
            this.lblApprovedHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblApprovedHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApprovedHeader.Location = new System.Drawing.Point(5, 5);
            this.lblApprovedHeader.Name = "lblApprovedHeader";
            this.lblApprovedHeader.Size = new System.Drawing.Size(344, 30);
            this.lblApprovedHeader.TabIndex = 0;
            this.lblApprovedHeader.Text = "Approved";
            // 
            // pnlSubmitted
            // 
            this.pnlSubmitted.Controls.Add(this.flpSubmitted);
            this.pnlSubmitted.Controls.Add(this.lblSubmittedHeader);
            this.pnlSubmitted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubmitted.Location = new System.Drawing.Point(363, 3);
            this.pnlSubmitted.Name = "pnlSubmitted";
            this.pnlSubmitted.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSubmitted.Size = new System.Drawing.Size(354, 574);
            this.pnlSubmitted.TabIndex = 1;
            // 
            // flpSubmitted
            // 
            this.flpSubmitted.AutoScroll = true;
            this.flpSubmitted.BackColor = System.Drawing.Color.White;
            this.flpSubmitted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSubmitted.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSubmitted.Location = new System.Drawing.Point(5, 35);
            this.flpSubmitted.Name = "flpSubmitted";
            this.flpSubmitted.Size = new System.Drawing.Size(344, 534);
            this.flpSubmitted.TabIndex = 1;
            this.flpSubmitted.WrapContents = false;
            // 
            // lblSubmittedHeader
            // 
            this.lblSubmittedHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubmittedHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubmittedHeader.Location = new System.Drawing.Point(5, 5);
            this.lblSubmittedHeader.Name = "lblSubmittedHeader";
            this.lblSubmittedHeader.Size = new System.Drawing.Size(344, 30);
            this.lblSubmittedHeader.TabIndex = 0;
            this.lblSubmittedHeader.Text = "Submitted";
            // 
            // pnlDraft
            // 
            this.pnlDraft.Controls.Add(this.flpDraft);
            this.pnlDraft.Controls.Add(this.lblDraftHeader);
            this.pnlDraft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDraft.Location = new System.Drawing.Point(3, 3);
            this.pnlDraft.Name = "pnlDraft";
            this.pnlDraft.Padding = new System.Windows.Forms.Padding(5);
            this.pnlDraft.Size = new System.Drawing.Size(354, 574);
            this.pnlDraft.TabIndex = 0;
            // 
            // flpDraft
            // 
            this.flpDraft.AutoScroll = true;
            this.flpDraft.BackColor = System.Drawing.Color.White;
            this.flpDraft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDraft.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDraft.Location = new System.Drawing.Point(5, 35);
            this.flpDraft.Name = "flpDraft";
            this.flpDraft.Size = new System.Drawing.Size(344, 534);
            this.flpDraft.TabIndex = 1;
            this.flpDraft.WrapContents = false;
            // 
            // lblDraftHeader
            // 
            this.lblDraftHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDraftHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDraftHeader.Location = new System.Drawing.Point(5, 5);
            this.lblDraftHeader.Name = "lblDraftHeader";
            this.lblDraftHeader.Size = new System.Drawing.Size(344, 30);
            this.lblDraftHeader.TabIndex = 0;
            this.lblDraftHeader.Text = "Draft";
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.BackColor = System.Drawing.Color.White;
            this.lblTenNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenNhanVien.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenNhanVien.Location = new System.Drawing.Point(10, 10);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTenNhanVien.Size = new System.Drawing.Size(1080, 40);
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
            this.pnlContainer.ResumeLayout(false);
            this.tblMainLayout.ResumeLayout(false);
            this.pnlApproved.ResumeLayout(false);
            this.pnlSubmitted.ResumeLayout(false);
            this.pnlDraft.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TableLayoutPanel tblMainLayout;
        private System.Windows.Forms.Panel pnlApproved;
        private System.Windows.Forms.Panel pnlSubmitted;
        private System.Windows.Forms.Panel pnlDraft;
        private System.Windows.Forms.Label lblApprovedHeader;
        private System.Windows.Forms.Label lblSubmittedHeader;
        private System.Windows.Forms.Label lblDraftHeader;
        private System.Windows.Forms.FlowLayoutPanel flpApproved;
        private System.Windows.Forms.FlowLayoutPanel flpSubmitted;
        private System.Windows.Forms.FlowLayoutPanel flpDraft;
    }
}