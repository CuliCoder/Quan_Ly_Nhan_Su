using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class SalaryBLL
    {
        private readonly SalaryDAO _dao = new SalaryDAO();

        // ALL
        public List<SalaryDTO> GetAll()
        {
            return _dao.GetAll(); 
        }

        // get by ID
        public SalaryDTO GetById(string maLuong)
        {
            if (string.IsNullOrWhiteSpace(maLuong))
                return null;
            return _dao.GetById(maLuong);
        }

        // Thêm
        public bool Insert(SalaryDTO salary)
        {
            if (salary == null ||
                string.IsNullOrWhiteSpace(salary.MaLuong) ||
                salary.LuongCoBan < 0 ||
                salary.LuongThuong < 0 ||
                salary.PhuCapChucVu < 0 ||
                salary.PhuCapKhac < 0 ||
                salary.KhoanTruBaoHiem < 0 ||
                salary.KhoanTruKhac < 0 ||
                salary.Thue < 0)
            {
                return false;
            }
            if (_dao.GetById(salary.MaLuong) != null)
                return false;

            return _dao.Insert(salary);
        }

        // Update
        public bool Update(SalaryDTO salary)
        {
            if (salary == null ||
                string.IsNullOrWhiteSpace(salary.MaLuong) ||
                salary.LuongCoBan < 0 ||
                salary.LuongThuong < 0 ||
                salary.PhuCapChucVu < 0 ||
                salary.PhuCapKhac < 0 ||
                salary.KhoanTruBaoHiem < 0 ||
                salary.KhoanTruKhac < 0 ||
                salary.Thue < 0)
            {
                return false;
            }
            if (_dao.GetById(salary.MaLuong) == null)
                return false;

            return _dao.Update(salary);
        }

        // Xóa (set TinhTrang = 0)
        public bool Delete(string maLuong)
        {
            if (string.IsNullOrWhiteSpace(maLuong))
                return false;
            if (_dao.GetById(maLuong) == null)
                return false;

            return _dao.Delete(maLuong);
        }
    }
}