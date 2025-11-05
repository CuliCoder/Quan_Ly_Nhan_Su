

using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class EmployeeDTO
    {
        private string maNhanVien;
        private string soCmnd;
        private string maLuong;
        private string maHopDong;
        private string maChucVu;
        private string maTaiKhoan;
        private string maPhong;
        private decimal? mucLuong;

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string SoCmnd { get => soCmnd; set => soCmnd = value; }
        public string MaLuong { get => maLuong; set => maLuong = value; }
        public string MaHopDong { get => maHopDong; set => maHopDong = value; }
        public string MaChucVu { get => maChucVu; set => maChucVu = value; }
        public string MaTaiKhoan { get => maTaiKhoan; set => maTaiKhoan = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public decimal? MucLuong { get => mucLuong; set => mucLuong = value; }

        public EmployeeDTO() { }

 
        public EmployeeDTO(
            string maNhanVien,
            string soCmnd,
            string maLuong,
            string maHopDong,
            string maChucVu,
            string maTaiKhoan,
            string maPhong,
            decimal? mucLuong)
        {
            this.maNhanVien = maNhanVien;
            this.soCmnd = soCmnd;
            this.maLuong = maLuong;
            this.maHopDong = maHopDong;
            this.maChucVu = maChucVu;
            this.maTaiKhoan = maTaiKhoan;
            this.maPhong = maPhong;
            this.mucLuong = mucLuong;
        }

        public EmployeeDTO(EmployeeDTO other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            this.maNhanVien = other.maNhanVien;
            this.soCmnd = other.soCmnd;
            this.maLuong = other.maLuong;
            this.maHopDong = other.maHopDong;
            this.maChucVu = other.maChucVu;
            this.maTaiKhoan = other.maTaiKhoan;
            this.maPhong = other.maPhong;
            this.mucLuong = other.mucLuong;
        }

        public override string ToString()
        {
            return $"Mã NV: {maNhanVien}, CMND: {soCmnd}, Mã Lương: {maLuong}, " +
                   $"Mã Hợp Đồng: {maHopDong}" +
                   $"Mã Chức Vụ: {maChucVu}, Mã Tài Khoản: {maTaiKhoan}, " +
                   $"Mã Phòng: {maPhong}, Mức Lương: {mucLuong?.ToString("N2") ?? "Chưa có"}";
        }
    }
}