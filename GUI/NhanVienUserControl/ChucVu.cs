using OfficeOpenXml.Table.PivotTable;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.Constants;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.NhanVienUserControl
{
    public partial class ChucVu : UserControl
    {
        private readonly PositionBLL positionBLL;
        private List<PositionDTO> list;
        public ChucVu()
        {
            InitializeComponent();
            positionBLL = new PositionBLL();
           
            list = positionBLL.GetAll();
            showData(list);
            ApplyPermissions();
        }
        private void ApplyPermissions()
        {
            bool canCreate = SessionManager.Instance.CanCreate(FunctionNames.CHUC_VU);
            layoutThem.Visible = canCreate;

            bool canDelete = SessionManager.Instance.CanDelete(FunctionNames.CHUC_VU);
            layoutXoa.Visible = canDelete;
            bool canUpdate = SessionManager.Instance.CanUpdate(FunctionNames.CHUC_VU);
            layoutSua.Visible = canUpdate;
        }
        private void showData(List<PositionDTO> list)
        {
            tableData.DataSource = null;
            tableData.DataSource = list;
            tableData.Columns["NgayNhanChuc"].Visible = false;
            tableData.Columns["Display"].Visible = false;

            tableData.Columns["MaChucVu"].HeaderText = "Mã Chức Vụ";
            tableData.Columns["TenChucVu"].HeaderText = "Tên Chức Vụ";
            tableData.Columns["PhuCapChucVu"].HeaderText = "Phụ Cấp Chức Vụ";
            tableData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void reload()
        {
            list = positionBLL.GetAll();
            showData(list);
        }
        private void tableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void luuThanhcong(object sender, EventArgs e, string message)
        {
            MessageBox.Show(message);
            reload();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //Hạn chế truyền null vào, biến giả
            PositionDTO positionDTO = new PositionDTO();
            ChucVuNhapLieu chucVuNhapLieu = new ChucVuNhapLieu(positionDTO, "Them");

            chucVuNhapLieu.StartPosition = FormStartPosition.CenterScreen;
            chucVuNhapLieu.LbHanhDong.Text = "Thêm Chức Vụ";
            chucVuNhapLieu.luuThongTinForm += (s, ev) => luuThanhcong(s, ev, "Lưu thành công!");
            chucVuNhapLieu.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string maChucVu = tableData.CurrentRow.Cells["MaChucVu"].Value?.ToString();

            if (positionBLL.Delete(maChucVu))
            {             
                MessageBox.Show("Xóa chức vụ thành công");
                reload();
            }
            else
            {
                MessageBox.Show("Xóa chức vụ thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maChucVu = tableData.CurrentRow.Cells["MaChucVu"].Value?.ToString();
            string tenChucVu = tableData.CurrentRow.Cells["TenChucVu"].Value?.ToString();
            decimal phuCapChucVu = Convert.ToDecimal(tableData.CurrentRow.Cells["PhuCapChucVu"].Value);

            if (maChucVu == null || tenChucVu == null || phuCapChucVu == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ để sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PositionDTO position = new PositionDTO
            {
                MaChucVu = maChucVu,
                TenChucVu = tenChucVu,
                PhuCapChucVu = phuCapChucVu
            };

            ChucVuNhapLieu chucVuNhapLieu = new ChucVuNhapLieu(position, "Sua");
            chucVuNhapLieu.StartPosition = FormStartPosition.CenterScreen;
            chucVuNhapLieu.LbHanhDong.Text = "Sửa Chức Vụ";
            chucVuNhapLieu.luuThongTinForm += (s, ev) => luuThanhcong(s, ev, "Sửa thành công!");
            chucVuNhapLieu.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void getDataSearch()
        {
            string keyWord = tbSearch.Text.Trim();
            List<PositionDTO> listSearch = positionBLL.Search(keyWord);
            showData(listSearch);
        }

        private void tbSearch_TextChanged(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                getDataSearch();
                tbSearch.Text = "";
            }
        }
    }
}
