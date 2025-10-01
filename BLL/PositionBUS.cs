using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
namespace Quan_Ly_Nhan_Su.BLL
{
    public class PositionBUS
    {
        private readonly PositionDAO dao;
        private static List<PositionDTO> list;

        public PositionBUS()
        {
            dao = new PositionDAO();
            if (list == null)
                list = dao.getAll();
        }

        public List<PositionDTO> getAll() => list;

        public void insert(PositionDTO position)
        {
            if(dao.Create(position))
                list.Add(position);
        }

        public void update(PositionDTO position)
        {
            if(dao.Update(position))
            {
                var index = list.FindIndex(x => x.MaChucVu == position.MaChucVu);
                list[index] = position;
            }

        }

        public void delete(String maChucVu)
        {
            if(dao.Delete(maChucVu))
            {
                var item = list.FirstOrDefault(x => x.MaChucVu == maChucVu);
                list.Remove(item);
            }
        }
    }
}