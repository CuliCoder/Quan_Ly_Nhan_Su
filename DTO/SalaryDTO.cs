using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for Salary table
    /// </summary>
    public class SalaryDTO
    {
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
        public decimal LuongCoBan
        {
            get => luongCoBan;
            set => luongCoBan = value;
        }
        public decimal? LuongThucTe
        {
            get => luongThucTe;
            set => luongThucTe = value;
        }
        public decimal LuongThuong
        {
            get => luongThuong;
            set => luongThuong = value;
        }
        public string MaLuong
        {
            get => maLuong;
            set => maLuong = value;
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
        public decimal? ThucLanh
        {
            get => thucLanh;
            set => thucLanh = value;
        }
        public decimal Thue
        {
            get => thue;
            set => thue = value;
        }

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
            this.khoanTruBaoHiem = khoanTruBaoHiem;
            this.khoanTruKhac = khoanTruKhac;
            this.luongCoBan = luongCoBan;
            this.luongThucTe = luongThucTe;
            this.luongThuong = luongThuong;
            this.maLuong = maLuong;
            this.phuCapChucVu = phuCapChucVu;
            this.phuCapKhac = phuCapKhac;
            this.thucLanh = thucLanh;
            this.thue = thue;
        }
    }
}