using Quan_Ly_Nhan_Su.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su
{
    public enum TabType
    {
        ThongKe,
        QuanLy
    }
    public partial class departmentTab : UserControl
    {
        private TabType currentTab = TabType.ThongKe;
        public departmentTab()
        {
            InitializeComponent();
            edit_btnThongKe();
            edit_btnQuanLy();
            btnThongKe.Paint += paint_border;
            btnQuanLy.Paint += paint_border;

            btnThongKe_Click(btnThongKe, EventArgs.Empty);
        }
        private void edit_btnThongKe()
        {
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.BorderColor = Color.White;    
            btnThongKe.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnThongKe.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnThongKe.BackColor = Color.Transparent;
            btnThongKe.Paint += new PaintEventHandler(paint_border);
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            currentTab = TabType.ThongKe;
            btnThongKe.Invalidate();
            btnQuanLy.Invalidate();
            mainContent.Controls.Clear();
            btnThongKe btnTK = new btnThongKe();
            btnTK.Dock = DockStyle.Fill;
            mainContent.Controls.Add(btnTK);
        }
        private void edit_btnQuanLy()
        {
            btnQuanLy.FlatStyle = FlatStyle.Flat;
            btnQuanLy.FlatAppearance.BorderSize = 0;
            btnQuanLy.FlatAppearance.BorderColor = Color.White;
            btnQuanLy.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnQuanLy.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnQuanLy.BackColor = Color.Transparent;
        }
        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            currentTab = TabType.QuanLy;
            btnThongKe.Invalidate();
            btnQuanLy.Invalidate();
            mainContent.Controls.Clear();
            btnQuanLy btnQL = new btnQuanLy();
            btnQL.Dock = DockStyle.Fill;
            mainContent.Controls.Add(btnQL);
        }
        private void paint_border(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            bool isActive = (btn == btnThongKe && currentTab == TabType.ThongKe)
                         || (btn == btnQuanLy && currentTab == TabType.QuanLy);

            if (isActive)
            {
                using (Pen pen = new Pen(ColorTranslator.FromHtml("#5DC2A7"), 2))
                {
                    int y = btn.Height - 1;
                    e.Graphics.DrawLine(pen, 0, y, btn.Width, y);
                }
            }
        }
    }
}
