using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;

namespace Quan_Ly_Nhan_Su.BUS
{
    public class SalaryFullBUS
    {
        private SalaryFullDAO dao = new SalaryFullDAO();

        // Giả sử bạn đã có AttendanceBLL với hàm TinhTongGioLam(maNhanVien, thang, nam)
        private AttendanceBLL attendanceBLL = new AttendanceBLL();


        public SalaryFullDTO GetSalaryFull(string maNhanVien, int thang, int nam)
        {
            var salary = dao.GetSalaryData(maNhanVien, thang, nam);
            if (salary == null) return null;

            // Lấy tổng giờ làm
            salary.TongGioLam = attendanceBLL.calculateTotalOfMonth(maNhanVien, thang, nam).TotalHours;
            int TongGioBatBuoc = AttendanceBLL.TinhTongGioLam(thang, nam);
            decimal tongGioLam = (decimal)salary.TongGioLam;
            decimal tongGioBatBuoc = (decimal)TongGioBatBuoc;

            // Tính lương thực lãnh
            if (tongGioLam >= tongGioBatBuoc)
            {
                salary.LuongThucLanh = salary.LuongCoBan
                    + (tongGioLam - tongGioBatBuoc) * salary.LuongTheoGio
                    + salary.TongPhuCap
                    - salary.TongKhoanTru;
            }
            else
            {
                salary.LuongThucLanh = (salary.LuongCoBan / tongGioBatBuoc * tongGioLam)
                    + salary.TongPhuCap
                    - salary.TongKhoanTru;
            }

            return salary;
        }
    }
}
