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
        // Khai báo các lớp BLL cần thiết để tương tác với logic và CSDL
        private readonly PermissionGroupBLL permissionGroupBLL = new PermissionGroupBLL();
        private readonly FunctionBLL functionBLL = new FunctionBLL();
        private readonly PermissionDetailBLL permissionDetailBLL = new PermissionDetailBLL();

        // Biến này sẽ lưu danh sách TẤT CẢ các chức năng có trong hệ thống
        // Tải một lần để tái sử dụng, tránh gọi CSDL nhiều lần
        private List<FunctionDTO> allFunctions;

        public TaiKhoanMain()
        {
            InitializeComponent();
            // Cấu hình để tùy chỉnh TabControl
            this.tabMain.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabMain.Appearance = TabAppearance.Buttons;
            this.tabMain.SizeMode = TabSizeMode.Fixed;
            this.tabMain.ItemSize = new Size(120, 35);

            // Gắn các sự kiện
            this.tabMain.DrawItem += new DrawItemEventHandler(tabMain_DrawItem);
            this.Load += TaiKhoanMain_Load; // Sự kiện khi UserControl được tải
            this.dgvPhanQuyen.SelectionChanged += dgvPhanQuyen_SelectionChanged; // Khi chọn nhóm quyền
            this.btnLuuQuyen.Click += btnLuuQuyen_Click; // Khi nhấn nút Lưu

            // Gắn sự kiện cho các nút CRUD Chức năng
            this.btnThemCn.Click += btnThemCn_Click;
            this.btnSuaCn.Click += btnSuaCn_Click;
            this.btnXoaCn.Click += btnXoaCn_Click;

            // Gắn sự kiện cho các nút CRUD Phân quyền 
            this.btnThemPq.Click += btnThemPq_Click;
            // Bạn cần tự thêm 2 nút btnSuaPq và btnXoaPq vào Designer
            // this.btnSuaPq.Click += btnSuaPq_Click;
            // this.btnXoaPq.Click += btnXoaPq_Click;
        }

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
                        LoadPermissionGroups(); // Tải lại lưới
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm nhóm quyền: " + ex.Message);
                    }
                }
            }
        }

        // Sửa Nhóm quyền (btnSuaPq)
        // Tương tự btnSuaCn, bạn tự hoàn thiện nhé!

        // Xóa Nhóm Quyền (btnXoaPq)
        private void btnXoaPq_Click(object sender, EventArgs e)
        {
            if (dgvPhanQuyen.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhóm quyền để xóa.");
                return;
            }

            if (MessageBox.Show("Xóa nhóm quyền sẽ xóa TẤT CẢ các quyền chi tiết đã cấp. Bạn có chắc chắn?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int groupId = Convert.ToInt32(dgvPhanQuyen.CurrentRow.Cells["colPqMaNhom"].Value);
                    permissionGroupBLL.Delete(groupId); // Đây là soft delete (chuyển TinhTrang = 0)
                    MessageBox.Show("Xóa nhóm quyền thành công!");
                    LoadPermissionGroups(); // Tải lại
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhóm quyền: " + ex.Message);
                }
            }
        }

        private void LoadDataForChucNang()
        {
            try
            {
                dgvChucNang.Rows.Clear();
                var functions = functionBLL.GetAll();
                foreach (var func in functions)
                {
                    dgvChucNang.Rows.Add(func.MaChucNang, func.TenChucNang, func.TinhTrang ? "Hoạt động" : "Không hoạt động");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chức năng: " + ex.Message);
            }
        }

        private void btnThemCn_Click(object sender, EventArgs e)
        {
            using (var form = new frmFunctionCU())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var newFunction = form.FunctionData;
                        functionBLL.Create(newFunction);
                        MessageBox.Show("Thêm chức năng thành công!");
                        LoadDataForChucNang(); // Tải lại lưới
                        LoadAllFunctions(); // Cập nhật lại danh sách cho tab Phân Quyền
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm chức năng: " + ex.Message);
                    }
                }
            }
        }

        private void btnSuaCn_Click(object sender, EventArgs e)
        {
            if (dgvChucNang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một chức năng để sửa.");
                return;
            }

            try
            {
                // Lấy ID từ dòng đang chọn và lấy toàn bộ object từ BLL
                int functionId = Convert.ToInt32(dgvChucNang.CurrentRow.Cells["colCnMa"].Value);
                var currentFunction = functionBLL.GetAll().FirstOrDefault(f => f.MaChucNang == functionId);

                if (currentFunction == null)
                {
                    MessageBox.Show("Không tìm thấy chức năng!");
                    return;
                }

                using (var form = new frmFunctionCU(currentFunction))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var updatedFunction = form.FunctionData;
                        functionBLL.Update(updatedFunction);
                        MessageBox.Show("Cập nhật chức năng thành công!");
                        LoadDataForChucNang(); // Tải lại lưới
                        LoadAllFunctions(); // Cập nhật lại danh sách cho tab Phân Quyền
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa chức năng: " + ex.Message);
            }
        }

        private void btnXoaCn_Click(object sender, EventArgs e)
        {
            if (dgvChucNang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một chức năng để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chức năng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int functionId = Convert.ToInt32(dgvChucNang.CurrentRow.Cells["colCnMa"].Value);
                    functionBLL.Delete(functionId);
                    MessageBox.Show("Xóa chức năng thành công!");
                    LoadDataForChucNang(); // Tải lại lưới
                    LoadAllFunctions(); // Cập nhật lại danh sách cho tab Phân Quyền
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa chức năng: " + ex.Message);
                }
            }
        }

        private void TaiKhoanMain_Load(object sender, EventArgs e)
        {
            // Khi form được tải lên, thực hiện các công việc khởi tạo
            ConfigurePermissionDetailsGrid(); // Cấu hình các cột cho lưới chi tiết quyền
            LoadAllFunctions(); // Tải tất cả chức năng từ CSDL
            LoadPermissionGroups(); // Tải tất cả nhóm quyền
            LoadDataForChucNang();
        }

        private void ConfigurePermissionDetailsGrid()
        {
            // Hàm này thiết lập các cột cho DataGridView dgvChiTietQuyen
            dgvChiTietQuyen.AutoGenerateColumns = false;
            dgvChiTietQuyen.Columns.Clear();

            // Cột Mã Chức Năng (để lưu ID, nhưng ẩn đi không cho người dùng thấy)
            dgvChiTietQuyen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCnId", DataPropertyName = "FunctionID", Visible = false });
            // Cột Tên Chức Năng (chỉ đọc)
            dgvChiTietQuyen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCnTen", HeaderText = "Tên Chức Năng", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            // Các cột CheckBox cho từng quyền
            dgvChiTietQuyen.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colCnRead", HeaderText = "Xem", Width = 60 });
            dgvChiTietQuyen.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colCnCreate", HeaderText = "Thêm", Width = 60 });
            dgvChiTietQuyen.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colCnUpdate", HeaderText = "Sửa", Width = 60 });
            dgvChiTietQuyen.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colCnDelete", HeaderText = "Xóa", Width = 60 });
        }

        private void LoadAllFunctions()
        {
            try
            {
                allFunctions = functionBLL.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chức năng: " + ex.Message);
                allFunctions = new List<FunctionDTO>(); // Khởi tạo rỗng để tránh lỗi
            }
        }

        private void LoadPermissionGroups()
        {
            try
            {
                // Tải danh sách nhóm quyền và hiển thị lên dgvPhanQuyen
                var groups = permissionGroupBLL.GetAll();
                dgvPhanQuyen.AutoGenerateColumns = false; // Tắt tự động tạo cột
                dgvPhanQuyen.DataSource = groups;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhóm quyền: " + ex.Message);
            }
        }

        private void dgvPhanQuyen_SelectionChanged(object sender, EventArgs e)
        {
            // Sự kiện này được kích hoạt mỗi khi người dùng chọn một dòng (nhóm quyền) khác
            if (dgvPhanQuyen.CurrentRow == null)
            {
                dgvChiTietQuyen.Rows.Clear(); // Nếu không có dòng nào được chọn, xóa trắng lưới bên phải
                return;
            }

            // Lấy ID của nhóm quyền vừa được chọn
            int selectedGroupId = Convert.ToInt32(dgvPhanQuyen.CurrentRow.Cells["colPqMaNhom"].Value);
            LoadPermissionsForGroup(selectedGroupId);
        }

        private void LoadPermissionsForGroup(int groupId)
        {
            try
            {
                // 1. Lấy danh sách quyền chi tiết hiện tại của nhóm này từ CSDL
                // Dùng ToDictionary để tra cứu nhanh hơn (key là FunctionID)
                var currentPermissions = permissionDetailBLL.GetByGroupId(groupId)
                                                            .ToDictionary(p => p.FunctionID);

                // 2. Xóa dữ liệu cũ và nạp lại từ đầu
                dgvChiTietQuyen.Rows.Clear();

                // 3. Duyệt qua TẤT CẢ các chức năng của hệ thống
                foreach (var func in allFunctions)
                {
                    // Thêm một dòng mới vào lưới chi tiết quyền
                    int rowIndex = dgvChiTietQuyen.Rows.Add();
                    var row = dgvChiTietQuyen.Rows[rowIndex];

                    // Gán giá trị Mã và Tên Chức Năng
                    row.Cells["colCnId"].Value = func.MaChucNang;
                    row.Cells["colCnTen"].Value = func.TenChucNang;

                    // 4. KIỂM TRA và TÍCH vào các checkbox tương ứng
                    if (currentPermissions.ContainsKey(func.MaChucNang))
                    {
                        // Nếu chức năng này đã có trong CSDL (đã được cấp quyền)
                        var permission = currentPermissions[func.MaChucNang];
                        row.Cells["colCnRead"].Value = permission.CanRead;
                        row.Cells["colCnCreate"].Value = permission.CanCreate;
                        row.Cells["colCnUpdate"].Value = permission.CanUpdate;
                        row.Cells["colCnDelete"].Value = permission.CanDelete;
                    }
                    else
                    {
                        // Nếu chưa có, mặc định là false (không có quyền)
                        row.Cells["colCnRead"].Value = false;
                        row.Cells["colCnCreate"].Value = false;
                        row.Cells["colCnUpdate"].Value = false;
                        row.Cells["colCnDelete"].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết quyền: " + ex.Message);
            }
        }

        private void btnLuuQuyen_Click(object sender, EventArgs e)
        {
            if (dgvPhanQuyen.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhóm quyền để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID của nhóm quyền đang được chọn
            int selectedGroupId = Convert.ToInt32(dgvPhanQuyen.CurrentRow.Cells["colPqMaNhom"].Value);

            // Tạo một danh sách để chứa thông tin các quyền sẽ được lưu
            var permissionsToSave = new List<PermissionDetailDTO>();

            // Duyệt qua từng dòng trong lưới chi tiết quyền
            foreach (DataGridViewRow row in dgvChiTietQuyen.Rows)
            {
                // Tạo một đối tượng DTO và lấy trạng thái của các checkbox
                var dto = new PermissionDetailDTO
                {
                    PermissionGroupID = selectedGroupId,
                    FunctionID = Convert.ToInt32(row.Cells["colCnId"].Value),
                    CanRead = Convert.ToBoolean(row.Cells["colCnRead"].Value ?? false),
                    CanCreate = Convert.ToBoolean(row.Cells["colCnCreate"].Value ?? false),
                    CanUpdate = Convert.ToBoolean(row.Cells["colCnUpdate"].Value ?? false),
                    CanDelete = Convert.ToBoolean(row.Cells["colCnDelete"].Value ?? false)
                };
                permissionsToSave.Add(dto);
            }

            try
            {
                // Gọi BLL để thực hiện lưu vào CSDL
                bool success = permissionDetailBLL.SavePermissions(selectedGroupId, permissionsToSave);

                if (success)
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

        // ---- Phần code vẽ TabControl cho đẹp, giữ nguyên ----
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

            g.Dispose();
            textBrush.Dispose();
        }
    }
}