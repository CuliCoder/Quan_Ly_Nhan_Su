using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.GUI.NhanVienUserControl;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class SalaryFullBLL
    {
        private readonly SalaryFullDAO dao = new SalaryFullDAO();
        private readonly AttendanceBLL attendanceBLL = new AttendanceBLL();

        public List<SalaryFullDTO> GetAllSalaryFull()
        {
            var list = dao.GetAllSalaryFull(DateTime.Now.Month, DateTime.Now.Year);

            foreach (var salary in list)
            {
                salary.TongGioLam = attendanceBLL.calculateTotalOfMonth(salary.MaNhanVien, DateTime.Now.Month, DateTime.Now.Year).TotalHours;
                salary.LuongThucLanh = TinhLuongThucLanh(salary);
            } 
            return list;
        }

        public List<SalaryFullDTO> GetSalaryFullByMonthYear(int thang, int nam)
        {
            var list = dao.GetAllSalaryFull(thang, nam);
            foreach (var salary in list)
            {
                salary.TongGioLam = attendanceBLL.calculateTotalOfMonth(salary.MaNhanVien, DateTime.Now.Month, DateTime.Now.Year).TotalHours;
                salary.LuongThucLanh = TinhLuongThucLanh(salary);
            }

            return list;
        }

        private decimal TinhLuongThucLanh(SalaryFullDTO salary)
        {
            float TongGioBatBuoc = AttendanceBLL.TinhTongGioLam(DateTime.Now.Month, DateTime.Now.Year);
            salary.TongGioLam = attendanceBLL.calculateTotalOfMonth(salary.MaNhanVien, DateTime.Now.Month, DateTime.Now.Year).TotalHours;
            decimal tongGioLam = (decimal)salary.TongGioLam;
            decimal tongGioBatBuoc = (decimal)TongGioBatBuoc;
            if (salary.TongGioLam >= TongGioBatBuoc)
            {
                return salary.LuongCoBan
                    + (tongGioLam - tongGioBatBuoc) * salary.LuongTheoGio
                    + salary.TongPhuCap
                    - salary.TongKhoanTru
                    + salary.LuongCoBan * salary.TongThuong / 100m;
            }
            else
            {
                return (salary.LuongCoBan / tongGioBatBuoc * tongGioLam)
                    + salary.TongPhuCap
                    - salary.TongKhoanTru
                    + salary.LuongCoBan * salary.TongThuong / 100m;
            }
        }

        public SalaryFullDTO GetSalaryFull(string maNhanVien, int thang, int nam)
        {
            var salary = dao.GetSalaryData(maNhanVien, thang, nam);
            if (salary == null) return null;

            salary.TongGioLam = attendanceBLL.calculateTotalOfMonth(maNhanVien, thang, nam).TotalHours;
            int TongGioBatBuoc = AttendanceBLL.TinhTongGioLam(thang, nam);
            decimal tongGioLam = (decimal)salary.TongGioLam;
            decimal tongGioBatBuoc = (decimal)TongGioBatBuoc;

            if (salary.TongGioLam >= TongGioBatBuoc)
            {
                salary.LuongThucLanh = salary.LuongCoBan
                    + (tongGioLam - tongGioBatBuoc) * salary.LuongTheoGio
                    + salary.TongPhuCap
                    - salary.TongKhoanTru
                    +salary.LuongCoBan * salary.TongThuong / 100m;
            }
            else
            {
                salary.LuongThucLanh = (salary.LuongCoBan / tongGioBatBuoc * tongGioLam)
                    + salary.TongPhuCap
                    - salary.TongKhoanTru
                    + salary.LuongCoBan * salary.TongThuong / 100m;
            }

            return salary;
        }
    }
}
