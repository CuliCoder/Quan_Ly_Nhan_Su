using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class SalaryBLL
    {
        private readonly SalaryDAO _dao = new SalaryDAO();

        // LẤY TẤT CẢ
        public List<SalaryDTO> GetAll() => _dao.GetAll();

        // LẤY THEO MÃ LƯƠNG
        public SalaryDTO GetById(string maLuong)
        {
            if (string.IsNullOrWhiteSpace(maLuong)) return null;
            return _dao.GetById(maLuong);
        }

        // THÊM
        public bool Insert(SalaryDTO s)
        {
            if (!IsValidForSave(s)) return false;
            if (_dao.GetById(s.MaLuong) != null) return false; // đã tồn tại
            return _dao.Insert(s);
        }

        // CẬP NHẬT
        public bool Update(SalaryDTO s)
        {
            if (!IsValidForSave(s)) return false;
            if (_dao.GetById(s.MaLuong) == null) return false; // không tồn tại
            return _dao.Update(s);
        }

        // XÓA MỀM
        public bool Delete(string maLuong)
        {
            if (string.IsNullOrWhiteSpace(maLuong)) return false;
            if (_dao.GetById(maLuong) == null) return false;
            return _dao.Delete(maLuong);
        }

        // LẤY PHIẾU LƯƠNG THEO MÃ NHÂN VIÊN
        public SalaryDTO GetSalaryByEmployee(string maNhanVien)
        {
            if (string.IsNullOrWhiteSpace(maNhanVien)) return null;
            return _dao.GetSalaryByEmployee(maNhanVien);
        }

        // Validate căn bản cho Insert/Update
        private static bool IsValidForSave(SalaryDTO s)
        {
            if (s == null) return false;
            if (string.IsNullOrWhiteSpace(s.MaLuong)) return false;
            if (s.LuongCoBan < 0 || s.LuongThuong < 0 ||
                s.PhuCapChucVu < 0 || s.PhuCapKhac < 0 ||
                s.KhoanTruBaoHiem < 0 || s.KhoanTruKhac < 0 ||
                s.Thue < 0)
                return false;

            return true;
        }
    }
}
