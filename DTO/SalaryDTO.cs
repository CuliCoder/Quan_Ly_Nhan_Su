using System;

namespace YourNamespace.DTO
{
    /// <summary>
    /// DTO for Salary table
    /// </summary>
    public class SalaryDTO
    {
        public string MaLuong { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal LuongThuong { get; set; }
        public decimal? LuongThucTe { get; set; }
        public decimal PhuCapChucVu { get; set; }
        public decimal PhuCapKhac { get; set; }
        public decimal KhoanTruBaoHiem { get; set; }
        public decimal KhoanTruKhac { get; set; }
        public decimal Thue { get; set; }
        public decimal? ThucLanh { get; set; }
    }
}