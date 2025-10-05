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

        public List<PositionDTO> GetAll() => new List<PositionDTO>(list);

        public bool Insert(PositionDTO position)
        {
            if (position == null)
                throw new ArgumentNullException(nameof(position), "Dữ liệu chức vụ không hợp lệ!");

            bool success = _dao.Create(position);
            if (success)
                list.Add(position);

            return success;
        }

        public bool Update(PositionDTO position)
        {
            if (position == null)
                throw new ArgumentNullException(nameof(position), "Dữ liệu chức vụ không hợp lệ!");

            bool success = _dao.Update(position);
            if (success)
            {
                int index = list.FindIndex(x => x.MaChucVu == position.MaChucVu);
                if (index != -1)
                    list[index] = position;
            }

            return success;
        }

        public bool Delete(string maChucVu)
        {
            if (string.IsNullOrWhiteSpace(maChucVu))
                throw new ArgumentException("Mã chức vụ không được để trống!");

            bool success = _dao.Delete(maChucVu);
            if (success)
                list.RemoveAll(x => x.MaChucVu == maChucVu);

            return success;
        }
        public List<PositionDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<PositionDTO>(list);

            return _dao.searchPositionDTO(keyword);
        }
    }
}
