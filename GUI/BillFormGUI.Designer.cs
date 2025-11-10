using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    partial class BillFormGUI
    {
        private System.ComponentModel.IContainer components = null;

        // Root + Header
        private Panel pnlRoot;
        private Panel pnlHeader;
        private Label lblTitle;

        // Stack container
        private Panel stack;

        // Employee Info
        private TableLayoutPanel tblInfo;
        private Label lblMaNV;
        private Label lblHoTen;
        private Label lblPhongBan;
        private Label lblChucVu;

        // Income card
        private Panel cardIncome;
        private Panel cardIncomeHeader;
        private Label lblIncomeTitle;
        private TableLayoutPanel tblIncome;
        private Label lblLuongCoBan;
        private Label lblThuong;
        private Label lblPhuCapCV;
        private Label lblPhuCapKhac;

        // Deduction card
        private Panel cardDeduct;
        private Panel cardDeductHeader;
        private Label lblDeductTitle;
        private TableLayoutPanel tblDeduct;
        private Label lblTruBH;
        private Label lblTruKhac;
        private Label lblThue;

        // Total
        private Panel pnlTotal;
        private Label lblThucLanh;

        // Sign card
        private Panel cardSign;
        private Panel cardSignHeader;
        private Label lblSignTitle;
        private TableLayoutPanel tblSign;
        private Label lblNguoiLap;
        private Label lblNgayLap;
        private Label lblNguoiDuyet;
        private Label lblNhanVienXN;

        // Print button
        private Button btnPrint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.stack = new System.Windows.Forms.Panel();
            this.cardSign = new System.Windows.Forms.Panel();
            this.tblSign = new System.Windows.Forms.TableLayoutPanel();
            this.lblNguoiLap = new System.Windows.Forms.Label();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.lblNguoiDuyet = new System.Windows.Forms.Label();
            this.lblNhanVienXN = new System.Windows.Forms.Label();
            this.cardSignHeader = new System.Windows.Forms.Panel();
            this.lblSignTitle = new System.Windows.Forms.Label();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblThucLanh = new System.Windows.Forms.Label();
            this.cardDeduct = new System.Windows.Forms.Panel();
            this.tblDeduct = new System.Windows.Forms.TableLayoutPanel();
            this.lblTruBH = new System.Windows.Forms.Label();
            this.lblTruKhac = new System.Windows.Forms.Label();
            this.lblThue = new System.Windows.Forms.Label();
            this.cardDeductHeader = new System.Windows.Forms.Panel();
            this.lblDeductTitle = new System.Windows.Forms.Label();
            this.cardIncome = new System.Windows.Forms.Panel();
            this.tblIncome = new System.Windows.Forms.TableLayoutPanel();
            this.lblLuongCoBan = new System.Windows.Forms.Label();
            this.lblThuong = new System.Windows.Forms.Label();
            this.lblPhuCapCV = new System.Windows.Forms.Label();
            this.lblPhuCapKhac = new System.Windows.Forms.Label();
            this.cardIncomeHeader = new System.Windows.Forms.Panel();
            this.lblIncomeTitle = new System.Windows.Forms.Label();
            this.tblInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlRoot.SuspendLayout();
            this.stack.SuspendLayout();
            this.cardSign.SuspendLayout();
            this.tblSign.SuspendLayout();
            this.cardSignHeader.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.cardDeduct.SuspendLayout();
            this.tblDeduct.SuspendLayout();
            this.cardDeductHeader.SuspendLayout();
            this.cardIncome.SuspendLayout();
            this.tblIncome.SuspendLayout();
            this.cardIncomeHeader.SuspendLayout();
            this.tblInfo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRoot
            // 
            this.pnlRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlRoot.Controls.Add(this.stack);
            this.pnlRoot.Controls.Add(this.pnlHeader);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Padding = new System.Windows.Forms.Padding(18);
            this.pnlRoot.Size = new System.Drawing.Size(650, 723);
            this.pnlRoot.TabIndex = 0;
            // 
            // stack
            // 
            this.stack.BackColor = this.pnlRoot.BackColor;
            this.stack.Controls.Add(this.cardSign);
            this.stack.Controls.Add(this.pnlTotal);
            this.stack.Controls.Add(this.cardDeduct);
            this.stack.Controls.Add(this.cardIncome);
            this.stack.Controls.Add(this.tblInfo);
            this.stack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stack.Location = new System.Drawing.Point(18, 90);
            this.stack.Name = "stack";
            this.stack.Size = new System.Drawing.Size(614, 615);
            this.stack.TabIndex = 0;
            // 
            // cardSign
            // 
            this.cardSign.BackColor = System.Drawing.Color.White;
            this.cardSign.Controls.Add(this.tblSign);
            this.cardSign.Controls.Add(this.cardSignHeader);
            this.cardSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardSign.Location = new System.Drawing.Point(0, 550);
            this.cardSign.Name = "cardSign";
            this.cardSign.Padding = new System.Windows.Forms.Padding(16);
            this.cardSign.Size = new System.Drawing.Size(614, 65);
            this.cardSign.TabIndex = 0;
            // 
            // tblSign
            // 
            this.tblSign.ColumnCount = 2;
            this.tblSign.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSign.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSign.Controls.Add(this.lblNguoiLap, 0, 0);
            this.tblSign.Controls.Add(this.lblNgayLap, 1, 0);
            this.tblSign.Controls.Add(this.lblNguoiDuyet, 0, 1);
            this.tblSign.Controls.Add(this.lblNhanVienXN, 1, 1);
            this.tblSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSign.Location = new System.Drawing.Point(16, 52);
            this.tblSign.Name = "tblSign";
            this.tblSign.Padding = new System.Windows.Forms.Padding(4);
            this.tblSign.RowCount = 2;
            this.tblSign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSign.Size = new System.Drawing.Size(582, 0);
            this.tblSign.TabIndex = 0;
            // 
            // lblNguoiLap
            // 
            this.lblNguoiLap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNguoiLap.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblNguoiLap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblNguoiLap.Location = new System.Drawing.Point(7, 4);
            this.lblNguoiLap.Name = "lblNguoiLap";
            this.lblNguoiLap.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblNguoiLap.Size = new System.Drawing.Size(281, 1);
            this.lblNguoiLap.TabIndex = 0;
            this.lblNguoiLap.Text = "Người lập phiếu: _____________";
            this.lblNguoiLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgayLap.Font = this.lblNguoiLap.Font;
            this.lblNgayLap.ForeColor = this.lblNguoiLap.ForeColor;
            this.lblNgayLap.Location = new System.Drawing.Point(294, 4);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Padding = this.lblNguoiLap.Padding;
            this.lblNgayLap.Size = new System.Drawing.Size(281, 1);
            this.lblNgayLap.TabIndex = 1;
            this.lblNgayLap.Text = "Ngày: __/__/____";
            this.lblNgayLap.TextAlign = this.lblNguoiLap.TextAlign;
            // 
            // lblNguoiDuyet
            // 
            this.lblNguoiDuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNguoiDuyet.Font = this.lblNguoiLap.Font;
            this.lblNguoiDuyet.ForeColor = this.lblNguoiLap.ForeColor;
            this.lblNguoiDuyet.Location = new System.Drawing.Point(7, 4);
            this.lblNguoiDuyet.Name = "lblNguoiDuyet";
            this.lblNguoiDuyet.Padding = this.lblNguoiLap.Padding;
            this.lblNguoiDuyet.Size = new System.Drawing.Size(281, 1);
            this.lblNguoiDuyet.TabIndex = 2;
            this.lblNguoiDuyet.Text = "Người duyệt: _____________";
            this.lblNguoiDuyet.TextAlign = this.lblNguoiLap.TextAlign;
            // 
            // lblNhanVienXN
            // 
            this.lblNhanVienXN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhanVienXN.Font = this.lblNguoiLap.Font;
            this.lblNhanVienXN.ForeColor = this.lblNguoiLap.ForeColor;
            this.lblNhanVienXN.Location = new System.Drawing.Point(294, 4);
            this.lblNhanVienXN.Name = "lblNhanVienXN";
            this.lblNhanVienXN.Padding = this.lblNguoiLap.Padding;
            this.lblNhanVienXN.Size = new System.Drawing.Size(281, 1);
            this.lblNhanVienXN.TabIndex = 3;
            this.lblNhanVienXN.Text = "Nhân viên xác nhận: _____________";
            this.lblNhanVienXN.TextAlign = this.lblNguoiLap.TextAlign;
            // 
            // cardSignHeader
            // 
            this.cardSignHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(63)))), ((int)(((byte)(211)))));
            this.cardSignHeader.Controls.Add(this.lblSignTitle);
            this.cardSignHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardSignHeader.Location = new System.Drawing.Point(16, 16);
            this.cardSignHeader.Name = "cardSignHeader";
            this.cardSignHeader.Size = new System.Drawing.Size(582, 36);
            this.cardSignHeader.TabIndex = 1;
            // 
            // lblSignTitle
            // 
            this.lblSignTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSignTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblSignTitle.ForeColor = System.Drawing.Color.White;
            this.lblSignTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSignTitle.Name = "lblSignTitle";
            this.lblSignTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblSignTitle.Size = new System.Drawing.Size(582, 36);
            this.lblSignTitle.TabIndex = 0;
            this.lblSignTitle.Text = "KÝ & XÁC NHẬN";
            this.lblSignTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(196)))));
            this.pnlTotal.Controls.Add(this.lblThucLanh);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTotal.Location = new System.Drawing.Point(0, 480);
            this.pnlTotal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Padding = new System.Windows.Forms.Padding(18);
            this.pnlTotal.Size = new System.Drawing.Size(614, 70);
            this.pnlTotal.TabIndex = 1;
            // 
            // lblThucLanh
            // 
            this.lblThucLanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThucLanh.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblThucLanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.lblThucLanh.Location = new System.Drawing.Point(18, 18);
            this.lblThucLanh.Name = "lblThucLanh";
            this.lblThucLanh.Size = new System.Drawing.Size(578, 34);
            this.lblThucLanh.TabIndex = 0;
            this.lblThucLanh.Text = "👉 Thực lãnh:";
            this.lblThucLanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cardDeduct
            // 
            this.cardDeduct.BackColor = System.Drawing.Color.White;
            this.cardDeduct.Controls.Add(this.tblDeduct);
            this.cardDeduct.Controls.Add(this.cardDeductHeader);
            this.cardDeduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardDeduct.Location = new System.Drawing.Point(0, 320);
            this.cardDeduct.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.cardDeduct.Name = "cardDeduct";
            this.cardDeduct.Padding = new System.Windows.Forms.Padding(16);
            this.cardDeduct.Size = new System.Drawing.Size(614, 160);
            this.cardDeduct.TabIndex = 2;
            // 
            // tblDeduct
            // 
            this.tblDeduct.ColumnCount = 1;
            this.tblDeduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 704F));
            this.tblDeduct.Controls.Add(this.lblTruBH, 0, 0);
            this.tblDeduct.Controls.Add(this.lblTruKhac, 0, 1);
            this.tblDeduct.Controls.Add(this.lblThue, 0, 2);
            this.tblDeduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDeduct.Location = new System.Drawing.Point(16, 52);
            this.tblDeduct.Name = "tblDeduct";
            this.tblDeduct.Padding = new System.Windows.Forms.Padding(4);
            this.tblDeduct.RowCount = 3;
            this.tblDeduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblDeduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblDeduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblDeduct.Size = new System.Drawing.Size(582, 92);
            this.tblDeduct.TabIndex = 0;
            // 
            // lblTruBH
            // 
            this.lblTruBH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTruBH.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblTruBH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTruBH.Location = new System.Drawing.Point(7, 4);
            this.lblTruBH.Name = "lblTruBH";
            this.lblTruBH.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblTruBH.Size = new System.Drawing.Size(698, 28);
            this.lblTruBH.TabIndex = 0;
            this.lblTruBH.Text = "Khấu trừ BH:";
            this.lblTruBH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTruKhac
            // 
            this.lblTruKhac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTruKhac.Font = this.lblTruBH.Font;
            this.lblTruKhac.ForeColor = this.lblTruBH.ForeColor;
            this.lblTruKhac.Location = new System.Drawing.Point(7, 32);
            this.lblTruKhac.Name = "lblTruKhac";
            this.lblTruKhac.Padding = this.lblTruBH.Padding;
            this.lblTruKhac.Size = new System.Drawing.Size(698, 28);
            this.lblTruKhac.TabIndex = 1;
            this.lblTruKhac.Text = "Khấu trừ khác:";
            this.lblTruKhac.TextAlign = this.lblTruBH.TextAlign;
            // 
            // lblThue
            // 
            this.lblThue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThue.Font = this.lblTruBH.Font;
            this.lblThue.ForeColor = this.lblTruBH.ForeColor;
            this.lblThue.Location = new System.Drawing.Point(7, 60);
            this.lblThue.Name = "lblThue";
            this.lblThue.Padding = this.lblTruBH.Padding;
            this.lblThue.Size = new System.Drawing.Size(698, 28);
            this.lblThue.TabIndex = 2;
            this.lblThue.Text = "Thuế TNCN:";
            this.lblThue.TextAlign = this.lblTruBH.TextAlign;
            // 
            // cardDeductHeader
            // 
            this.cardDeductHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.cardDeductHeader.Controls.Add(this.lblDeductTitle);
            this.cardDeductHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardDeductHeader.Location = new System.Drawing.Point(16, 16);
            this.cardDeductHeader.Name = "cardDeductHeader";
            this.cardDeductHeader.Size = new System.Drawing.Size(582, 36);
            this.cardDeductHeader.TabIndex = 1;
            // 
            // lblDeductTitle
            // 
            this.lblDeductTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeductTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblDeductTitle.ForeColor = System.Drawing.Color.White;
            this.lblDeductTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDeductTitle.Name = "lblDeductTitle";
            this.lblDeductTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblDeductTitle.Size = new System.Drawing.Size(582, 36);
            this.lblDeductTitle.TabIndex = 0;
            this.lblDeductTitle.Text = "CÁC KHOẢN KHẤU TRỪ";
            this.lblDeductTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cardIncome
            // 
            this.cardIncome.BackColor = System.Drawing.Color.White;
            this.cardIncome.Controls.Add(this.tblIncome);
            this.cardIncome.Controls.Add(this.cardIncomeHeader);
            this.cardIncome.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardIncome.Location = new System.Drawing.Point(0, 120);
            this.cardIncome.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.cardIncome.Name = "cardIncome";
            this.cardIncome.Padding = new System.Windows.Forms.Padding(16);
            this.cardIncome.Size = new System.Drawing.Size(614, 200);
            this.cardIncome.TabIndex = 3;
            // 
            // tblIncome
            // 
            this.tblIncome.ColumnCount = 1;
            this.tblIncome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 704F));
            this.tblIncome.Controls.Add(this.lblLuongCoBan, 0, 0);
            this.tblIncome.Controls.Add(this.lblThuong, 0, 1);
            this.tblIncome.Controls.Add(this.lblPhuCapCV, 0, 2);
            this.tblIncome.Controls.Add(this.lblPhuCapKhac, 0, 3);
            this.tblIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblIncome.Location = new System.Drawing.Point(16, 52);
            this.tblIncome.Name = "tblIncome";
            this.tblIncome.Padding = new System.Windows.Forms.Padding(4);
            this.tblIncome.RowCount = 4;
            this.tblIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblIncome.Size = new System.Drawing.Size(582, 132);
            this.tblIncome.TabIndex = 0;
            // 
            // lblLuongCoBan
            // 
            this.lblLuongCoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLuongCoBan.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblLuongCoBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblLuongCoBan.Location = new System.Drawing.Point(7, 4);
            this.lblLuongCoBan.Name = "lblLuongCoBan";
            this.lblLuongCoBan.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblLuongCoBan.Size = new System.Drawing.Size(698, 31);
            this.lblLuongCoBan.TabIndex = 0;
            this.lblLuongCoBan.Text = "Lương cơ bản:";
            this.lblLuongCoBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThuong
            // 
            this.lblThuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThuong.Font = this.lblLuongCoBan.Font;
            this.lblThuong.ForeColor = this.lblLuongCoBan.ForeColor;
            this.lblThuong.Location = new System.Drawing.Point(7, 35);
            this.lblThuong.Name = "lblThuong";
            this.lblThuong.Padding = this.lblLuongCoBan.Padding;
            this.lblThuong.Size = new System.Drawing.Size(698, 31);
            this.lblThuong.TabIndex = 1;
            this.lblThuong.Text = "Thưởng:";
            this.lblThuong.TextAlign = this.lblLuongCoBan.TextAlign;
            // 
            // lblPhuCapCV
            // 
            this.lblPhuCapCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhuCapCV.Font = this.lblLuongCoBan.Font;
            this.lblPhuCapCV.ForeColor = this.lblLuongCoBan.ForeColor;
            this.lblPhuCapCV.Location = new System.Drawing.Point(7, 66);
            this.lblPhuCapCV.Name = "lblPhuCapCV";
            this.lblPhuCapCV.Padding = this.lblLuongCoBan.Padding;
            this.lblPhuCapCV.Size = new System.Drawing.Size(698, 31);
            this.lblPhuCapCV.TabIndex = 2;
            this.lblPhuCapCV.Text = "Phụ cấp chức vụ:";
            this.lblPhuCapCV.TextAlign = this.lblLuongCoBan.TextAlign;
            // 
            // lblPhuCapKhac
            // 
            this.lblPhuCapKhac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhuCapKhac.Font = this.lblLuongCoBan.Font;
            this.lblPhuCapKhac.ForeColor = this.lblLuongCoBan.ForeColor;
            this.lblPhuCapKhac.Location = new System.Drawing.Point(7, 97);
            this.lblPhuCapKhac.Name = "lblPhuCapKhac";
            this.lblPhuCapKhac.Padding = this.lblLuongCoBan.Padding;
            this.lblPhuCapKhac.Size = new System.Drawing.Size(698, 31);
            this.lblPhuCapKhac.TabIndex = 3;
            this.lblPhuCapKhac.Text = "Phụ cấp khác:";
            this.lblPhuCapKhac.TextAlign = this.lblLuongCoBan.TextAlign;
            // 
            // cardIncomeHeader
            // 
            this.cardIncomeHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.cardIncomeHeader.Controls.Add(this.lblIncomeTitle);
            this.cardIncomeHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardIncomeHeader.Location = new System.Drawing.Point(16, 16);
            this.cardIncomeHeader.Name = "cardIncomeHeader";
            this.cardIncomeHeader.Size = new System.Drawing.Size(582, 36);
            this.cardIncomeHeader.TabIndex = 1;
            // 
            // lblIncomeTitle
            // 
            this.lblIncomeTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIncomeTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblIncomeTitle.ForeColor = System.Drawing.Color.White;
            this.lblIncomeTitle.Location = new System.Drawing.Point(0, 0);
            this.lblIncomeTitle.Name = "lblIncomeTitle";
            this.lblIncomeTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblIncomeTitle.Size = new System.Drawing.Size(582, 36);
            this.lblIncomeTitle.TabIndex = 0;
            this.lblIncomeTitle.Text = "CỘNG THU NHẬP";
            this.lblIncomeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblInfo
            // 
            this.tblInfo.BackColor = System.Drawing.Color.White;
            this.tblInfo.ColumnCount = 2;
            this.tblInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInfo.Controls.Add(this.lblMaNV, 0, 0);
            this.tblInfo.Controls.Add(this.lblHoTen, 1, 0);
            this.tblInfo.Controls.Add(this.lblPhongBan, 0, 1);
            this.tblInfo.Controls.Add(this.lblChucVu, 1, 1);
            this.tblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblInfo.Location = new System.Drawing.Point(0, 0);
            this.tblInfo.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.tblInfo.Name = "tblInfo";
            this.tblInfo.Padding = new System.Windows.Forms.Padding(16);
            this.tblInfo.RowCount = 2;
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInfo.Size = new System.Drawing.Size(614, 120);
            this.tblInfo.TabIndex = 4;
            // 
            // lblMaNV
            // 
            this.lblMaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNV.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblMaNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblMaNV.Location = new System.Drawing.Point(19, 16);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblMaNV.Size = new System.Drawing.Size(285, 44);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Mã NV:";
            this.lblMaNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHoTen
            // 
            this.lblHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblHoTen.Location = new System.Drawing.Point(310, 16);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblHoTen.Size = new System.Drawing.Size(285, 44);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ tên:";
            this.lblHoTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPhongBan
            // 
            this.lblPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhongBan.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblPhongBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblPhongBan.Location = new System.Drawing.Point(19, 60);
            this.lblPhongBan.Name = "lblPhongBan";
            this.lblPhongBan.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblPhongBan.Size = new System.Drawing.Size(285, 44);
            this.lblPhongBan.TabIndex = 2;
            this.lblPhongBan.Text = "Phòng ban:";
            this.lblPhongBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChucVu
            // 
            this.lblChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChucVu.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblChucVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblChucVu.Location = new System.Drawing.Point(310, 60);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblChucVu.Size = new System.Drawing.Size(285, 44);
            this.lblChucVu.TabIndex = 3;
            this.lblChucVu.Text = "Chức vụ:";
            this.lblChucVu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(120)))), ((int)(((byte)(246)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(18, 18);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(614, 72);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(614, 72);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PHIẾU LƯƠNG NHÂN VIÊN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(120)))), ((int)(((byte)(246)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(0, 723);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(650, 67);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "In phiếu lương (PDF)";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // BillFormGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(650, 790);
            this.Controls.Add(this.pnlRoot);
            this.Controls.Add(this.btnPrint);
            this.Name = "BillFormGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu Lương Nhân Viên";
            this.pnlRoot.ResumeLayout(false);
            this.stack.ResumeLayout(false);
            this.cardSign.ResumeLayout(false);
            this.tblSign.ResumeLayout(false);
            this.cardSignHeader.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.cardDeduct.ResumeLayout(false);
            this.tblDeduct.ResumeLayout(false);
            this.cardDeductHeader.ResumeLayout(false);
            this.cardIncome.ResumeLayout(false);
            this.tblIncome.ResumeLayout(false);
            this.cardIncomeHeader.ResumeLayout(false);
            this.tblInfo.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
