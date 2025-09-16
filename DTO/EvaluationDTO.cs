using System;

namespace YourNamespace.DTO
{
    /// <summary>
    /// DTO for Evaluation table
    /// </summary>
    public class EvaluationDTO
    {
        public string MaDanhGia { get; set; }
        public string MaNhanVien { get; set; }
        public string MaNguoiDanhGia { get; set; }
        public DateTime NgayDanhGia { get; set; }
        public int DiemDanhGia { get; set; }
        public string XepLoai { get; set; }
        public string ChiTietDanhGia { get; set; }
        public string GhiChu { get; set; }
    }
}