using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class btnQuanLy : UserControl
    {
        public btnQuanLy()
        {
            InitializeComponent();
            load_tbPB();
            load_tbNV();
        }
        private void load_tbPB()
        {
            tbPB.BackgroundColor = Color.White;
            tbPB.Rows.Clear();
            tbPB.Columns.Clear();
            tbPB.Font = new Font("Montserrat", 12, FontStyle.Regular);

            // Thêm các cột vào DataGridView
            tbPB.Columns.Add("STT", "STT");
            tbPB.Columns.Add("PhongBan", "Phòng ban");
            tbPB.Columns.Add("NgayThanhLap", "Ngày thành lập");
            tbPB.Columns.Add("QuanLy", "Quản lý");
            tbPB.Columns.Add("NgayNhanChuc", "Ngày nhận chức");
            tbPB.Columns.Add("NhanVien", "Nhân viên");
            tbPB.Columns.Add("LuongTrungBinh", "Lương trung bình");


            tbPB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tbPB.ColumnHeadersHeight = 40;
            // set chiều cao của các row
            tbPB.RowTemplate.Height = 36;


            // xóa tất cả các border mặc định
            tbPB.BorderStyle = BorderStyle.None;
            tbPB.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tbPB.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tbPB.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Định dạng cột để set %
            tbPB.Columns["STT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbPB.Columns["PhongBan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbPB.Columns["NgayThanhLap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbPB.Columns["QuanLy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbPB.Columns["NgayNhanChuc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbPB.Columns["NhanVien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbPB.Columns["LuongTrungBinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // set % cột
            tbPB.Columns["STT"].FillWeight = 8;               // 8%
            tbPB.Columns["PhongBan"].FillWeight = 18;         // 18%
            tbPB.Columns["NgayThanhLap"].FillWeight = 15;     // 15%
            tbPB.Columns["QuanLy"].FillWeight = 18;           // 18%
            tbPB.Columns["NgayNhanChuc"].FillWeight = 15;     // 15%
            tbPB.Columns["NhanVien"].FillWeight = 10;         // 10%
            tbPB.Columns["LuongTrungBinh"].FillWeight = 16;   // 16%


            tbPB.Rows.Add("1", "Phòng A", "01/01/2020", "Nguyễn Văn A", "01/02/2021", "10", "15,000,000");
            tbPB.Rows.Add("2", "Phòng B", "15/03/2019", "Trần Thị B", "10/04/2020", "8", "13,500,000");
            tbPB.Rows.Add("3", "Phòng C", "20/06/2018", "Lê Văn C", "05/07/2019", "12", "16,200,000");
            tbPB.Rows.Add("1", "Phòng A", "01/01/2020", "Nguyễn Văn A", "01/02/2021", "10", "15,000,000");
            tbPB.Rows.Add("2", "Phòng B", "15/03/2019", "Trần Thị B", "10/04/2020", "8", "13,500,000");
            tbPB.Rows.Add("3", "Phòng C", "20/06/2018", "Lê Văn C", "05/07/2019", "12", "16,200,000");
            tbPB.Rows.Add("1", "Phòng A", "01/01/2020", "Nguyễn Văn A", "01/02/2021", "10", "15,000,000");
            tbPB.Rows.Add("2", "Phòng B", "15/03/2019", "Trần Thị B", "10/04/2020", "8", "13,500,000");
            tbPB.Rows.Add("3", "Phòng C", "20/06/2018", "Lê Văn C", "05/07/2019", "12", "16,200,000");
            tbPB.Rows.Add("1", "Phòng A", "01/01/2020", "Nguyễn Văn A", "01/02/2021", "10", "15,000,000");
            tbPB.Rows.Add("2", "Phòng B", "15/03/2019", "Trần Thị B", "10/04/2020", "8", "13,500,000");
            tbPB.Rows.Add("3", "Phòng C", "20/06/2018", "Lê Văn C", "05/07/2019", "12", "16,200,000");

            // Vẽ border dưới cho từng hàng
            tbPB.CellPainting += Table_CellPainting;

            // chọn cả 1 hàng và chỉ 1 hàng được chọn
            tbPB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tbPB.MultiSelect = false;

            // xóa cột xám đứng trước stt
            tbPB.RowHeadersVisible = false;

        }
        private void Table_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.PaintContent(e.ClipBounds);

                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    // Vẽ border dưới
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top - 1, e.CellBounds.Right, e.CellBounds.Top - 1);
                }
                e.Handled = true;
            }
            else if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                // Vẽ lại header với màu nền mặc định
                e.Graphics.FillRectangle(new SolidBrush(tbPB.ColumnHeadersDefaultCellStyle.BackColor), e.CellBounds);
                TextRenderer.DrawText(e.Graphics, e.FormattedValue?.ToString() ?? "",
                    tbPB.ColumnHeadersDefaultCellStyle.Font,
                    e.CellBounds,
                    tbPB.ColumnHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                e.Handled = true;
            }
        }
        private void load_tbNV()
        {
            tbNV.BackgroundColor = Color.White;
            tbNV.Rows.Clear();
            tbNV.Columns.Clear();
            tbNV.Font = new Font("Montserrat", 12, FontStyle.Regular);
            // Thêm các cột vào DataGridView
            tbNV.Columns.Add("STT", "STT");
            tbNV.Columns.Add("MaNV", "Mã NV");
            tbNV.Columns.Add("HoTen", "Họ tên");
            tbNV.Columns.Add("ChucVu", "Chức vụ");
            tbNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tbNV.ColumnHeadersHeight = 40;
            // set chiều cao của các row
            tbNV.RowTemplate.Height = 36;
            // xóa tất cả các border mặc định
            tbNV.BorderStyle = BorderStyle.None;
            tbNV.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tbNV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tbNV.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            // Định dạng cột để set %
            tbNV.Columns["STT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbNV.Columns["MaNV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbNV.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbNV.Columns["ChucVu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // set % cột
            tbNV.Columns["STT"].FillWeight = 10;       // 10%
            tbNV.Columns["MaNV"].FillWeight = 20;     // 20%
            tbNV.Columns["HoTen"].FillWeight = 40;    // 40%
            tbNV.Columns["ChucVu"].FillWeight = 30;   // 30%
            tbNV.Rows.Add("1", "NV001", "Nguyễn Văn A", "Nhân viên");
            tbNV.Rows.Add("2", "NV002", "Trần Thị B", "Trưởng phòng");
            tbNV.Rows.Add("3", "NV003", "Lê Văn C", "Giám đốc");
            // Vẽ border dưới cho từng hàng
            // chọn cả 1 hàng và chỉ 1 hàng được chọn
            tbNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tbNV.MultiSelect = false;
            // xóa cột xám đứng trước stt
            tbNV.RowHeadersVisible = false;
        }
    }
}
