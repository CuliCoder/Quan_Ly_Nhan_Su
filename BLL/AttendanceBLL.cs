using Quan_Ly_Nhan_Su.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class AttendanceBLL
    {
        private AttendanceDAO attendanceDAO = new AttendanceDAO();
        private readonly calamviecDTO calamviecDTO = new calamviecDTO("Giờ hành chính", TimeSpan.FromHours(8), TimeSpan.FromHours(17));
        public AttendanceBLL()
        {


        }
        public bool addAttendance(string maNV)
        {
            if (maNV == null || maNV == "")
            {
                return false;
            }
            DateTime today = DateTime.Today;
            DateTime now = DateTime.Now;
            string idChamCong = maNV + "_" + today.ToString("dd/MM/yyyy");
            AttendanceDTO attendanceToday = attendanceDAO.get_attendance_by_id(idChamCong);
            if (attendanceToday == null)
            {
                DateTime ngayChamCong = today;
                DateTime? checkIn = now;
                DateTime? checkOut = null;
                AttendanceDTO newAttendance = new AttendanceDTO(idChamCong, maNV, ngayChamCong, checkIn, checkOut, 0, 0, 0);
                return attendanceDAO.addAttendance(newAttendance);
            }
            else
            {
                attendanceToday.CheckOutTime = now;

                int go_late = calculateLateMinutes(attendanceToday.CheckInTime);
                int leave_early = calculateEarlyLeaveMinutes(attendanceToday.CheckOutTime);
                float sogiolamviec = calculateWorkHours(go_late, attendanceToday.CheckInTime, attendanceToday.CheckOutTime);

                attendanceToday.Go_late = go_late;
                attendanceToday.Leave_early = leave_early;
                attendanceToday.Sogiolamviec = sogiolamviec;

                return attendanceDAO.updateAttendance(attendanceToday);
            }
        }
        public bool changeStatusAttendance(string id, string status)
        {
            if (id == null || status == null)
            {
                return false;
            }

            return attendanceDAO.updateStatusAttendance(id, status);
        }
        public List<AttendanceDTO> getAttendanceByEmployeeId(string maNhanVien)
        {
            if (maNhanVien == null || maNhanVien == "")
            {
                return new List<AttendanceDTO>();
            }
            return attendanceDAO.get_attendance_by_ID_NhanVien(maNhanVien);
        }
        private float calculateWorkHours(int lateMinutes, DateTime? CheckInTime, DateTime? checkOutTime)
        {
            float totalWorkedHours = 0;
            if (CheckInTime.Value.TimeOfDay < calamviecDTO.StartTime)
            {
                totalWorkedHours = (float)Math.Round(((int)(checkOutTime.Value.TimeOfDay - calamviecDTO.StartTime).TotalMinutes - lateMinutes) / 60.0f, 2);
            }
            else
            {
                totalWorkedHours = (float)Math.Round((int)(checkOutTime.Value.TimeOfDay - CheckInTime.Value.TimeOfDay).TotalMinutes / 60.0f, 2);
            }
            if (totalWorkedHours >= 5)
            {
                totalWorkedHours -= 1;
            }
            return totalWorkedHours < 0 ? 0 : totalWorkedHours;
        }
        private int calculateLateMinutes(DateTime? checkInTime)
        {
            if (checkInTime == null)
            {
                return 0;
            }
            TimeSpan checkIn = checkInTime.Value.TimeOfDay;
            if (checkIn <= calamviecDTO.EndTime)
            {
                if (checkIn < calamviecDTO.StartTime)
                {
                    return 0;
                }
                return (int)Math.Round((checkIn - calamviecDTO.StartTime).TotalMinutes, 0);
            }
            return 8 * 60;
        }
        private int calculateEarlyLeaveMinutes(DateTime? checkOutTime)
        {
            if (checkOutTime == null)
            {
                return 0;
            }
            TimeSpan checkOut = checkOutTime.Value.TimeOfDay;
            if (checkOut >= calamviecDTO.StartTime)
            {
                if (checkOut > calamviecDTO.EndTime)
                {
                    return 0;
                }
                return (int)Math.Round((calamviecDTO.EndTime - checkOut).TotalMinutes, 0);
            }
            return 8 * 60;
        }
        // Tính tổng số giờ làm việc, số lần đi muộn và số lần về sớm trong một tháng của nhân viên
        public AttendanceTotalOfMonthDTO calculateTotalOfMonth(string maNV, int month, int year)
        {
            return attendanceDAO.calculateTotalOfMonth(maNV, month, year);
        }
        // Tính tổng số giờ làm việc trong một tháng, giả sử mỗi ngày làm việc là 8 giờ và không tính ngày cuối tuần
        public static int TinhTongGioLam(int thang, int nam)
        {

            // Lấy số ngày trong tháng
            int soNgay = DateTime.DaysInMonth(nam, thang);

            // Khởi tạo tổng giờ làm
            int tongGio = 0;

            // Duyệt qua từng ngày trong tháng
            for (int ngay = 1; ngay <= soNgay; ngay++)
            {
                DateTime ngayHienTai = new DateTime(nam, thang, ngay);
                // Kiểm tra nếu là thứ Bảy (6) hoặc Chủ Nhật (0)
                if (ngayHienTai.DayOfWeek == DayOfWeek.Saturday || ngayHienTai.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }
                // Cộng 8 giờ cho ngày làm việc
                tongGio += 8;
            }

            return tongGio;
        }
        public List<AttendanceDTO> filterByTime(string manv, int thang, int nam)
        {
            return attendanceDAO.filterByTime(manv, thang, nam);
        }
        public List<AttendanceDTO> filterByTimesheet(DateTime startTime, DateTime endTime)
        {
            return attendanceDAO.filterByTimesheet(startTime,endTime);
        }
    }
}
