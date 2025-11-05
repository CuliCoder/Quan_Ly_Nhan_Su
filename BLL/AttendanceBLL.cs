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
        private readonly int standardWorkMinutesPerDay = 8 * 60;
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
                float sogiolamviec = calculateWorkHours(go_late, leave_early);

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
        private float calculateWorkHours(int lateMinutes, int earlyLeaveMinutes)
        {
            float totalWorkedHours = (float)Math.Round((standardWorkMinutesPerDay - lateMinutes - earlyLeaveMinutes) / 60.0f, 2);
            if (totalWorkedHours >= 5)
            {
                totalWorkedHours -= 1;
            }
            return totalWorkedHours;
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
                return (int)(checkIn - calamviecDTO.StartTime).TotalMinutes;
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
                return (int)(calamviecDTO.EndTime - checkOut).TotalMinutes;
            }
            return 8 * 60;
        }
    }
}
