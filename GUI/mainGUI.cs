using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.GUI.TaiKhoanUserControl;
using Quan_Ly_Nhan_Su.GUI.NhanVienUserControl;
using Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class mainGUI : Form
    {
        homePage homePage = new homePage();
        departmentTab departmentTab = new departmentTab();
        LaborContractGUI laborContract = new LaborContractGUI();
        TuyenDungMain tuyenDungGUI = new TuyenDungMain();
        NhanVien nhanVienGUI = new NhanVien();
        StatisticsGUI statistics = new StatisticsGUI();
        TaiKhoanMain taiKhoanMain = new TaiKhoanMain();
        List<Panel> listpnlbSideBar = new List<Panel>();
        public mainGUI()
        {
            InitializeComponent();
            designForm();
            addUserControl(homePage);
            pnlbTrangChu.BackColor = ColorTranslator.FromHtml("#5DC2A7");
            addPanelToList();
            addEventToPanel();
        }
        private void designForm()
        {
            design.paintBorder(this.panel5, Color.Gray, 4, 30, 0, this.panel5.Width - 30, 0);
            design.paintBorder(this.panel2, Color.Gray, 4, 0, 0, 0, this.panel2.Height);
        }
        private void addUserControl(UserControl userControl)
        {
            if (userControl == null)
            {
                return;
            }
            userControl.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(userControl);
            userControl.BringToFront();
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
    }
}
