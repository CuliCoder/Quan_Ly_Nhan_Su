using System;
using System.Collections.Generic;
using YourNamespace.DTO;
using Quan_Ly_Nhan_Su.DAO;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class LaborContractBLL
    {
        private readonly LaborContractDAO _dao;

        public LaborContractBLL()
        {
            _dao = new LaborContractDAO();
        }

        /// <summary>
        /// Lấy danh sách tất cả hợp đồng lao động
        /// </summary>
        public List<LaborContractDTO> GetAllContracts()
        {
            try
            {
                return _dao.GetAllContracts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BLL: {ex.Message}");
                return new List<LaborContractDTO>();
            }
        }

        /// <summary>
        /// Tìm kiếm hợp đồng dựa trên từ khóa (mã hợp đồng, tên nhân viên, hoặc phòng ban)
        /// </summary>
        public List<LaborContractDTO> SearchContracts(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return GetAllContracts();
            }

            List<LaborContractDTO> allContracts = GetAllContracts();
            return allContracts.FindAll(contract =>
                contract.MaHopDong.Contains(keyword) ||
                contract.TenNhanVien.Contains(keyword) ||
                contract.PhongBan.Contains(keyword));
        }

        /// <summary>
        /// Tạo mới hợp đồng lao động
        /// </summary>
        public bool CreateContract(LaborContractDTO contract)
        {
            if (string.IsNullOrEmpty(contract.MaHopDong) || string.IsNullOrEmpty(contract.MaNhanVien))
            {
                return false;
            }
            return _dao.Create(contract);
        }

        /// <summary>
        /// Cập nhật hợp đồng lao động
        /// </summary>
        public bool UpdateContract(LaborContractDTO contract)
        {
            if (string.IsNullOrEmpty(contract.MaHopDong))
            {
                return false;
            }
            return _dao.Update(contract);
        }

        /// <summary>
        /// Xóa hợp đồng lao động
        /// </summary>
        public bool DeleteContract(string maHopDong)
        {
            if (string.IsNullOrEmpty(maHopDong))
            {
                return false;
            }
            return _dao.Delete(maHopDong);
        }
    }
}