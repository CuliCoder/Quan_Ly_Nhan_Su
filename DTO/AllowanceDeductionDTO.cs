using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO cho bảng PhuCapKhoanTru
    /// </summary>
    public class AllowanceDeductionDTO
    {
        public int MaPhuCapKhoanTru { get; set; }
        public string MaNhanVien { get; set; }
        public string Loai { get; set; } // "PhuCap" hoặc "KhoanTru"
        public string MoTa { get; set; }
        public decimal SoTien { get; set; }
        public int ThangApDung { get; set; }
        public int NamApDung { get; set; }

        public AllowanceDeductionDTO() { }

        public AllowanceDeductionDTO(int maPhuCapKhoanTru, string maNhanVien, string loai, string moTa,
                                 decimal soTien, int thangApDung, int namApDung)
        {
            MaPhuCapKhoanTru = maPhuCapKhoanTru;
            MaNhanVien = maNhanVien;
            Loai = loai;
            MoTa = moTa;
            SoTien = soTien;
            ThangApDung = thangApDung;
            NamApDung = namApDung;
        }

        public override string ToString()
        {
            return $"{Loai} ({MoTa}) - {SoTien:N0} VNĐ - {ThangApDung}/{NamApDung}";
        }
    }
}
