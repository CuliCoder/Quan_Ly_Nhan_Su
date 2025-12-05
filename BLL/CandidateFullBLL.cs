using System.Collections.Generic;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class CandidateFullBLL
    {
        private readonly CandidateFullDAO _dao;
        private readonly CandidateDAO _candidateDao;

        public CandidateFullBLL()
        {
            _dao = new CandidateFullDAO();
            _candidateDao = new CandidateDAO();
        }

        public List<CandidateFullDTO> GetAll() => _dao.GetAll();
        

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
            if(!_candidateDao.CheckId(cadiDto.MaUngVien))
            {
                MessageBox.Show("Mã ứng viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_dao.CreateCandidateWithProfile(perDTO, cadiDto))
            {
                return true;
            }
            return false;
        }

        public bool ORMCreateCadidateWPersonalProfile(PersonalProfileDTO perDTO, CandidateDTO cadiDto)
        {
            if (!_candidateDao.CheckId(cadiDto.MaUngVien))
            {
                MessageBox.Show("Mã ứng viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_dao.ORMCreateCandidateWithProfile(perDTO, cadiDto))
            {
                return true;
            }
            return false;
        }

        public List<CandidateFullDTO> Search(string keyword)
        {
            return _dao.Search(keyword);
        }

    }
}
