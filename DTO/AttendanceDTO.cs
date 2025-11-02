using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class AttendanceDTO
    {
        private string idChamCong;
        private string maNhanVien;
        private DateTime ngayChamCong;
        private DateTime? checkInTime;
        private DateTime? checkOutTime;
        private string trangThai;
        private string approved_by;
        private DateTime? approved_date;
        private int go_late;
        private int leave_early;
        private float sogiolamviec;
        private int soca;
        private string notes;
        public AttendanceDTO(string idChamCong, string maNhanVien, DateTime ngayChamCong, DateTime? checkInTime, DateTime? checkOutTime, string trangThai, string approved_by, DateTime? approved_date, int go_late, int leave_early, float sogiolamviec, int soca, string notes)
        {
            this.idChamCong = idChamCong;
            this.maNhanVien = maNhanVien;
            this.ngayChamCong = ngayChamCong;
            this.checkInTime = checkInTime;
            this.checkOutTime = checkOutTime;
            this.trangThai = trangThai;
            this.approved_by = approved_by;
            this.approved_date = approved_date;
            this.go_late = go_late;
            this.leave_early = leave_early;
            this.sogiolamviec = sogiolamviec;
            this.soca = soca;
            this.notes = notes;
        }
        public string IdChamCong { get => idChamCong; set => idChamCong = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayChamCong { get => ngayChamCong; set => ngayChamCong = value; }
        public DateTime? CheckInTime { get => checkInTime; set => checkInTime = value; }
        public DateTime? CheckOutTime { get => checkOutTime; set => checkOutTime = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string Approved_by { get => approved_by; set => approved_by = value; }
        public DateTime? Approved_date { get => approved_date; set => approved_date = value; }
        public string Notes { get => notes; set => notes = value; }
        public int Soca { get => soca; set => soca = value; }
        public float Sogiolamviec { get => sogiolamviec; set => sogiolamviec = value; }
        public int Leave_early { get => leave_early; set => leave_early = value; }
        public int Go_late { get => go_late; set => go_late = value; }

    }
}
