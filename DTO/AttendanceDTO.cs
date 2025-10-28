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
        private string notes;
        public AttendanceDTO(string idChamCong, string maNhanVien, DateTime ngayChamCong, DateTime? checkInTime, DateTime? checkOutTime, string trangThai, string approved_by, DateTime? approved_date, string notes)
        {
            this.idChamCong = idChamCong;
            this.maNhanVien = maNhanVien;
            this.ngayChamCong = ngayChamCong;
            this.checkInTime = checkInTime;
            this.checkOutTime = checkOutTime;
            this.trangThai = trangThai;
            this.approved_by = approved_by;
            this.approved_date = approved_date;
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
    }
}
