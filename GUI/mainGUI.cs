using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.GUI.ChamCong;
using Quan_Ly_Nhan_Su.GUI.DanhGiaUserControl;
using Quan_Ly_Nhan_Su.GUI.LuongThuongUserControl;
using Quan_Ly_Nhan_Su.GUI.NhanVienUserControl;
using Quan_Ly_Nhan_Su.GUI.TaiKhoanUserControl;
using Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl;
using Quan_Ly_Nhan_Su.GUI.ChamCongUserControl;
using Quan_Ly_Nhan_Su.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
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
        ucKiemTraCongCa chiTietChamCongGUI = new ucKiemTraCongCa();
        User_LabtracGUI user_LabtracGUI = new User_LabtracGUI();
        ProfileStaffGUI profileStaffGUI = new ProfileStaffGUI();
        AttendanceGUI attendanceGUI = new AttendanceGUI();
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
            attendanceGUI.getDanhSachNhanVienGUI().EmployeeSelected += ChamCongGUI_EmployeeSelected;
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
            label1.Text = SessionManager.Instance.FullName;
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

        // === CÁC HÀM XỬ LÝ CHO CHỨC NĂNG CHẤM CÔNG ===

        // 1. Khi một nhân viên được chọn (double-click) từ màn hình danh sách
        private void ChamCongGUI_EmployeeSelected(string maNhanVien)
        {
            Console.WriteLine($"Đã chọn nhân viên với mã: {maNhanVien}");
            chiTietChamCongGUI.checkCongCaByIDNV(maNhanVien);
            addUserControl(chiTietChamCongGUI);
        }

        // 2. Khi nhấn nút "Back" từ màn hình chi tiết
        private void ChiTietChamCongGUI_BackButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Quay lại danh sách nhân viên chấm công");
            attendanceGUI.backDanhSachNhanVien();
            addUserControl(attendanceGUI); // Quay lại màn hình danh sách
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
            listpnlbSideBar.Add(pnlbHopdongcanhan);
            listpnlbSideBar.Add(pnlbQLTTCN);
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
                    addUserControl(attendanceGUI);
                    break;
                case "pnlbHopdongcanhan":
                    addUserControl(user_LabtracGUI);
                    break;
                case "pnlbQLTTCN":
                    addUserControl(profileStaffGUI);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Cấu hình menu theo quyền - Phiên bản cải tiến
        /// </summary>
        private void ConfigureMenuByPermission()
        {
            var session = SessionManager.Instance;

            // Nếu là Admin thì hiển thị tất cả
            if (session.IsAdmin || session.Username.Equals("dev"))
            {
                ShowAllMenus();
                return;
            }

            // Cấu hình từng menu theo quyền
            ConfigureMenuItem(pnlbTrangChu, FunctionNames.THONG_KE);
            ConfigureMenuItem(pnlbNhanVien, FunctionNames.NHAN_VIEN);
            ConfigureMenuItem(pnlbTuyenDung, FunctionNames.TUYEN_DUNG);
            ConfigureMenuItem(pnlbPhongBan, FunctionNames.PHONG_BAN);
            ConfigureMenuItem(pnlbHopDong, FunctionNames.HOP_DONG);
            ConfigureMenuItem(pnlbChamCong, FunctionNames.CHAM_CONG);
            ConfigureMenuItem(pnlbLuongThuong, FunctionNames.LUONG);
            ConfigureMenuItem(pnlbDanhGia, FunctionNames.DANH_GIA);
            ConfigureMenuItem(pnlbTaiKhoan, FunctionNames.TAI_KHOAN);

            // Menu cá nhân luôn hiển thị
            pnlbHopdongcanhan.Visible = true;
            pnlbQLTTCN.Visible = true;
        }

        /// <summary>
        /// Cấu hình một menu item theo quyền
        /// </summary>
        private void ConfigureMenuItem(Panel panel, string functionName)
        {
            var session = SessionManager.Instance;

            // Kiểm tra có quyền truy cập không
            bool hasPermission = session.HasAnyPermission(functionName);

            panel.Visible = hasPermission;
            panel.Enabled = hasPermission;

            // Đổi màu nếu không có quyền (tùy chọn)
            if (!hasPermission)
            {
                panel.BackColor = Color.LightGray;
            }
        }

        /// <summary>
        /// Hiển thị tất cả menu (dành cho Admin)
        /// </summary>
        private void ShowAllMenus()
        {
            foreach (var panel in listpnlbSideBar)
            {
                panel.Visible = true;
                panel.Enabled = true;
            }
        }

        /// <summary>
        /// Kiểm tra quyền trước khi thực hiện hành động
        /// </summary>
        private bool CheckPermissionBeforeAction(string functionName, string action)
        {
            var session = SessionManager.Instance;
            bool hasPermission = false;

            switch (action.ToLower())
            {
                case "read":
                case "view":
                    hasPermission = session.CanRead(functionName);
                    break;
                case "create":
                case "add":
                    hasPermission = session.CanCreate(functionName);
                    break;
                case "update":
                case "edit":
                    hasPermission = session.CanUpdate(functionName);
                    break;
                case "delete":
                case "remove":
                    hasPermission = session.CanDelete(functionName);
                    break;
            }

            if (!hasPermission)
            {
                MessageBox.Show(
                    $"Bạn không có quyền {action} trên chức năng {functionName}!",
                    "Không đủ quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

            return hasPermission;
        }

        /// <summary>
        /// Ví dụ sử dụng kiểm tra quyền
        /// </summary>
        private void ExampleUsage()
        {
            // Kiểm tra trước khi thêm nhân viên
            if (CheckPermissionBeforeAction(FunctionNames.NHAN_VIEN, "create"))
            {
                // Code thêm nhân viên
            }

            // Kiểm tra trước khi xóa hợp đồng
            if (CheckPermissionBeforeAction(FunctionNames.HOP_DONG, "delete"))
            {
                // Code xóa hợp đồng
            }

            // Kiểm tra có quyền xem thống kê không
            if (SessionManager.Instance.CanRead(FunctionNames.THONG_KE))
            {
                // Hiển thị thống kê
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
