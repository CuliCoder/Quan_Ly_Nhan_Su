using System;
using System.Windows.Forms;
using System.Drawing;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class DepartmentGUI : UserControl
    {
        public DepartmentGUI()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Main TabControl
            this.tabControl = new TabControl();
            this.tabPageThongKe = new TabPage();
            this.tabPageQuanLy = new TabPage();

            // --- TabControl ---
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
            this.tabControl.Controls.Add(this.tabPageThongKe);
            this.tabControl.Controls.Add(this.tabPageQuanLy);

            // --- TabPage Thống Kê ---
            this.tabPageThongKe.Text = "Thống Kê";
            this.tabPageThongKe.BackColor = Color.White;

            // --- TabPage Quản Lý ---
            this.tabPageQuanLy.Text = "Quản lý";
            this.tabPageQuanLy.BackColor = Color.White;

            // Panel quản lý phòng ban
            var panelQuanLy = new Panel { Dock = DockStyle.Top, Height = 250, BackColor = Color.WhiteSmoke, Padding = new Padding(5) };
            var labelQuanLy = new Label { Text = "Quản lý Phòng ban", Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Dock = DockStyle.Top, Height = 25 };
            var panelButton = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Top, Height = 40, Padding = new Padding(0, 5, 5, 0) };
            var btnThem = new Button { Text = "+ Thêm", Width = 90, Height = 30, BackColor = Color.White, ImageAlign = ContentAlignment.MiddleLeft };
            var btnSua = new Button { Text = "Sửa", Width = 90, Height = 30, BackColor = Color.White, ImageAlign = ContentAlignment.MiddleLeft };
            var btnXoa = new Button { Text = "Xóa", Width = 90, Height = 30, BackColor = Color.White, ImageAlign = ContentAlignment.MiddleLeft };
            panelButton.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa });

            // DataGridView phòng ban
            var dgvPhongBan = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 30,
                Font = new Font("Microsoft Sans Serif", 10F)
            };
            dgvPhongBan.Columns.Add("STT", "STT");
            dgvPhongBan.Columns.Add("PhongBan", "Phòng ban");
            dgvPhongBan.Columns.Add("NgayThanhLap", "Ngày thành Lập");
            dgvPhongBan.Columns.Add("TruongPhong", "Trưởng phòng");
            dgvPhongBan.Columns.Add("NgayNhanChuc", "Ngày nhận chức");
            dgvPhongBan.Columns.Add("NhanVien", "Nhân viên");
            dgvPhongBan.Columns.Add("LuongTrungBinh", "Lương Trung Bình");
            foreach (DataGridViewColumn col in dgvPhongBan.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            panelQuanLy.Controls.Add(dgvPhongBan);
            panelQuanLy.Controls.Add(panelButton);
            panelQuanLy.Controls.Add(labelQuanLy);

            // Panel nhân viên phòng kỹ thuật + thông tin nhân viên
            var panelBottom = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 10, 0, 0), BackColor = Color.White };
            var panelBottomMain = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            panelBottomMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
            panelBottomMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));

            // Nhân viên phòng kỹ thuật
            var panelNVKT = new Panel { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke, Padding = new Padding(5) };
            var labelNVKT = new Label { Text = "Nhân viên phòng kĩ thuật", Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Dock = DockStyle.Top, Height = 25 };
            var dgvNVKT = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 30,
                Font = new Font("Microsoft Sans Serif", 10F)
            };
            dgvNVKT.Columns.Add("STT", "STT");
            dgvNVKT.Columns.Add("NhanVien", "Nhân Viên");
            dgvNVKT.Columns.Add("LoaiHinh", "Loại Hình");
            dgvNVKT.Columns.Add("ChucVu", "Chức Vụ");
            foreach (DataGridViewColumn col in dgvNVKT.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            panelNVKT.Controls.Add(dgvNVKT);
            panelNVKT.Controls.Add(labelNVKT);

            // Thông tin nhân viên
            var panelTTNV = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(10) };
            var labelTTNV = new Label { Text = "Thông tin nhân viên", Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Dock = DockStyle.Top, Height = 25 };
            var tableTTNV = new TableLayoutPanel { Dock = DockStyle.Top, RowCount = 9, ColumnCount = 2, Height = 220 };
            tableTTNV.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            tableTTNV.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            string[] labels = { "Mã Số:", "Họ tên:", "Giới tính:", "Ngày sinh :", "Điện thoại :", "Địa chỉ:", "Phòng ban:", "Chức vụ:", "Ngày nhận chức:" };
            for (int i = 0; i < labels.Length; i++)
            {
                tableTTNV.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
                tableTTNV.Controls.Add(new Label { Text = labels[i], Anchor = AnchorStyles.Left, AutoSize = true }, 0, i);
                tableTTNV.Controls.Add(new Label { Text = "", Name = "lblValue" + i, Anchor = AnchorStyles.Left, AutoSize = true }, 1, i);
            }
            var btnSuaTT = new Button { Text = "Sửa", Width = 90, Height = 30, BackColor = Color.White, ImageAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Bottom, Margin = new Padding(0, 10, 0, 0) };
            panelTTNV.Controls.Add(btnSuaTT);
            panelTTNV.Controls.Add(tableTTNV);
            panelTTNV.Controls.Add(labelTTNV);

            // Add to bottom main panel
            panelBottomMain.Controls.Add(panelNVKT, 0, 0);
            panelBottomMain.Controls.Add(panelTTNV, 1, 0);
            panelBottom.Controls.Add(panelBottomMain);

            // Add to tabPageQuanLy
            this.tabPageQuanLy.Controls.Add(panelBottom);
            this.tabPageQuanLy.Controls.Add(panelQuanLy);

            // Add TabControl to UserControl
            this.Controls.Add(this.tabControl);

            // Set UserControl size
            this.Size = new Size(1100, 700);
        }

        private TabControl tabControl;
        private TabPage tabPageThongKe;
        private TabPage tabPageQuanLy;
    }
}