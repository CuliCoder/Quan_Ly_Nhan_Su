using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO lưu lịch sử gia hạn hợp đồng
    /// </summary>
    public class ExtensionHistoryDTO
    {
        public string MaQuyetDinh { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayQuyetDinh { get; set; }
        public decimal ThoiGianGiaHan { get; set; } // Số năm (1, 2, 1.5...)
    }
}
