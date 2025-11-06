using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for Salary table + extended employee info (for salary invoice)
    /// </summary>
    public class SalaryDTO
    {
        // ====== Các trường lương trong DB ======
        private decimal khoanTruBaoHiem;
        private decimal khoanTruKhac;
        private decimal luongCoBan;
        private decimal? luongThucTe;
        private decimal luongThuong;
        private string maLuong;
        private decimal phuCapChucVu;
        private decimal phuCapKhac;
        private decimal? thucLanh;
        private decimal thue;

        public string MaLuong
        {
            get => maLuong;
            set => maLuong = value;
        }

        public decimal LuongCoBan
        {
            get => luongCoBan;
            set => luongCoBan = value;
        }

        public decimal LuongThuong
        {
            get => luongThuong;
            set => luongThuong = value;
        }

        public decimal? LuongThucTe
        {
            get => luongThucTe;
            set => luongThucTe = value;
        }

        public decimal PhuCapChucVu
        {
            get => phuCapChucVu;
            set => phuCapChucVu = value;
        }

        public decimal PhuCapKhac
        {
            get => phuCapKhac;
            set => phuCapKhac = value;
        }

        public decimal KhoanTruBaoHiem
        {
            get => khoanTruBaoHiem;
            set => khoanTruBaoHiem = value;
        }

        public decimal KhoanTruKhac
        {
            get => khoanTruKhac;
            set => khoanTruKhac = value;
        }

        public decimal Thue
        {
            get => thue;
            set => thue = value;
        }

        public decimal? ThucLanh
        {
            get => thucLanh;
            set => thucLanh = value;
        }

        // ====== Các trường mở rộng (JOIN từ bảng khác) ======
        public string MaNhanVien { get; set; }         // từ bảng nhanvien
        public string HoTen { get; set; }              // từ bảng hosocanhan
        public string TenChucVu { get; set; }          // từ bảng chucvu
        public string TenPhong { get; set; }           // từ bảng phongban

        // Ngày lập phiếu lương (không bắt buộc)
        public DateTime? NgayLap { get; set; }

        // ====== Constructors ======
        public SalaryDTO() { }

        public SalaryDTO(
            string maLuong,
            decimal luongCoBan,
            decimal luongThuong,
            decimal? luongThucTe,
            decimal phuCapChucVu,
            decimal phuCapKhac,
            decimal khoanTruBaoHiem,
            decimal khoanTruKhac,
            decimal thue,
            decimal? thucLanh)
        {
            this.maLuong = maLuong;
            this.luongCoBan = luongCoBan;
            this.luongThuong = luongThuong;
            this.luongThucTe = luongThucTe;
            this.phuCapChucVu = phuCapChucVu;
            this.phuCapKhac = phuCapKhac;
            this.khoanTruBaoHiem = khoanTruBaoHiem;
            this.khoanTruKhac = khoanTruKhac;
            this.thue = thue;
            this.thucLanh = thucLanh;
        }
    }
}
