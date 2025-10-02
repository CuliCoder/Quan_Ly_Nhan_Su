using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for Salary table
    /// </summary>
    public class SalaryDTO
    {
        public decimal KhoanTruBaoHiem { get; set; }
        public decimal KhoanTruKhac { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal? LuongThucTe { get; set; }
        public decimal LuongThuong { get; set; }
        public string MaLuong { get; set; }
        public decimal PhuCapChucVu { get; set; }
        public decimal PhuCapKhac { get; set; }
        public decimal? ThucLanh { get; set; }
        public decimal Thue { get; set; }

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
            KhoanTruBaoHiem = khoanTruBaoHiem;
            KhoanTruKhac = khoanTruKhac;
            LuongCoBan = luongCoBan;
            LuongThucTe = luongThucTe;
            LuongThuong = luongThuong;
            MaLuong = maLuong;
            PhuCapChucVu = phuCapChucVu;
            PhuCapKhac = phuCapKhac;
            ThucLanh = thucLanh;
            Thue = thue;
        }
    }
}