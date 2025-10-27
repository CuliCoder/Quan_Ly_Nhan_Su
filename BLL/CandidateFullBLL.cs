using System.Collections.Generic;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class CandidateFullBLL
    {
        private readonly CandidateFullDAO _dao;
        private static List<CandidateFullDTO> list;

        public CandidateFullBLL()
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

        public bool DeleteCadidateWithProfile(string soCccd, string maUngVien)
        {
            if (_dao.DeleteCandidateWithProfile(soCccd, maUngVien))
            {
                return true;
            }
            return false;
        }

        public bool CreateCadidateWPersonalProfile(PersonalProfileDTO perDTO, CandidateDTO cadiDto)
        {
            if (_dao.CreateCandidateWithProfile(perDTO, cadiDto))
            {
                return true;
            }
            return false;
        }
    }
}
