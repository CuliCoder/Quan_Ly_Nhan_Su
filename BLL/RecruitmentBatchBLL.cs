using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class RecruitmentBatchBLL
    {
        private readonly RecruitmentBatchDAO _dao;
        private static List<RecruitmentBatchDTO> list;
        public RecruitmentBatchBLL()
        {
            _dao = new RecruitmentBatchDAO();
            if (list == null)
                list = _dao.getAll();
        }

        public List<RecruitmentBatchDTO> GetAll() => new List<RecruitmentBatchDTO>(list);

        public RecruitmentBatchDTO GetById(string maTuyenDung)
        {
            return _dao.GetById(maTuyenDung);
        }

        public bool checkedId(string maTuyenDung)
        {
            if (!_dao.checkID(maTuyenDung))
            {
                return false;
            }
            return true;
        }
        public bool Create(RecruitmentBatchDTO batch)
        {

            bool success = _dao.Create(batch);
            if (success)
                list.Add(batch);

            return success;
        }

        public bool Update(RecruitmentBatchDTO batch)
        {
            bool success = _dao.Update(batch);
            if (success)
            {
                int index = list.FindIndex(x => x.MaTuyenDung == batch.MaTuyenDung);
                if (index != -1)
                    list[index] = batch;
            }

            return success;
        }

        public bool Delete(string maTuyenDung)
        {
            bool success = _dao.Delete(maTuyenDung);
            if (success)
                list.RemoveAll(x => x.MaTuyenDung == maTuyenDung);

            return success;
        }
        public List<RecruitmentBatchDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<RecruitmentBatchDTO>(list);

            return _dao.searchRecruitmentBatch(keyword);
        }

        public List<RecruitmentBatchDTO> searchDay (DateTime startDay, DateTime endDay)
        {
            if(startDay == null || endDay == null) 
            {
                return new List<RecruitmentBatchDTO>(list);
            }
            return _dao.searchDayRecruitmentBatch(startDay, endDay);
        }
    }
}
