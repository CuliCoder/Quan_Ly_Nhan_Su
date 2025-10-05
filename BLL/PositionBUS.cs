using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
namespace Quan_Ly_Nhan_Su.BLL
{
    public class PositionBUS
    {
        private readonly PositionDAO _dao;
        private static List<PositionDTO> list;

        public PositionBUS()
        {
            _dao = new PositionDAO();
            if (list == null)
                list = _dao.getAll();
        }

        public List<PositionDTO> getAll() => list;

        public void insert(PositionDTO position)
        {
            if(_dao.Create(position))
                list.Add(position);
        }

        public void update(PositionDTO position)
        {
            if(_dao.Update(position))
            {
                var index = list.FindIndex(x => x.MaChucVu == position.MaChucVu);
                list[index] = position;
            }

        }
        public void delete(string maChucVu)
        {
            if(_dao.Delete(maChucVu))
            {
                var item = list.FirstOrDefault(x => x.MaChucVu == maChucVu);
                list.Remove(item);
            }
        }
        public List<PositionDTO> searchPositionDTO(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _dao.getAll();
            return _dao.searchPositionDTO(keyword);
        }

    }
}