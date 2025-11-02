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
        private readonly List<calamviecDTO> calamviecList = new List<calamviecDTO> {
            new calamviecDTO("Ca sáng",TimeSpan.FromHours(8), TimeSpan.FromHours(12)),
            new calamviecDTO("Ca chiều",TimeSpan.FromHours(13), TimeSpan.FromHours(17)),
            new calamviecDTO("Ca tối",TimeSpan.FromHours(18), TimeSpan.FromHours(22))
     };
        private readonly int standardWorkMinutesPerDay = 4 * 3 * 60;
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
                string approved_by = null;
                DateTime? approved_date = null;
                string notes = null;
                AttendanceDTO newAttendance = new AttendanceDTO(idChamCong, maNV, ngayChamCong, checkIn, checkOut, "", approved_by, approved_date, 0, 0, 0, 0, notes);
                return attendanceDAO.addAttendance(newAttendance);
            }
            else
            {
                attendanceToday.CheckOutTime = now;

                int go_late = calculateLateMinutes(attendanceToday.CheckInTime);
                int leave_early = calculateEarlyLeaveMinutes(attendanceToday.CheckOutTime);
                float sogiolamviec = (float)Math.Round(standardWorkMinutesPerDay - (go_late + leave_early) / 60f, 2);
                int soca = calculateSoCa(attendanceToday.CheckInTime, attendanceToday.CheckOutTime);

                attendanceToday.Go_late = go_late;
                attendanceToday.Leave_early = leave_early;
                attendanceToday.Sogiolamviec = sogiolamviec;
                attendanceToday.Soca = soca;

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
        private int calculateSoCa(DateTime? checkInTime, DateTime? checkOutTime)
        {
            if (checkInTime == null || checkOutTime == null)
            {
                return 0;
            }
            int soCa = 0;
            foreach (calamviecDTO calamviec in calamviecList)
            {
                if (checkCalam(checkInTime, checkOutTime, calamviec))
                    soCa++;
            }
            return 0;
        }
        private bool checkCalam(DateTime? checkInTime, DateTime? checkOutTime, calamviecDTO calamviec)
        {
            if (checkInTime == null || checkOutTime == null)
            {
                return false;
            }
            TimeSpan shiftStartTime = calamviec.StartTime;
            TimeSpan shiftEndTime = calamviec.EndTime;
            TimeSpan actualCheckInTime = checkInTime.Value.TimeOfDay;
            TimeSpan actualCheckOutTime = checkOutTime.Value.TimeOfDay;
            return actualCheckInTime <= shiftEndTime && actualCheckOutTime >= shiftStartTime && actualCheckInTime <= shiftEndTime;
        }
        private int calculateLateMinutes(DateTime? checkInTime)
        {
            if (checkInTime == null)
            {
                return 0;
            }
            foreach (calamviecDTO calamviec in calamviecList)
            {
                TimeSpan checkIn = checkInTime.Value.TimeOfDay;
                if (checkIn <= calamviec.EndTime)
                {
                    if (checkIn <= calamviec.StartTime)
                    {
                        return 0;
                    }
                    return (int)(checkIn - calamviec.StartTime).TotalMinutes;
                }
            }
            return 0;
        }
        private int calculateEarlyLeaveMinutes(DateTime? checkOutTime)
        {
            if (checkOutTime == null)
            {
                return 0;
            }
            foreach (calamviecDTO calamviec in calamviecList.AsEnumerable().Reverse())
            {
                TimeSpan checkOut = checkOutTime.Value.TimeOfDay;
                if (checkOut >= calamviec.StartTime)
                {
                    if (checkOut >= calamviec.EndTime)
                    {
                        return 0;
                    }
                    return (int)(calamviec.EndTime - checkOut).TotalMinutes;
                }
            }
            return 0;
        }
    }
}
