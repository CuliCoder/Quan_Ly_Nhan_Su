using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class BillFormGUI : Form
    {
        private readonly SalaryFullBLL _salaryFullBLL = new SalaryFullBLL();
        private readonly EmployeeFullBLL _employeeBLL = new EmployeeFullBLL();
        private readonly AllowanceDeductionBLL _allowanceDeductionBLL = new AllowanceDeductionBLL();
        private readonly string _maNhanVien;
        private readonly int _thang;
        private readonly int _nam;

        // Dùng khi in
        private Bitmap _captureBmp;

        /// <summary>
        /// Truyền mã nhân viên, tháng và năm để xem phiếu lương
        /// </summary>
        public BillFormGUI(string maNhanVien, int thang, int nam)
        {
            InitializeComponent();
            _maNhanVien = maNhanVien;
            _thang = thang;
            _nam = nam;

            // Gắn sự kiện load và in
            this.Load += BillFormGUI_Load;
            this.btnPrint.Click += btnPrint_Click;
        }

        /// <summary>
        /// (Tuỳ chọn) Constructor không tham số, tiện test Designer.
        /// </summary>
        public BillFormGUI() : this(null, DateTime.Now.Month, DateTime.Now.Year)
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
                MessageBox.Show("Mã nhân viên rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalaryFullDTO salary = _salaryFullBLL.GetSalaryFull(_maNhanVien, _thang, _nam);
            var employee = _employeeBLL.GetEmployeeById(_maNhanVien);
            
            // LẤY PHỤ CẤP VÀ KHOẢN TRỪ CHI TIẾT
            var allowancesDeductions = _allowanceDeductionBLL.GetByEmployeeAndMonth(_maNhanVien, _thang, _nam);

            if (salary == null && employee == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu cho nhân viên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Thông tin nhân viên
            lblMaNV.Text = $"Mã NV: {Safe(employee?.MaNhanVien ?? _maNhanVien)}";
            lblHoTen.Text = $"Họ tên: {Safe(employee?.HoTen)}";
            lblPhongBan.Text = $"Phòng ban: {Safe(employee?.PhongBan)}";
            lblChucVu.Text = $"Chức vụ: {Safe(employee?.ChucVu)}";

            if (salary != null)
            {
                // TÍNH TOÁN CHI TIẾT PHỤ CẤP VÀ KHOẢN TRỪ
                decimal phuCapChucVu = allowancesDeductions
                    .Where(x => x.Loai == "PhuCap" && x.MoTa.Contains("chức vụ"))
                    .Sum(x => x.SoTien);

                decimal phuCapKhac = allowancesDeductions
                    .Where(x => x.Loai == "PhuCap" && !x.MoTa.Contains("chức vụ"))
                    .Sum(x => x.SoTien);

                decimal thue = allowancesDeductions
                    .Where(x => x.Loai == "KhoanTru" && x.MoTa.Contains("Thuế"))
                    .Sum(x => x.SoTien);

                decimal truDiTre = allowancesDeductions
                    .Where(x => x.Loai == "KhoanTru" && x.MoTa.Contains("trễ"))
                    .Sum(x => x.SoTien);

                decimal khoanTruKhac = allowancesDeductions
                    .Where(x => x.Loai == "KhoanTru" && !x.MoTa.Contains("Thuế") && !x.MoTa.Contains("trễ"))
                    .Sum(x => x.SoTien);

                // Thu nhập
                lblLuongCoBan.Text = $"Lương cơ bản: {FmtVND(salary.LuongCoBan)}";
                lblThuong.Text = $"Thưởng: {salary.TongThuong:N0} %";
                lblPhuCapCV.Text = $"Phụ cấp chức vụ: {FmtVND(phuCapChucVu)}";
                lblPhuCapKhac.Text = $"Phụ cấp khác: {FmtVND(phuCapKhac)}";

                // Khoản trừ
                lblTruBH.Text = $"Khấu trừ đi trễ: {FmtVND(truDiTre)}";
                lblTruKhac.Text = $"Khấu trừ khác: {FmtVND(khoanTruKhac)}";
                lblThue.Text = $"Thuế TNCN: {FmtVND(thue)}";

                // SỬ DỤNG LƯƠNG THỰC LÃNH TỪ DATABASE (KHÔNG TÍNH LẠI)
                lblThucLanh.Text = $"👉 Thực lãnh: {FmtVND(salary.LuongThucLanh)}";

                // Ngày lập
                lblNgayLap.Text = $"Ngày: {DateTime.Now:dd/MM/yyyy}";
            }
        }

        private static string Safe(string s) => string.IsNullOrWhiteSpace(s) ? "-" : s.Trim();

        private static string FmtVND(decimal value)
        {
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

        private void lblPhuCapCV_Click(object sender, EventArgs e)
        {

        }
    }
}
