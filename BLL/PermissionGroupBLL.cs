using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class PermissionGroupBLL
    {
        private readonly PermissionGroupDAO _dao = new PermissionGroupDAO();

        // get ALL
        public List<PermissionGroupDTO> GetAll()
        {
            return _dao.GetAll();
        }

        // get by ID
        public PermissionGroupDTO GetById(int id)
        {
            return _dao.GetbyID(id);
        }

        // Thêm
        public bool Insert(PermissionGroupDTO group)
        {
            return _dao.Insert(group);
        }

        // Update
        public bool Update(PermissionGroupDTO group)
        {
            return _dao.Update(group);
        }

        // Xóa (chuyển trạng thái)
        public bool Delete(int id)
        {
            return _dao.Delete(id);
        }
    }
}