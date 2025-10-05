using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class RecruitmentBatchBUS
    {
        private readonly RecruitmentBatchDAO _dao;
        private static List<RecruitmentBatchDTO> list;
        public RecruitmentBatchBUS()
        {
            _dao = new RecruitmentBatchDAO();
            if (list == null)
                list = _dao.getAll();
        }

        public List<RecruitmentBatchDTO> GetAll() => new List<RecruitmentBatchDTO>(list);

        public bool Create(RecruitmentBatchDTO batch)
        {
            if (batch == null)
                throw new ArgumentNullException(nameof(batch), "Thông tin đợt tuyển dụng không hợp lệ!");

            bool success = _dao.Create(batch);
            if (success)
                list.Add(batch);

            return success;
        }

        public bool Update(RecruitmentBatchDTO batch)
        {
            if (batch == null)
                throw new ArgumentNullException(nameof(batch), "Thông tin đợt tuyển dụng không hợp lệ!");

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
            if (string.IsNullOrWhiteSpace(maTuyenDung))
                throw new ArgumentException("Mã tuyển dụng không được để trống!");

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
    }
}
