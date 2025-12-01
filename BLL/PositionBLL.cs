using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class PositionBLL
    {
        private readonly PositionDAO _dao;

        public PositionBLL()
        {
            _dao = new PositionDAO();
        }

        public List<PositionDTO> GetAll() => _dao.getAll();

        public bool Insert(PositionDTO position)
        {
            return _dao.Create(position);
        }

        public bool Update(PositionDTO position)
        {
            return _dao.Update(position);
        }

        public bool Delete(string maChucVu)
        {
            return _dao.Delete(maChucVu);
        }
        public List<PositionDTO> Search(string keyword)
        {
            return _dao.searchPositionDTO(keyword);
        }

        public PositionDTO GetPosition(string maChucVu)
        {
            return _dao.GetPosition(maChucVu);
        }

        public List<PositionDTO> GetAllPositions() => _dao.GetAllPositions();

        public decimal GetLuongTheoGio(string maChucVu) => _dao.GetLuongTheoGioByMaChucVu(maChucVu);
    }
}
