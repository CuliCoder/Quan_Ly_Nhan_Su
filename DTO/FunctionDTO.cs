// File: Quan_Ly_Nhan_Su.DTO/FunctionDTO.cs
using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class FunctionDTO
    {
        // Sửa: MaChucNang -> int, TinhTrang -> bool
        public int MaChucNang { get; set; }
        public string TenChucNang { get; set; }
        public bool TinhTrang { get; set; }
    }
}