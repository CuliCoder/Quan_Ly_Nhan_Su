using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.ChamCong
{
    public partial class ucChiTietChamCong : UserControl
    {
        public event EventHandler BackButtonClicked;

        private readonly EmployeeFullBLL employeeBLL = new EmployeeFullBLL();
        // Giả định bạn có BLL cho việc lấy dữ liệu Yêu cầu
        // private readonly YeuCauBLL yeuCauBLL = new YeuCauBLL(); 
        private EmployeeFullDTO currentEmployee;

        public ucChiTietChamCong()
        {
            InitializeComponent();
            btnBack.Click += btnBack_Click;
            cboNam.SelectedIndexChanged += UpdateRequestDisplay;
            cboThang.SelectedIndexChanged += UpdateRequestDisplay;
        }

        public void LoadEmployeeData(string maNhanVien)
        {
            try
            {
                currentEmployee = employeeBLL.GetEmployeeById(maNhanVien);
                if (currentEmployee != null)
                {
                    lblTenNhanVien.Text = $"{currentEmployee.MaNhanVien} - {currentEmployee.HoTen}";
                    PopulateDateTimeControls();
                    LoadAndDisplayRequests();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BackButtonClicked?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin nhân viên: {ex.Message}");
            }
        }

        private void PopulateDateTimeControls()
        {
            cboNam.Items.Clear();
            cboThang.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 5; i <= currentYear + 5; i++) cboNam.Items.Add(i);
            cboNam.SelectedItem = currentYear;
            for (int i = 1; i <= 12; i++) cboThang.Items.Add(i);
            cboThang.SelectedItem = DateTime.Now.Month;
        }

        private void UpdateRequestDisplay(object sender, EventArgs e)
        {
            LoadAndDisplayRequests();
        }

        private void LoadAndDisplayRequests()
        {
            if (currentEmployee == null || cboNam.SelectedItem == null || cboThang.SelectedItem == null)
                return;

            int year = Convert.ToInt32(cboNam.SelectedItem);
            int month = Convert.ToInt32(cboThang.SelectedItem);

            try
            {
                // **PHẦN QUAN TRỌNG:** Bạn cần triển khai logic để lấy danh sách yêu cầu
                // List<YeuCauDTO> requests = yeuCauBLL.GetRequestsByEmployeeAndMonth(currentEmployee.MaNhanVien, year, month);

                // Dữ liệu mẫu để minh họa
                var requests = GetSampleRequests();

                DisplayRequests(requests);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách yêu cầu: {ex.Message}");
            }
        }

        // PHƯƠNG THỨC DÙNG DỮ LIỆU MẪU - HÃY THAY THẾ BẰNG LOGIC GỌI BLL THỰC TẾ
        private List<YeuCauDTO> GetSampleRequests()
        {
            return new List<YeuCauDTO>
            {
                new YeuCauDTO { TenNguoiGui = "Nguyễn Ngọc Vân", EmailNguoiGui = "vannn@teky.vn", NgayBatDau = new DateTime(2025, 10, 21), NgayKetThuc = new DateTime(2025, 10, 28), TrangThai = "Draft" },
                new YeuCauDTO { TenNguoiGui = "Nguyễn Thị Minh Trang", EmailNguoiGui = "mintrang9@gmail.com", NgayBatDau = new DateTime(2025, 10, 21), NgayKetThuc = new DateTime(2025, 11, 2), TrangThai = "Submitted" },
                new YeuCauDTO { TenNguoiGui = "Nguyễn Thị Quỳnh Mai", EmailNguoiGui = "maiquynh@gmail.com", NgayBatDau = new DateTime(2025, 10, 16), NgayKetThuc = new DateTime(2025, 10, 19), TrangThai = "Approved" },
                new YeuCauDTO { TenNguoiGui = "Lê Minh Thành", EmailNguoiGui = "thanhlm@teky.vn", NgayBatDau = new DateTime(2025, 10, 16), NgayKetThuc = new DateTime(2025, 10, 31), TrangThai = "Approved" },
                new YeuCauDTO { TenNguoiGui = "Hoàng Tuấn Sơn", EmailNguoiGui = "tuansonzz13@gmail.com", NgayBatDau = new DateTime(2025, 10, 16), NgayKetThuc = new DateTime(2025, 10, 19), TrangThai = "Submitted" }
            };
        }

        private void DisplayRequests(List<YeuCauDTO> requests)
        {
            flpDraft.Controls.Clear();
            flpSubmitted.Controls.Clear();
            flpApproved.Controls.Clear();

            if (requests == null) return;

            foreach (var req in requests)
            {
                var card = new ucRequestCard();
                card.LoadData(req);

                // Phân loại card vào đúng cột dựa trên trạng thái
                switch (req.TrangThai?.ToLower())
                {
                    case "draft":
                        flpDraft.Controls.Add(card);
                        break;
                    case "submitted":
                        flpSubmitted.Controls.Add(card);
                        break;
                    case "approved":
                        flpApproved.Controls.Add(card);
                        break;
                    default:
                        // Có thể thêm vào một cột mặc định nếu cần
                        break;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}