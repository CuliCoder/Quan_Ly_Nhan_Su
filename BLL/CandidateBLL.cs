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
        
        public CandidateBLL()
        {
            _dao = new CandidateDAO();

        }

        public List<CandidateDTO> GetAll() => _dao.getAll();


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
           
            return _dao.update(dto);
        }

        public bool UpdateStatus(string maUngVien, string trangThai)
        {
            if (string.IsNullOrEmpty(maUngVien) || string.IsNullOrEmpty(trangThai))
                return false;     
            return _dao.UpdateStatus(maUngVien, trangThai);
        }

        public bool Delete(string maUngVien)
        {
            if (string.IsNullOrWhiteSpace(maUngVien))
                throw new ArgumentException("Mã ứng viên không được để trống!");
            return _dao.delete(maUngVien);
        }

 

        public List<CandidateDTO> Search(string keyword)
        {
            return _dao.search(keyword);
        }
    }
}
