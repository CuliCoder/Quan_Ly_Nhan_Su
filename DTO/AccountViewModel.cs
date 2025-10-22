namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// ViewModel for displaying account information in the UI (DataGridView).
    /// This class combines data from multiple DTOs.
    /// </summary>
    public class AccountViewModel
    {
        // Properties for display columns
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string TenDangNhap { get; set; }
        public string TenNhomQuyen { get; set; }
        public bool TinhTrang { get; set; }

        // Hidden property to uniquely identify the account for operations like edit/delete
        public string MaTaiKhoan { get; set; }
    }
}