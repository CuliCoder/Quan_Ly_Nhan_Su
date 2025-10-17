using System.Collections.Generic;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class CandidateFullBUS
    {
        private readonly CandidateFullDAO _dao;
        private static List<CandidateFullDTO> list;

        public CandidateFullBUS()
        {
            _dao = new CandidateFullDAO();

            if (list == null)
                list = _dao.GetAll();
        }

        public List<CandidateFullDTO> GetAll() => new List<CandidateFullDTO>(list);
        

        public void Refresh()
        {
            list = _dao.GetAll();
        }

        public CandidateFullDTO GetById(string maUngVien)
        {
            CandidateFullDTO cadiFull = _dao.GetByID(maUngVien);
            if (cadiFull != null)
            {
                return cadiFull;
            }
            return null;
        }
    }
}
