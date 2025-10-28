using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    internal class PersonalProfileBLL
    {
        private readonly PersonalProfileDAO _dao;
        private static List<PersonalProfileDTO> list;

        public PersonalProfileBLL()
        {
            _dao = new PersonalProfileDAO();
            if (list == null)
                list = _dao.GetAll();
        }

        public List<PersonalProfileDTO> GetAll() => new List<PersonalProfileDTO>(list);

        public PersonalProfileDTO GetById(string soCmnd)
        {
            return _dao.GetById(soCmnd);
        }

        public bool checkID(string cccd)
        {
            if(!_dao.CheckCccd(cccd)) 
            {
               
                return false; 
            }
            return true;
        }
        public bool Create(PersonalProfileDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            bool success = _dao.Create(dto);
            if (success)
                list.Add(dto);

            return success;
        }

        public bool Update(PersonalProfileDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            bool success = _dao.Update(dto);
            if (success)
            {
                int index = list.FindIndex(x => x.SoCmnd == dto.SoCmnd);
                if (index != -1)
                    list[index] = dto;
            }

            return success;
        }

        public bool Delete(string soCmnd)
        {
            if (string.IsNullOrWhiteSpace(soCmnd))
                throw new ArgumentException("Số CMND không được để trống!");

            bool success = _dao.Delete(soCmnd);
            if (success)
                list.RemoveAll(x => x.SoCmnd == soCmnd);

            return success;
        }

        public bool DeleteList(string soCmnd)
        {
            if(soCmnd.Length > 0)
            {
                list.RemoveAll(x => x.SoCmnd == soCmnd);
                return true;
            }
            return false;
        }

        public List<PersonalProfileDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<PersonalProfileDTO>(list);

            return _dao.Search(keyword);
        }
    }
}
