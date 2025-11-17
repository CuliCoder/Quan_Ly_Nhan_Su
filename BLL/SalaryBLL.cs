using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class SalaryBLL
    {
        private readonly SalaryDAO dao = new SalaryDAO();

        public List<SalaryDTO> GetAllSalaries()
        {
            return dao.GetAll();
        }

        public bool AddSalary(SalaryDTO luong)
        {
            return dao.Insert(luong);
        }

        public bool UpdateSalary(SalaryDTO luong)
        {
            return dao.Update(luong);
        }

        public bool DeleteSalary(string maLuong)
        {
            return dao.Delete(maLuong);
        }

        public List<SalaryDTO> SearchSalary(string tuKhoa)
        {
            return dao.Search(tuKhoa);
        }
    }
}
