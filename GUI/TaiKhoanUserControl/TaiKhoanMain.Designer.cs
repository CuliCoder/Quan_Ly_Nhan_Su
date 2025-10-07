namespace Quan_Ly_Nhan_Su.GUI.TaiKhoanUserControl
{
    partial class TaiKhoanMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageTaiKhoan = new System.Windows.Forms.TabPage();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.colTkSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTkNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTaiKhoanControls = new System.Windows.Forms.Panel();
            this.btnSuaTk = new System.Windows.Forms.Button();
            this.btnXoaTk = new System.Windows.Forms.Button();
            this.btnThemTk = new System.Windows.Forms.Button();
            this.btnTimKiemTk = new System.Windows.Forms.Button();
            this.txtTimKiemTk = new System.Windows.Forms.TextBox();
            this.tabPagePhanQuyen = new System.Windows.Forms.TabPage();
            this.dgvChiTietQuyen = new System.Windows.Forms.DataGridView();
            this.dgvPhanQuyen = new System.Windows.Forms.DataGridView();
            this.colPqMaNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPqTenNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelPhanQuyenControls = new System.Windows.Forms.Panel();
            this.btnLuuQuyen = new System.Windows.Forms.Button();
            this.btnThemPq = new System.Windows.Forms.Button();
            this.tabPageChucNang = new System.Windows.Forms.TabPage();
            this.dgvChucNang = new System.Windows.Forms.DataGridView();
            this.colCnMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCnTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCnMoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelChucNangControls = new System.Windows.Forms.Panel();
            this.btnSuaCn = new System.Windows.Forms.Button();
            this.btnXoaCn = new System.Windows.Forms.Button();
            this.btnThemCn = new System.Windows.Forms.Button();
            this.btnTimKiemCn = new System.Windows.Forms.Button();
            this.txtTimKiemCn = new System.Windows.Forms.TextBox();
            this.tabMain.SuspendLayout();
            this.tabPageTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.panelTaiKhoanControls.SuspendLayout();
            this.tabPagePhanQuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).BeginInit();
            this.panelPhanQuyenControls.SuspendLayout();
            this.tabPageChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucNang)).BeginInit();
            this.panelChucNangControls.SuspendLayout();
            this.SuspendLayout();
            //
            // tabMain
            //
            this.tabMain.Controls.Add(this.tabPageTaiKhoan);
            this.tabMain.Controls.Add(this.tabPagePhanQuyen);
            this.tabMain.Controls.Add(this.tabPageChucNang);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1020, 630);
            this.tabMain.TabIndex = 0;
            //
            // tabPageTaiKhoan
            //
            this.tabPageTaiKhoan.BackColor = System.Drawing.Color.White;
            this.tabPageTaiKhoan.Controls.Add(this.dgvTaiKhoan);
            this.tabPageTaiKhoan.Controls.Add(this.panelTaiKhoanControls);
            this.tabPageTaiKhoan.Location = new System.Drawing.Point(4, 32);
            this.tabPageTaiKhoan.Name = "tabPageTaiKhoan";
            this.tabPageTaiKhoan.Padding = new System.Windows.Forms.Padding(15);
            this.tabPageTaiKhoan.Size = new System.Drawing.Size(1012, 594);
            this.tabPageTaiKhoan.TabIndex = 0;
            this.tabPageTaiKhoan.Text = "Tài Khoản";
            //
            // dgvTaiKhoan
            //
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTaiKhoan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaiKhoan.ColumnHeadersHeight = 40;
            this.dgvTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTkSTT,
            this.colTkNhanVien});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaiKhoan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiKhoan.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(15, 75);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.RowHeadersVisible = false;
            this.dgvTaiKhoan.RowTemplate.Height = 35;
            this.dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(982, 504);
            this.dgvTaiKhoan.TabIndex = 1;
            //
            // colTkSTT
            //
            this.colTkSTT.HeaderText = "STT";
            this.colTkSTT.Name = "colTkSTT";
            this.colTkSTT.ReadOnly = true;
            this.colTkSTT.Width = 80;
            //
            // colTkNhanVien
            //
            this.colTkNhanVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTkNhanVien.HeaderText = "NHÂN VIÊN";
            this.colTkNhanVien.Name = "colTkNhanVien";
            this.colTkNhanVien.ReadOnly = true;
            //
            // panelTaiKhoanControls
            //
            this.panelTaiKhoanControls.Controls.Add(this.btnSuaTk);
            this.panelTaiKhoanControls.Controls.Add(this.btnXoaTk);
            this.panelTaiKhoanControls.Controls.Add(this.btnThemTk);
            this.panelTaiKhoanControls.Controls.Add(this.btnTimKiemTk);
            this.panelTaiKhoanControls.Controls.Add(this.txtTimKiemTk);
            this.panelTaiKhoanControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTaiKhoanControls.Location = new System.Drawing.Point(15, 15);
            this.panelTaiKhoanControls.Name = "panelTaiKhoanControls";
            this.panelTaiKhoanControls.Size = new System.Drawing.Size(982, 60);
            this.panelTaiKhoanControls.TabIndex = 0;
            //
            // btnSuaTk
            //
            this.btnSuaTk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuaTk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSuaTk.FlatAppearance.BorderSize = 0;
            this.btnSuaTk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaTk.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaTk.ForeColor = System.Drawing.Color.White;
            this.btnSuaTk.Location = new System.Drawing.Point(879, 10);
            this.btnSuaTk.Name = "btnSuaTk";
            this.btnSuaTk.Size = new System.Drawing.Size(100, 40);
            this.btnSuaTk.TabIndex = 4;
            this.btnSuaTk.Text = "Sửa";
            this.btnSuaTk.UseVisualStyleBackColor = false;
            //
            // btnXoaTk
            //
            this.btnXoaTk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaTk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoaTk.FlatAppearance.BorderSize = 0;
            this.btnXoaTk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTk.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaTk.ForeColor = System.Drawing.Color.White;
            this.btnXoaTk.Location = new System.Drawing.Point(773, 10);
            this.btnXoaTk.Name = "btnXoaTk";
            this.btnXoaTk.Size = new System.Drawing.Size(100, 40);
            this.btnXoaTk.TabIndex = 3;
            this.btnXoaTk.Text = "Xóa";
            this.btnXoaTk.UseVisualStyleBackColor = false;
            //
            // btnThemTk
            //
            this.btnThemTk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemTk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnThemTk.FlatAppearance.BorderSize = 0;
            this.btnThemTk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTk.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTk.ForeColor = System.Drawing.Color.White;
            this.btnThemTk.Location = new System.Drawing.Point(667, 10);
            this.btnThemTk.Name = "btnThemTk";
            this.btnThemTk.Size = new System.Drawing.Size(100, 40);
            this.btnThemTk.TabIndex = 2;
            this.btnThemTk.Text = "+ Thêm";
            this.btnThemTk.UseVisualStyleBackColor = false;
            //
            // btnTimKiemTk
            //
            this.btnTimKiemTk.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTimKiemTk.FlatAppearance.BorderSize = 0;
            this.btnTimKiemTk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemTk.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemTk.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemTk.Location = new System.Drawing.Point(286, 10);
            this.btnTimKiemTk.Name = "btnTimKiemTk";
            this.btnTimKiemTk.Size = new System.Drawing.Size(40, 40);
            this.btnTimKiemTk.TabIndex = 1;
            this.btnTimKiemTk.UseVisualStyleBackColor = false;
            //
            // txtTimKiemTk
            //
            this.txtTimKiemTk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemTk.Location = new System.Drawing.Point(3, 13);
            this.txtTimKiemTk.Name = "txtTimKiemTk";
            this.txtTimKiemTk.Size = new System.Drawing.Size(277, 34);
            this.txtTimKiemTk.TabIndex = 0;
            //
            // tabPagePhanQuyen
            //
            this.tabPagePhanQuyen.BackColor = System.Drawing.Color.White;
            this.tabPagePhanQuyen.Controls.Add(this.dgvChiTietQuyen);
            this.tabPagePhanQuyen.Controls.Add(this.dgvPhanQuyen);
            this.tabPagePhanQuyen.Controls.Add(this.panelPhanQuyenControls);
            this.tabPagePhanQuyen.Location = new System.Drawing.Point(4, 32);
            this.tabPagePhanQuyen.Name = "tabPagePhanQuyen";
            this.tabPagePhanQuyen.Padding = new System.Windows.Forms.Padding(15);
            this.tabPagePhanQuyen.Size = new System.Drawing.Size(1012, 594);
            this.tabPagePhanQuyen.TabIndex = 1;
            this.tabPagePhanQuyen.Text = "Phân Quyền";
            //
            // dgvChiTietQuyen
            //
            this.dgvChiTietQuyen.AllowUserToAddRows = false;
            this.dgvChiTietQuyen.AllowUserToDeleteRows = false;
            this.dgvChiTietQuyen.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietQuyen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTietQuyen.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietQuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChiTietQuyen.ColumnHeadersHeight = 40;
            this.dgvChiTietQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietQuyen.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvChiTietQuyen.Location = new System.Drawing.Point(365, 75);
            this.dgvChiTietQuyen.Name = "dgvChiTietQuyen";
            this.dgvChiTietQuyen.RowHeadersVisible = false;
            this.dgvChiTietQuyen.RowTemplate.Height = 35;
            this.dgvChiTietQuyen.Size = new System.Drawing.Size(632, 504);
            this.dgvChiTietQuyen.TabIndex = 3;
            //
            // dgvPhanQuyen
            //
            this.dgvPhanQuyen.AllowUserToAddRows = false;
            this.dgvPhanQuyen.AllowUserToDeleteRows = false;
            this.dgvPhanQuyen.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhanQuyen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhanQuyen.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhanQuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPhanQuyen.ColumnHeadersHeight = 40;
            this.dgvPhanQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPqMaNhom,
            this.colPqTenNhom});
            this.dgvPhanQuyen.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvPhanQuyen.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvPhanQuyen.Location = new System.Drawing.Point(15, 75);
            this.dgvPhanQuyen.MultiSelect = false;
            this.dgvPhanQuyen.Name = "dgvPhanQuyen";
            this.dgvPhanQuyen.ReadOnly = true;
            this.dgvPhanQuyen.RowHeadersVisible = false;
            this.dgvPhanQuyen.RowTemplate.Height = 35;
            this.dgvPhanQuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhanQuyen.Size = new System.Drawing.Size(350, 504);
            this.dgvPhanQuyen.TabIndex = 2;
            //
            // colPqMaNhom
            //
            this.colPqMaNhom.DataPropertyName = "MaNhomQuyen";
            this.colPqMaNhom.HeaderText = "Mã";
            this.colPqMaNhom.Name = "colPqMaNhom";
            this.colPqMaNhom.ReadOnly = true;
            this.colPqMaNhom.Width = 60;
            //
            // colPqTenNhom
            //
            this.colPqTenNhom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPqTenNhom.DataPropertyName = "TenNhomQuyen";
            this.colPqTenNhom.HeaderText = "Tên Nhóm Quyền";
            this.colPqTenNhom.Name = "colPqTenNhom";
            this.colPqTenNhom.ReadOnly = true;
            //
            // panelPhanQuyenControls
            //
            this.panelPhanQuyenControls.Controls.Add(this.btnLuuQuyen);
            this.panelPhanQuyenControls.Controls.Add(this.btnThemPq);
            this.panelPhanQuyenControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPhanQuyenControls.Location = new System.Drawing.Point(15, 15);
            this.panelPhanQuyenControls.Name = "panelPhanQuyenControls";
            this.panelPhanQuyenControls.Size = new System.Drawing.Size(982, 60);
            this.panelPhanQuyenControls.TabIndex = 1;
            //
            // btnLuuQuyen
            //
            this.btnLuuQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuQuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnLuuQuyen.FlatAppearance.BorderSize = 0;
            this.btnLuuQuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuQuyen.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuQuyen.ForeColor = System.Drawing.Color.White;
            this.btnLuuQuyen.Location = new System.Drawing.Point(857, 10);
            this.btnLuuQuyen.Name = "btnLuuQuyen";
            this.btnLuuQuyen.Size = new System.Drawing.Size(122, 40);
            this.btnLuuQuyen.TabIndex = 3;
            this.btnLuuQuyen.Text = "Lưu Quyền";
            this.btnLuuQuyen.UseVisualStyleBackColor = false;
            //
            // btnThemPq
            //
            this.btnThemPq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnThemPq.FlatAppearance.BorderSize = 0;
            this.btnThemPq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemPq.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemPq.ForeColor = System.Drawing.Color.White;
            this.btnThemPq.Location = new System.Drawing.Point(3, 10);
            this.btnThemPq.Name = "btnThemPq";
            this.btnThemPq.Size = new System.Drawing.Size(176, 40);
            this.btnThemPq.TabIndex = 2;
            this.btnThemPq.Text = "+ Thêm Nhóm Quyền";
            this.btnThemPq.UseVisualStyleBackColor = false;
            //
            // tabPageChucNang
            //
            this.tabPageChucNang.BackColor = System.Drawing.Color.White;
            this.tabPageChucNang.Controls.Add(this.dgvChucNang);
            this.tabPageChucNang.Controls.Add(this.panelChucNangControls);
            this.tabPageChucNang.Location = new System.Drawing.Point(4, 32);
            this.tabPageChucNang.Name = "tabPageChucNang";
            this.tabPageChucNang.Padding = new System.Windows.Forms.Padding(15);
            this.tabPageChucNang.Size = new System.Drawing.Size(1012, 594);
            this.tabPageChucNang.TabIndex = 2;
            this.tabPageChucNang.Text = "Chức Năng";
            //
            // dgvChucNang
            //
            this.dgvChucNang.AllowUserToAddRows = false;
            this.dgvChucNang.AllowUserToDeleteRows = false;
            this.dgvChucNang.BackgroundColor = System.Drawing.Color.White;
            this.dgvChucNang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChucNang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChucNang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvChucNang.ColumnHeadersHeight = 40;
            this.dgvChucNang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCnMa,
            this.colCnTen,
            this.colCnMoTa});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChucNang.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChucNang.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvChucNang.Location = new System.Drawing.Point(15, 75);
            this.dgvChucNang.Name = "dgvChucNang";
            this.dgvChucNang.ReadOnly = true;
            this.dgvChucNang.RowHeadersVisible = false;
            this.dgvChucNang.RowTemplate.Height = 35;
            this.dgvChucNang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChucNang.Size = new System.Drawing.Size(982, 504);
            this.dgvChucNang.TabIndex = 2;
            //
            // colCnMa
            //
            this.colCnMa.HeaderText = "Mã chức năng";
            this.colCnMa.Name = "colCnMa";
            this.colCnMa.ReadOnly = true;
            this.colCnMa.Width = 150;
            //
            // colCnTen
            //
            this.colCnTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCnTen.HeaderText = "Tên chức năng";
            this.colCnTen.Name = "colCnTen";
            this.colCnTen.ReadOnly = true;
            //
            // colCnMoTa
            //
            this.colCnMoTa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCnMoTa.HeaderText = "Mô tả";
            this.colCnMoTa.Name = "colCnMoTa";
            this.colCnMoTa.ReadOnly = true;
            //
            // panelChucNangControls
            //
            this.panelChucNangControls.Controls.Add(this.btnSuaCn);
            this.panelChucNangControls.Controls.Add(this.btnXoaCn);
            this.panelChucNangControls.Controls.Add(this.btnThemCn);
            this.panelChucNangControls.Controls.Add(this.btnTimKiemCn);
            this.panelChucNangControls.Controls.Add(this.txtTimKiemCn);
            this.panelChucNangControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelChucNangControls.Location = new System.Drawing.Point(15, 15);
            this.panelChucNangControls.Name = "panelChucNangControls";
            this.panelChucNangControls.Size = new System.Drawing.Size(982, 60);
            this.panelChucNangControls.TabIndex = 1;
            //
            // btnSuaCn
            //
            this.btnSuaCn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuaCn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSuaCn.FlatAppearance.BorderSize = 0;
            this.btnSuaCn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaCn.ForeColor = System.Drawing.Color.White;
            this.btnSuaCn.Location = new System.Drawing.Point(879, 10);
            this.btnSuaCn.Name = "btnSuaCn";
            this.btnSuaCn.Size = new System.Drawing.Size(100, 40);
            this.btnSuaCn.TabIndex = 4;
            this.btnSuaCn.Text = "Sửa";
            this.btnSuaCn.UseVisualStyleBackColor = false;
            //
            // btnXoaCn
            //
            this.btnXoaCn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaCn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoaCn.FlatAppearance.BorderSize = 0;
            this.btnXoaCn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCn.ForeColor = System.Drawing.Color.White;
            this.btnXoaCn.Location = new System.Drawing.Point(773, 10);
            this.btnXoaCn.Name = "btnXoaCn";
            this.btnXoaCn.Size = new System.Drawing.Size(100, 40);
            this.btnXoaCn.TabIndex = 3;
            this.btnXoaCn.Text = "Xóa";
            this.btnXoaCn.UseVisualStyleBackColor = false;
            //
            // btnThemCn
            //
            this.btnThemCn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemCn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnThemCn.FlatAppearance.BorderSize = 0;
            this.btnThemCn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCn.ForeColor = System.Drawing.Color.White;
            this.btnThemCn.Location = new System.Drawing.Point(667, 10);
            this.btnThemCn.Name = "btnThemCn";
            this.btnThemCn.Size = new System.Drawing.Size(100, 40);
            this.btnThemCn.TabIndex = 2;
            this.btnThemCn.Text = "+ Thêm";
            this.btnThemCn.UseVisualStyleBackColor = false;
            //
            // btnTimKiemCn
            //
            this.btnTimKiemCn.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTimKiemCn.FlatAppearance.BorderSize = 0;
            this.btnTimKiemCn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemCn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemCn.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemCn.Location = new System.Drawing.Point(286, 10);
            this.btnTimKiemCn.Name = "btnTimKiemCn";
            this.btnTimKiemCn.Size = new System.Drawing.Size(40, 40);
            this.btnTimKiemCn.TabIndex = 1;
            this.btnTimKiemCn.UseVisualStyleBackColor = false;
            //
            // txtTimKiemCn
            //
            this.txtTimKiemCn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemCn.Location = new System.Drawing.Point(3, 13);
            this.txtTimKiemCn.Name = "txtTimKiemCn";
            this.txtTimKiemCn.Size = new System.Drawing.Size(277, 34);
            this.txtTimKiemCn.TabIndex = 0;
            //
            // TaiKhoanMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabMain);
            this.Name = "TaiKhoanMain";
            this.Size = new System.Drawing.Size(1020, 630);
            this.tabMain.ResumeLayout(false);
            this.tabPageTaiKhoan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.panelTaiKhoanControls.ResumeLayout(false);
            this.panelTaiKhoanControls.PerformLayout();
            this.tabPagePhanQuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).EndInit();
            this.panelPhanQuyenControls.ResumeLayout(false);
            this.tabPageChucNang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucNang)).EndInit();
            this.panelChucNangControls.ResumeLayout(false);
            this.panelChucNangControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageTaiKhoan;
        private System.Windows.Forms.TabPage tabPagePhanQuyen;
        private System.Windows.Forms.TabPage tabPageChucNang;
        private System.Windows.Forms.Panel panelTaiKhoanControls;
        private System.Windows.Forms.Button btnSuaTk;
        private System.Windows.Forms.Button btnXoaTk;
        private System.Windows.Forms.Button btnThemTk;
        private System.Windows.Forms.Button btnTimKiemTk;
        private System.Windows.Forms.TextBox txtTimKiemTk;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTkSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTkNhanVien;
        private System.Windows.Forms.Panel panelPhanQuyenControls;
        private System.Windows.Forms.Button btnThemPq;
        private System.Windows.Forms.DataGridView dgvPhanQuyen;
        private System.Windows.Forms.Panel panelChucNangControls;
        private System.Windows.Forms.Button btnSuaCn;
        private System.Windows.Forms.Button btnXoaCn;
        private System.Windows.Forms.Button btnThemCn;
        private System.Windows.Forms.Button btnTimKiemCn;
        private System.Windows.Forms.TextBox txtTimKiemCn;
        private System.Windows.Forms.DataGridView dgvChucNang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCnMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCnTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCnMoTa;
        private System.Windows.Forms.DataGridView dgvChiTietQuyen;
        private System.Windows.Forms.Button btnLuuQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPqMaNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPqTenNhom;
    }
}