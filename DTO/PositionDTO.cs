using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for Position table
    /// </summary>
    public class PositionDTO
    {
        public string MaChucVu { get; set; }
        public string TenChucVu { get; set; }
        public decimal PhuCapChucVu { get; set; }
        public DateTime? NgayNhanChuc { get; set; }
    }
}