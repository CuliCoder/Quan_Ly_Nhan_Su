using System;

namespace YourNamespace.DTO
{
    /// <summary>
    /// DTO for Candidate table
    /// </summary>
    public class CandidateDTO
    {
        public string MaUngVien { get; set; }
        public string SoCmnd { get; set; }
        public string MaTuyenDung { get; set; }
        public decimal? MucLuongDeal { get; set; }
        public string MaTrinhDo { get; set; }
        public string ChucVu { get; set; }
        public string TrangThai { get; set; }
    }
}