using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class SalaryIncreaseDTO
    {
        public int Id { get; set; }
        public string MaNhanVien { get; set; }
        public decimal LuongHienTai { get; set; }
        public float DiemDanhGia { get; set; }
        public decimal? PhanTramTang { get; set; }
        public decimal? LuongMoi { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public string TrangThai { get; set; }
    }
}
