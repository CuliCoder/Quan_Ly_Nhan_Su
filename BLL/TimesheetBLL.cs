using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class TimesheetBLL
    {
        private readonly TimesheetDAO _dao = new TimesheetDAO();

        // Lấy tất cả
        public List<TimesheetDTO> GetAll()
        {
            return _dao.GetAll();
        }

        // Lấy theo mã
        public TimesheetDTO GetById(string maBangChamCong)
        {
            if (string.IsNullOrWhiteSpace(maBangChamCong))
                return null;
            return _dao.GetById(maBangChamCong);
        }

        // Thêm mới
        public bool Insert(TimesheetDTO timesheet)
        {
            if (timesheet == null ||
                string.IsNullOrWhiteSpace(timesheet.MaBangChamCong) ||
                string.IsNullOrWhiteSpace(timesheet.MaNV) ||
                timesheet.ThangChamCong <= 0 ||
                timesheet.NamChamCong <= 0 ||
                timesheet.SoNgayLamViec < 0 ||
                timesheet.SoNgayNghi < 0 ||
                timesheet.SoNgayTre < 0 ||
                timesheet.SoGioLamThem < 0)
            {
                return false;
            }
            if (_dao.GetById(timesheet.MaBangChamCong) != null)
                return false;

            return _dao.Insert(timesheet);
        }

        // Cập nhật
        public bool Update(TimesheetDTO timesheet)
        {
            if (timesheet == null ||
                string.IsNullOrWhiteSpace(timesheet.MaBangChamCong) ||
                string.IsNullOrWhiteSpace(timesheet.MaNV) ||
                timesheet.ThangChamCong <= 0 ||
                timesheet.NamChamCong <= 0 ||
                timesheet.SoNgayLamViec < 0 ||
                timesheet.SoNgayNghi < 0 ||
                timesheet.SoNgayTre < 0 ||
                timesheet.SoGioLamThem < 0)
            {
                return false;
            }
            if (_dao.GetById(timesheet.MaBangChamCong) == null)
                return false;

            return _dao.Update(timesheet);
        }

        // Xóa (xóa vật lý)
        public bool Delete(string maBangChamCong)
        {
            if (string.IsNullOrWhiteSpace(maBangChamCong))
                return false;
            if (_dao.GetById(maBangChamCong) == null)
                return false;

            return _dao.Delete(maBangChamCong);
        }

        // Tìm kiếm
        public List<TimesheetDTO> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<TimesheetDTO>();
            return _dao.Search(searchTerm);
        }
    }
}