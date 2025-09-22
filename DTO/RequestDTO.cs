using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for Request table
    /// </summary>
    public class RequestDTO
    {
        public string MaYeuCau { get; set; }
        public string MaNguoiGui { get; set; }
        public string ThongTinYeuCau { get; set; }
        public string LyDo { get; set; }
        public DateTime NgayGui { get; set; }
        public string NguoiXacNhan { get; set; }
        public string TrangThai { get; set; }
    }
}