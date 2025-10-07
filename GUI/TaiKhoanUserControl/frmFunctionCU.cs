using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.TaiKhoanUserControl
{
    public partial class frmFunctionCU : Form
    {
        // Dùng một thuộc tính public để lưu trữ dữ liệu trả về
        public FunctionDTO FunctionData { get; private set; }
        private bool isUpdateMode = false;

        // Constructor cho chế độ TẠO MỚI
        public frmFunctionCU()
        {
            InitializeComponent();
            this.Text = "Thêm Chức Năng Mới";
            chkTinhTrang.Checked = true; // Mặc định là hoạt động
        }

        // Constructor cho chế độ CẬP NHẬT (truyền vào dữ liệu cũ)
        public frmFunctionCU(FunctionDTO currentFunction)
        {
            InitializeComponent();
            this.Text = "Cập Nhật Chức Năng";
            isUpdateMode = true;

            // Nạp dữ liệu cũ lên form
            FunctionData = currentFunction;
            txtTenChucNang.Text = currentFunction.TenChucNang;
            chkTinhTrang.Checked = currentFunction.TinhTrang;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenChucNang.Text))
            {
                MessageBox.Show("Tên chức năng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu là chế độ cập nhật, giữ nguyên MaChucNang cũ
            if (isUpdateMode)
            {
                FunctionData.TenChucNang = txtTenChucNang.Text.Trim();
                FunctionData.TinhTrang = chkTinhTrang.Checked;
            }
            else // Chế độ tạo mới
            {
                FunctionData = new FunctionDTO
                {
                    TenChucNang = txtTenChucNang.Text.Trim(),
                    TinhTrang = chkTinhTrang.Checked
                };
            }

            this.DialogResult = DialogResult.OK; // Đánh dấu là thành công
            this.Close(); // Đóng form
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}