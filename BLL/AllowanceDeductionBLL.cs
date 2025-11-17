using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class AllowanceDeductionBLL
    {
        private readonly AllowanceDeductionDAO dao = new AllowanceDeductionDAO();

        public List<AllowanceDeductionDTO> GetAll()
        {
            return dao.GetAll();
        }

        public bool Insert(AllowanceDeductionDTO phuCapKhoanTru)
        {
            return dao.Insert(phuCapKhoanTru);
        }

        public bool Update(AllowanceDeductionDTO phuCapKhoanTru)
        {
            return dao.Update(phuCapKhoanTru);
        }

        public bool Delete(int maPhuCapKhoanTru)
        {
            return dao.Delete(maPhuCapKhoanTru);
        }

        public List<AllowanceDeductionDTO> Search(string tuKhoa)
        {
            return dao.Search(tuKhoa);
        }
    }
}
