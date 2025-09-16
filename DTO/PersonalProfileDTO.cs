using System;

namespace YourNamespace.DTO
{
    /// <summary>
    /// DTO for PersonalProfile table
    /// </summary>
    public class PersonalProfileDTO
    {
        public string SoCmnd { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string NoiCap { get; set; }
        public DateTime NgayCap { get; set; }
        public string TinhTrangHonNhan { get; set; }
        public string DanToc { get; set; }
    }
}