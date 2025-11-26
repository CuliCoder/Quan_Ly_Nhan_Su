using Google.Protobuf.WellKnownTypes;
using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for Candidate table
    /// </summary>
    public class CandidateDTO
    {
        private string maUngVien;
        private string soCmnd;
        private string maTuyenDung;
        private decimal? mucLuongDeal;
        private string chucVu;
        private string trangThai;

        public string MaUngVien
        {
            get => maUngVien;
            set => maUngVien = value;
           
        }

        public string SoCmnd
        {
            get => soCmnd;
            set => soCmnd = value;
        }

        public string MaTuyenDung
        {
            get => maTuyenDung;
            set => maTuyenDung = value;
        }

        public decimal? MucLuongDeal
        {
            get => mucLuongDeal;
            set => mucLuongDeal = value;
        }


        public string ChucVu
        {
            get => chucVu;
            set => chucVu = value;
        }

        public string TrangThai
        {
            get => trangThai;
            set => trangThai = value;
        }

        public CandidateDTO() { }

        public CandidateDTO(string maUngVien, string soCmnd, string maTuyenDung,
                          decimal? mucLuongDeal,
                          string chucVu, string trangThai)
        {
            this.maUngVien = maUngVien;
            this.soCmnd = soCmnd;
            this.maTuyenDung = maTuyenDung;
            this.mucLuongDeal = mucLuongDeal;
            this.chucVu = chucVu;
            this.trangThai = trangThai;
        }

        public CandidateDTO(CandidateDTO other)
        {
            this.maUngVien = other.maUngVien;
            this.soCmnd = other.soCmnd;
            this.maTuyenDung = other.maTuyenDung;
            this.mucLuongDeal = other.mucLuongDeal;
            this.chucVu = other.chucVu;
            this.trangThai = other.trangThai;
        }
        public override string ToString() =>
            $"Mã Ứng Viên: {maUngVien}, " +
            $"CMND: {soCmnd}, " +
            $"Mã Tuyển Dụng: {maTuyenDung}, " +
            $"Lương Deal: {(mucLuongDeal.HasValue ? mucLuongDeal.Value.ToString("N2") : "N/A")}, " +
            $"Chức Vụ: {chucVu}, " +
            $"Trạng Thái: {trangThai}";
    }
}