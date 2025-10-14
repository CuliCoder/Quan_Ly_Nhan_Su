using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.TaiKhoanUserControl
{
    public partial class TaiKhoanMain : UserControl
    {
        // Khai báo các lớp BLL cần thiết
        private readonly PermissionGroupBLL permissionGroupBLL = new PermissionGroupBLL();
        private readonly FunctionBLL functionBLL = new FunctionBLL();
        private readonly PermissionDetailBLL permissionDetailBLL = new PermissionDetailBLL();

        // Biến lưu danh sách TẤT CẢ các chức năng của hệ thống
        private List<FunctionDTO> allFunctions;

        public TaiKhoanMain()
        {
            InitializeComponent();
            // Cấu hình TabControl
            this.tabMain.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabMain.Appearance = TabAppearance.Buttons;
            this.tabMain.SizeMode = TabSizeMode.Fixed;
            this.tabMain.ItemSize = new Size(120, 35);

            // Gắn các sự kiện
            this.tabMain.DrawItem += new DrawItemEventHandler(tabMain_DrawItem);
            this.Load += TaiKhoanMain_Load;
            this.dgvPhanQuyen.SelectionChanged += dgvPhanQuyen_SelectionChanged;
            this.btnLuuQuyen.Click += btnLuuQuyen_Click;

            // Gắn sự kiện cho CRUD Chức năng
            this.btnThemCn.Click += btnThemCn_Click;
            this.btnSuaCn.Click += btnSuaCn_Click;
            this.btnXoaCn.Click += btnXoaCn_Click;

            // Gắn sự kiện cho CRUD Phân quyền
            this.btnThemPq.Click += btnThemPq_Click;
            // this.btnSuaPq.Click += btnSuaPq_Click; // Uncomment if you have these buttons
            // this.btnXoaPq.Click += btnXoaPq_Click;
        }

        private void TaiKhoanMain_Load(object sender, EventArgs e)
        {
            // Khi form được tải, thực hiện các công việc khởi tạo
            ConfigurePermissionDetailsGrid();
            LoadPermissionGroups();
            // Tải tất cả dữ liệu chức năng (cho cả 2 tab) chỉ trong 1 lần gọi
            ReloadAllFunctionData();
        }

        #region Chức Năng (Tab 2) - CRUD Events

        private void btnThemCn_Click(object sender, EventArgs e)
        {
            using (var form = new frmFunctionCU())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var newFunction = form.FunctionData;
                        if (functionBLL.Create(newFunction))
                        {
                            MessageBox.Show("Thêm chức năng thành công!");
                            ReloadAllFunctionData(); // Tải lại dữ liệu cho cả hai tab
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm chức năng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSuaCn_Click(object sender, EventArgs e)
        {
            if (dgvChucNang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một chức năng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int functionId = Convert.ToInt32(dgvChucNang.CurrentRow.Cells["colCnMa"].Value);
                // Lấy thông tin chức năng một cách hiệu quả bằng GetById
                var currentFunction = functionBLL.GetById(functionId);

                if (currentFunction == null)
                {
                    MessageBox.Show("Không tìm thấy chức năng này. Dữ liệu có thể đã được thay đổi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ReloadAllFunctionData();
                    return;
                }

                using (var form = new frmFunctionCU(currentFunction))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var updatedFunction = form.FunctionData;
                        if (functionBLL.Update(updatedFunction))
                        {
                            MessageBox.Show("Cập nhật chức năng thành công!");
                            ReloadAllFunctionData(); // Tải lại dữ liệu cho cả hai tab
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa chức năng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaCn_Click(object sender, EventArgs e)
        {
            if (dgvChucNang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một chức năng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chức năng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int functionId = Convert.ToInt32(dgvChucNang.CurrentRow.Cells["colCnMa"].Value);
                    if (functionBLL.Delete(functionId))
                    {
                        MessageBox.Show("Xóa chức năng thành công!");
                        ReloadAllFunctionData(); // Tải lại dữ liệu cho cả hai tab
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa chức năng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Phân Quyền (Tab 1) - Events and Methods

        private void btnThemPq_Click(object sender, EventArgs e)
        {
            using (var form = new frmPermissionGroupCU())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var newGroup = form.GroupData;
                        permissionGroupBLL.Insert(newGroup);
                        MessageBox.Show("Thêm nhóm quyền thành công!");
                        LoadPermissionGroups(); // Chỉ cần tải lại nhóm quyền
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm nhóm quyền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvPhanQuyen_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhanQuyen.CurrentRow == null)
            {
                dgvChiTietQuyen.Rows.Clear();
                return;
            }
            int selectedGroupId = Convert.ToInt32(dgvPhanQuyen.CurrentRow.Cells["colPqMaNhom"].Value);
            LoadPermissionsForGroup(selectedGroupId);
        }

        private void btnLuuQuyen_Click(object sender, EventArgs e)
        {
            if (dgvPhanQuyen.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhóm quyền để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedGroupId = Convert.ToInt32(dgvPhanQuyen.CurrentRow.Cells["colPqMaNhom"].Value);
            var permissionsToSave = new List<PermissionDetailDTO>();

            foreach (DataGridViewRow row in dgvChiTietQuyen.Rows)
            {
                permissionsToSave.Add(new PermissionDetailDTO
                {
                    PermissionGroupID = selectedGroupId,
                    FunctionID = Convert.ToInt32(row.Cells["colCnId"].Value),
                    CanRead = Convert.ToBoolean(row.Cells["colCnRead"].Value ?? false),
                    CanCreate = Convert.ToBoolean(row.Cells["colCnCreate"].Value ?? false),
                    CanUpdate = Convert.ToBoolean(row.Cells["colCnUpdate"].Value ?? false),
                    CanDelete = Convert.ToBoolean(row.Cells["colCnDelete"].Value ?? false)
                });
            }

            try
            {
                if (permissionDetailBLL.SavePermissions(selectedGroupId, permissionsToSave))
                {
                    MessageBox.Show("Lưu quyền thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lưu quyền thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình lưu: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Data Loading and Configuration

        /// <summary>
        /// *** TỐI ƯU HÓA ***
        /// Tải hoặc tải lại TOÀN BỘ dữ liệu chức năng từ CSDL.
        /// Cập nhật cả danh sách allFunctions và DataGridView dgvChucNang.
        /// </summary>
        private void ReloadAllFunctionData()
        {
            try
            {
                // 1. Lấy dữ liệu từ BLL (chỉ gọi CSDL một lần)
                allFunctions = functionBLL.GetAll();

                // 2. Xóa dữ liệu cũ trên grid
                dgvChucNang.Rows.Clear();

                // 3. Hiển thị dữ liệu mới lên grid
                foreach (var func in allFunctions)
                {
                    dgvChucNang.Rows.Add(func.MaChucNang, func.TenChucNang, func.TinhTrang ? "Hoạt động" : "Không hoạt động");
                }

                // 4. Tải lại chi tiết quyền cho nhóm đang chọn (nếu có)
                if (dgvPhanQuyen.CurrentRow != null)
                {
                    int selectedGroupId = Convert.ToInt32(dgvPhanQuyen.CurrentRow.Cells["colPqMaNhom"].Value);
                    LoadPermissionsForGroup(selectedGroupId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chức năng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allFunctions = new List<FunctionDTO>(); // Đảm bảo list không bị null
            }
        }

        private void LoadPermissionGroups()
        {
            try
            {
                var groups = permissionGroupBLL.GetAll();
                dgvPhanQuyen.DataSource = groups;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhóm quyền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPermissionsForGroup(int groupId)
        {
            try
            {
                var currentPermissions = permissionDetailBLL.GetByGroupId(groupId)
                                                            .ToDictionary(p => p.FunctionID);
                dgvChiTietQuyen.Rows.Clear();

                foreach (var func in allFunctions)
                {
                    int rowIndex = dgvChiTietQuyen.Rows.Add();
                    var row = dgvChiTietQuyen.Rows[rowIndex];

                    row.Cells["colCnId"].Value = func.MaChucNang;
                    row.Cells["colCnTen"].Value = func.TenChucNang;

                    if (currentPermissions.TryGetValue(func.MaChucNang, out var permission))
                    {
                        row.Cells["colCnRead"].Value = permission.CanRead;
                        row.Cells["colCnCreate"].Value = permission.CanCreate;
                        row.Cells["colCnUpdate"].Value = permission.CanUpdate;
                        row.Cells["colCnDelete"].Value = permission.CanDelete;
                    }
                    else
                    {
                        row.Cells["colCnRead"].Value = false;
                        row.Cells["colCnCreate"].Value = false;
                        row.Cells["colCnUpdate"].Value = false;
                        row.Cells["colCnDelete"].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết quyền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurePermissionDetailsGrid()
        {
            dgvChiTietQuyen.AutoGenerateColumns = false;
            dgvChiTietQuyen.Columns.Clear();
            dgvChiTietQuyen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCnId", DataPropertyName = "FunctionID", Visible = false });
            dgvChiTietQuyen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCnTen", HeaderText = "Tên Chức Năng", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvChiTietQuyen.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colCnRead", HeaderText = "Xem", Width = 60 });
            dgvChiTietQuyen.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colCnCreate", HeaderText = "Thêm", Width = 60 });
            dgvChiTietQuyen.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colCnUpdate", HeaderText = "Sửa", Width = 60 });
            dgvChiTietQuyen.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colCnDelete", HeaderText = "Xóa", Width = 60 });
        }

        #endregion

        #region UI Drawing (Giữ nguyên)

        private void tabMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush textBrush;
            TabPage tabPage = this.tabMain.TabPages[e.Index];
            Rectangle tabBounds = this.tabMain.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, 240, 229)), e.Bounds);
                textBrush = new SolidBrush(Color.Black);
            }
            else
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(236, 236, 236)), e.Bounds);
                textBrush = new SolidBrush(Color.Gray);
            }

            Font tabFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            StringFormat stringFlags = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(tabPage.Text, tabFont, textBrush, tabBounds, new StringFormat(stringFlags));
        }

        #endregion
    }
}