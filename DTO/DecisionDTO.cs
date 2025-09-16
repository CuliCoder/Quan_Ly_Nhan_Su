using System;

namespace YourNamespace.DTO
{
    /// <summary>
    /// DTO for Decision table
    /// </summary>
    public class DecisionDTO
    {
        public string MaQuyetDinh { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayQuyetDinh { get; set; }
        public string ChucVuBanDau { get; set; }
        public string ChucVuSauQuyetDinh { get; set; }
        public string NguoiLapQuyetDinh { get; set; }
        public string LyDo { get; set; }
    }
}