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
using Quan_Ly_Nhan_Su.GUI;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class mainGUI : Form
    {
        // Khai báo biến để lưu UserControl hợp đồng
        private LaborContractGUI laborContractGUI;
        public mainGUI()
        {
            InitializeComponent();
            designForm();
        }
        private void designForm()
        {
            design.paintBorder(this.panel5, Color.Gray, 4, 30, 0, this.panel5.Width - 30, 0);
            design.paintBorder(this.panel2, Color.Gray, 4, 0, 0, 0, this.panel2.Height);
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

        private void pnlbHopDong_click(object sender, EventArgs e)
        {
            // Xóa các controls hiện tại trong panel6 (nơi hiển thị nội dung chính)
            panel6.Controls.Clear();

            // Khởi tạo UserControl nếu chưa có
            if (laborContractGUI == null)
            {
                laborContractGUI = new LaborContractGUI();
            }

            // Thiết lập UserControl để lấp đầy panel6
            laborContractGUI.Dock = DockStyle.Fill;

            // Thêm UserControl vào panel6
            panel6.Controls.Add(laborContractGUI);
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

        private void laborContractGUI1_Load(object sender, EventArgs e)
        {

        }

        private void laborContractGUI1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
