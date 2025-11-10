using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class BillFormGUI : Form
    {
        private readonly SalaryBLL _salaryBLL = new SalaryBLL();
        private readonly string _maNhanVien;

        // Dùng khi in
        private Bitmap _captureBmp;

        /// <summary>
        /// Truyền mã nhân viên đang xem phiếu lương (ví dụ: "NV001")
        /// </summary>
        public BillFormGUI(string maNhanVien)
        {
            InitializeComponent();
            _maNhanVien = maNhanVien; // không thao tác layout ở đây để Designer mở an toàn
            this.Load += BillFormGUI_Load; // bảo đảm đã gắn sự kiện Load
        }

        /// <summary>
        /// (Tuỳ chọn) Constructor không tham số, tiện test Designer.
        /// </summary>
        public BillFormGUI() : this(null)
        {
        }

        private void BillFormGUI_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải phiếu lương.\nChi tiết: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region ===== Nạp dữ liệu lên giao diện =====

        private void LoadBill()
        {
            if (string.IsNullOrWhiteSpace(_maNhanVien))
            {
                MessageBox.Show("Chưa có mã nhân viên. Vui lòng truyền mã nhân viên khi mở form.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalaryDTO data = _salaryBLL.GetSalaryByEmployee(_maNhanVien);
            if (data == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu lương cho nhân viên này!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Thông tin nhân viên
            lblMaNV.Text = $"Mã NV: {Safe(data.MaNhanVien)}";
            lblHoTen.Text = $"Họ tên: {Safe(data.HoTen)}";
            lblPhongBan.Text = $"Phòng ban: {Safe(data.TenPhong)}";
            lblChucVu.Text = $"Chức vụ: {Safe(data.TenChucVu)}";

            // Thu nhập
            lblLuongCoBan.Text = $"Lương cơ bản: {FmtVND(data.LuongCoBan)}";
            lblThuong.Text = $"Thưởng: {FmtVND(data.LuongThuong)}";
            lblPhuCapCV.Text = $"Phụ cấp chức vụ: {FmtVND(data.PhuCapChucVu)}";
            lblPhuCapKhac.Text = $"Phụ cấp khác: {FmtVND(data.PhuCapKhac)}";

            // Khấu trừ
            lblTruBH.Text = $"Khấu trừ BH: {FmtVND(data.KhoanTruBaoHiem)}";
            lblTruKhac.Text = $"Khấu trừ khác: {FmtVND(data.KhoanTruKhac)}";
            lblThue.Text = $"Thuế TNCN: {FmtVND(data.Thue)}";

            // Thực lãnh
            var thucLanh = data.ThucLanh ?? (data.LuongCoBan + data.LuongThuong + data.PhuCapChucVu + data.PhuCapKhac
                                             - data.KhoanTruBaoHiem - data.KhoanTruKhac - data.Thue);
            lblThucLanh.Text = $"👉 Thực lãnh: {FmtVND(thucLanh)}";

            // Ngày lập
            lblNgayLap.Text = $"Ngày: {(data.NgayLap ?? DateTime.Now):dd/MM/yyyy}";
        }

        private static string Safe(string s) => string.IsNullOrWhiteSpace(s) ? "-" : s.Trim();

        private static string FmtVND(decimal value)
        {
            // Định dạng VN: phân tách hàng nghìn, không ký hiệu tiền để ghép "VNĐ" tùy ý
            // Dùng vi-VN để có dấu chấm/phẩy quen thuộc
            var vi = new CultureInfo("vi-VN");
            return string.Format(vi, "{0:N0} VNĐ", value);
        }

        #endregion

        #region ===== In PDF (Microsoft Print to PDF) =====

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var safeMaNV = string.IsNullOrWhiteSpace(_maNhanVien) ? "NV" : _maNhanVien.Trim();
                string suggestedName = $"PhieuLuong_{safeMaNV}_{DateTime.Now:yyyyMMdd}.pdf";

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF file (*.pdf)|*.pdf";
                    sfd.FileName = suggestedName;
                    sfd.Title = "Chọn nơi lưu phiếu lương (PDF)";
                    if (sfd.ShowDialog(this) == DialogResult.OK)
                    {
                        PrintPanelToPdf(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi tạo in PDF.\nChi tiết: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintPanelToPdf(string filePath)
        {
            // Chụp toàn bộ vùng phiếu (header + nội dung)
            _captureBmp = CaptureControl(this.pnlRoot);

            using (var pd = new PrintDocument())
            {
                string pdfPrinter = "Microsoft Print to PDF";
                bool hasPdfPrinter = false;

                foreach (string p in PrinterSettings.InstalledPrinters)
                {
                    if (string.Equals(p, pdfPrinter, StringComparison.OrdinalIgnoreCase))
                    {
                        hasPdfPrinter = true;
                        break;
                    }
                }

                if (hasPdfPrinter)
                {
                    pd.PrinterSettings.PrinterName = pdfPrinter;
                    pd.PrinterSettings.PrintToFile = true;
                    pd.PrinterSettings.PrintFileName = filePath;
                }

                // Thiết lập A4 dọc + lề 1 inch
                pd.DefaultPageSettings.Landscape = false;
                pd.DefaultPageSettings.Margins = new Margins(100, 100, 100, 100);

                pd.PrintPage += (s, e) =>
                {
                    if (_captureBmp == null)
                    {
                        e.HasMorePages = false;
                        return;
                    }

                    Rectangle marginBounds = e.MarginBounds;

                    // Scale giữ tỉ lệ
                    float ratio = Math.Min(
                        (float)marginBounds.Width / _captureBmp.Width,
                        (float)marginBounds.Height / _captureBmp.Height
                    );

                    int drawW = (int)(_captureBmp.Width * ratio);
                    int drawH = (int)(_captureBmp.Height * ratio);
                    int x = marginBounds.X + (marginBounds.Width - drawW) / 2;
                    int y = marginBounds.Y + (marginBounds.Height - drawH) / 2;

                    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    e.Graphics.DrawImage(_captureBmp, new Rectangle(x, y, drawW, drawH));
                    e.HasMorePages = false;
                };

                try
                {
                    if (hasPdfPrinter)
                    {
                        pd.Print();
                        MessageBox.Show("Đã xuất phiếu lương ra PDF:\n" + filePath,
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        try
                        {
                            System.Diagnostics.Process.Start("explorer.exe", "/select,\"" + filePath + "\"");
                        }
                        catch { /* ignore */ }
                    }
                    else
                    {
                        // Nếu máy không có driver "Microsoft Print to PDF", cho phép người dùng chọn thủ công
                        using (var dlg = new PrintDialog())
                        {
                            dlg.AllowSomePages = false;
                            dlg.Document = pd;
                            if (dlg.ShowDialog(this) == DialogResult.OK)
                            {
                                pd.Print();
                                MessageBox.Show(
                                    "Đã gửi lệnh in. Nếu chọn 'Microsoft Print to PDF' Windows sẽ hỏi nơi lưu file.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể in ra PDF.\nChi tiết: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _captureBmp?.Dispose();
                    _captureBmp = null;
                }
            }
        }

        private Bitmap CaptureControl(Control c)
        {
            // Đảm bảo layout mới nhất
            c.Refresh();

            // Chụp toàn bộ control (DPI cao để in nét)
            var bmp = new Bitmap(c.Width, c.Height);
            bmp.SetResolution(300, 300);
            c.DrawToBitmap(bmp, new Rectangle(Point.Empty, c.Size));
            return bmp;
        }

        #endregion

        private void lblTitle_Click(object sender, EventArgs e)
        {
            // Tuỳ chọn: mở dialog thông tin, hoặc không làm gì
        }
    }
}
