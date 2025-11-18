using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class RecruitmentBatchBLL
    {
        private readonly RecruitmentBatchDAO _dao;
        public RecruitmentBatchBLL()
        {
            _dao = new RecruitmentBatchDAO();
        }

        public List<RecruitmentBatchDTO> GetAll()
        {
            return _dao.getAll();
        }

        public RecruitmentBatchDTO GetById(string maTuyenDung)
        {
            return _dao.GetById(maTuyenDung);
        }

       
        public bool Create(RecruitmentBatchDTO batch)
        {
            if(!checkedId(batch.MaTuyenDung))
            {
                MessageBox.Show("Mã tuyển dụng đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool success = _dao.Create(batch);
            return success;
        }

        public bool checkedId(string maTuyenDung)
        {
            return _dao.checkID(maTuyenDung);
        }

        public bool Update(RecruitmentBatchDTO batch)
        {
            return _dao.Update(batch);
        }

        public bool UpdateProfileCreate(string maTuyenDung)
        {      
            return _dao.updateProfileCreate(maTuyenDung);
        }

        public bool UpdateProfileDelete(string maTuyenDung)
        {
            return _dao.updateProfileDelete(maTuyenDung);
        }

        public bool updateNumberOfRecruited(string maTuyenDung)
        {
            return _dao.updateNumberOfRecruited(maTuyenDung);
        }

        public bool Delete(string maTuyenDung)
        {
            return _dao.Delete(maTuyenDung);
        }
        public List<RecruitmentBatchDTO> Search(string keyword)
        {
            return _dao.searchRecruitmentBatch(keyword);
        }

        public List<RecruitmentBatchDTO> searchDay (DateTime startDay, DateTime endDay)
        {
            return _dao.searchDayRecruitmentBatch(startDay, endDay);
        }
    }
}
