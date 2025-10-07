using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class frmPermissionGroupCU : Form
    {
        public PermissionGroupDTO GroupData { get; private set; }
        private bool isUpdateMode = false;

        public frmPermissionGroupCU()
        {
            InitializeComponent();
            this.Text = "Thêm Nhóm Quyền Mới";
        }

        public frmPermissionGroupCU(PermissionGroupDTO currentGroup)
        {
            InitializeComponent();
            this.Text = "Cập Nhật Nhóm Quyền";
            isUpdateMode = true;

            GroupData = currentGroup;
            txtTenNhomQuyen.Text = currentGroup.TenNhomQuyen;
            txtMoTa.Text = currentGroup.MoTa;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNhomQuyen.Text))
            {
                MessageBox.Show("Tên nhóm quyền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isUpdateMode)
            {
                GroupData.TenNhomQuyen = txtTenNhomQuyen.Text.Trim();
                GroupData.MoTa = txtMoTa.Text.Trim();
            }
            else
            {
                GroupData = new PermissionGroupDTO
                {
                    TenNhomQuyen = txtTenNhomQuyen.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim()
                };
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}