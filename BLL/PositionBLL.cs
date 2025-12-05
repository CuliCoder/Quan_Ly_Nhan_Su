using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class PositionBLL
    {
        private readonly PositionDAO _dao;
        private List<PositionDTO> listCache;
        public PositionBLL()
        {
            _dao = new PositionDAO();
            if(listCache == null)
                listCache = _dao.getAll();
        }

        public List<PositionDTO> GetAll() => _dao.getAll();

        public bool Insert(PositionDTO position)
        {
            if (!_dao.CheckId(position.MaChucVu))
            {
                MessageBox.Show("Mã chức vụ đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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


        public List<PositionDTO> SearchLINQ(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return new List<PositionDTO>(listCache);
            }   

            string lowerKeyword = keyword.ToLower().Trim();

            var filteredList = listCache.Where(pos =>
                    (pos.MaChucVu ?? "").ToLower().Contains(lowerKeyword) ||
                    (pos.TenChucVu ?? "").ToLower().Contains(lowerKeyword)
            );
            return filteredList.ToList();
        }
    }
}
