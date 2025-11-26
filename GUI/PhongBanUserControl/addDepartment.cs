using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.PhongBanUserControl
{
    public partial class addDepartment : Form
    {
        private DepartmentBLL departmentBLL = new DepartmentBLL();
        public addDepartment()
        {
            InitializeComponent();
            this.Text = "Thêm Phòng Ban";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            loadDate();
        }
        public void loadDate()
        {
            textDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            textDate.ReadOnly = true;
            textDate.Font = new Font("Montserrat", textDate.Font.Size, FontStyle.Italic);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string maPhong = textMPB.Text.Trim();
            string tenPhong = textTenPB.Text.Trim();
            DateTime? ngayThanhLap = null;
            if (DateTime.TryParseExact(textDate.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
                ngayThanhLap = dt;
            DepartmentDTO departmentDTO = new DepartmentDTO(maPhong, tenPhong, ngayThanhLap, null);

            if (departmentBLL.AddDepartment(departmentDTO))
            {
                MessageBox.Show("Thêm phòng ban thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm phòng ban thất bại!");
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
