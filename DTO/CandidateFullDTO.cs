using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class CandidateFullDTO
    {
        // ====== Fields ======
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
        private string trinhDoHocVan;
        private string honNhan;
        private string chuyenNganh;
        private string hinhAnh;

        // Tuyển dụng
        private string maTuyenDung;
        private string chucVu;
        private string gioiTinhTuyenDung;
        private string doTuoi;
        private DateTime hanNopHoSo;
        private decimal? mucLuongToiThieu;
        private decimal? mucLuongToiDa;
        private int soLuongNop;
        private int soLuongDaTuyen;

        // Ứng viên
        private string maUngVien;
        private decimal? mucLuongDeal;
        private string trangThai;

        // ====== Properties ======
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
        public string TrinhDoHocVan { get => trinhDoHocVan; set => trinhDoHocVan = value; }
        public string HonNhan { get => honNhan; set => honNhan = value; }
        public string ChuyenNganh { get => chuyenNganh; set => chuyenNganh = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }

        public string MaTuyenDung { get => maTuyenDung; set => maTuyenDung = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string GioiTinhTuyenDung { get => gioiTinhTuyenDung; set => gioiTinhTuyenDung = value; }
        public string DoTuoi { get => doTuoi; set => doTuoi = value; }
        public DateTime HanNopHoSo { get => hanNopHoSo; set => hanNopHoSo = value; }
        public decimal? MucLuongToiThieu { get => mucLuongToiThieu; set => mucLuongToiThieu = value; }
        public decimal? MucLuongToiDa { get => mucLuongToiDa; set => mucLuongToiDa = value; }
        public int SoLuongNop { get => soLuongNop; set => soLuongNop = value; }
        public int SoLuongDaTuyen { get => soLuongDaTuyen; set => soLuongDaTuyen = value; }

        public string MaUngVien { get => maUngVien; set => maUngVien = value; }
        public decimal? MucLuongDeal { get => mucLuongDeal; set => mucLuongDeal = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }

        // ====== Constructors ======

        // 1️⃣ Constructor mặc định
        public CandidateFullDTO() { }

        // 2️⃣ Constructor đầy đủ
        public CandidateFullDTO(
            string soCmnd, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi,
            string email, string soDienThoai, string noiCap, DateTime ngayCap, string danToc,
            string trinhDoHocVan, string honNhan, string chuyenNganh, string hinhAnh,
            string maTuyenDung, string chucVu, string gioiTinhTuyenDung, string doTuoi,
            DateTime hanNopHoSo, decimal? mucLuongToiThieu, decimal? mucLuongToiDa,
            int soLuongNop, int soLuongDaTuyen,
            string maUngVien, decimal? mucLuongDeal, string trangThai)
        {
            SoCmnd = soCmnd;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            Email = email;
            SoDienThoai = soDienThoai;
            NoiCap = noiCap;
            NgayCap = ngayCap;
            DanToc = danToc;
            TrinhDoHocVan = trinhDoHocVan;
            HonNhan = honNhan;
            ChuyenNganh = chuyenNganh;
            HinhAnh = hinhAnh;
            MaTuyenDung = maTuyenDung;
            ChucVu = chucVu;
            GioiTinhTuyenDung = gioiTinhTuyenDung;
            DoTuoi = doTuoi;
            HanNopHoSo = hanNopHoSo;
            MucLuongToiThieu = mucLuongToiThieu;
            MucLuongToiDa = mucLuongToiDa;
            SoLuongNop = soLuongNop;
            SoLuongDaTuyen = soLuongDaTuyen;
            MaUngVien = maUngVien;
            MucLuongDeal = mucLuongDeal;
            TrangThai = trangThai;
        }

        // 3️⃣ Constructor sao chép (copy)
        public CandidateFullDTO(CandidateFullDTO other)
        {
            if (other != null)
            {
                SoCmnd = other.SoCmnd;
                HoTen = other.HoTen;
                NgaySinh = other.NgaySinh;
                GioiTinh = other.GioiTinh;
                DiaChi = other.DiaChi;
                Email = other.Email;
                SoDienThoai = other.SoDienThoai;
                NoiCap = other.NoiCap;
                NgayCap = other.NgayCap;
                DanToc = other.DanToc;
                TrinhDoHocVan = other.TrinhDoHocVan;
                HonNhan = other.HonNhan;
                ChuyenNganh = other.ChuyenNganh;
                HinhAnh = other.HinhAnh;
                MaTuyenDung = other.MaTuyenDung;
                ChucVu = other.ChucVu;
                GioiTinhTuyenDung = other.GioiTinhTuyenDung;
                DoTuoi = other.DoTuoi;
                HanNopHoSo = other.HanNopHoSo;
                MucLuongToiThieu = other.MucLuongToiThieu;
                MucLuongToiDa = other.MucLuongToiDa;
                SoLuongNop = other.SoLuongNop;
                SoLuongDaTuyen = other.SoLuongDaTuyen;
                MaUngVien = other.MaUngVien;
                MucLuongDeal = other.MucLuongDeal;
                TrangThai = other.TrangThai;
            }
        }

        // ====== ToString() ======
        public override string ToString()
        {
            return
                $"[Ứng viên]\n" +
                $"Mã ứng viên: {MaUngVien}\n" +
                $"Họ tên: {HoTen}\n" +
                $"Số CMND: {SoCmnd}\n" +
                $"Ngày sinh: {NgaySinh:dd/MM/yyyy}\n" +
                $"Giới tính: {GioiTinh}\n" +
                $"Địa chỉ: {DiaChi}\n" +
                $"Email: {Email}\n" +
                $"SĐT: {SoDienThoai}\n" +
                $"Nơi cấp: {NoiCap}\n" +
                $"Ngày cấp: {NgayCap:dd/MM/yyyy}\n" +
                $"Dân tộc: {DanToc}\n" +
                $"Trình độ học vấn: {TrinhDoHocVan}\n" +
                $"Hôn nhân: {HonNhan}\n" +
                $"Chuyên ngành: {ChuyenNganh}\n" +
                $"Hình ảnh: {HinhAnh}\n" +
                $"Mức lương Deal: {MucLuongDeal}\n" +
                $"Trạng thái: {TrangThai}\n\n" +
                $"[Tuyển dụng]\n" +
                $"Mã tuyển dụng: {MaTuyenDung}\n" +
                $"Chức vụ: {ChucVu}\n" +
                $"Giới tính tuyển dụng: {GioiTinhTuyenDung}\n" +
                $"Độ tuổi: {DoTuoi}\n" +
                $"Hạn nộp hồ sơ: {HanNopHoSo:dd/MM/yyyy}\n" +
                $"Mức lương tối thiểu: {MucLuongToiThieu}\n" +
                $"Mức lương tối đa: {MucLuongToiDa}\n" +
                $"Số lượng nộp: {SoLuongNop}\n" +
                $"Số lượng đã tuyển: {SoLuongDaTuyen}";
        }
    }
}
