using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    internal class CandidateBUS
    {
        private readonly CandidateDAO _dao;
        private static List<CandidateDTO> list;

        public CandidateBUS()
        {
            _dao = new CandidateDAO();
            if (list == null)
                list = _dao.getAll();
        }

        public List<CandidateDTO> GetAll() => new List<CandidateDTO>(list);

        public CandidateDTO GetById(string maUngVien)
        {
            if (string.IsNullOrWhiteSpace(maUngVien))
                throw new ArgumentException("Mã ứng viên không được để trống!");

            return _dao.getById(maUngVien);
        }

        public bool Create(CandidateDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (_dao.create(dto))
            {
                list.Add(dto);
                return true;
            }
            return false;
        }

        public bool Update(CandidateDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            bool success = _dao.update(dto);
            if (success)
            {
                int index = list.FindIndex(x => x.MaUngVien == dto.MaUngVien);
                if (index != -1)
                    list[index] = dto;
            }
            return success;
        }

        public bool Delete(string maUngVien)
        {
            if (string.IsNullOrWhiteSpace(maUngVien))
                throw new ArgumentException("Mã ứng viên không được để trống!");

            bool success = _dao.delete(maUngVien);
            if (success)
                list.RemoveAll(x => x.MaUngVien == maUngVien);

            return success;
        }

        public List<CandidateDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<CandidateDTO>(list);

            return _dao.search(keyword);
        }
    }
}
