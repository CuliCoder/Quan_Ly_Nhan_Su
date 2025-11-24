using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.GUI.DanhGiaUserControl
{
    public partial class DanhGia : UserControl
    {
        private readonly EvaluationFullBLL _evaluationBLL;
        private readonly EvaluationBLL _evaluationCRUDBLL;
        private List<EvaluationFullDTO> _currentData;

        public DanhGia()
        {
            InitializeComponent();
            _evaluationBLL = new EvaluationFullBLL();
            _evaluationCRUDBLL = new EvaluationBLL();
            _currentData = new List<EvaluationFullDTO>();
        }

        private void DanhGia_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo DateTimePicker
                dtpFromDate.Value = DateTime.Now.AddMonths(-1);
                dtpToDate.Value = DateTime.Now;

                LoadEvaluations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải danh sách đánh giá
        /// </summary>
        private void LoadEvaluations()
        {
            try
            {
                _currentData = _evaluationBLL.GetAllEvaluationsFull();
                BindDataToGrid(_currentData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đánh giá: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind dữ liệu vào DataGridView
        /// </summary>
        private void BindDataToGrid(List<EvaluationFullDTO> data)
        {
            dgvEvaluations.Rows.Clear();

            if (data == null || data.Count == 0)
            {
                return;
            }

            int stt = 1;
            foreach (var item in data)
            {
                int rowIndex = dgvEvaluations.Rows.Add();
                DataGridViewRow row = dgvEvaluations.Rows[rowIndex];

                row.Cells["colSTT"].Value = stt++;
                row.Cells["colMaDanhGia"].Value = item.MaDanhGia;
                row.Cells["colMaNhanVien"].Value = item.MaNhanVien;
                row.Cells["colTenNhanVien"].Value = item.TenNhanVien;
                row.Cells["colPhongBan"].Value = item.PhongBan;
                row.Cells["colNgayDanhGia"].Value = item.NgayDanhGia.ToString("dd/MM/yyyy");
                row.Cells["colTenNguoiDanhGia"].Value = item.TenNguoiDanhGia;
                row.Cells["colDiemDanhGia"].Value = item.DiemDanhGia;
                row.Cells["colXepLoai"].Value = item.XepLoai;

                // Tô màu theo xếp loại
                ApplyRankingColor(row, item.XepLoai);

                // Lưu tag để dễ truy xuất
                row.Tag = item;
            }
        }

        /// <summary>
        /// Tô màu theo xếp loại
        /// </summary>
        private void ApplyRankingColor(DataGridViewRow row, string xepLoai)
        {
            if (string.IsNullOrEmpty(xepLoai)) return;

            switch (xepLoai.ToUpper())
            {
                case "XUẤT SẮC":
                case "A":
                    row.Cells["colXepLoai"].Style.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
                    row.Cells["colXepLoai"].Style.ForeColor = System.Drawing.Color.White;
                    break;
                case "TỐT":
                case "B":
                    row.Cells["colXepLoai"].Style.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
                    row.Cells["colXepLoai"].Style.ForeColor = System.Drawing.Color.White;
                    break;
                case "KHÁ":
                case "C":
                    row.Cells["colXepLoai"].Style.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
                    row.Cells["colXepLoai"].Style.ForeColor = System.Drawing.Color.Black;
                    break;
                case "TRUNG BÌNH":
                case "D":
                    row.Cells["colXepLoai"].Style.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
                    row.Cells["colXepLoai"].Style.ForeColor = System.Drawing.Color.White;
                    break;
                case "YẾU":
                case "F":
                    row.Cells["colXepLoai"].Style.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
                    row.Cells["colXepLoai"].Style.ForeColor = System.Drawing.Color.White;
                    break;
            }
        }

        /// <summary>
        /// Tìm kiếm
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();

                if (string.IsNullOrEmpty(keyword))
                {
                    LoadEvaluations();
                    return;
                }

                _currentData = _evaluationBLL.Search(keyword);
                BindDataToGrid(_currentData);

                if (_currentData.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Enter để tìm kiếm
        /// </summary>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Lọc theo ngày
        /// </summary>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _currentData = _evaluationBLL.FilterByDate(fromDate, toDate);
                BindDataToGrid(_currentData);

                if (_currentData.Count == 0)
                {
                    MessageBox.Show($"Không có đánh giá nào từ {fromDate:dd/MM/yyyy} đến {toDate:dd/MM/yyyy}!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reset bộ lọc
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpToDate.Value = DateTime.Now;
            LoadEvaluations();
        }

        /// <summary>
        /// Thêm đánh giá mới
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Mở form thêm đánh giá
                frmEvaluationCU form = new frmEvaluationCU();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadEvaluations();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xem chi tiết đánh giá
        /// </summary>
        private void btnDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEvaluations.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một đánh giá để xem chi tiết!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedEvaluation = dgvEvaluations.SelectedRows[0].Tag as EvaluationFullDTO;
                if (selectedEvaluation == null) return;

                // TODO: Mở form chi tiết
                // frmEvaluationDetail form = new frmEvaluationDetail(selectedEvaluation.MaDanhGia);
                // form.ShowDialog();

                MessageBox.Show($"Chi tiết đánh giá:\n\n" +
                    $"Mã: {selectedEvaluation.MaDanhGia}\n" +
                    $"Nhân viên: {selectedEvaluation.TenNhanVien}\n" +
                    $"Ngày: {selectedEvaluation.NgayDanhGia:dd/MM/yyyy}\n" +
                    $"Người đánh giá: {selectedEvaluation.TenNguoiDanhGia}\n" +
                    $"Điểm: {selectedEvaluation.DiemDanhGia}\n" +
                    $"Xếp loại: {selectedEvaluation.XepLoai}\n" +
                    $"Chi tiết: {selectedEvaluation.ChiTietDanhGia}",
                    "Chi tiết đánh giá", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa đánh giá
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEvaluations.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn đánh giá cần xóa!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedEvaluation = dgvEvaluations.SelectedRows[0].Tag as EvaluationFullDTO;
                if (selectedEvaluation == null) return;

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa đánh giá của nhân viên '{selectedEvaluation.TenNhanVien}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = _evaluationCRUDBLL.Delete(selectedEvaluation.MaDanhGia);

                    if (success)
                    {
                        MessageBox.Show("Xóa đánh giá thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEvaluations();
                    }
                    else
                    {
                        MessageBox.Show("Xóa đánh giá thất bại!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Làm mới dữ liệu (public method để gọi từ form cha)
        /// </summary>
        public void RefreshData()
        {
            LoadEvaluations();
        }
    }
}