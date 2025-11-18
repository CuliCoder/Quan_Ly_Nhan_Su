using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO đầy đủ cho đánh giá nhân viên (join nhiều bảng)
    /// </summary>
    public class EvaluationFullDTO
    {
        public string MaDanhGia { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string PhongBan { get; set; }
        public string ChucVu { get; set; }
        public string MaNguoiDanhGia { get; set; }
        public string TenNguoiDanhGia { get; set; }
        public DateTime NgayDanhGia { get; set; }
        public int DiemDanhGia { get; set; }
        public string XepLoai { get; set; }
        public string ChiTietDanhGia { get; set; }
        public string GhiChu { get; set; }
        public string HinhAnh { get; set; }
    }
}