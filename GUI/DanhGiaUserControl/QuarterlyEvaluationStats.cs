using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.GUI.DanhGiaUserControl
{
    public partial class QuarterlyEvaluationStats : UserControl
    {
        private readonly EvaluationBLL _evaluationBLL;
        private readonly EvaluationFullBLL _evaluationFullBLL;

        private ComboBox cboYear;
        private Panel pnlQuarters;
        private DataGridView dgvStats;

        public QuarterlyEvaluationStats()
        {
            InitializeComponent();
            _evaluationBLL = new EvaluationBLL();
            _evaluationFullBLL = new EvaluationFullBLL();
            InitializeCustomControls();
        }

        private void InitializeCustomControls()
        {
            // Header Panel
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White,
                Padding = new Padding(20, 15, 20, 15)
            };

            Label lblTitle = new Label
            {
                Text = "THỐNG KÊ ĐÁNH GIÁ THEO QUÝ",
                Font = new Font("Times New Roman", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 123, 255),
                Location = new Point(0, 20),
                AutoSize = true
            };
            pnlHeader.Controls.Add(lblTitle);

            // Year selector panel
            Panel pnlYearSelector = new Panel
            {
                Dock = DockStyle.Right,
                Width = 200
            };

            Label lblYear = new Label
            {
                Text = "Năm:",
                Location = new Point(10, 20),
                Font = new Font("Times New Roman", 12, FontStyle.Bold),
                AutoSize = true
            };

            cboYear = new ComboBox
            {
                Location = new Point(60, 17),
                Size = new Size(120, 30),
                Font = new Font("Times New Roman", 12),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboYear.SelectedIndexChanged += CboYear_SelectedIndexChanged;

            // Load years (current year and 5 years back)
            for (int year = DateTime.Now.Year; year >= DateTime.Now.Year - 5; year--)
            {
                cboYear.Items.Add(year);
            }
            cboYear.SelectedIndex = 0;

            pnlYearSelector.Controls.AddRange(new Control[] { lblYear, cboYear });
            pnlHeader.Controls.Add(pnlYearSelector);

            // Quarters Panel (contains 4 quarter cards)
            pnlQuarters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 140,
                BackColor = Color.White,
                Padding = new Padding(20, 10, 20, 10)
            };

            // Create 4 quarter cards
            for (int i = 1; i <= 4; i++)
            {
                CreateQuarterCard(pnlQuarters, i);
            }

            // DataGridView for detailed stats
            dgvStats = new DataGridView
            {
                Dock = DockStyle.Fill,
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

            dgvStats.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                Font = new Font("Times New Roman", 11, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            dgvStats.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Times New Roman", 10),
                SelectionBackColor = Color.FromArgb(204, 229, 255),
                SelectionForeColor = Color.Black
            };

            dgvStats.RowTemplate.Height = 35;

            // Add columns
            dgvStats.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQuarter", HeaderText = "Quý", FillWeight = 60 });
            dgvStats.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMaNV", HeaderText = "Mã NV", FillWeight = 80 });
            dgvStats.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTenNV", HeaderText = "Tên nhân viên", FillWeight = 150 });
            dgvStats.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPhongBan", HeaderText = "Phòng ban", FillWeight = 120 });
            dgvStats.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNgayDG", HeaderText = "Ngày ĐG", FillWeight = 90 });
            dgvStats.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDiem", HeaderText = "Điểm", FillWeight = 60 });
            dgvStats.Columns.Add(new DataGridViewTextBoxColumn { Name = "colXepLoai", HeaderText = "Xếp loại", FillWeight = 90 });

            // Main panel to hold DataGridView
            Panel pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            pnlMain.Controls.Add(dgvStats);

            // Add all controls to UserControl in correct order
            this.Controls.Add(pnlMain);      // Fill - bottom layer
            this.Controls.Add(pnlQuarters);  // Top
            this.Controls.Add(pnlHeader);    // Top

            // Load initial data
            LoadData();
        }

        private void CreateQuarterCard(Panel parent, int quarter)
        {
            int cardWidth = 270;
            int cardHeight = 100;
            int spacing = 20;
            int xPos = (quarter - 1) * (cardWidth + spacing) + 10;

            Panel card = new Panel
            {
                Location = new Point(xPos, 10),
                Size = new Size(cardWidth, cardHeight),
                BackColor = GetQuarterColor(quarter),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = quarter
            };

            // Add hover effect
            card.MouseEnter += (s, e) => card.BackColor = LightenColor(GetQuarterColor(quarter), 20);
            card.MouseLeave += (s, e) => card.BackColor = GetQuarterColor(quarter);

            Label lblQuarter = new Label
            {
                Text = $"QUÝ {quarter}",
                Location = new Point(10, 10),
                Size = new Size(250, 25),
                Font = new Font("Times New Roman", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };

            Label lblDateRange = new Label
            {
                Name = $"lblDateRange{quarter}",
                Text = GetQuarterDateRangeText(quarter, DateTime.Now.Year),
                Location = new Point(10, 35),
                Size = new Size(250, 20),
                Font = new Font("Times New Roman", 9),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };

            Label lblCount = new Label
            {
                Name = $"lblCount{quarter}",
                Text = "0 đánh giá",
                Location = new Point(10, 60),
                Size = new Size(250, 30),
                Font = new Font("Times New Roman", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Make child controls also trigger click
            lblQuarter.Click += (s, e) => FilterByQuarter(quarter);
            lblDateRange.Click += (s, e) => FilterByQuarter(quarter);
            lblCount.Click += (s, e) => FilterByQuarter(quarter);

            card.Controls.AddRange(new Control[] { lblQuarter, lblDateRange, lblCount });
            card.Click += (s, e) => FilterByQuarter(quarter);

            parent.Controls.Add(card);
        }

        private Color GetQuarterColor(int quarter)
        {
            switch (quarter)
            {
                case 1: return Color.FromArgb(0, 123, 255);      // Blue
                case 2: return Color.FromArgb(40, 167, 69);      // Green
                case 3: return Color.FromArgb(255, 193, 7);      // Yellow/Orange
                case 4: return Color.FromArgb(220, 53, 69);      // Red
                default: return Color.Gray;
            }
        }

        private Color LightenColor(Color color, int amount)
        {
            return Color.FromArgb(
                Math.Min(255, color.R + amount),
                Math.Min(255, color.G + amount),
                Math.Min(255, color.B + amount)
            );
        }

        private string GetQuarterDateRangeText(int quarter, int year)
        {
            var tempDate = new DateTime(year, quarter * 3, 1);
            var (startDate, endDate) = _evaluationBLL.GetQuarterDateRange(tempDate);
            return $"{startDate:dd/MM} - {endDate:dd/MM}/{year}";
        }

        private void CboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (cboYear.SelectedItem == null) return;

            int year = (int)cboYear.SelectedItem;

            // Update quarter cards
            for (int quarter = 1; quarter <= 4; quarter++)
            {
                var evaluations = _evaluationBLL.GetByQuarter(quarter, year);

                var lblCount = pnlQuarters.Controls.Find($"lblCount{quarter}", true).FirstOrDefault() as Label;
                var lblDateRange = pnlQuarters.Controls.Find($"lblDateRange{quarter}", true).FirstOrDefault() as Label;

                if (lblCount != null)
                {
                    lblCount.Text = $"{evaluations.Count} đánh giá";
                }

                if (lblDateRange != null)
                {
                    lblDateRange.Text = GetQuarterDateRangeText(quarter, year);
                }
            }

            // Load all evaluations for the year
            LoadYearEvaluations(year);
        }

        private void LoadYearEvaluations(int year)
        {
            dgvStats.Rows.Clear();

            var allEvaluations = _evaluationFullBLL.GetAllEvaluationsFull()
                .Where(e => e.NgayDanhGia.Year == year)
                .OrderBy(e => _evaluationBLL.GetQuarter(e.NgayDanhGia))
                .ThenBy(e => e.NgayDanhGia)
                .ToList();

            if (allEvaluations.Count == 0)
            {
                // Show message if no data
                int rowIndex = dgvStats.Rows.Add();
                dgvStats.Rows[rowIndex].Cells["colTenNV"].Value = $"Không có dữ liệu đánh giá năm {year}";
                return;
            }

            foreach (var eval in allEvaluations)
            {
                int quarter = _evaluationBLL.GetQuarter(eval.NgayDanhGia);
                int rowIndex = dgvStats.Rows.Add();
                DataGridViewRow row = dgvStats.Rows[rowIndex];

                row.Cells["colQuarter"].Value = $"Q{quarter}";
                row.Cells["colMaNV"].Value = eval.MaNhanVien;
                row.Cells["colTenNV"].Value = eval.TenNhanVien;
                row.Cells["colPhongBan"].Value = eval.PhongBan;
                row.Cells["colNgayDG"].Value = eval.NgayDanhGia.ToString("dd/MM/yyyy");
                row.Cells["colDiem"].Value = eval.DiemDanhGia;
                row.Cells["colXepLoai"].Value = eval.XepLoai;

                // Color quarter column by quarter
                row.Cells["colQuarter"].Style.BackColor = GetQuarterColor(quarter);
                row.Cells["colQuarter"].Style.ForeColor = Color.White;
                row.Cells["colQuarter"].Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);

                // Color by rating
                ApplyRankingColor(row, eval.XepLoai);
            }
        }

        private void FilterByQuarter(int quarter)
        {
            if (cboYear.SelectedItem == null) return;

            int year = (int)cboYear.SelectedItem;
            dgvStats.Rows.Clear();

            var evaluations = _evaluationFullBLL.GetAllEvaluationsFull()
                .Where(e => e.NgayDanhGia.Year == year && _evaluationBLL.GetQuarter(e.NgayDanhGia) == quarter)
                .OrderBy(e => e.NgayDanhGia)
                .ToList();

            if (evaluations.Count == 0)
            {
                int rowIndex = dgvStats.Rows.Add();
                dgvStats.Rows[rowIndex].Cells["colTenNV"].Value = $"Không có dữ liệu Quý {quarter}/{year}";
                return;
            }

            foreach (var eval in evaluations)
            {
                int rowIndex = dgvStats.Rows.Add();
                DataGridViewRow row = dgvStats.Rows[rowIndex];

                row.Cells["colQuarter"].Value = $"Q{quarter}";
                row.Cells["colMaNV"].Value = eval.MaNhanVien;
                row.Cells["colTenNV"].Value = eval.TenNhanVien;
                row.Cells["colPhongBan"].Value = eval.PhongBan;
                row.Cells["colNgayDG"].Value = eval.NgayDanhGia.ToString("dd/MM/yyyy");
                row.Cells["colDiem"].Value = eval.DiemDanhGia;
                row.Cells["colXepLoai"].Value = eval.XepLoai;

                row.Cells["colQuarter"].Style.BackColor = GetQuarterColor(quarter);
                row.Cells["colQuarter"].Style.ForeColor = Color.White;
                row.Cells["colQuarter"].Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);

                ApplyRankingColor(row, eval.XepLoai);
            }
        }

        private void ApplyRankingColor(DataGridViewRow row, string xepLoai)
        {
            if (string.IsNullOrEmpty(xepLoai)) return;

            switch (xepLoai.ToUpper())
            {
                case "XUẤT SẮC":
                case "A":
                    row.Cells["colXepLoai"].Style.BackColor = Color.FromArgb(40, 167, 69);
                    row.Cells["colXepLoai"].Style.ForeColor = Color.White;
                    row.Cells["colXepLoai"].Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                    break;
                case "TỐT":
                case "B":
                    row.Cells["colXepLoai"].Style.BackColor = Color.FromArgb(0, 123, 255);
                    row.Cells["colXepLoai"].Style.ForeColor = Color.White;
                    row.Cells["colXepLoai"].Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                    break;
                case "KHÁ":
                case "C":
                    row.Cells["colXepLoai"].Style.BackColor = Color.FromArgb(255, 193, 7);
                    row.Cells["colXepLoai"].Style.ForeColor = Color.Black;
                    row.Cells["colXepLoai"].Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                    break;
                case "TRUNG BÌNH":
                case "D":
                    row.Cells["colXepLoai"].Style.BackColor = Color.FromArgb(255, 152, 0);
                    row.Cells["colXepLoai"].Style.ForeColor = Color.White;
                    row.Cells["colXepLoai"].Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                    break;
                case "YẾU":
                case "F":
                    row.Cells["colXepLoai"].Style.BackColor = Color.FromArgb(220, 53, 69);
                    row.Cells["colXepLoai"].Style.ForeColor = Color.White;
                    row.Cells["colXepLoai"].Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                    break;
            }
        }

        /// <summary>
        /// Public method để refresh data từ bên ngoài
        /// </summary>
        public void RefreshData()
        {
            LoadData();
        }
    }
}