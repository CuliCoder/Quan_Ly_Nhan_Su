using System;

namespace YourNamespace.DTO
{
    /// <summary>
    /// DTO for PermissionGroup table
    /// </summary>
    public class PermissionGroupDTO
    {
        public string MaNhomQuyen { get; set; }
        public string TenNhomQuyen { get; set; }
        public string MangChucNang { get; set; } // JSON stored as string
    }
}