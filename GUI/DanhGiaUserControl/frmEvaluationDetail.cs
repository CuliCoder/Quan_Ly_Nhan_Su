using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.GUI.DanhGiaUserControl
{
    public partial class frmEvaluationDetail : Form
    {
        private readonly EvaluationBLL _evaluationBLL;
        private readonly EvaluationDetailBLL _detailBLL;
        private readonly EmployeeFullBLL _employeeBLL;
        private readonly PersonalProfileBLL _profileBLL;
        private readonly string _maDanhGia;

        public frmEvaluationDetail(string maDanhGia)
        {
            _maDanhGia = maDanhGia;
            _evaluationBLL = new EvaluationBLL();
            _detailBLL = new EvaluationDetailBLL();
            _employeeBLL = new EmployeeFullBLL();
            _profileBLL = new PersonalProfileBLL();

            // Cấu hình form
            this.Text = "Chi tiết đánh giá";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            InitializeControls();
            LoadEvaluationData();
        }

        private void InitializeControls()
        {
            // Header Panel
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(0, 123, 255),
                Padding = new Padding(20, 20, 20, 10)
            };

            Label lblTitle = new Label
            {
                Text = "CHI TIẾT ĐÁNH GIÁ NHÂN VIÊN",
                Font = new Font("Times New Roman", 18, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlHeader.Controls.Add(lblTitle);

            // Button Panel (đặt trước để Dock.Bottom)
            Panel pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                Padding = new Padding(20, 15, 20, 15)
            };

            Button btnEdit = new Button
            {
                Text = "Sửa đánh giá",
                Size = new Size(120, 40),
                Location = new Point(300, 15),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Times New Roman", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += BtnEdit_Click;

            Button btnClose = new Button
            {
                Text = "Đóng",
                Size = new Size(120, 40),
                Location = new Point(460, 15),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Times New Roman", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            pnlButtons.Controls.AddRange(new Control[] { btnEdit, btnClose });

            // Main Content Panel với AutoScroll
            Panel pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                AutoScroll = true,
                BackColor = Color.White
            };

            // Info Panel
            GroupBox grpInfo = new GroupBox
            {
                Text = "Thông tin chung",
                Font = new Font("Times New Roman", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(840, 180),
                Padding = new Padding(10),
                BackColor = Color.White
            };

            // Labels cho thông tin - Tăng khoảng cách giữa các dòng
            CreateInfoLabel(grpInfo, "Mã đánh giá:", 20, 35, "lblMaDanhGia");
            CreateInfoLabel(grpInfo, "Nhân viên:", 20, 70, "lblNhanVien");
            CreateInfoLabel(grpInfo, "Người đánh giá:", 20, 105, "lblNguoiDanhGia");
            CreateInfoLabel(grpInfo, "Ngày đánh giá:", 20, 140, "lblNgayDanhGia");
            CreateInfoLabel(grpInfo, "Điểm:", 450, 35, "lblDiem");
            CreateInfoLabel(grpInfo, "Xếp loại:", 450, 70, "lblXepLoai");

            pnlMain.Controls.Add(grpInfo);

            // Criteria Panel - Đặt xuống dưới Info Panel
            GroupBox grpCriteria = new GroupBox
            {
                Text = "Chi tiết đánh giá theo tiêu chí",
                Font = new Font("Times New Roman", 12, FontStyle.Bold),
                Location = new Point(10, 200),
                Size = new Size(840, 380),
                Padding = new Padding(10),
                BackColor = Color.White
            };

            DataGridView dgvDetails = new DataGridView
            {
                Name = "dgvDetails",
                Location = new Point(10, 35),
                Size = new Size(820, 335),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 40
            };

            // Configure columns
            dgvDetails.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                Font = new Font("Times New Roman", 11, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            dgvDetails.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Times New Roman", 10),
                SelectionBackColor = Color.FromArgb(204, 229, 255),
                SelectionForeColor = Color.Black
            };

            dgvDetails.RowTemplate.Height = 35;

            // Add columns
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTieuChi",
                HeaderText = "Tiêu chí",
                FillWeight = 200
            });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMucDanhGia",
                HeaderText = "Mức đánh giá",
                FillWeight = 80
            });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDiemDat",
                HeaderText = "Điểm đạt",
                FillWeight = 60
            });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDiemToiDa",
                HeaderText = "Điểm tối đa",
                FillWeight = 80
            });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGhiChu",
                HeaderText = "Ghi chú",
                FillWeight = 150
            });

            grpCriteria.Controls.Add(dgvDetails);
            pnlMain.Controls.Add(grpCriteria);

            // Thêm controls vào form theo thứ tự QUAN TRỌNG
            this.Controls.Add(pnlMain);      // Fill - ở giữa
            this.Controls.Add(pnlButtons);   // Bottom - ở dưới
            this.Controls.Add(pnlHeader);    // Top - ở trên
        }

        private void CreateInfoLabel(GroupBox parent, string labelText, int x, int y, string valueName)
        {
            Label lblCaption = new Label
            {
                Text = labelText,
                Location = new Point(x, y),
                Size = new Size(150, 30),  // Tăng height
                Font = new Font("Times New Roman", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblValue = new Label
            {
                Name = valueName,
                Location = new Point(x + 155, y),
                Size = new Size(250, 30),  // Tăng height
                Font = new Font("Times New Roman", 11),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(0, 102, 204)
            };

            parent.Controls.AddRange(new Control[] { lblCaption, lblValue });
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

                // Load thông tin nhân viên
                var employee = _employeeBLL.GetEmployeeById(evaluation.MaNhanVien);
                var evaluator = _employeeBLL.GetEmployeeById(evaluation.MaNguoiDanhGia);

                // Hiển thị thông tin chung
                FindControlByName("lblMaDanhGia").Text = evaluation.MaDanhGia;
                FindControlByName("lblNhanVien").Text = employee?.HoTen ?? "N/A";
                FindControlByName("lblNguoiDanhGia").Text = evaluator?.HoTen ?? "N/A";
                FindControlByName("lblNgayDanhGia").Text = evaluation.NgayDanhGia.ToString("dd/MM/yyyy");
                FindControlByName("lblDiem").Text = evaluation.DiemDanhGia.ToString();

                Label lblXepLoai = FindControlByName("lblXepLoai") as Label;
                if (lblXepLoai != null)
                {
                    lblXepLoai.Text = evaluation.XepLoai;
                    lblXepLoai.Font = new Font("Times New Roman", 11, FontStyle.Bold);

                    // Đổi màu xếp loại
                    switch (evaluation.XepLoai?.ToUpper())
                    {
                        case "XUẤT SẮC":
                            lblXepLoai.ForeColor = Color.FromArgb(0, 153, 51);
                            break;
                        case "TỐT":
                            lblXepLoai.ForeColor = Color.FromArgb(0, 123, 255);
                            break;
                        case "KHÁ":
                            lblXepLoai.ForeColor = Color.FromArgb(255, 153, 0);
                            break;
                        case "TRUNG BÌNH":
                            lblXepLoai.ForeColor = Color.FromArgb(255, 102, 0);
                            break;
                        default:
                            lblXepLoai.ForeColor = Color.FromArgb(220, 53, 69);
                            break;
                    }
                }

                // Load chi tiết đánh giá
                var details = _detailBLL.GetByEvaluationId(_maDanhGia);
                DataGridView dgv = FindControlByName("dgvDetails") as DataGridView;

                if (dgv != null)
                {
                    dgv.Rows.Clear();

                    if (details != null && details.Count > 0)
                    {
                        string currentGroup = "";
                        foreach (var detail in details)
                        {
                            string group = GetGroupName(detail.MaTieuChi);

                            // Thêm header nhóm
                            if (group != currentGroup)
                            {
                                int groupRowIndex = dgv.Rows.Add();
                                DataGridViewRow groupRow = dgv.Rows[groupRowIndex];
                                groupRow.Cells["colTieuChi"].Value = group;
                                groupRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
                                groupRow.DefaultCellStyle.ForeColor = Color.White;
                                groupRow.DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                                currentGroup = group;
                            }

                            // Thêm dòng tiêu chí
                            int rowIndex = dgv.Rows.Add();
                            DataGridViewRow row = dgv.Rows[rowIndex];
                            row.Cells["colTieuChi"].Value = "   " + detail.TenTieuChi;
                            row.Cells["colMucDanhGia"].Value = GetLevelText(detail.MucDanhGia);
                            row.Cells["colDiemDat"].Value = detail.DiemDatDuoc;
                            row.Cells["colDiemToiDa"].Value = detail.DiemToiDa;
                            row.Cells["colGhiChu"].Value = detail.GhiChu;

                            // Tô màu theo mức đánh giá
                            if (detail.MucDanhGia == 4)
                                row.DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 218);
                            else if (detail.MucDanhGia == 1)
                                row.DefaultCellStyle.BackColor = Color.FromArgb(248, 215, 218);
                        }
                    }
                    else
                    {
                        dgv.Rows.Add("Không có chi tiết đánh giá theo tiêu chí", "", "", "", "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetGroupName(string maTieuChi)
        {
            if (maTieuChi.StartsWith("TC01")) return "I. Ý THỨC KỶ LUẬT";
            if (maTieuChi.StartsWith("TC02")) return "II. TÁC PHONG LÀM VIỆC";
            if (maTieuChi.StartsWith("TC03")) return "III. QUAN HỆ LÀM VIỆC";
            if (maTieuChi.StartsWith("TC04")) return "IV. HIỆU QUẢ CÔNG VIỆC";
            return "KHÁC";
        }

        private string GetLevelText(int level)
        {
            switch (level)
            {
                case 1: return "Yếu (1)";
                case 2: return "Trung bình (2)";
                case 3: return "Khá (3)";
                case 4: return "Tốt (4)";
                default: return "Chưa đánh giá";
            }
        }

        private Control FindControlByName(string name)
        {
            return FindControlRecursive(this, name);
        }

        private Control FindControlRecursive(Control parent, string name)
        {
            if (parent.Name == name)
                return parent;

            foreach (Control child in parent.Controls)
            {
                Control found = FindControlRecursive(child, name);
                if (found != null)
                    return found;
            }

            return null;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmEvaluationCU form = new frmEvaluationCU(_maDanhGia);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadEvaluationData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}