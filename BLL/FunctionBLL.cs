using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
  public class FunctionBLL
  {
    private readonly FunctionDAO dao;

    public FunctionBLL()
    {
      dao = new FunctionDAO();
    }

    public List<FunctionDTO> GetAll()
    {
      return dao.GetAll();
    }

    public bool Create(FunctionDTO function)
    {
      if (function == null || string.IsNullOrWhiteSpace(function.MaChucNang))
      {
        throw new Exception("Dữ liệu không hợp lệ!");
      }

      var existingFunctions = dao.Search(function.MaChucNang).FirstOrDefault(f => f.MaChucNang == function.MaChucNang);
      if (existingFunctions != null)
      {
        throw new Exception("Mã chức năng đã tồn tại!");
      }

      return dao.Create(function);
    }

    public bool Update(FunctionDTO function)
    {
      if (function == null || string.IsNullOrWhiteSpace(function.MaChucNang))
      {
        throw new Exception("Dữ liệu không hợp lệ!");
      }

      return dao.Update(function);
    }

    public bool Delete(string maChucNang)
    {
      return dao.Delete(maChucNang);
    }

    public List<FunctionDTO> Search(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            Console.WriteLine("Từ khóa tìm kiếm không hợp lệ!");
            return new List<FunctionDTO>();
        }

        return dao.Search(searchTerm);
    }

  }
}