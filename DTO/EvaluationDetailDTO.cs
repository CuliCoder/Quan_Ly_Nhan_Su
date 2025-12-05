using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO cho bảng danhgia_chitiet - Chi tiết đánh giá theo tiêu chí
    /// </summary>
    public class EvaluationDetailDTO
    {
        public int MaChiTiet { get; set; }
        public string MaDanhGia { get; set; }
        public string MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        public int MucDanhGia { get; set; }
        public int DiemToiDa { get; set; }
        public int DiemDatDuoc { get; set; }
        public string GhiChu { get; set; }

        public EvaluationDetailDTO()
        {
            DiemToiDa = 4; // Mặc định điểm tối đa là 4
        }

        public EvaluationDetailDTO(string maDanhGia, string maTieuChi, string tenTieuChi,
                                   int mucDanhGia, int diemToiDa, int diemDatDuoc, string ghiChu = null)
        {
            MaDanhGia = maDanhGia;
            MaTieuChi = maTieuChi;
            TenTieuChi = tenTieuChi;
            MucDanhGia = mucDanhGia;
            DiemToiDa = diemToiDa;
            DiemDatDuoc = diemDatDuoc;
            GhiChu = ghiChu;
        }

        public override string ToString()
        {
            return $"{TenTieuChi}: {DiemDatDuoc}/{DiemToiDa} điểm";
        }
    }

    /// <summary>
    /// DTO cho tiêu chí đánh giá chuẩn
    /// </summary>
    public class EvaluationCriteriaDTO
    {
        public string MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        public string NhomTieuChi { get; set; }
        public int DiemToiDa { get; set; }
        public string MoTa { get; set; }

        public EvaluationCriteriaDTO()
        {
            DiemToiDa = 4; // Mặc định 4 điểm
        }
    }
}