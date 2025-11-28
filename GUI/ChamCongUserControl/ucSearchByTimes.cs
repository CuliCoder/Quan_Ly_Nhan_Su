using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.ChamCongUserControl
{
    public partial class ucSearchByTimes : UserControl
    {
        private AttendanceBLL attendanceBLL;
        private EmployeeFullBLL employeeBLL;
        private List<AttendanceDTO> attendanceDTOs;
        public event Action<(int m, int y, string maNV)> EmployeeSelected;

        public ucSearchByTimes()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode)
            {
                return;
            }

            attendanceBLL = new AttendanceBLL();
            employeeBLL = new EmployeeFullBLL();

            InitDefaultRange();
            BuildMonthTimeline();
        }

        private void InitDefaultRange()
        {
            // Mặc định: từ đầu tháng hiện tại đến hôm nay
            var today = DateTime.Today;
            var first = new DateTime(today.Year, today.Month, 1);
            dtpRangeFrom.Value = first;
            dtpRangeTo.Value = today;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode) return;
            InitDefaultRange();
            BuildMonthTimeline();
        }

        private void btnApplyRange_Click(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode) return;
            if (dtpRangeFrom.Value.Date > dtpRangeTo.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
                return;
            }
            BuildMonthTimeline();
        }

        // Dựng các panel tháng theo khoảng thời gian chọn
        private void BuildMonthTimeline()
        {
            DateTime start = dtpRangeFrom.Value.Date;
            DateTime end = dtpRangeTo.Value.Date;
            if (end < start) return;

            var monthPoints = new List<(int m, int y)>();
            var cursor = new DateTime(start.Year, start.Month, 1);
            var lastMonthStart = new DateTime(end.Year, end.Month, 1);
            attendanceDTOs = attendanceBLL.filterByTimesheet(start, end.AddDays(1));
            flMonths.Controls.Clear();
            if (attendanceDTOs.Count == 0)
            {
                return;
            }
            while (cursor <= lastMonthStart)
            {
                monthPoints.Add((cursor.Month, cursor.Year));
                cursor = cursor.AddMonths(1);
            }

            flMonths.SuspendLayout();

            foreach (var p in monthPoints)
            {
                var filtered = attendanceDTOs
                   .Where(r => r.NgayChamCong.Month == p.m && r.NgayChamCong.Year == p.y)
                   .ToList();
                if (filtered.Count == 0) continue;
                var panel = CreateMonthPanel(p.m, p.y, filtered);
                flMonths.Controls.Add(panel);
            }

            flMonths.ResumeLayout();
        }

        private Panel CreateMonthPanel(int month, int year, List<AttendanceDTO> attendanceDTOs)
        {
            var outer = new Panel
            {
                Width = flMonths.ClientSize.Width - 36,
                Height = 80,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 12),
                BorderStyle = BorderStyle.FixedSingle
            };

            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 44,
                BackColor = SystemColors.Control
            };

            var lbl = new Label
            {
                Text = $"Tháng {month} - {year}",
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Left,
                Width = 220,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };

            var btnToggle = new Button
            {
                Text = "Xem danh sách",
                Font = new Font("Segoe UI", 10F),
                Dock = DockStyle.Right,
                Width = 140
            };

            var content = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                Visible = false
            };

            var lstEmployees = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                HideSelection = false
            };
            lstEmployees.Columns.Add("Mã NV", 120);
            lstEmployees.Columns.Add("Họ tên", 200);
            lstEmployees.Columns.Add("Email", 200);
            lstEmployees.Columns.Add("Chức vụ", 140);

            content.Controls.Add(lstEmployees);
            header.Controls.Add(btnToggle);
            header.Controls.Add(lbl);
            outer.Controls.Add(content);
            outer.Controls.Add(header);

            btnToggle.Click += (s, e) =>
            {
                if (!content.Visible)
                {
                    LoadEmployeesForMonth(lstEmployees, month, year, attendanceDTOs);
                    content.Visible = true;
                    outer.Height = 260;
                    btnToggle.Text = "Thu gọn";
                }
                else
                {
                    content.Visible = false;
                    outer.Height = 80;
                    btnToggle.Text = "Xem danh sách";
                }
            };
            lstEmployees.MouseDoubleClick += (s, e) =>
            {
                var hit = lstEmployees.HitTest(e.Location);
                var item = hit.Item;
                if (item == null) return;
                string maNV = item.Text;
                EmployeeSelected?.Invoke((month, year, maNV));
            };
            return outer;
        }

        private void LoadEmployeesForMonth(ListView listView, int month, int year, List<AttendanceDTO> attendanceDTOs)
        {
            listView.Items.Clear();
            if (attendanceDTOs.Count == 0) return;

            foreach (var emp in attendanceDTOs)
            {
                if (string.IsNullOrEmpty(emp.MaNhanVien)) continue;
                if (listView.Items.Cast<ListViewItem>().Any(i => i.Text == emp.MaNhanVien))
                {
                    continue;
                }
                EmployeeFullDTO employee = employeeBLL.GetEmployeeById(emp.MaNhanVien);
                var item = new ListViewItem(employee.MaNhanVien);
                item.SubItems.Add(employee.HoTen);
                item.SubItems.Add(employee.Email);
                item.SubItems.Add(employee.ChucVu);

                listView.Items.Add(item);
            }
        }

        // Mock data
        private List<EmployeeFullDTO> MockEmployees()
        {
            return new List<EmployeeFullDTO>
            {
                new EmployeeFullDTO { MaNhanVien = "NV001", HoTen = "Nguyễn Văn A", Email="a@example.com", PhongBan="Kế toán", ChucVu="Nhân viên" },
                new EmployeeFullDTO { MaNhanVien = "NV002", HoTen = "Trần Thị B", Email="b@example.com", PhongBan="Nhân sự", ChucVu="Chuyên viên" },
                new EmployeeFullDTO { MaNhanVien = "NV003", HoTen = "Lê Văn C", Email="c@example.com", PhongBan="IT", ChucVu="Dev" },
                new EmployeeFullDTO { MaNhanVien = "NV004", HoTen = "Phạm Thị D", Email="d@example.com", PhongBan="IT", ChucVu="Tester" }
            };
        }

        private List<AttendanceDTO> MockAttendanceFor(string maNV, int month, int year)
        {
            var rnd = new Random(maNV.GetHashCode() + month * 77 + year * 13);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            var list = new List<AttendanceDTO>();
            int count = rnd.Next(4, 9);
            var used = new HashSet<int>();
            while (used.Count < count)
            {
                int d = rnd.Next(1, daysInMonth + 1);
                var date = new DateTime(year, month, d);
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) continue;
                used.Add(d);
            }
            foreach (var d in used)
            {
                var ngay = new DateTime(year, month, d);
                var checkIn = ngay.AddHours(8).AddMinutes(rnd.Next(0, 25));
                var checkOut = ngay.AddHours(17).AddMinutes(rnd.Next(0, 15));
                list.Add(new AttendanceDTO(
                    $"{maNV}_{ngay:dd/MM/yyyy}",
                    maNV,
                    ngay,
                    checkIn,
                    checkOut,
                    Math.Max(0, (int)(checkIn - ngay.AddHours(8)).TotalMinutes),
                    Math.Max(0, (int)(ngay.AddHours(17) - checkOut).TotalMinutes),
                    8f));
            }
            return list;
        }
    }
}