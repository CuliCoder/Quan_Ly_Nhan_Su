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
            string idChamCong = maNV + "_" + today.ToString("dd/MM/yyyy");
            AttendanceDTO attendanceToday = attendanceDAO.get_attendance_by_id(idChamCong);
            if (attendanceToday == null)
            {
                DateTime ngayChamCong = today;
                DateTime? checkIn = DateTime.Now;
                DateTime? checkOut = null;
                string approved_by = null;
                DateTime? approved_date = null;
                string notes = null;
                AttendanceDTO newAttendance = new AttendanceDTO(idChamCong, maNV, ngayChamCong, checkIn, checkOut, "", approved_by, approved_date, notes);
                return attendanceDAO.addAttendance(newAttendance);
            }
            else
            {
                attendanceToday.CheckOutTime = DateTime.Now;
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
    }
}
