using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.TaiKhoanUserControl
{
    public partial class TaiKhoanMain : UserControl
    {
        public TaiKhoanMain()
        {
            InitializeComponent();
            // Cấu hình để tùy chỉnh TabControl
            this.tabMain.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabMain.Appearance = TabAppearance.Buttons;
            this.tabMain.SizeMode = TabSizeMode.Fixed;
            this.tabMain.ItemSize = new Size(120, 35);

            // Gắn sự kiện DrawItem
            this.tabMain.DrawItem += new DrawItemEventHandler(tabMain_DrawItem);
        }

        private void tabMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush textBrush;
            TabPage tabPage = this.tabMain.TabPages[e.Index];
            Rectangle tabBounds = this.tabMain.GetTabRect(e.Index);

            // Màu nền cho tab được chọn và không được chọn
            if (e.State == DrawItemState.Selected)
            {
                // Màu nền cho tab đang được chọn
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, 240, 229)), e.Bounds);
                textBrush = new SolidBrush(Color.Black); // Màu chữ cho tab được chọn
            }
            else
            {
                // Màu nền cho các tab không được chọn
                g.FillRectangle(new SolidBrush(Color.FromArgb(236, 236, 236)), e.Bounds);
                textBrush = new SolidBrush(Color.Gray); // Màu chữ cho tab không được chọn
            }

            // Vẽ chữ cho tiêu đề tab
            Font tabFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            StringFormat stringFlags = new StringFormat();
            stringFlags.Alignment = StringAlignment.Center;
            stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(tabPage.Text, tabFont, textBrush, tabBounds, new StringFormat(stringFlags));

            // Dọn dẹp
            g.Dispose();
            textBrush.Dispose();
        }

        // Gợi ý: Bạn có thể thêm sự kiện Load cho UserControl để tải dữ liệu
        // private void TaiKhoanMain_Load(object sender, EventArgs e)
        // {
        //     LoadDataForTaiKhoan();
        //     LoadDataForPhanQuyen();
        //     LoadDataForChucNang();
        // }
    }
}