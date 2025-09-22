using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for Department table
    /// </summary>
    public class DepartmentDTO
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public DateTime? NgayThanhLap { get; set; }
        public string MaTruongPhong { get; set; }
    }
}