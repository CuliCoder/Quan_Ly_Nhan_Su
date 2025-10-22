namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for 'taikhoan' table. Represents the raw data structure.
    /// </summary>
    public class AccountDTO
    {
        public string MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int? MaNhomQuyen { get; set; }
        public bool TinhTrang { get; set; }
    }
}