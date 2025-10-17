using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class RecruitmentBatchDTO
    {
        private string maTuyenDung;
        private string chucVu;
        private string hocVan;
        private string gioiTinh;
        private string doTuoi;
        private int soLuongCanTuyen;
        private DateTime hanNopHoSo;
        private decimal? mucLuongToiThieu;
        private decimal? mucLuongToiDa;
        private int soLuongNop;
        private int soLuongDaTuyen;

        public RecruitmentBatchDTO() { }

        public RecruitmentBatchDTO(string maTuyenDung, string chucVu, string hocVan, string gioiTinh, 
            string doTuoi, int soLuongCanTuyen, DateTime hanNopHoSo, decimal? mucLuongToiThieu, 
            decimal? mucLuongToiDa, int soLuongNop, int soLuongDaTuyen)
        {
            this.maTuyenDung = maTuyenDung;
            this.chucVu = chucVu;
            this.hocVan = hocVan;
            this.gioiTinh = gioiTinh;
            this.doTuoi = doTuoi;
            this.soLuongCanTuyen = soLuongCanTuyen;
            this.hanNopHoSo = hanNopHoSo;
            this.mucLuongToiThieu = mucLuongToiThieu;
            this.mucLuongToiDa = mucLuongToiDa;
            this.soLuongNop = soLuongNop;
            this.soLuongDaTuyen = soLuongDaTuyen;
        }
        
        public string MaTuyenDung
        {
            get => maTuyenDung;
            set => maTuyenDung = value;
        }

        public string ChucVu
        {
            get => chucVu;
            set => chucVu = value;
        }

        public string HocVan
        {
            get => hocVan; set => hocVan = value;
        }

        public string DoTuoi
        {
            get => doTuoi;
            set => doTuoi = value;
        }
        public string GioiTinh
        {
            get => gioiTinh;
            set => gioiTinh = value;
        }
        public int SoLuongCanTuyen
        {
            get => soLuongCanTuyen;
            set => soLuongCanTuyen = value;
        }

        public DateTime HanNopHoSo
        {
            get => hanNopHoSo;
            set => hanNopHoSo = value;
        }

        public decimal? MucLuongToiThieu
        {
            get => mucLuongToiThieu;
            set => mucLuongToiThieu = value;
        }

        public decimal? MucLuongToiDa
        {
            get => mucLuongToiDa;
            set => mucLuongToiDa = value;
        }
        
        public int SoLuongNop
        {
            get => soLuongNop;
            set => soLuongNop = value;
        }

        public int SoLuongDaTuyen
        {
            get => soLuongDaTuyen;
            set => soLuongDaTuyen = value;
        }

        public override string ToString()
        {
            return $"matuyendung: {maTuyenDung}, chucvu: {chucVu}, hocVan: {HocVan}, gioiTinh: {gioiTinh}" +
                $"doTuoi: { doTuoi}, soLuongCanTuyen: {soLuongCanTuyen}, hanNopHoSo: {hanNopHoSo}, mucLuongToiThieu: {mucLuongToiThieu}" +
                $"mucLuongToiDa: {mucLuongToiDa}, soLuongNop: {soLuongNop}, soLuongDaTuyen: {soLuongDaTuyen}"
            ;
        }
    }
}