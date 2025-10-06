using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class DepartmentDTO
    {
        private string maPhong;
        private string tenPhong;
        private DateTime? ngayThanhLap;
        private string maTruongPhong;

        public string MaPhong
        {
            get { return maPhong; }
            set { maPhong = value; }
        }

        public string TenPhong
        {
            get { return tenPhong; }
            set { tenPhong = value; }
        }

        public DateTime? NgayThanhLap
        {
            get { return ngayThanhLap; }
            set { ngayThanhLap = value; }
        }

        public string MaTruongPhong
        {
            get { return maTruongPhong; }
            set { maTruongPhong = value; }
        }

        public DepartmentDTO() { }

        public DepartmentDTO(string maPhong, string tenPhong, DateTime? ngayThanhLap, string maTruongPhong)
        {
            this.maPhong = maPhong;
            this.tenPhong = tenPhong;
            this.ngayThanhLap = ngayThanhLap;
            this.maTruongPhong = maTruongPhong;
        }

        public DepartmentDTO(DepartmentDTO other)
        {
            this.maPhong = other.maPhong;
            this.tenPhong = other.tenPhong;
            this.ngayThanhLap = other.ngayThanhLap;
            this.maTruongPhong = other.maTruongPhong;
        }

        public override string ToString()
        {
            return $"Mã phòng: {maPhong}, Tên phòng: {tenPhong}, Ngày thành lập: {ngayThanhLap?.ToString("dd/MM/yyyy") ?? "N/A"}, Mã trưởng phòng: {maTruongPhong}";
        }
    }
}
