using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO cho bảng Luong
    /// </summary>
    public class SalaryDTO
    {
        public string MaLuong { get; set; }
        public string MaNhanVien { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal LuongTheoGio { get; set; }

        public SalaryDTO() { }

        public SalaryDTO(string maLuong, string maNhanVien, decimal luongCoBan, decimal luongTheoGio)
        {
            MaLuong = maLuong;
            MaNhanVien = maNhanVien;
            LuongCoBan = luongCoBan;
            LuongTheoGio = luongTheoGio;
        }

        public override string ToString()
        {
            return $"{MaLuong} - {MaNhanVien} | Cơ bản: {LuongCoBan:N0} | Giờ: {LuongTheoGio:N0}";
        }
    }
}
