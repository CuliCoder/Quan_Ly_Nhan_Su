using System;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.BLL;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class ProfileStaffGUI : UserControl
    {   
        AttendanceBLL attendanceBLL = new AttendanceBLL();
        public ProfileStaffGUI()
        {
            InitializeComponent();

            // Gắn sự kiện nút
        //  button3.Click += ButtonSave_Click;
         //button2.Click += ButtonReload_Click;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Ví dụ: thu thập dữ liệu từ các textbox
            string maNV = textBox1.Text;
            string hoTen = textBox5.Text;
            string sdt = textBox17.Text;

            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã nhân viên và Họ tên.", "Thiếu thông tin");
                return;
            }

            // TODO: Thực hiện lưu dữ liệu vào DB (nếu có)
            MessageBox.Show($"Đã lưu hồ sơ cho nhân viên: {hoTen} ({maNV})", "Thành công");
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            // Xóa toàn bộ textbox
            foreach (Control ctrl in this.Controls)
                ClearTextBoxes(ctrl);
        }

        private void ClearTextBoxes(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
                else
                    ClearTextBoxes(ctrl);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void changepasswordGUI1_Load(object sender, EventArgs e)
        {

        }

        private void BtnChamCong_Click(object sender, EventArgs e)
        {
            attendanceBLL.addAttendance("NV003");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
