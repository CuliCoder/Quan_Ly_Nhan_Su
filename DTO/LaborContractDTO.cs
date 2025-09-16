using System;

namespace YourNamespace.DTO
{
    /// <summary>
    /// DTO for LaborContract table
    /// </summary>
    public class LaborContractDTO
    {
        public string MaHopDong { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public string LoaiHopDong { get; set; }
        public string PhongBan { get; set; }
        public decimal LuongCoBan { get; set; }
        public string MaBangChamCong { get; set; }
    }
}