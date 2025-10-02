using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for PermissionGroup table
    /// </summary>
    public class PermissionGroupDTO
    {
        public int MaNhomQuyen { get; set; }
        public string TenNhomQuyen { get; set; }
        public string MoTa { get; set; }

        public PermissionGroupDTO() { }

        public PermissionGroupDTO(int maNhomQuyen, string tenNhomQuyen, string moTa)
        {
            MaNhomQuyen = maNhomQuyen;
            TenNhomQuyen = tenNhomQuyen;
            MoTa = moTa;
        }
    }
}