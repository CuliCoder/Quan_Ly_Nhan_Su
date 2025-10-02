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
            return _dao.GetById(maLuong);
        }

        // Thêm
        public bool Insert(SalaryDTO salary)
        {
            return _dao.Insert(salary);
        }

        // Update
        public bool Update(SalaryDTO salary)
        {
            return _dao.Update(salary);
        }

        // Xóa (set TinhTrang = 0)
        public bool Delete(string maLuong)
        {
            return _dao.Delete(maLuong);
        }
    }
}