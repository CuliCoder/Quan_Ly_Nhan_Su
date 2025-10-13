using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for PermissionGroup table
    /// </summary>
    public class PermissionGroupDTO
    {
        private int maNhomQuyen;
        private string tenNhomQuyen;
        private string moTa;

        public int MaNhomQuyen
        {
            get => maNhomQuyen;
            set => maNhomQuyen = value;
        }
        public string TenNhomQuyen
        {
            get => tenNhomQuyen;
            set => tenNhomQuyen = value;
        }
        public string MoTa
        {
            get => moTa;
            set => moTa = value;
        }

        public PermissionGroupDTO() { }

        public PermissionGroupDTO(int maNhomQuyen, string tenNhomQuyen, string moTa)
        {
            this.maNhomQuyen = maNhomQuyen;
            this.tenNhomQuyen = tenNhomQuyen;
            this.moTa = moTa;
        }
    }
}