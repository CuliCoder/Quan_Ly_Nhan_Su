using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class LaborContractDTO
    {
        public int STT { get; set; }
        public string MaHopDong { get; set; }
        public string TenNhanVien { get; set; } // Tên nhân viên kết hợp với mã
        public string PhongBan { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public string LoaiHopDong { get; set; }
        public decimal LuongCoBan { get; set; }
        public string MaNhanVien { get; set; } // Giữ nguyên để sử dụng trong CRUD
        public string MaBangChamCong { get; set; }
        public string HinhAnh { get; set; }
    }
}