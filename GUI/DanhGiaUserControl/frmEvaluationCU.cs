using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.GUI.DanhGiaUserControl
{
    public partial class frmEvaluationCU : Form
    {
        private readonly EvaluationBLL _evaluationBLL;
        private readonly EvaluationDetailBLL _detailBLL;
        private readonly EmployeeFullBLL _employeeBLL;
        private readonly string _maDanhGia;
        private bool _isEditMode;
        private List<EvaluationDetailDTO> _evaluationDetails;

        // UI Components cho đánh giá chi tiết
        private Panel pnlDetailedEvaluation;
        private CheckBox chkUseDetailedEvaluation;
        private Panel pnlCriteriaContainer;
        private Label lblDetailedScore;
        private Label lblDetailedRating;
        private Label lblPercentage;
        private Label lblQuarterInfo;

        public frmEvaluationCU()
        {
            InitializeComponent();
            _evaluationBLL = new EvaluationBLL();
            _detailBLL = new EvaluationDetailBLL();
            _employeeBLL = new EmployeeFullBLL();
            _isEditMode = false;
            _maDanhGia = GenerateNewCode();
            _evaluationDetails = new List<EvaluationDetailDTO>();
        }

        public frmEvaluationCU(string maDanhGia) : this()
        {
            _maDanhGia = maDanhGia;
            _isEditMode = true;
        }

        private void frmEvaluationCU_Load(object sender, EventArgs e)
        {
            try
            {
                // Tăng kích thước form để chứa cả phần tiêu chí
                this.Size = new Size(1180, 800);
                this.MinimumSize = new Size(1180, 800);
                this.StartPosition = FormStartPosition.CenterScreen;

                // QUAN TRỌNG: Đổi Dock của grpInfo thành None để có thể đặt các control khác
                grpInfo.Dock = DockStyle.None;
                grpInfo.Location = new Point(20, 70);
                grpInfo.Size = new Size(500, 620);

                // Cấu hình NumericUpDown
                numDiem.Minimum = 0;
                numDiem.Maximum = 100;
                numDiem.Value = 0;

                // Thêm label hiển thị thông tin quý
                lblQuarterInfo = new Label
                {
                    Location = new Point(180, 208), // Ngay dưới dtpNgayDanhGia
                    Size = new Size(462, 25),
                    Font = new Font("Times New Roman", 10, FontStyle.Italic),
                    ForeColor = Color.FromArgb(0, 123, 255),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                grpInfo.Controls.Add(lblQuarterInfo);
                lblQuarterInfo.BringToFront();

                // Gắn sự kiện cho DateTimePicker
                dtpNgayDanhGia.ValueChanged += dtpNgayDanhGia_ValueChanged;

                // Thêm phần đánh giá chi tiết
                AddDetailedEvaluationSection();

                // Load danh sách nhân viên
                LoadEmployees();

                if (_isEditMode)
                {
                    lblTitle.Text = "CẬP NHẬT ĐÁNH GIÁ";
                    this.Text = "Cập nhật đánh giá";
                    LoadEvaluationData();
                }
                else
                {
                    lblTitle.Text = "THÊM ĐÁNH GIÁ MỚI";
                    this.Text = "Thêm đánh giá mới";
                    txtMaDanhGia.Text = _maDanhGia;
                    dtpNgayDanhGia.Value = DateTime.Now;
                    _evaluationDetails = _detailBLL.CreateDefaultDetails(_maDanhGia);
                    RenderCriteriaControls();

                    // Hiển thị thông tin quý ban đầu
                    UpdateQuarterInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateQuarterInfo()
        {
            if (lblQuarterInfo == null || _evaluationBLL == null) return;

            string quarterName = _evaluationBLL.GetQuarterName(dtpNgayDanhGia.Value);
            var (startDate, endDate) = _evaluationBLL.GetQuarterDateRange(dtpNgayDanhGia.Value);

            lblQuarterInfo.Text = $"📅 {quarterName} (Từ {startDate:dd/MM/yyyy} đến {endDate:dd/MM/yyyy})";

            // Kiểm tra xem nhân viên đã được đánh giá trong quý chưa
            if (cboNhanVien.SelectedValue != null)
            {
                string maNhanVien = cboNhanVien.SelectedValue.ToString();
                bool isEvaluated = _isEditMode
                    ? _evaluationBLL.IsEmployeeEvaluatedInQuarter(maNhanVien, dtpNgayDanhGia.Value, _maDanhGia)
                    : _evaluationBLL.IsEmployeeEvaluatedInQuarter(maNhanVien, dtpNgayDanhGia.Value);

                if (isEvaluated)
                {
                    lblQuarterInfo.Text += " ⚠️ Đã có đánh giá";
                    lblQuarterInfo.ForeColor = Color.FromArgb(220, 53, 69); // Màu đỏ
                }
                else
                {
                    lblQuarterInfo.Text += " ✓ Chưa có đánh giá";
                    lblQuarterInfo.ForeColor = Color.FromArgb(40, 167, 69); // Màu xanh
                }
            }
        }



        private void AddDetailedEvaluationSection()
        {
            // Checkbox để bật/tắt đánh giá chi tiết
            chkUseDetailedEvaluation = new CheckBox
            {
                Text = "✓ Sử dụng đánh giá chi tiết theo tiêu chí chuẩn",
                Location = new Point(540, 70),
                Size = new Size(400, 30),
                Font = new Font("Times New Roman", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 123, 255),
                Checked = true,
                Cursor = Cursors.Hand
            };
            chkUseDetailedEvaluation.CheckedChanged += ChkUseDetailedEvaluation_CheckedChanged;
            pnlMain.Controls.Add(chkUseDetailedEvaluation);

            // Panel chính chứa đánh giá chi tiết
            pnlDetailedEvaluation = new Panel
            {
                Location = new Point(540, 105),
                Size = new Size(610, 585),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 249, 250)
            };

            // Header panel cho điểm số
            Panel pnlScoreHeader = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(608, 80),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Icon điểm số
            Label lblScoreIcon = new Label
            {
                Text = "📊",
                Location = new Point(15, 15),
                Size = new Size(40, 40),
                Font = new Font("Segoe UI", 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlScoreHeader.Controls.Add(lblScoreIcon);

            // Label tổng điểm
            lblDetailedScore = new Label
            {
                Text = "Tổng điểm: 0/52",
                Location = new Point(65, 12),
                Size = new Size(250, 28),
                Font = new Font("Times New Roman", 15, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204)
            };
            pnlScoreHeader.Controls.Add(lblDetailedScore);

            // Label phần trăm
            lblPercentage = new Label
            {
                Text = "(0%)",
                Location = new Point(65, 40),
                Size = new Size(100, 20),
                Font = new Font("Times New Roman", 10, FontStyle.Italic),
                ForeColor = Color.FromArgb(108, 117, 125)
            };
            pnlScoreHeader.Controls.Add(lblPercentage);

            // Label xếp loại
            lblDetailedRating = new Label
            {
                Text = "Chưa đánh giá",
                Location = new Point(400, 20),
                Size = new Size(190, 35),
                Font = new Font("Times New Roman", 13, FontStyle.Bold),
                ForeColor = Color.FromArgb(108, 117, 125),
                TextAlign = ContentAlignment.MiddleRight
            };
            pnlScoreHeader.Controls.Add(lblDetailedRating);

            // Đường kẻ ngăn cách
            Panel pnlDivider = new Panel
            {
                Location = new Point(0, 79),
                Size = new Size(608, 1),
                BackColor = Color.FromArgb(222, 226, 230)
            };
            pnlScoreHeader.Controls.Add(pnlDivider);

            pnlDetailedEvaluation.Controls.Add(pnlScoreHeader);

            // Hướng dẫn đánh giá
            Panel pnlGuide = new Panel
            {
                Location = new Point(0, 80),
                Size = new Size(608, 35),
                BackColor = Color.FromArgb(255, 243, 205)
            };

            Label lblGuide = new Label
            {
                Text = "💡 Hướng dẫn: 1=Yếu | 2=Trung bình | 3=Khá | 4=Tốt",
                Location = new Point(10, 8),
                Size = new Size(588, 20),
                Font = new Font("Times New Roman", 10, FontStyle.Italic),
                ForeColor = Color.FromArgb(133, 100, 4)
            };
            pnlGuide.Controls.Add(lblGuide);
            pnlDetailedEvaluation.Controls.Add(pnlGuide);

            // Panel chứa các tiêu chí với scroll
            pnlCriteriaContainer = new Panel
            {
                Location = new Point(0, 115),
                Size = new Size(608, 468),
                AutoScroll = true,
                BackColor = Color.White
            };
            pnlDetailedEvaluation.Controls.Add(pnlCriteriaContainer);

            pnlMain.Controls.Add(pnlDetailedEvaluation);
            pnlDetailedEvaluation.BringToFront(); // Đưa lên trên cùng
        }

        private void RenderCriteriaControls()
        {
            pnlCriteriaContainer.Controls.Clear();

            if (_evaluationDetails == null || _evaluationDetails.Count == 0)
            {
                _evaluationDetails = _detailBLL.CreateDefaultDetails(_maDanhGia);
            }

            int yPosition = 10;
            string currentGroup = "";
            int criterionIndex = 0;

            foreach (var detail in _evaluationDetails)
            {
                string group = GetGroupName(detail.MaTieuChi);

                // Header nhóm
                if (group != currentGroup)
                {
                    Panel pnlGroupHeader = new Panel
                    {
                        Location = new Point(10, yPosition),
                        Size = new Size(570, 40),
                        BackColor = Color.FromArgb(0, 123, 255)
                    };

                    Label lblGroup = new Label
                    {
                        Text = group,
                        Location = new Point(15, 10),
                        Size = new Size(540, 20),
                        Font = new Font("Times New Roman", 11, FontStyle.Bold),
                        ForeColor = Color.White
                    };
                    pnlGroupHeader.Controls.Add(lblGroup);
                    pnlCriteriaContainer.Controls.Add(pnlGroupHeader);

                    yPosition += 45;
                    currentGroup = group;
                }

                // Panel cho mỗi tiêu chí
                Panel pnlCriterion = new Panel
                {
                    Location = new Point(10, yPosition),
                    Size = new Size(570, 75),
                    BackColor = criterionIndex % 2 == 0 ? Color.White : Color.FromArgb(248, 249, 250),
                    BorderStyle = BorderStyle.None,
                    Name = $"pnlCriterion_{criterionIndex}"
                };

                // Đường viền dưới
                Panel pnlBorder = new Panel
                {
                    Location = new Point(0, 74),
                    Size = new Size(570, 1),
                    BackColor = Color.FromArgb(222, 226, 230)
                };
                pnlCriterion.Controls.Add(pnlBorder);

                // Tên tiêu chí với số thứ tự
                Label lblName = new Label
                {
                    Text = $"{criterionIndex + 1}. {detail.TenTieuChi}",
                    Location = new Point(15, 10),
                    Size = new Size(340, 55),
                    Font = new Font("Times New Roman", 10),
                    AutoSize = false
                };
                pnlCriterion.Controls.Add(lblName);

                // Panel chứa radio buttons
                Panel pnlRadios = new Panel
                {
                    Location = new Point(365, 15),
                    Size = new Size(195, 45),
                    BackColor = Color.Transparent
                };

                // Radio buttons (4 mức)
                string[] levels = { "1", "2", "3", "4" };
                Color[] colors = {
                    Color.FromArgb(220, 53, 69),   // Yếu - Đỏ
                    Color.FromArgb(255, 152, 0),   // TB - Cam
                    Color.FromArgb(255, 193, 7),   // Khá - Vàng
                    Color.FromArgb(40, 167, 69)    // Tốt - Xanh
                };

                string[] tooltips = { "Yếu", "Trung bình", "Khá", "Tốt" };

                for (int i = 0; i < 4; i++)
                {
                    RadioButton rad = new RadioButton
                    {
                        Text = levels[i],
                        Location = new Point(5 + (i * 46), 10),
                        Size = new Size(41, 30),
                        Tag = detail,
                        Checked = detail.MucDanhGia == (i + 1),
                        Font = new Font("Times New Roman", 11, FontStyle.Bold),
                        ForeColor = colors[i],
                        Appearance = Appearance.Button,
                        TextAlign = ContentAlignment.MiddleCenter,
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand,
                        Name = $"rad_{detail.MaTieuChi}_{i + 1}"
                    };

                    rad.FlatAppearance.BorderColor = colors[i];
                    rad.FlatAppearance.BorderSize = 2;
                    rad.FlatAppearance.CheckedBackColor = colors[i];

                    // Tooltip
                    ToolTip tooltip = new ToolTip();
                    tooltip.SetToolTip(rad, tooltips[i]);

                    int colorIndex = i;
                    // Sự kiện hover
                    rad.MouseEnter += (s, e) =>
                    {
                        if (!rad.Checked)
                        {
                            rad.BackColor = Color.FromArgb(30, colors[colorIndex].R, colors[colorIndex].G, colors[colorIndex].B);
                        }
                    };
                    rad.MouseLeave += (s, e) =>
                    {
                        if (!rad.Checked)
                            rad.BackColor = Color.Transparent;
                    };

                    int level = i + 1;
                    rad.CheckedChanged += (s, e) =>
                    {
                        if (rad.Checked)
                        {
                            var d = (EvaluationDetailDTO)rad.Tag;
                            d.MucDanhGia = level;
                            d.DiemDatDuoc = _detailBLL.CalculateScore(level, d.DiemToiDa);

                            // Đổi màu chữ khi được chọn
                            rad.ForeColor = Color.White;

                            // Highlight panel tiêu chí này
                            pnlCriterion.BackColor = Color.FromArgb(232, 244, 253);

                            UpdateDetailedScore();
                        }
                        else
                        {
                            rad.ForeColor = colors[colorIndex];
                        }
                    };

                    pnlRadios.Controls.Add(rad);
                }

                pnlCriterion.Controls.Add(pnlRadios);
                pnlCriteriaContainer.Controls.Add(pnlCriterion);

                yPosition += 75;
                criterionIndex++;
            }

            UpdateDetailedScore();
        }

        private string GetGroupName(string maTieuChi)
        {
            if (maTieuChi.StartsWith("TC01")) return "I. Ý THỨC KỶ LUẬT";
            if (maTieuChi.StartsWith("TC02")) return "II. TÁC PHONG LÀM VIỆC";
            if (maTieuChi.StartsWith("TC03")) return "III. QUAN HỆ LÀM VIỆC";
            if (maTieuChi.StartsWith("TC04")) return "IV. HIỆU QUẢ CÔNG VIỆC";
            return "KHÁC";
        }

        private void UpdateDetailedScore()
        {
            if (!chkUseDetailedEvaluation.Checked || _evaluationDetails == null)
                return;

            int tongDiem = _detailBLL.CalculateTotalScore(_evaluationDetails);
            int tongDiemToiDa = _evaluationDetails.Sum(d => d.DiemToiDa);
            string xepLoai = _detailBLL.DetermineRating(tongDiem, tongDiemToiDa);
            double percentage = tongDiemToiDa > 0 ? (double)tongDiem / tongDiemToiDa * 100 : 0;

            // Cập nhật label
            lblDetailedScore.Text = $"Tổng điểm: {tongDiem}/{tongDiemToiDa}";
            lblPercentage.Text = $"({percentage:F1}%)";
            lblDetailedRating.Text = xepLoai;

            // Tự động cập nhật vào form chính
            numDiem.Value = tongDiem;
            txtXepLoai.Text = xepLoai;

            // Đổi màu theo xếp loại
            Color ratingColor;
            switch (xepLoai)
            {
                case "Xuất sắc":
                    ratingColor = Color.FromArgb(0, 153, 51);
                    break;
                case "Tốt":
                    ratingColor = Color.FromArgb(0, 102, 204);
                    break;
                case "Khá":
                    ratingColor = Color.FromArgb(255, 153, 0);
                    break;
                case "Trung bình":
                    ratingColor = Color.FromArgb(255, 102, 0);
                    break;
                default:
                    ratingColor = Color.FromArgb(220, 53, 69);
                    break;
            }

            lblDetailedScore.ForeColor = ratingColor;
            lblPercentage.ForeColor = ratingColor;
            lblDetailedRating.ForeColor = ratingColor;
        }

        private void ChkUseDetailedEvaluation_CheckedChanged(object sender, EventArgs e)
        {
            pnlDetailedEvaluation.Visible = chkUseDetailedEvaluation.Checked;
            numDiem.ReadOnly = chkUseDetailedEvaluation.Checked;
            txtXepLoai.ReadOnly = chkUseDetailedEvaluation.Checked;

            if (chkUseDetailedEvaluation.Checked)
            {
                UpdateDetailedScore();
                txtChiTiet.ReadOnly = true;
                txtChiTiet.BackColor = Color.FromArgb(233, 236, 239);
                txtChiTiet.Text = "Đánh giá dựa trên tiêu chí chuẩn";
            }
            else
            {
                txtChiTiet.ReadOnly = false;
                txtChiTiet.BackColor = Color.White;
                txtChiTiet.Clear();
            }
        }

        private void LoadEmployees()
        {
            try
            {
                var employees = _employeeBLL.GetAllEmployees();

                var employeeList1 = employees.ToList();
                var employeeList2 = employees.ToList();

                cboNhanVien.DataSource = employeeList1;
                cboNhanVien.DisplayMember = "HoTen";
                cboNhanVien.ValueMember = "MaNhanVien";

                cboNguoiDanhGia.DataSource = employeeList2;
                cboNguoiDanhGia.DisplayMember = "HoTen";
                cboNguoiDanhGia.ValueMember = "MaNhanVien";

                // Gắn sự kiện
                cboNhanVien.SelectedIndexChanged += cboNhanVien_SelectedIndexChanged;

                if (employees.Count > 0)
                {
                    cboNhanVien.SelectedIndex = 0;
                    cboNguoiDanhGia.SelectedIndex = employees.Count > 1 ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEvaluationData()
        {
            try
            {
                var evaluation = _evaluationBLL.GetById(_maDanhGia);
                if (evaluation == null)
                {
                    MessageBox.Show("Không tìm thấy đánh giá!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtMaDanhGia.Text = evaluation.MaDanhGia;
                cboNhanVien.SelectedValue = evaluation.MaNhanVien;
                cboNguoiDanhGia.SelectedValue = evaluation.MaNguoiDanhGia;
                dtpNgayDanhGia.Value = evaluation.NgayDanhGia;
                numDiem.Value = evaluation.DiemDanhGia;
                txtXepLoai.Text = evaluation.XepLoai;
                txtChiTiet.Text = evaluation.ChiTietDanhGia;
                txtGhiChu.Text = evaluation.GhiChu;

                // Load chi tiết đánh giá
                _evaluationDetails = _detailBLL.GetByEvaluationId(_maDanhGia);

                if (_evaluationDetails != null && _evaluationDetails.Count > 0)
                {
                    chkUseDetailedEvaluation.Checked = true;
                    RenderCriteriaControls();
                }
                else
                {
                    chkUseDetailedEvaluation.Checked = false;
                    _evaluationDetails = _detailBLL.CreateDefaultDetails(_maDanhGia);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numDiem_ValueChanged(object sender, EventArgs e)
        {
            if (!chkUseDetailedEvaluation.Checked)
            {
                int diem = (int)numDiem.Value;
                string xepLoai = GetRankingByScore(diem);
                txtXepLoai.Text = xepLoai;
            }
        }

        private string GetRankingByScore(int score)
        {
            if (score >= 90) return "Xuất sắc";
            if (score >= 80) return "Tốt";
            if (score >= 70) return "Khá";
            if (score >= 50) return "Trung bình";
            return "Yếu";
        }

        private bool ValidateData()
        {
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return false;
            }

            if (cboNguoiDanhGia.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn người đánh giá!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNguoiDanhGia.Focus();
                return false;
            }

            if (cboNhanVien.SelectedValue.ToString() == cboNguoiDanhGia.SelectedValue.ToString())
            {
                MessageBox.Show("Nhân viên không thể tự đánh giá mình!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpNgayDanhGia.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày đánh giá không được lớn hơn ngày hiện tại!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayDanhGia.Focus();
                return false;
            }

            // Kiểm tra giới hạn đánh giá theo quý
            string maNhanVien = cboNhanVien.SelectedValue.ToString();
            DateTime ngayDanhGia = dtpNgayDanhGia.Value;

            try
            {
                // Kiểm tra đã có đánh giá trong quý chưa
                bool isEvaluated = _isEditMode
                    ? _evaluationBLL.IsEmployeeEvaluatedInQuarter(maNhanVien, ngayDanhGia, _maDanhGia)
                    : _evaluationBLL.IsEmployeeEvaluatedInQuarter(maNhanVien, ngayDanhGia);

                if (isEvaluated)
                {
                    var existingEval = _evaluationBLL.GetExistingQuarterEvaluation(maNhanVien, ngayDanhGia, _maDanhGia);
                    string quarterName = _evaluationBLL.GetQuarterName(ngayDanhGia);
                    var (startDate, endDate) = _evaluationBLL.GetQuarterDateRange(ngayDanhGia);

                    string message = $"❌ Nhân viên đã được đánh giá trong {quarterName}!\n\n" +
                                   $"📅 Khoảng thời gian: {startDate:dd/MM/yyyy} - {endDate:dd/MM/yyyy}\n" +
                                   $"📋 Mã đánh giá hiện có: {existingEval?.MaDanhGia}\n" +
                                   $"📆 Ngày đánh giá: {existingEval?.NgayDanhGia:dd/MM/yyyy}\n\n" +
                                   $"⚠️ Mỗi nhân viên chỉ được đánh giá 1 lần mỗi quý!\n\n" +
                                   $"💡 Gợi ý: Chọn ngày đánh giá ở quý khác hoặc chỉnh sửa đánh giá hiện có.";

                    MessageBox.Show(message, "Giới hạn đánh giá theo quý",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpNgayDanhGia.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra đánh giá: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate đánh giá chi tiết nếu được bật
            if (chkUseDetailedEvaluation.Checked)
            {
                var errors = _detailBLL.ValidateDetails(_evaluationDetails);
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors),
                        "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Kiểm tra có ít nhất 1 tiêu chí được đánh giá
                bool hasRating = _evaluationDetails.Any(d => d.MucDanhGia > 0);
                if (!hasRating)
                {
                    MessageBox.Show("Vui lòng đánh giá ít nhất một tiêu chí!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateData())
                    return;

                var evaluation = new EvaluationDTO
                {
                    MaDanhGia = txtMaDanhGia.Text.Trim(),
                    MaNhanVien = cboNhanVien.SelectedValue.ToString(),
                    MaNguoiDanhGia = cboNguoiDanhGia.SelectedValue.ToString(),
                    NgayDanhGia = dtpNgayDanhGia.Value,
                    DiemDanhGia = (int)numDiem.Value,
                    XepLoai = txtXepLoai.Text.Trim(),
                    ChiTietDanhGia = chkUseDetailedEvaluation.Checked ?
                        "Đánh giá theo tiêu chí chuẩn" : txtChiTiet.Text.Trim(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                bool success;
                try
                {
                    if (_isEditMode)
                    {
                        success = _evaluationBLL.Update(evaluation);

                        if (success && chkUseDetailedEvaluation.Checked)
                        {
                            _detailBLL.SaveEvaluationDetails(_maDanhGia, _evaluationDetails);
                        }

                        if (success)
                        {
                            string quarterName = _evaluationBLL.GetQuarterName(evaluation.NgayDanhGia);
                            MessageBox.Show($"✅ Cập nhật đánh giá {quarterName} thành công!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        success = _evaluationBLL.Insert(evaluation);

                        if (success && chkUseDetailedEvaluation.Checked)
                        {
                            _detailBLL.SaveEvaluationDetails(evaluation.MaDanhGia, _evaluationDetails);
                        }

                        if (success)
                        {
                            string quarterName = _evaluationBLL.GetQuarterName(evaluation.NgayDanhGia);
                            MessageBox.Show($"✅ Thêm đánh giá {quarterName} thành công!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (success)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Exception từ Insert/Update sẽ chứa thông báo về giới hạn quý
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm method để hiển thị thông tin quý khi chọn ngày
        private void dtpNgayDanhGia_ValueChanged(object sender, EventArgs e)
        {
            UpdateQuarterInfo();
        }

        // Cập nhật khi chọn nhân viên
        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateQuarterInfo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string GenerateNewCode()
        {
            return "DG" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }


    }

}