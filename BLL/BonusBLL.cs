using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BULL
{
    public class BonusBULL
    {
        private readonly BonusDAO dao = new BonusDAO();

        public List<BonusDTO> GetAllBonuses()
        {
            return dao.GetAll();
        }

        public bool AddBonus(BonusDTO thuong)
        {
            return dao.Insert(thuong);
        }

        public bool UpdateBonus(BonusDTO thuong)
        {
            return dao.Update(thuong);
        }

        public bool DeleteBonus(int maThuong)
        {
            return dao.Delete(maThuong);
        }

        public List<BonusDTO> SearchBonus(string tuKhoa)
        {
            return dao.Search(tuKhoa);
        }
    }
}
