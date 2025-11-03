using Quan_Ly_Nhan_Su.BLL; // Sử dụng BLL
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    /// <summary>
    /// LỚP MÔ PHỎNG ĐĂNG NHẬP (Tạm thời)
    /// Thay thế bằng logic lấy mã nhân viên đã đăng nhập của bạn
    /// </summary>
    public static class AuthService
    {
        // TODO: Thay bằng mã NV lấy từ phiên đăng nhập
        public static string MaNhanVien = "NV001"; // Ví dụ mã nhân viên
    }

    public partial class User_LabtracGUI : UserControl
    {
        // Khai báo BLL
        private LaborContractBLL _contractBLL;

        public User_LabtracGUI()
        {
            InitializeComponent();
        }

        // Thêm sự kiện Load cho UserControl
        private void User_LabtracGUI_Load(object sender, EventArgs e)
        {
            // Ngăn code chạy khi đang ở chế độ Design
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            // Khởi tạo BLL
            _contractBLL = new LaborContractBLL();

            // Tải thông tin
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
                // 1. Lấy mã nhân viên đang đăng nhập
                string maNhanVien = AuthService.MaNhanVien;
                if (string.IsNullOrWhiteSpace(maNhanVien))
                {
                    MessageBox.Show("Không thể xác định người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearContractLabels();
                    return;
                }

                // 2. Lấy MaHopDong từ MaNhanVien (qua BLL)
                string maHopDong = _contractBLL.GetMaHopDongByMaNhanVien(maNhanVien);
                if (string.IsNullOrWhiteSpace(maHopDong))
                {
                    MessageBox.Show("Nhân viên này chưa có hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Vẫn tải thông tin cá nhân dù chưa có HĐ
                    LoadEmployeeDetailsOnly(maNhanVien);
                    ClearContractLabels(false); // Chỉ xóa label hợp đồng
                    return;
                }

                // 3. Lấy chi tiết hợp đồng (qua BLL)
                LaborContractDTO contract = _contractBLL.GetContractById(maHopDong);
                if (contract == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết hợp đồng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearContractLabels();
                    return;
                }

                // 4. Gán dữ liệu lên các Labels
                CultureInfo ci = new CultureInfo("vi-VN"); // Để định dạng tiền tệ
                LblMaNhanVien.Text = contract.MaNhanVien;
                LblHoTen.Text = contract.TenNhanVien; // DAO đã format "Họ Tên (Mã NV)"
                LblPhongBan.Text = contract.PhongBan;
                LblMaHopDong.Text = contract.MaHopDong;
                LblNgayBatDau.Text = contract.TuNgay?.ToString("dd/MM/yyyy") ?? "N/A";
                LblNgayHetHan.Text = contract.DenNgay?.ToString("dd/MM/yyyy") ?? "N/A";
                LblLoaiHopDong.Text = contract.LoaiHopDong;
                LblMucLuong.Text = contract.LuongCoBan.ToString("C0", ci); // Định dạng VNĐ
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin hợp đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearContractLabels();
            }
        }

        /// <summary>
        /// Hàm này chỉ tải thông tin cơ bản của NV nếu họ chưa có hợp đồng
        /// </summary>
        private void LoadEmployeeDetailsOnly(string maNhanVien)
        {
            try
            {
                // Sử dụng hàm GetEmployeeById từ DAO (thông qua BLL)
                // Bạn cần thêm hàm này vào BLL (xem bước 3)
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
                MessageBox.Show($"Lỗi khi tải thông tin nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadExtensionHistory()
        {
            try
            {
                string maNhanVien = AuthService.MaNhanVien;
                if (string.IsNullOrWhiteSpace(maNhanVien))
                {
                    ClearHistoryLabels();
                    return; // Không có mã NV, không cần tải
                }

                // Lấy danh sách lịch sử từ BLL
                List<ExtensionHistoryDTO> history = _contractBLL.GetExtensionHistory(maNhanVien);

                // Lấy bản ghi mới nhất (DAO đã sắp xếp DESC)
                ExtensionHistoryDTO latestHistory = history.FirstOrDefault();

                if (latestHistory != null)
                {
                    // Gán dữ liệu cho các labels trong panel3
                    // Đảm bảo LblHoTen đã được tải từ LoadContractDetails
                    label12.Text = string.IsNullOrEmpty(LblHoTen.Text) || LblHoTen.Text == "N/A" ? maNhanVien : LblHoTen.Text;
                    label16.Text = latestHistory.NgayQuyetDinh.ToString("dd/MM/yyyy");
                    label24.Text = latestHistory.ThoiGianGiaHan.ToString("N1") + " năm"; // Hiển thị "1.5 năm"
                }
                else
                {
                    // Nếu không có lịch sử
                    ClearHistoryLabels();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử gia hạn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearHistoryLabels();
            }
        }

        /// <summary>
        /// Xóa văn bản trên các Label chi tiết hợp đồng
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
        /// Xóa văn bản trên các Label lịch sử gia hạn
        /// </summary>
        private void ClearHistoryLabels()
        {
            label12.Text = "N/A"; // Nhân viên
            label16.Text = "N/A"; // Ngày cập nhật
            label24.Text = "N/A"; // Gia hạn thêm
        }


        // Các sự kiện click trống (đã có trong tệp .cs bạn tải lên)
        private void label1_Click(object sender, EventArgs e)
        {
            // Có thể dùng để refresh
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Có thể dùng để refresh
        }
    }
}
