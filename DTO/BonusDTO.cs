using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO cho bảng Thuong
    /// </summary>
    public class BonusDTO
    {
        public int MaThuong { get; set; }
        public string MaNhanVien { get; set; }
        public string TenThuong { get; set; }
        public decimal PhanTramThuong { get; set; }
        public int ThangApDung { get; set; }
        public int NamApDung { get; set; }

        public BonusDTO() { }

        public BonusDTO(int maThuong, string maNhanVien, string tenThuong, decimal phanTramThuong, int thangApDung, int namApDung)
        {
            MaThuong = maThuong;
            MaNhanVien = maNhanVien;
            TenThuong = tenThuong;
            PhanTramThuong = phanTramThuong;
            ThangApDung = thangApDung;
            NamApDung = namApDung;
        }

        public override string ToString()
        {
            return $"{MaNhanVien} - Thưởng: {PhanTramThuong}% ({ThangApDung}/{NamApDung})";
        }
    }
}
