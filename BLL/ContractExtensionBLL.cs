//using System;
//using System.Collections.Generic;
//using Quan_Ly_Nhan_Su.DAO;
//using Quan_Ly_Nhan_Su.DTO;

//namespace Quan_Ly_Nhan_Su.BLL
//{
//    /// <summary>
//    /// Business Logic Layer for ContractExtension
//    /// </summary>
//    public class ContractExtensionBLL
//    {
//        private readonly ContractExtensionDAO _dao;

//        public ContractExtensionBLL()
//        {
//            _dao = new ContractExtensionDAO();
//        }

//        /// <summary>
//        /// Gets all contract extensions
//        /// </summary>
//        public List<ContractExtensionDTO> GetAllExtensions()
//        {
//            try
//            {
//                return _dao.GetAll();
//            }
//            catch (Exception ex)
//            {
//                // Xử lý lỗi (ví dụ: log hoặc throw cho GUI)
//                throw new Exception($"Lỗi khi lấy danh sách gia hạn hợp đồng: {ex.Message}");
//            }
//        }

//        /// <summary>
//        /// Creates a new contract extension
//        /// </summary>
//        public bool CreateExtension(ContractExtensionDTO extension)
//        {
//            if (string.IsNullOrEmpty(extension.MaQuyetDinh) || extension.ThoiGianGiaHan <= 0)
//            {
//                throw new ArgumentException("Dữ liệu không hợp lệ: Mã quyết định hoặc thời gian gia hạn không đúng.");
//            }
//            try
//            {
//                return _dao.Create(extension);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Lỗi khi tạo gia hạn hợp đồng: {ex.Message}");
//            }
//        }

//        /// <summary>
//        /// Updates an existing contract extension
//        /// </summary>
//        public bool UpdateExtension(ContractExtensionDTO extension)
//        {
//            if (string.IsNullOrEmpty(extension.MaQuyetDinh) || extension.ThoiGianGiaHan <= 0)
//            {
//                throw new ArgumentException("Dữ liệu không hợp lệ: Mã quyết định hoặc thời gian gia hạn không đúng.");
//            }
//            try
//            {
//                return _dao.Update(extension);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Lỗi khi cập nhật gia hạn hợp đồng: {ex.Message}");
//            }
//        }

//        /// <summary>
//        /// Deletes a contract extension
//        /// </summary>
//        public bool DeleteExtension(string maQuyetDinh)
//        {
//            if (string.IsNullOrEmpty(maQuyetDinh))
//            {
//                throw new ArgumentException("Mã quyết định không được để trống.");
//            }
//            try
//            {
//                return _dao.Delete(maQuyetDinh);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Lỗi khi xóa gia hạn hợp đồng: {ex.Message}");
//            }
//        }

//        /// <summary>
//        /// Searches for contract extensions by term
//        /// </summary>
//        public List<ContractExtensionDTO> SearchExtensions(string searchTerm)
//        {
//            try
//            {
//                return _dao.Search(searchTerm);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Lỗi khi tìm kiếm gia hạn hợp đồng: {ex.Message}");
//            }
//        }
//    }
//}