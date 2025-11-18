using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.GUI.DanhGiaUserControl
{
    public partial class frmEvaluationCU : Form
    {
        private readonly EvaluationBLL _evaluationBLL;
        private readonly EmployeeFullBLL _employeeBLL;
        private readonly string _maDanhGia;
        private bool _isEditMode;

        /// <summary>
        /// Constructor cho chế độ thêm mới
        /// </summary>
        public frmEvaluationCU()
        {
            InitializeComponent();
            _evaluationBLL = new EvaluationBLL();
            _employeeBLL = new EmployeeFullBLL();
            _isEditMode = false;
            _maDanhGia = GenerateNewCode();
        }

        /// <summary>
        /// Constructor cho chế độ sửa
        /// </summary>
        public frmEvaluationCU(string maDanhGia) : this()
        {
            _maDanhGia = maDanhGia;
            _isEditMode = true;
        }

        private void frmEvaluationCU_Load(object sender, EventArgs e)
        {
            try
            {
                // Cấu hình NumericUpDown
                numDiem.Minimum = 0;
                numDiem.Maximum = 100;
                numDiem.Value = 0;

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load danh sách nhân viên
        /// </summary>
        private void LoadEmployees()
        {
            try
            {
                var employees = _employeeBLL.GetAllEmployees();

                // Combobox nhân viên được đánh giá
                cboNhanVien.DataSource = employees.ToList();
                cboNhanVien.DisplayMember = "HoTen";
                cboNhanVien.ValueMember = "MaNhanVien";

                // Combobox người đánh giá
                cboNguoiDanhGia.DataSource = employees.ToList();
                cboNguoiDanhGia.DisplayMember = "HoTen";
                cboNguoiDanhGia.ValueMember = "MaNhanVien";

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

        /// <summary>
        /// Load dữ liệu đánh giá (chế độ sửa)
        /// </summary>
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tự động cập nhật xếp loại khi thay đổi điểm
        /// </summary>
        private void numDiem_ValueChanged(object sender, EventArgs e)
        {
            int diem = (int)numDiem.Value;
            string xepLoai = GetRankingByScore(diem);
            txtXepLoai.Text = xepLoai;
        }

        /// <summary>
        /// Xác định xếp loại theo điểm
        /// </summary>
        private string GetRankingByScore(int score)
        {
            if (score >= 90) return "Xuất sắc";
            if (score >= 80) return "Tốt";
            if (score >= 70) return "Khá";
            if (score >= 50) return "Trung bình";
            return "Yếu";
        }

        /// <summary>
        /// Validate dữ liệu
        /// </summary>
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

            if (numDiem.Value < 0 || numDiem.Value > 100)
            {
                MessageBox.Show("Điểm đánh giá phải từ 0 đến 100!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDiem.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
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
                    ChiTietDanhGia = txtChiTiet.Text.Trim(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                bool success;
                if (_isEditMode)
                {
                    success = _evaluationBLL.Update(evaluation);
                    if (success)
                    {
                        MessageBox.Show("Cập nhật đánh giá thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    success = _evaluationBLL.Insert(evaluation);
                    if (success)
                    {
                        MessageBox.Show("Thêm đánh giá thành công!",
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
                MessageBox.Show($"Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hủy bỏ
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Tạo mã đánh giá mới
        /// </summary>
        private string GenerateNewCode()
        {
            return "DG" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}