using Mysqlx.Crud;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Quan_Ly_Nhan_Su.BLL
{
    public class RecruitmentBatchBUS
    {
        private readonly RecruitmentBatchDAO dao;
        private static List<RecruitmentBatchDTO> list;

        public RecruitmentBatchBUS()
        {
            dao = new RecruitmentBatchDAO();
            if(list == null )
                list = dao.getAll();
        }

        public List<RecruitmentBatchDTO> getAll() => list;

        public void create(RecruitmentBatchDTO batch)
        {
            dao.Create(batch);
            list.Add(batch);
        }

        public void delete(String maTuyenDung) 
        {
            if(dao.Delete(maTuyenDung))
            {
                var item = list.FirstOrDefault(x => x.MaTuyenDung == maTuyenDung);
                if (item != null)
                {
                    list.Remove(item);
                }
            }
        }

        public void update(RecruitmentBatchDTO batch)
        {
            if (dao.Update(batch))
            {
                var index = list.FindIndex(x => x.MaTuyenDung == batch.MaTuyenDung);
                if(index != -1)
                {
                    list[index] = batch;
                }
            }
        }
    }
}