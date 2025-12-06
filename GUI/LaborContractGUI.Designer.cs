using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    partial class LaborContractGUI
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageHopDong = new System.Windows.Forms.TabPage();
            this.tabPageKiHopDong = new System.Windows.Forms.TabPage();
            this.panelMain = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nhanvien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phongban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thuviectu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxThongTin = new System.Windows.Forms.GroupBox();
            this.labelLuong = new System.Windows.Forms.Label();
            this.labelcv = new System.Windows.Forms.Label();
            this.labelpb = new System.Windows.Forms.Label();
            this.labelcn = new System.Windows.Forms.Label();
            this.labelhv = new System.Windows.Forms.Label();
            this.labelcc = new System.Windows.Forms.Label();
            this.labelem = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labeldc = new System.Windows.Forms.Label();
            this.labelgt = new System.Windows.Forms.Label();
            this.labelns = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.labelMucLuong = new System.Windows.Forms.Label();
            this.labelChucVu = new System.Windows.Forms.Label();
            this.labelPhongBan = new System.Windows.Forms.Label();
            this.labelChuyenNganh = new System.Windows.Forms.Label();
            this.labelHocVan = new System.Windows.Forms.Label();
            this.labelCCCD = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelSDT = new System.Windows.Forms.Label();
            this.labelDiaChi = new System.Windows.Forms.Label();
            this.labelGioiTinh = new System.Windows.Forms.Label();
            this.labelNgaySinh = new System.Windows.Forms.Label();
            this.labelNhanVien = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.groupBoxBoSung = new System.Windows.Forms.GroupBox();
            this.buttonTaoHopDong = new System.Windows.Forms.Button();
            this.textBoxThoiHan = new System.Windows.Forms.TextBox();
            this.textBoxKetThuc = new System.Windows.Forms.TextBox();
            this.textBoxBatDau = new System.Windows.Forms.TextBox();
            this.labelThoiHan = new System.Windows.Forms.Label();
            this.labelKetThuc = new System.Windows.Forms.Label();
            this.labelBatDau = new System.Windows.Forms.Label();
            this.tabPageThongKe = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.contractGUI = new Quan_Ly_Nhan_Su.GUI.ContractGUI();
            this.statisticsGUI1 = new Quan_Ly_Nhan_Su.GUI.StatisticsGUI();
            this.tabControl.SuspendLayout();
            this.tabPageHopDong.SuspendLayout();
            this.tabPageKiHopDong.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxThongTin.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.groupBoxBoSung.SuspendLayout();
            this.tabPageThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageHopDong);
            this.tabControl.Controls.Add(this.tabPageKiHopDong);
            this.tabControl.Controls.Add(this.tabPageThongKe);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tabControl.ItemSize = new System.Drawing.Size(120, 25);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1957, 1405);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageHopDong
            // 
            this.tabPageHopDong.Controls.Add(this.contractGUI);
            this.tabPageHopDong.Location = new System.Drawing.Point(4, 29);
            this.tabPageHopDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageHopDong.Name = "tabPageHopDong";
            this.tabPageHopDong.Size = new System.Drawing.Size(1949, 1372);
            this.tabPageHopDong.TabIndex = 0;
            this.tabPageHopDong.Text = "HỢP ĐỒNG";
            this.tabPageHopDong.UseVisualStyleBackColor = true;
            // 
            // tabPageKiHopDong
            // 
            this.tabPageKiHopDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.tabPageKiHopDong.Controls.Add(this.panelMain);
            this.tabPageKiHopDong.Location = new System.Drawing.Point(4, 29);
            this.tabPageKiHopDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageKiHopDong.Name = "tabPageKiHopDong";
            this.tabPageKiHopDong.Size = new System.Drawing.Size(1949, 1372);
            this.tabPageKiHopDong.TabIndex = 1;
            this.tabPageKiHopDong.Text = "KÍ HỢP ĐỒNG";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.button1);
            this.panelMain.Controls.Add(this.textBoxSearch);
            this.panelMain.Controls.Add(this.buttonSearch);
            this.panelMain.Controls.Add(this.dateTimePickerFrom);
            this.panelMain.Controls.Add(this.dateTimePickerTo);
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.groupBoxThongTin);
            this.panelMain.Controls.Add(this.panelRight);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1949, 1372);
            this.panelMain.TabIndex = 1;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // button1
            // 
            this.button1.Image = global::Quan_Ly_Nhan_Su.Properties.Resources._211817_search_strong_icon1;
            this.button1.Location = new System.Drawing.Point(850, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 41);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxSearch.Location = new System.Drawing.Point(506, 31);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(337, 34);
            this.textBoxSearch.TabIndex = 12;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(703, 40);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(84, 29);
            this.buttonSearch.TabIndex = 1;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Checked = false;
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(27, 35);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(295, 42);
            this.dateTimePickerFrom.TabIndex = 10;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Checked = false;
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(251, 35);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(337, 42);
            this.dateTimePickerTo.TabIndex = 11;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Nhanvien,
            this.phongban,
            this.thuviectu});
            this.dataGridView1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView1.Location = new System.Drawing.Point(3, 84);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1081, 876);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // Nhanvien
            // 
            this.Nhanvien.HeaderText = "Nhân viên";
            this.Nhanvien.MinimumWidth = 6;
            this.Nhanvien.Name = "Nhanvien";
            this.Nhanvien.ReadOnly = true;
            // 
            // phongban
            // 
            this.phongban.HeaderText = "Phòng ban";
            this.phongban.MinimumWidth = 6;
            this.phongban.Name = "phongban";
            this.phongban.ReadOnly = true;
            // 
            // thuviectu
            // 
            this.thuviectu.HeaderText = "Thử việc từ ";
            this.thuviectu.MinimumWidth = 6;
            this.thuviectu.Name = "thuviectu";
            this.thuviectu.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh sách nhân viên thử việc";
            // 
            // groupBoxThongTin
            // 
            this.groupBoxThongTin.BackColor = System.Drawing.Color.White;
            this.groupBoxThongTin.Controls.Add(this.labelLuong);
            this.groupBoxThongTin.Controls.Add(this.labelcv);
            this.groupBoxThongTin.Controls.Add(this.labelpb);
            this.groupBoxThongTin.Controls.Add(this.labelcn);
            this.groupBoxThongTin.Controls.Add(this.labelhv);
            this.groupBoxThongTin.Controls.Add(this.labelcc);
            this.groupBoxThongTin.Controls.Add(this.labelem);
            this.groupBoxThongTin.Controls.Add(this.label7);
            this.groupBoxThongTin.Controls.Add(this.labeldc);
            this.groupBoxThongTin.Controls.Add(this.labelgt);
            this.groupBoxThongTin.Controls.Add(this.labelns);
            this.groupBoxThongTin.Controls.Add(this.labelId);
            this.groupBoxThongTin.Controls.Add(this.labelMucLuong);
            this.groupBoxThongTin.Controls.Add(this.labelChucVu);
            this.groupBoxThongTin.Controls.Add(this.labelPhongBan);
            this.groupBoxThongTin.Controls.Add(this.labelChuyenNganh);
            this.groupBoxThongTin.Controls.Add(this.labelHocVan);
            this.groupBoxThongTin.Controls.Add(this.labelCCCD);
            this.groupBoxThongTin.Controls.Add(this.labelEmail);
            this.groupBoxThongTin.Controls.Add(this.labelSDT);
            this.groupBoxThongTin.Controls.Add(this.labelDiaChi);
            this.groupBoxThongTin.Controls.Add(this.labelGioiTinh);
            this.groupBoxThongTin.Controls.Add(this.labelNgaySinh);
            this.groupBoxThongTin.Controls.Add(this.labelNhanVien);
            this.groupBoxThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxThongTin.Location = new System.Drawing.Point(1096, 2);
            this.groupBoxThongTin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxThongTin.Name = "groupBoxThongTin";
            this.groupBoxThongTin.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxThongTin.Size = new System.Drawing.Size(531, 578);
            this.groupBoxThongTin.TabIndex = 0;
            this.groupBoxThongTin.TabStop = false;
            this.groupBoxThongTin.Text = "HỢP ĐỒNG LAO ĐỘNG";
            // 
            // labelLuong
            // 
            this.labelLuong.BackColor = System.Drawing.Color.Transparent;
            this.labelLuong.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelLuong.Location = new System.Drawing.Point(133, 517);
            this.labelLuong.Name = "labelLuong";
            this.labelLuong.Size = new System.Drawing.Size(376, 34);
            this.labelLuong.TabIndex = 24;
            // 
            // labelcv
            // 
            this.labelcv.BackColor = System.Drawing.Color.Transparent;
            this.labelcv.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelcv.Location = new System.Drawing.Point(122, 465);
            this.labelcv.Name = "labelcv";
            this.labelcv.Size = new System.Drawing.Size(376, 34);
            this.labelcv.TabIndex = 23;
            // 
            // labelpb
            // 
            this.labelpb.BackColor = System.Drawing.Color.Transparent;
            this.labelpb.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelpb.Location = new System.Drawing.Point(133, 418);
            this.labelpb.Name = "labelpb";
            this.labelpb.Size = new System.Drawing.Size(392, 34);
            this.labelpb.TabIndex = 22;
            this.labelpb.Click += new System.EventHandler(this.labelpb_Click);
            // 
            // labelcn
            // 
            this.labelcn.BackColor = System.Drawing.Color.Transparent;
            this.labelcn.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelcn.Location = new System.Drawing.Point(169, 374);
            this.labelcn.Name = "labelcn";
            this.labelcn.Size = new System.Drawing.Size(356, 34);
            this.labelcn.TabIndex = 21;
            // 
            // labelhv
            // 
            this.labelhv.BackColor = System.Drawing.Color.Transparent;
            this.labelhv.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelhv.Location = new System.Drawing.Point(112, 318);
            this.labelhv.Name = "labelhv";
            this.labelhv.Size = new System.Drawing.Size(385, 34);
            this.labelhv.TabIndex = 20;
            this.labelhv.Click += new System.EventHandler(this.labelhv_Click);
            // 
            // labelcc
            // 
            this.labelcc.BackColor = System.Drawing.Color.Transparent;
            this.labelcc.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelcc.Location = new System.Drawing.Point(86, 272);
            this.labelcc.Name = "labelcc";
            this.labelcc.Size = new System.Drawing.Size(416, 34);
            this.labelcc.TabIndex = 19;
            // 
            // labelem
            // 
            this.labelem.BackColor = System.Drawing.Color.Transparent;
            this.labelem.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelem.Location = new System.Drawing.Point(86, 222);
            this.labelem.Name = "labelem";
            this.labelem.Size = new System.Drawing.Size(381, 34);
            this.labelem.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label7.Location = new System.Drawing.Point(155, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(369, 34);
            this.label7.TabIndex = 17;
            // 
            // labeldc
            // 
            this.labeldc.BackColor = System.Drawing.Color.Transparent;
            this.labeldc.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldc.Location = new System.Drawing.Point(98, 135);
            this.labeldc.Name = "labeldc";
            this.labeldc.Size = new System.Drawing.Size(376, 34);
            this.labeldc.TabIndex = 16;
            // 
            // labelgt
            // 
            this.labelgt.BackColor = System.Drawing.Color.Transparent;
            this.labelgt.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelgt.Location = new System.Drawing.Point(387, 92);
            this.labelgt.Name = "labelgt";
            this.labelgt.Size = new System.Drawing.Size(122, 34);
            this.labelgt.TabIndex = 14;
            this.labelgt.Click += new System.EventHandler(this.labelgt_Click);
            // 
            // labelns
            // 
            this.labelns.BackColor = System.Drawing.Color.Transparent;
            this.labelns.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelns.Location = new System.Drawing.Point(122, 92);
            this.labelns.Name = "labelns";
            this.labelns.Size = new System.Drawing.Size(156, 34);
            this.labelns.TabIndex = 13;
            // 
            // labelId
            // 
            this.labelId.BackColor = System.Drawing.Color.Transparent;
            this.labelId.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelId.Location = new System.Drawing.Point(133, 48);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(376, 32);
            this.labelId.TabIndex = 13;
            // 
            // labelMucLuong
            // 
            this.labelMucLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMucLuong.Location = new System.Drawing.Point(10, 516);
            this.labelMucLuong.Name = "labelMucLuong";
            this.labelMucLuong.Size = new System.Drawing.Size(150, 35);
            this.labelMucLuong.TabIndex = 11;
            this.labelMucLuong.Text = "Mức lương:";
            // 
            // labelChucVu
            // 
            this.labelChucVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelChucVu.Location = new System.Drawing.Point(16, 465);
            this.labelChucVu.Name = "labelChucVu";
            this.labelChucVu.Size = new System.Drawing.Size(111, 40);
            this.labelChucVu.TabIndex = 10;
            this.labelChucVu.Text = "Chức vụ:";
            // 
            // labelPhongBan
            // 
            this.labelPhongBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelPhongBan.Location = new System.Drawing.Point(10, 418);
            this.labelPhongBan.Name = "labelPhongBan";
            this.labelPhongBan.Size = new System.Drawing.Size(150, 25);
            this.labelPhongBan.TabIndex = 9;
            this.labelPhongBan.Text = "Phòng ban:";
            this.labelPhongBan.Click += new System.EventHandler(this.labelPhongBan_Click);
            // 
            // labelChuyenNganh
            // 
            this.labelChuyenNganh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelChuyenNganh.Location = new System.Drawing.Point(6, 374);
            this.labelChuyenNganh.Name = "labelChuyenNganh";
            this.labelChuyenNganh.Size = new System.Drawing.Size(173, 24);
            this.labelChuyenNganh.TabIndex = 8;
            this.labelChuyenNganh.Text = "Chuyên Ngành:";
            // 
            // labelHocVan
            // 
            this.labelHocVan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelHocVan.Location = new System.Drawing.Point(6, 318);
            this.labelHocVan.Name = "labelHocVan";
            this.labelHocVan.Size = new System.Drawing.Size(150, 25);
            this.labelHocVan.TabIndex = 7;
            this.labelHocVan.Text = "Học vấn :";
            // 
            // labelCCCD
            // 
            this.labelCCCD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelCCCD.Location = new System.Drawing.Point(6, 272);
            this.labelCCCD.Name = "labelCCCD";
            this.labelCCCD.Size = new System.Drawing.Size(91, 25);
            this.labelCCCD.TabIndex = 6;
            this.labelCCCD.Text = "CCCD:";
            // 
            // labelEmail
            // 
            this.labelEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelEmail.Location = new System.Drawing.Point(10, 222);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(79, 31);
            this.labelEmail.TabIndex = 5;
            this.labelEmail.Text = "Email:";
            this.labelEmail.Click += new System.EventHandler(this.labelEmail_Click);
            // 
            // labelSDT
            // 
            this.labelSDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelSDT.Location = new System.Drawing.Point(6, 182);
            this.labelSDT.Name = "labelSDT";
            this.labelSDT.Size = new System.Drawing.Size(172, 25);
            this.labelSDT.TabIndex = 4;
            this.labelSDT.Text = "Số điện thoại:";
            // 
            // labelDiaChi
            // 
            this.labelDiaChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelDiaChi.Location = new System.Drawing.Point(14, 140);
            this.labelDiaChi.Name = "labelDiaChi";
            this.labelDiaChi.Size = new System.Drawing.Size(128, 25);
            this.labelDiaChi.TabIndex = 3;
            this.labelDiaChi.Text = "Địa chỉ:";
            // 
            // labelGioiTinh
            // 
            this.labelGioiTinh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelGioiTinh.Location = new System.Drawing.Point(284, 92);
            this.labelGioiTinh.Name = "labelGioiTinh";
            this.labelGioiTinh.Size = new System.Drawing.Size(119, 25);
            this.labelGioiTinh.TabIndex = 2;
            this.labelGioiTinh.Text = "Giới Tính:";
            this.labelGioiTinh.Click += new System.EventHandler(this.labelGioiTinh_Click);
            // 
            // labelNgaySinh
            // 
            this.labelNgaySinh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelNgaySinh.Location = new System.Drawing.Point(10, 92);
            this.labelNgaySinh.Name = "labelNgaySinh";
            this.labelNgaySinh.Size = new System.Drawing.Size(150, 25);
            this.labelNgaySinh.TabIndex = 1;
            this.labelNgaySinh.Text = "Ngày sinh:";
            // 
            // labelNhanVien
            // 
            this.labelNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelNhanVien.Location = new System.Drawing.Point(10, 48);
            this.labelNhanVien.Name = "labelNhanVien";
            this.labelNhanVien.Size = new System.Drawing.Size(150, 25);
            this.labelNhanVien.TabIndex = 0;
            this.labelNhanVien.Text = "Nhân Viên:";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.groupBoxBoSung);
            this.panelRight.Location = new System.Drawing.Point(1100, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(526, 960);
            this.panelRight.TabIndex = 1;
            this.panelRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRight_Paint);
            // 
            // groupBoxBoSung
            // 
            this.groupBoxBoSung.BackColor = System.Drawing.Color.White;
            this.groupBoxBoSung.Controls.Add(this.buttonTaoHopDong);
            this.groupBoxBoSung.Controls.Add(this.textBoxThoiHan);
            this.groupBoxBoSung.Controls.Add(this.textBoxKetThuc);
            this.groupBoxBoSung.Controls.Add(this.textBoxBatDau);
            this.groupBoxBoSung.Controls.Add(this.labelThoiHan);
            this.groupBoxBoSung.Controls.Add(this.labelKetThuc);
            this.groupBoxBoSung.Controls.Add(this.labelBatDau);
            this.groupBoxBoSung.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBoSung.Location = new System.Drawing.Point(-4, 584);
            this.groupBoxBoSung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxBoSung.Name = "groupBoxBoSung";
            this.groupBoxBoSung.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxBoSung.Size = new System.Drawing.Size(524, 376);
            this.groupBoxBoSung.TabIndex = 1;
            this.groupBoxBoSung.TabStop = false;
            this.groupBoxBoSung.Text = "BỔ SUNG THÔNG TIN";
            // 
            // buttonTaoHopDong
            // 
            this.buttonTaoHopDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.buttonTaoHopDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTaoHopDong.ForeColor = System.Drawing.Color.White;
            this.buttonTaoHopDong.Location = new System.Drawing.Point(161, 298);
            this.buttonTaoHopDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTaoHopDong.Name = "buttonTaoHopDong";
            this.buttonTaoHopDong.Size = new System.Drawing.Size(231, 54);
            this.buttonTaoHopDong.TabIndex = 6;
            this.buttonTaoHopDong.Text = "Tạo hợp đồng";
            this.buttonTaoHopDong.UseVisualStyleBackColor = false;
            this.buttonTaoHopDong.Click += new System.EventHandler(this.buttonTaoHopDong_Click);
            // 
            // textBoxThoiHan
            // 
            this.textBoxThoiHan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxThoiHan.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.textBoxThoiHan.Location = new System.Drawing.Point(40, 218);
            this.textBoxThoiHan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxThoiHan.Name = "textBoxThoiHan";
            this.textBoxThoiHan.Size = new System.Drawing.Size(362, 40);
            this.textBoxThoiHan.TabIndex = 5;
            // 
            // textBoxKetThuc
            // 
            this.textBoxKetThuc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxKetThuc.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.textBoxKetThuc.Location = new System.Drawing.Point(270, 95);
            this.textBoxKetThuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxKetThuc.Name = "textBoxKetThuc";
            this.textBoxKetThuc.Size = new System.Drawing.Size(227, 40);
            this.textBoxKetThuc.TabIndex = 4;
            // 
            // textBoxBatDau
            // 
            this.textBoxBatDau.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.textBoxBatDau.Location = new System.Drawing.Point(4, 95);
            this.textBoxBatDau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBatDau.Name = "textBoxBatDau";
            this.textBoxBatDau.Size = new System.Drawing.Size(187, 40);
            this.textBoxBatDau.TabIndex = 3;
            // 
            // labelThoiHan
            // 
            this.labelThoiHan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThoiHan.Location = new System.Drawing.Point(43, 176);
            this.labelThoiHan.Name = "labelThoiHan";
            this.labelThoiHan.Size = new System.Drawing.Size(424, 39);
            this.labelThoiHan.TabIndex = 2;
            this.labelThoiHan.Text = "Thời hạn hợp đồng";
            // 
            // labelKetThuc
            // 
            this.labelKetThuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKetThuc.Location = new System.Drawing.Point(272, 59);
            this.labelKetThuc.Name = "labelKetThuc";
            this.labelKetThuc.Size = new System.Drawing.Size(256, 34);
            this.labelKetThuc.TabIndex = 1;
            this.labelKetThuc.Text = "Kết thúc hợp đồng";
            // 
            // labelBatDau
            // 
            this.labelBatDau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBatDau.Location = new System.Drawing.Point(-2, 59);
            this.labelBatDau.Name = "labelBatDau";
            this.labelBatDau.Size = new System.Drawing.Size(268, 34);
            this.labelBatDau.TabIndex = 0;
            this.labelBatDau.Text = "Bắt đầu hợp đồng";
            // 
            // tabPageThongKe
            // 
            this.tabPageThongKe.AutoScroll = true;
            this.tabPageThongKe.Controls.Add(this.statisticsGUI1);
            this.tabPageThongKe.Location = new System.Drawing.Point(4, 29);
            this.tabPageThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageThongKe.Name = "tabPageThongKe";
            this.tabPageThongKe.Size = new System.Drawing.Size(2339, 1646);
            this.tabPageThongKe.TabIndex = 2;
            this.tabPageThongKe.Text = "THỐNG KÊ";
            this.tabPageThongKe.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // contractGUI
            // 
            this.contractGUI.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.contractGUI.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.contractGUI.Location = new System.Drawing.Point(-7, 0);
            this.contractGUI.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.contractGUI.Name = "contractGUI";
            this.contractGUI.Size = new System.Drawing.Size(1622, 1125);
            this.contractGUI.TabIndex = 0;
            // 
            // statisticsGUI1
            // 
            this.statisticsGUI1.AutoScroll = true;
            this.statisticsGUI1.AutoSize = true;
            this.statisticsGUI1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statisticsGUI1.Cursor = System.Windows.Forms.Cursors.Default;
            this.statisticsGUI1.Location = new System.Drawing.Point(-4, 0);
            this.statisticsGUI1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.statisticsGUI1.Name = "statisticsGUI1";
            this.statisticsGUI1.Size = new System.Drawing.Size(1631, 1108);
            this.statisticsGUI1.TabIndex = 0;
            // 
            // LaborContractGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LaborContractGUI";
            this.Size = new System.Drawing.Size(1631, 1171);
            this.tabControl.ResumeLayout(false);
            this.tabPageHopDong.ResumeLayout(false);
            this.tabPageKiHopDong.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxThongTin.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.groupBoxBoSung.ResumeLayout(false);
            this.groupBoxBoSung.PerformLayout();
            this.tabPageThongKe.ResumeLayout(false);
            this.tabPageThongKe.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageHopDong;
        private System.Windows.Forms.TabPage tabPageKiHopDong;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox groupBoxThongTin;
        private System.Windows.Forms.Label labelNhanVien;
        private System.Windows.Forms.Label labelNgaySinh;
        private System.Windows.Forms.Label labelGioiTinh;
        private System.Windows.Forms.Label labelDiaChi;
        private System.Windows.Forms.Label labelSDT;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelCCCD;
        private System.Windows.Forms.Label labelHocVan;
        private System.Windows.Forms.Label labelChuyenNganh;
        private System.Windows.Forms.Label labelPhongBan;
        private System.Windows.Forms.Label labelChucVu;
        private System.Windows.Forms.Label labelMucLuong;
        private System.Windows.Forms.GroupBox groupBoxBoSung;
        private System.Windows.Forms.Label labelBatDau;
        private System.Windows.Forms.Label labelKetThuc;
        private System.Windows.Forms.Label labelThoiHan;
        private System.Windows.Forms.TextBox textBoxBatDau;
        private System.Windows.Forms.TextBox textBoxKetThuc;
        private System.Windows.Forms.TextBox textBoxThoiHan;
        private System.Windows.Forms.Button buttonTaoHopDong;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label labelLuong;
        private System.Windows.Forms.Label labelcv;
        private System.Windows.Forms.Label labelpb;
        private System.Windows.Forms.Label labelcn;
        private System.Windows.Forms.Label labelhv;
        private System.Windows.Forms.Label labelcc;
        private System.Windows.Forms.Label labelem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labeldc;
        private System.Windows.Forms.Label labelgt;
        private System.Windows.Forms.Label labelns;
        private System.Windows.Forms.Label labelId;
        private ContractGUI contractGUI;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nhanvien;
        private System.Windows.Forms.DataGridViewTextBoxColumn phongban;
        private System.Windows.Forms.DataGridViewTextBoxColumn thuviectu;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private TabPage tabPageThongKe;
        private StatisticsGUI statisticsGUI1;
        private Button button1;
    }
}