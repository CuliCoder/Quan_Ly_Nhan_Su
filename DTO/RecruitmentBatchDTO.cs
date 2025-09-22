using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for RecruitmentBatch table
    /// </summary>
    public class RecruitmentBatchDTO
    {
        public string MaTuyenDung { get; set; }
        public string ChucVu { get; set; }
        public string HocVan { get; set; }
        public string GioiTinh { get; set; }
        public string DoTuoi { get; set; }
        public int SoLuongCanTuyen { get; set; }
        public DateTime HanNopHoSo { get; set; }
        public decimal? MucLuongToiThieu { get; set; }
        public decimal? MucLuongToiDa { get; set; }
        public int SoLuongNopHoSo { get; set; }
        public int SoLuongDaTuyen { get; set; }
    }
}