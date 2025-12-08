using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System.IO;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class CT_LaborContractGUI : UserControl
    {
        private readonly LaborContractBLL _bll;
        private readonly EmployeeFullBLL _employeeBll;
        private string _contractId;

        public CT_LaborContractGUI()
        {
            InitializeComponent();
            _bll = new LaborContractBLL();
            _employeeBll = new EmployeeFullBLL();
            comboBoxGiaHanThem.Items.AddRange(new string[] { "0.5 năm", "1 năm", "1.5 năm", "2 năm", "3 năm", "4 năm" });
            LoadContractDetails();
        }

        private void LoadContractDetails()
        {
            try
            {
                if (string.IsNullOrEmpty(_contractId))
                {
                    Console.WriteLine("GUI Debug: _contractId is empty");
                    return;
                }
                Console.WriteLine($"GUI Debug: Loading for _contractId={_contractId}");

                LaborContractDTO contract = _bll.GetContractById(_contractId);
                if (contract != null)
                {
                    textBox1.Text = contract.MaNhanVien ?? "";
                    textBox2.Text = contract.TenNhanVien ?? "";
                    textBox3.Text = contract.PhongBan ?? "";
                    textBox4.Text = contract.MaHopDong ?? "";
                    textBox5.Text = contract.TuNgay?.ToString("dd/MM/yyyy") ?? "";
                    textBox6.Text = contract.DenNgay?.ToString("dd/MM/yyyy") ?? "";
                    textBox7.Text = contract.LoaiHopDong ?? "";
                    textBox8.Text = contract.LuongCoBan.ToString("N0") + " VND" ?? "0 VND";

                    CalculateContractDuration(contract);

                    // Load ảnh avatar
                    LoadAvatar(contract.HinhAnh);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hợp đồng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
                Console.WriteLine($"GUI Error: {ex.Message}");
            }
        }

        private void LoadAvatar(string imagePath)
        {
            try
            {
                // Lấy đường dẫn project root
                string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string defaultAvatar = Path.Combine(projectPath, @"GUI\assets\img\images.png");

                Console.WriteLine($"GUI Debug: Project path: {projectPath}");
                Console.WriteLine($"GUI Debug: Image path from DB: {imagePath}");

                // Kiểm tra nếu imagePath không rỗng
                if (!string.IsNullOrEmpty(imagePath))
                {
                    string fullPath = "";

                    // Nếu là relative path, combine với project path
                    if (!Path.IsPathRooted(imagePath))
                    {
                        fullPath = Path.Combine(projectPath, imagePath);
                    }
                    else
                    {
                        fullPath = imagePath;
                    }

                    Console.WriteLine($"GUI Debug: Trying to load image from: {fullPath}");

                    // Kiểm tra file tồn tại
                    if (File.Exists(fullPath))
                    {
                        pictureBoxAvatar.Image = Image.FromFile(fullPath);
                        pictureBoxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                        Console.WriteLine("GUI Debug: Image loaded successfully");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"GUI Debug: Image file not found at: {fullPath}");
                        
                        // Thử tìm với tên thư mục khác (Avatar vs Avatars)
                        string alternativePath = imagePath.Replace("\\Avatar\\", "\\Avatars\\").Replace("/Avatar/", "/Avatars/");
                        if (alternativePath != imagePath)
                        {
                            string altFullPath = Path.Combine(projectPath, alternativePath);
                            Console.WriteLine($"GUI Debug: Trying alternative path: {altFullPath}");
                            
                            if (File.Exists(altFullPath))
                            {
                                pictureBoxAvatar.Image = Image.FromFile(altFullPath);
                                pictureBoxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                                Console.WriteLine("GUI Debug: Image loaded from alternative path");
                                return;
                            }
                        }

                        // Thử tìm file theo tên trong cả 2 thư mục
                        string fileName = Path.GetFileName(imagePath);
                        if (!string.IsNullOrEmpty(fileName))
                        {
                            string[] possiblePaths = new string[]
                            {
                                Path.Combine(projectPath, "Images", "Avatar", fileName),
                                Path.Combine(projectPath, "Images", "Avatars", fileName)
                            };

                            foreach (string possiblePath in possiblePaths)
                            {
                                Console.WriteLine($"GUI Debug: Checking possible path: {possiblePath}");
                                if (File.Exists(possiblePath))
                                {
                                    pictureBoxAvatar.Image = Image.FromFile(possiblePath);
                                    pictureBoxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                                    Console.WriteLine($"GUI Debug: Image found at: {possiblePath}");
                                    return;
                                }
                            }
                        }
                    }
                }

                // Nếu không tìm thấy ảnh, dùng ảnh mặc định
                Console.WriteLine($"GUI Debug: Loading default avatar from: {defaultAvatar}");
                if (File.Exists(defaultAvatar))
                {
                    pictureBoxAvatar.Image = Image.FromFile(defaultAvatar);
                    pictureBoxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                    Console.WriteLine("GUI Debug: Default avatar loaded");
                }
                else
                {
                    pictureBoxAvatar.Image = null;
                    Console.WriteLine($"GUI Debug: Default avatar not found at: {defaultAvatar}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GUI Error loading avatar: {ex.Message}");
                Console.WriteLine($"GUI Stack trace: {ex.StackTrace}");
                pictureBoxAvatar.Image = null;
            }
        }

        private void CalculateContractDuration(LaborContractDTO contract)
        {
            if (contract.TuNgay.HasValue && contract.DenNgay.HasValue)
            {
                DateTime tuNgay = contract.TuNgay.Value;
                DateTime denNgay = contract.DenNgay.Value;
                DateTime ngayHienTai = DateTime.Now; // Sử dụng ngày hiện tại (28/09/2025)

                if (tuNgay > denNgay)
                {
                    textBox6.Text += " (Ngày kết thúc phải sau ngày bắt đầu)";
                    return;
                }

                TimeSpan thoiHan = denNgay - tuNgay;
                long totalDays = (long)thoiHan.TotalDays;

                int nam = (int)(totalDays / 365);
                long remainingAfterYears = totalDays % 365;
                int thang = (int)(remainingAfterYears / 30);
                int ngay = (int)(remainingAfterYears % 30);

                string ketQua = "";
                if (nam > 0) ketQua += $"{nam} năm ";
                if (thang > 0) ketQua += $"{thang} tháng ";
                if (ngay > 0) ketQua += $"{ngay} ngày";

                textBox6.Text = denNgay.ToString("dd/MM/yyyy") + " (" + (ketQua.Trim() == "" ? "0 ngày" : ketQua.Trim()) + ")";

                if (ngayHienTai > denNgay)
                {
                    textBox6.Text += " (Hợp đồng đã hết hạn)";
                }
            }
            else
            {
                textBox6.Text = "Dữ liệu ngày không hợp lệ";
            }
        }

        public void SetContractId(string contractId)
        {
            _contractId = contractId;
            LoadContractDetails();
        }

        private void buttonGiaHan_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxGiaHanThem.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn thời gian gia hạn!");
                    return;
                }

                string thoiGianGiaHan = comboBoxGiaHanThem.SelectedItem.ToString();
                if (_bll.ExtendContract(_contractId, thoiGianGiaHan))
                {
                    MessageBox.Show("Gia hạn hợp đồng thành công!");
                    LoadContractDetails(); // Tải lại
                    comboBoxGiaHanThem.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Gia hạn hợp đồng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gia hạn hợp đồng: {ex.Message}");
            }
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxGiaHanThem.SelectedIndex = -1;

                ContractGUI contractGUI = new ContractGUI();
                if (this.Parent is Panel panelContent)
                {
                    panelContent.Controls.Clear();
                    panelContent.Controls.Add(contractGUI);
                    contractGUI.Dock = DockStyle.Fill;
                }
                else
                {
                    Form contractForm = new Form { Text = "Danh sách hợp đồng" };
                    contractForm.Controls.Add(contractGUI);
                    contractForm.Size = new Size(1235, 747);
                    contractForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi quay lại: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo instance mới của ContractGUI
                ContractGUI contractGUI = new ContractGUI();

                // Kiểm tra nếu Parent là Panel
                if (this.Parent is Panel panelContent)
                {
                    panelContent.Controls.Clear(); // Xóa control hiện tại (CT_LaborContractGUI)
                    panelContent.Controls.Add(contractGUI); // Thêm ContractGUI
                    contractGUI.Dock = DockStyle.Fill; // Fill toàn panel
                }
                else
                {
                    // Nếu không phải Panel, show như Form mới (tùy chỉnh nếu cần)
                    Form contractForm = new Form { Text = "Danh sách hợp đồng" };
                    contractForm.Controls.Add(contractGUI);
                    contractForm.Size = new Size(1235, 747); // Kích thước tùy chỉnh
                    contractForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi quay lại ContractGUI: {ex.Message}");
            }
        }

        private void pictureBoxAvatar_Click(object sender, EventArgs e)
        {
        }
    }
}