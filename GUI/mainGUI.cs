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

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class mainGUI : Form
    {
        public mainGUI()
        {
            InitializeComponent();
            designForm();
            pnlbTrangChu_Click(pnlbTrangChu, EventArgs.Empty);
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
            bodyContent.Controls.Clear();
            homePage home = new homePage();
            home.Dock = DockStyle.Fill;
            bodyContent.Controls.Add(home);
            pnlbTrangChu.BackColor = System.Drawing.ColorTranslator.FromHtml("#5DC2A7");
        }

        private void pnlbPhongBan_Click(object sender, EventArgs e)
        {
            bodyContent.Controls.Clear();
            departmentTab department = new departmentTab();
            department.Dock = DockStyle.Fill;
            bodyContent.Controls.Add(department);
            pnlbPhongBan.BackColor = System.Drawing.ColorTranslator.FromHtml("#5DC2A7");
        }
    }
}
