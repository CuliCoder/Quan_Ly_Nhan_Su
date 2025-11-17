using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.BLL
{
    internal class CandidateBLL
    {
        private readonly CandidateDAO _dao;
        private static List<CandidateDTO> list;
        
        public CandidateBLL()
        {
            _dao = new CandidateDAO();
            if (list == null)
                list = _dao.getAll();
        }

        public List<CandidateDTO> GetAll() => new List<CandidateDTO>(list);


        public CandidateDTO GetById(string maUngVien)
        {
            return _dao.getById(maUngVien);
        }

        public bool Create(CandidateDTO dto)
        {
            if (!CheckId(dto.MaUngVien))
            {
               MessageBox.Show("Mã ứng viên đã tồn tại. Vui lòng sử dụng mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
            }

            if (_dao.Create(dto))
            {
                list.Add(dto);
                return true;
            }
            return false;
        }

        public bool CheckId(string id)
        {
            return _dao.CheckId(id);
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

        public bool UpdateStatus(string maUngVien, string trangThai)
        {
            if (string.IsNullOrEmpty(maUngVien) || string.IsNullOrEmpty(trangThai))
                return false;
            bool success = _dao.UpdateStatus(maUngVien, trangThai);
            if (success)
            {
                CandidateDTO dto = list.FirstOrDefault(x => x.MaUngVien == maUngVien);
                if (dto != null)
                {
                    dto.TrangThai = trangThai;
                }
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

        public bool DeleteList(string maUngVien)
        {
            if (maUngVien.Length > 0)
            {
                list.RemoveAll(x => x.MaUngVien == maUngVien);
                return true;
            }
            return false;
        }

        public List<CandidateDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<CandidateDTO>(list);

            return _dao.search(keyword);
        }
    }
}
