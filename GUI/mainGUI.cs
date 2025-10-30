using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.GUI.ChamCong;
using Quan_Ly_Nhan_Su.GUI.DanhGiaUserControl;
using Quan_Ly_Nhan_Su.GUI.LuongThuongUserControl;
using Quan_Ly_Nhan_Su.GUI.NhanVienUserControl;
using Quan_Ly_Nhan_Su.GUI.TaiKhoanUserControl;
using Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class mainGUI : Form
    {
        homePage homePage = new homePage();
        departmentTab departmentTab = new departmentTab();
        LaborContractGUI laborContract = new LaborContractGUI();
        TuyenDungMain tuyenDungGUI = new TuyenDungMain();
        NhanVien nhanVienGUI = new NhanVien();
        DanhGia danhGia = new DanhGia();
        TaiKhoanMain taiKhoanMain = new TaiKhoanMain();
        LuongThuong luongThuong = new LuongThuong();
        ucChamCong chamCongGUI = new ucChamCong();
        ucChiTietChamCong chiTietChamCongGUI = new ucChiTietChamCong();
        List<Panel> listpnlbSideBar = new List<Panel>();
        public mainGUI()
        {
            InitializeComponent();
            CheckLoginStatus();
            designForm();
            addUserControl(homePage);
            pnlbTrangChu.BackColor = ColorTranslator.FromHtml("#5DC2A7");
            addPanelToList();
            addEventToPanel();
            chamCongGUI.EmployeeSelected += ChamCongGUI_EmployeeSelected;
            chiTietChamCongGUI.BackButtonClicked += ChiTietChamCongGUI_BackButtonClicked;
            DisplayUserInfo();
            ConfigureMenuByPermission();
        }

        // ===== KIỂM TRA TRẠNG THÁI ĐĂNG NHẬP =====
        private void CheckLoginStatus()
        {
            if (!SessionManager.Instance.IsLoggedIn)
            {
                MessageBox.Show(
                    "Phiên làm việc đã hết hạn. Vui lòng đăng nhập lại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.Close();
            }
        }

        // ===== HIỂN THỊ THÔNG TIN NGƯỜI DÙNG =====
        private void DisplayUserInfo()
        {
            // Nếu bạn có các label để hiển thị thông tin user trên giao diện
            // Ví dụ: lblUsername, lblFullName, lblRole
            // Uncomment và sửa tên control theo form của bạn:

            // lblUsername.Text = SessionManager.Instance.Username;
            // lblFullName.Text = SessionManager.Instance.FullName;
            // lblRole.Text = SessionManager.Instance.PermissionGroupName;

            // Nếu có ảnh đại diện:
            // if (SessionManager.Instance.CurrentProfile?.HinhAnh != null)
            // {
            //     try
            //     {
            //         picAvatar.Image = Image.FromFile(
            //             SessionManager.Instance.CurrentProfile.HinhAnh
            //         );
            //     }
            //     catch { }
            // }

            // Hoặc hiển thị trên title bar
            this.Text = $"Quản Lý Nhân Sự - {SessionManager.Instance.FullName} ({SessionManager.Instance.PermissionGroupName})";
        }

        //===== CẤU HÌNH MENU THEO QUYỀN =====
        private void ConfigureMenuByPermission()
        {
            // Ví dụ cấu hình quyền truy cập các panel

            // Nếu không phải admin, ẩn một số chức năng
            if (!SessionManager.Instance.IsAdmin)
            {
                // Ví dụ: Chỉ admin mới thấy quản lý tài khoản
                // pnlbTaiKhoan.Visible = false;

                // Hoặc vô hiệu hóa
                // pnlbTaiKhoan.Enabled = false;
            }

            // Kiểm tra quyền theo mã nhóm quyền cụ thể
            // if (SessionManager.Instance.HasPermission(2)) // Mã quyền 2: Nhân sự
            // {
            //     pnlbNhanVien.Visible = true;
            //     pnlbTuyenDung.Visible = true;
            // }
            // else
            // {
            //     pnlbNhanVien.Visible = false;
            //     pnlbTuyenDung.Visible = false;
            // }

            // Hiện tại để mở hết, bạn có thể tùy chỉnh sau
        }

        // === CÁC HÀM XỬ LÝ CHO CHỨC NĂNG CHẤM CÔNG ===

        // 1. Khi một nhân viên được chọn (double-click) từ màn hình danh sách
        private void ChamCongGUI_EmployeeSelected(string maNhanVien)
        {
            addUserControl(chiTietChamCongGUI);
            chiTietChamCongGUI.LoadEmployeeData(maNhanVien); // Truyền mã nhân viên sang màn hình chi tiết
        }

        // 2. Khi nhấn nút "Back" từ màn hình chi tiết
        private void ChiTietChamCongGUI_BackButtonClicked(object sender, EventArgs e)
        {
            addUserControl(chamCongGUI); // Quay lại màn hình danh sách
        }

        private void addUserControl(UserControl userControl)
        {
            // Xóa control cũ trước khi thêm control mới
            this.panel6.Controls.Clear();

            userControl.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void designForm()
        {
            design.paintBorder(this.flowLayoutPanel1, Color.Gray, 4, 30, 0, this.flowLayoutPanel1.Width - 30, 0);
            design.paintBorder(this.panel2, Color.Gray, 4, 0, 0, 0, this.panel2.Height);
        }
        private void addPanelToList()
        {
            listpnlbSideBar.Add(pnlbTrangChu);
            listpnlbSideBar.Add(pnlbTuyenDung);
            listpnlbSideBar.Add(pnlbNhanVien);
            listpnlbSideBar.Add(pnlbPhongBan);
            listpnlbSideBar.Add(pnlbHopDong);
            listpnlbSideBar.Add(pnlbChamCong);
            listpnlbSideBar.Add(pnlbLuongThuong);
            listpnlbSideBar.Add(pnlbDanhGia);
            listpnlbSideBar.Add(pnlbTaiKhoan);
        }
        private void addEventToPanel()
        {
            foreach (Panel pnl in listpnlbSideBar)
            {
                //pnl.Visible = false; // Ẩn tất cả panel trước khi thêm sự kiện
                pnl.Click += new EventHandler(pnlb_Click);
                foreach (Control ctl in pnl.Controls)
                {
                    ctl.Click += new EventHandler(pnlb_Click);
                }
            }
        }
        private void pnlb_Click(object sender, EventArgs e)
        {
            Panel pnlb = sender as Panel;

            if (pnlb == null && sender is Control ctl)
            {
                // Nếu click vào control con thì lấy panel cha
                pnlb = ctl.Parent as Panel;
            }

            if (pnlb == null) return; // không phải panel thì bỏ qua

            // Reset lại màu của tất cả panel
            foreach (Panel pnl in listpnlbSideBar)
            {
                pnl.BackColor = System.Drawing.Color.Transparent;
            }

            // Đổi màu panel được click
            pnlb.BackColor = ColorTranslator.FromHtml("#5DC2A7");

            // Chuyển tab tương ứng
            switch (pnlb.Name)
            {
                case "pnlbTrangChu":
                    addUserControl(homePage);
                    break;
                case "pnlbPhongBan":
                    addUserControl(departmentTab);
                    break;
                case "pnlbHopDong":
                    addUserControl(laborContract);
                    break;
                case "pnlbTaiKhoan": 
                    addUserControl(taiKhoanMain);
                    break;
                case "pnlbTuyenDung":
                    addUserControl(tuyenDungGUI);
                    break;
                case "pnlbNhanVien":
                    addUserControl(nhanVienGUI);
                    break;
                case "pnlbLuongThuong":
                    addUserControl(luongThuong);
                    break;
                case "pnlbDanhGia":
                    addUserControl(danhGia);
                    break;
                case "pnlbChamCong": 
                    addUserControl(chamCongGUI);
                    break;
                default:
                    break;
            }
        }

        private void mainGUI_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnMainGui_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlbTrangChu_Click(object sender, EventArgs e)
        {

        }

        private void pnlbPhongBan_Click(object sender, EventArgs e)
        {

        }

        private void pnlbHopDong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
