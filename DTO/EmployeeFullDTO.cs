using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for Employee table
    /// </summary>
    public class EmployeeDTO
    {
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string SoCmnd { get; set; }
        public string HocVan { get; set; }
        public string ChuyenNganh { get; set; }
        public string PhongBan { get; set; }
        public string ChucVu { get; set; }
        public decimal MucLuong { get; set; }
        public string DiaChi { get; set; } // Thêm thuộc tính DiaChi
        public string HinhAnh { get; set; } // Thêm thuộc tính HinhAnh (path ảnh avatar)
    }
}