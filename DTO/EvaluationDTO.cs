    using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for Evaluation table
    /// </summary>
    public class EvaluationDTO
    {
        private string maDanhGia;
        private string maNhanVien;
        private string maNguoiDanhGia;
        private DateTime ngayDanhGia;
        private int diemDanhGia;
        private string xepLoai;
        private string chiTietDanhGia;
        private string ghiChu;

        public string MaDanhGia
        {
            get => maDanhGia;
            set => maDanhGia = value;
        }
        public string MaNhanVien
        {
            get => maNhanVien;
            set => maNhanVien = value;
        }
        public string MaNguoiDanhGia
        {
            get => maNguoiDanhGia;
            set => maNguoiDanhGia = value;
        }
        public DateTime NgayDanhGia
        {
            get => ngayDanhGia;
            set => ngayDanhGia = value;
        }
        public int DiemDanhGia
        {
            get => diemDanhGia;
            set => diemDanhGia = value;
        }
        public string XepLoai
        {
            get => xepLoai;
            set => xepLoai = value;
        }
        public string ChiTietDanhGia
        {
            get => chiTietDanhGia;
            set => chiTietDanhGia = value;
        }
        public string GhiChu
        {
            get => ghiChu;
            set => ghiChu = value;
        }
    }
}