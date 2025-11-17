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

       
        public bool Create(RecruitmentBatchDTO batch)
        {
            if(!checkedId(batch.MaTuyenDung))
            {
                MessageBox.Show("Mã tuyển dụng đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool success = _dao.Create(batch);
            if (success)
                list.Add(batch);

            return success;
        }
        public bool checkedId(string maTuyenDung)
        {
            return _dao.checkID(maTuyenDung);
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

        public bool UpdateProfileCreate(string maTuyenDung)
        {
            if (_dao.updateProfileCreate(maTuyenDung))
            {
                RecruitmentBatchDTO dto = list.FirstOrDefault(x => x.MaTuyenDung == maTuyenDung);
                if(dto != null)
                {
                    dto.SoLuongNop += 1;
                    return true;
                }
            }
            return false;
        }

        public bool UpdateProfileDelete(string maTuyenDung)
        {
            if (_dao.updateProfileDelete(maTuyenDung))
            {
                RecruitmentBatchDTO dto = list.FirstOrDefault(x => x.MaTuyenDung == maTuyenDung);
                if (dto != null)
                {
                    dto.SoLuongNop -= 1;
                    return true;
                }
            }
            return false;
        }

        public bool updateNumberOfRecruited(string maTuyenDung)
        {

            if (_dao.updateNumberOfRecruited(maTuyenDung))
            {
                RecruitmentBatchDTO dto = list.FirstOrDefault(x => x.MaTuyenDung == maTuyenDung);
                if (dto != null)
                {
                    dto.SoLuongDaTuyen += 1;
                    return true;
                }
            }
            return false;
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
