using System;

namespace YourNamespace.DTO
{
    /// <summary>
    /// DTO for Timesheet table
    /// </summary>
    public class TimesheetDTO
    {
        public string MaBangChamCong { get; set; }
        public string MaNV { get; set; }
        public int ThangChamCong { get; set; }
        public int NamChamCong { get; set; }
        public int SoNgayLamViec { get; set; }
        public int SoNgayNghi { get; set; }
        public int SoNgayTre { get; set; }
        public int SoGioLamThem { get; set; }
        public string ChiTiet { get; set; }
        public string TrangThai { get; set; }
    }
}