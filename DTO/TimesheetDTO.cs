using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for Timesheet table
    /// </summary>
    public class TimesheetDTO
    {
        private string maBangChamCong;
        private string maNV;
        private int thangChamCong;
        private int namChamCong;
        private int soNgayLamViec;
        private int soNgayNghi;
        private int soNgayTre;
        private int soGioLamThem;
        private string chiTiet;
        private string trangThai;

        public string MaBangChamCong
        {
            get => maBangChamCong;
            set => maBangChamCong = value;
        }
        public string MaNV
        {
            get => maNV;
            set => maNV = value;
        }
        public int ThangChamCong
        {
            get => thangChamCong;
            set => thangChamCong = value;
        }
        public int NamChamCong
        {
            get => namChamCong;
            set => namChamCong = value;
        }
        public int SoNgayLamViec
        {
            get => soNgayLamViec;
            set => soNgayLamViec = value;
        }
        public int SoNgayNghi
        {
            get => soNgayNghi;
            set => soNgayNghi = value;
        }
        public int SoNgayTre
        {
            get => soNgayTre;
            set => soNgayTre = value;
        }
        public int SoGioLamThem
        {
            get => soGioLamThem;
            set => soGioLamThem = value;
        }
        public string ChiTiet
        {
            get => chiTiet;
            set => chiTiet = value;
        }
        public string TrangThai
        {
            get => trangThai;
            set => trangThai = value;
        }

        public TimesheetDTO() { }

        public TimesheetDTO(string maBangChamCong, string maNV, int thangChamCong, int namChamCong, int soNgayLamViec, int soNgayNghi, int soNgayTre, int soGioLamThem, string chiTiet, string trangThai)
        {
            MaBangChamCong = maBangChamCong;
            MaNV = maNV;
            ThangChamCong = thangChamCong;
            NamChamCong = namChamCong;
            SoNgayLamViec = soNgayLamViec;
            SoNgayNghi = soNgayNghi;
            SoNgayTre = soNgayTre;
            SoGioLamThem = soGioLamThem;
            ChiTiet = chiTiet;
            TrangThai = trangThai;
        }
    }
}