using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class YeuCauDTO
    {
        public string MaYeuCau { get; set; }
        public string MaNguoiGui { get; set; }
        public string TenNguoiGui { get; set; }
        public string EmailNguoiGui { get; set; }
        public string ThongTinYeuCau { get; set; }
        public DateTime NgayGui { get; set; }
        public DateTime? NgayBatDau { get; set; } // Giả định có ngày bắt đầu/kết thúc
        public DateTime? NgayKetThuc { get; set; }
        public string TrangThai { get; set; } // Ví dụ: "Draft", "Submitted", "Approved"
    }
}