using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for Position table
    /// </summary>
    public class PositionDTO
    {
        private string maChucVu;
        private string tenChucVu;
        private decimal phuCapChucVu;
        private DateTime? ngayNhanChuc;

        public PositionDTO() { }

        public PositionDTO(string maChucVu, string tenChucVu, decimal phuCapChucVu, DateTime? ngayNhanChuc)
        {
            this.maChucVu = maChucVu;
            this.tenChucVu = tenChucVu;
            this.phuCapChucVu = phuCapChucVu;
            this.ngayNhanChuc = ngayNhanChuc;
        }

        public string MaChucVu 
        { 
            get => maChucVu;
            set => maChucVu = value;
        }

        public string TenChucVu
        {
            get => tenChucVu;
            set => tenChucVu = value;
        }

        public decimal PhuCapChucVu
        {
            get => phuCapChucVu;
            set => phuCapChucVu = value;
        }

        public DateTime? NgayNhanChuc
        {
            get => ngayNhanChuc;
            set => ngayNhanChuc = value;
        }
        public string Display => $"{MaChucVu} - {TenChucVu}";
        public override string ToString()
        {
            return $"maChucVu: {maChucVu}, tenChucVu: {tenChucVu}, phuCapChucVu: {phuCapChucVu}, ngayNhanChuc: {ngayNhanChuc}";
        }
    }
}