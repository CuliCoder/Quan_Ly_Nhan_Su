using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
  public class PersonalProfileBUS
  {
    private readonly PersonalProfileDAO dao;

    public PersonalProfileBUS()
    {
      dao = new PersonalProfileDAO();
    }

    public List<PersonalProfileDTO> GetAll()
    {
      return dao.Search("");
    }

    public bool Create(PersonalProfileDTO pp)
    {
      if (pp == null || string.IsNullOrWhiteSpace(pp.SoCmnd))
      {
        throw new Exception("Dữ liệu không hợp lệ!");
      }

      var existingProfiles = dao.Search(pp.SoCmnd).FirstOrDefault(f => f.SoCmnd == pp.SoCmnd);
      if (existingProfiles != null)
      {
        throw new Exception("Số CMND đã tồn tại!");
      }

      return dao.Create(pp);
    }

    public bool Update(PersonalProfileDTO pp)
    {
      if (pp == null || string.IsNullOrWhiteSpace(pp.SoCmnd))
      {
        throw new Exception("Dữ liệu không hợp lệ!");
      }

      return dao.Update(pp);
    }

    public bool Delete(PersonalProfileDTO pp)
    {
      return dao.Delete(pp.SoCmnd);
    }

  }
}