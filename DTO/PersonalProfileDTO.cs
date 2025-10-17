using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class PersonalProfileDTO
    {
        // ======= THUỘC TÍNH PRIVATE =======
        private string soCmnd;
        private string hoTen;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string diaChi;
        private string email;
        private string soDienThoai;
        private string noiCap;
        private DateTime ngayCap;
        private string danToc;
        private string hocVan;
        private string honNhan;
        private string chuyenNganh;
        private string hinhAnh;

        // ======= GETTER - SETTER =======
        public string SoCmnd { get => soCmnd; set => soCmnd = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string NoiCap { get => noiCap; set => noiCap = value; }
        public DateTime NgayCap { get => ngayCap; set => ngayCap = value; }
        public string DanToc { get => danToc; set => danToc = value; }
        public string HocVan { get => hocVan; set => hocVan = value; }
        public string HonNhan { get => honNhan; set => honNhan = value; }
        public string ChuyenNganh { get => chuyenNganh; set => chuyenNganh = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }

        // ======= CONSTRUCTOR MẶC ĐỊNH =======
        public PersonalProfileDTO()
        {
        }

        // ======= CONSTRUCTOR ĐẦY ĐỦ THÔNG TIN =======
        public PersonalProfileDTO(
            string soCmnd,
            string hoTen,
            DateTime ngaySinh,
            string gioiTinh,
            string diaChi,
            string email,
            string soDienThoai,
            string noiCap,
            DateTime ngayCap,
            string danToc,
            string hocVan,
            string honNhan,
            string chuyenNganh,
            string hinhAnh)
        {
            this.soCmnd = soCmnd;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.email = email;
            this.soDienThoai = soDienThoai;
            this.noiCap = noiCap;
            this.ngayCap = ngayCap;
            this.danToc = danToc;
            this.hocVan = hocVan;
            this.honNhan = honNhan;
            this.chuyenNganh = chuyenNganh;
            this.hinhAnh = hinhAnh;
        }

        // ======= CONSTRUCTOR SAO CHÉP =======
        public PersonalProfileDTO(PersonalProfileDTO other)
        {
            if (other == null) return;
            this.soCmnd = other.soCmnd;
            this.hoTen = other.hoTen;
            this.ngaySinh = other.ngaySinh;
            this.gioiTinh = other.gioiTinh;
            this.diaChi = other.diaChi;
            this.email = other.email;
            this.soDienThoai = other.soDienThoai;
            this.noiCap = other.noiCap;
            this.ngayCap = other.ngayCap;
            this.danToc = other.danToc;
            this.hocVan = other.hocVan;
            this.honNhan = other.honNhan;
            this.chuyenNganh = other.chuyenNganh;
            this.hinhAnh = other.hinhAnh;
        }

        // ======= PHƯƠNG THỨC TO STRING =======
        public override string ToString()
        {
            return $"CMND: {soCmnd}, Họ tên: {hoTen}, Ngày sinh: {ngaySinh:dd/MM/yyyy}, " +
                   $"Giới tính: {gioiTinh}, Email: {email}, SĐT: {soDienThoai}, " +
                   $"Địa chỉ: {diaChi}, Dân tộc: {danToc}, Học vấn: {hocVan}, " +
                   $"Hôn nhân: {honNhan}, Chuyên ngành: {chuyenNganh}";
        }
    }
}
