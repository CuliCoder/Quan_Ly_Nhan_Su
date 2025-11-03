using Quan_Ly_Nhan_Su.BLL; // BLL
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

// !!! Nếu SessionManager của bạn ở namespace khác, sửa dòng dưới cho khớp:
//using Quan_Ly_Nhan_Su.Core;   // Chứa SessionManager

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class User_LabtracGUI : UserControl
    {
        // BLL
        private LaborContractBLL _contractBLL;

        public User_LabtracGUI()
        {
            InitializeComponent();
        }

        // Sự kiện Load của UserControl
        private void User_LabtracGUI_Load(object sender, EventArgs e)
        {
            // Ngăn code chạy khi đang ở chế độ Design
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            _contractBLL = new LaborContractBLL();

            // Tải dữ liệu
            LoadContractDetails();
            LoadExtensionHistory();
        }

        /// <summary>
        /// Tải thông tin chi tiết hợp đồng của nhân viên đang đăng nhập
        /// </summary>
        private void LoadContractDetails()
        {
            try
            {
                // 1) Lấy mã NV từ SessionManager (bắt buộc phải có sau khi login)
                string maNhanVien = SessionManager.Instance.CurrentEmployee?.MaNhanVien;

                if (string.IsNullOrWhiteSpace(maNhanVien))
                {
                    MessageBox.Show(
                        "Không xác định được mã nhân viên từ phiên đăng nhập. Vui lòng đăng nhập lại.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    ClearContractLabels();
                    return;
                }

                // 2) Lấy mã hợp đồng theo mã NV
                string maHopDong = _contractBLL.GetMaHopDongByMaNhanVien(maNhanVien);

                if (string.IsNullOrWhiteSpace(maHopDong))
                {
                    // NV chưa có hợp đồng -> vẫn hiển thị info cơ bản
                    LoadEmployeeDetailsOnly(maNhanVien);
                    ClearContractLabels(false); // xoá các label thuộc hợp đồng, giữ lại info NV
                    return;
                }

                // 3) Lấy chi tiết hợp đồng
                LaborContractDTO contract = _contractBLL.GetContractById(maHopDong);
                if (contract == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết hợp đồng.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearContractLabels();
                    return;
                }

                // 4) Binding dữ liệu lên UI
                var ci = new CultureInfo("vi-VN");

                LblMaNhanVien.Text = contract.MaNhanVien;
                LblHoTen.Text = contract.TenNhanVien;
                LblPhongBan.Text = contract.PhongBan;
                LblMaHopDong.Text = contract.MaHopDong;
                LblNgayBatDau.Text = contract.TuNgay?.ToString("dd/MM/yyyy") ?? "N/A";
                LblNgayHetHan.Text = contract.DenNgay?.ToString("dd/MM/yyyy") ?? "N/A";
                LblLoaiHopDong.Text = contract.LoaiHopDong;
                LblMucLuong.Text = contract.LuongCoBan.ToString("C0", ci);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin hợp đồng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearContractLabels();
            }
        }

        /// <summary>
        /// Tải thông tin cơ bản của nhân viên nếu họ chưa có hợp đồng
        /// </summary>
        private void LoadEmployeeDetailsOnly(string maNhanVien)
        {
            try
            {
                // Lấy thông tin NV (qua BLL)
                EmployeeFullDTO employee = _contractBLL.GetEmployeeDetailsById(maNhanVien);
                if (employee != null)
                {
                    LblMaNhanVien.Text = employee.MaNhanVien;
                    LblHoTen.Text = employee.HoTen;
                    LblPhongBan.Text = employee.PhongBan ?? "N/A";
                    LblMucLuong.Text = employee.MucLuong.ToString("C0", new CultureInfo("vi-VN"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin nhân viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải lịch sử gia hạn hợp đồng (hiển thị khung bên phải)
        /// </summary>
        private void LoadExtensionHistory()
        {
            try
            {
                string maNhanVien = SessionManager.Instance.CurrentEmployee?.MaNhanVien;
                if (string.IsNullOrWhiteSpace(maNhanVien))
                {
                    ClearHistoryLabels();
                    return;
                }

                List<ExtensionHistoryDTO> history = _contractBLL.GetExtensionHistory(maNhanVien);

                var latest = history?.FirstOrDefault();

                if (latest == null)
                {
                    ClearHistoryLabels();
                    return;
                }

                // Nếu tên NV bên trái chưa có, fallback hiển thị mã NV
                label12.Text = string.IsNullOrWhiteSpace(LblHoTen.Text) || LblHoTen.Text == "N/A"
                    ? maNhanVien
                    : LblHoTen.Text;

                label16.Text = latest.NgayQuyetDinh.ToString("dd/MM/yyyy");
                label24.Text = $"{latest.ThoiGianGiaHan:N1} năm";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử gia hạn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearHistoryLabels();
            }
        }

        /// <summary>
        /// Xoá văn bản trên các Label phần chi tiết hợp đồng
        /// </summary>
        private void ClearContractLabels(bool clearAll = true)
        {
            if (clearAll)
            {
                LblMaNhanVien.Text = "N/A";
                LblHoTen.Text = "N/A";
                LblPhongBan.Text = "N/A";
                LblMucLuong.Text = "N/A";
            }

            LblMaHopDong.Text = "N/A";
            LblNgayBatDau.Text = "N/A";
            LblNgayHetHan.Text = "N/A";
            LblLoaiHopDong.Text = "N/A";
        }

        /// <summary>
        /// Xoá văn bản trên các Label phần lịch sử gia hạn
        /// </summary>
        private void ClearHistoryLabels()
        {
            label12.Text = "N/A"; // Nhân viên
            label16.Text = "N/A"; // Ngày cập nhật
            label24.Text = "N/A"; // Gia hạn thêm
        }

        /// <summary>
        /// Cho phép form/cha gọi refresh sau khi đăng nhập
        /// </summary>
        public void RefreshData()
        {
            LoadContractDetails();
            LoadExtensionHistory();
        }

        // Sự kiện trống có thể dùng để trigger refresh thủ công nếu muốn
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label24_Click(object sender, EventArgs e) { }

        private void LblNgayHetHan_Click(object sender, EventArgs e)
        {

        }
    }
}
