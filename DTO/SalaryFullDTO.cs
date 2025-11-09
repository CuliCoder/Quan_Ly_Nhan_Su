namespace Quan_Ly_Nhan_Su.DTO
{
    public class SalaryFullDTO
    {
        public string MaLuong { get; set; }
        public string MaNhanVien { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal LuongTheoGio { get; set; }
        public decimal TongPhuCap { get; set; }
        public decimal TongKhoanTru { get; set; }
        public float TongGioLam { get; set; }
        public decimal LuongThucLanh { get; set; }

        public SalaryFullDTO() { }
    }
}
