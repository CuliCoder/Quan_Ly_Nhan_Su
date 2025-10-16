using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.ChamCong
{
    public partial class ucChiTietChamCong : UserControl
    {
        public event EventHandler BackButtonClicked;
        private readonly EmployeeFullBLL employeeBLL = new EmployeeFullBLL();
        private EmployeeFullDTO currentEmployee;
        private List<Button> selectedDayButtons = new List<Button>();

        public ucChiTietChamCong()
        {
            InitializeComponent();
        }

        public void LoadEmployeeData(string maNhanVien)
        {
            try
            {
                currentEmployee = employeeBLL.GetEmployeeById(maNhanVien);
                if (currentEmployee != null)
                {
                    lblTenNhanVien.Text = $"{currentEmployee.MaNhanVien} - {currentEmployee.HoTen}";
                    PopulateDateTimeControls();
                    GenerateCalendar(DateTime.Now.Year, DateTime.Now.Month);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BackButtonClicked?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin nhân viên: {ex.Message}");
            }
        }

        private void PopulateDateTimeControls()
        {
            cboNam.Items.Clear();
            cboThang.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 5; i <= currentYear + 5; i++) cboNam.Items.Add(i);
            cboNam.SelectedItem = currentYear;
            for (int i = 1; i <= 12; i++) cboThang.Items.Add(i);
            cboThang.SelectedItem = DateTime.Now.Month;
        }

        private void UpdateCalendar(object sender, EventArgs e)
        {
            if (cboNam.SelectedItem != null && cboThang.SelectedItem != null)
            {
                GenerateCalendar(Convert.ToInt32(cboNam.SelectedItem), Convert.ToInt32(cboThang.SelectedItem));
            }
        }

        private void GenerateCalendar(int year, int month)
        {
            flpCalendar.Controls.Clear();
            var firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int offsetDays = (int)firstDayOfMonth.DayOfWeek;
            if (offsetDays == 0) offsetDays = 7; // Sunday

            string[] dayNames = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            foreach (var name in dayNames)
            {
                flpCalendar.Controls.Add(new Label { Text = name, Font = new Font("Segoe UI", 9, FontStyle.Bold), Size = new Size(60, 30), TextAlign = ContentAlignment.MiddleCenter });
            }

            for (int i = 1; i < offsetDays; i++)
            {
                flpCalendar.Controls.Add(new Panel { Size = new Size(60, 60) });
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                var btnDay = new Button
                {
                    Text = day.ToString(),
                    Tag = new DateTime(year, month, day),
                    Size = new Size(60, 60),
                    Font = new Font("Segoe UI", 10),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                };
                btnDay.FlatAppearance.BorderColor = Color.Gainsboro;
                btnDay.Click += DayButton_Click;
                flpCalendar.Controls.Add(btnDay);
            }
        }

        private void DayButton_Click(object sender, EventArgs e) { /* Giữ nguyên logic cũ */ }
        private void btnAction_Click(object sender, EventArgs e) { /* Giữ nguyên logic cũ */ }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}