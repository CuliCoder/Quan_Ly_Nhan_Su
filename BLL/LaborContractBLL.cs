using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
// Đã xóa 'using MySql.Data.MySqlClient;' và 'using Quan_Ly_Nhan_Su.config;' vì BLL không nên truy cập CSDL trực tiếp.

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
                return _dao.GetAllContracts(); //
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BLL: {ex.Message}");
                return new List<LaborContractDTO>();
            }
        }

        /// <summary>
        /// Gia hạn hợp đồng lao động
        /// </summary>
        public bool ExtendContract(string maHopDong, string thoiGianGiaHan)
        {
            Console.WriteLine($"Extending contract: maHopDong={maHopDong}, thoiGianGiaHan={thoiGianGiaHan}");
            if (string.IsNullOrEmpty(maHopDong) || string.IsNullOrEmpty(thoiGianGiaHan))
            {
                Console.WriteLine("Invalid input parameters");
                return false;
            }

            try
            {
                // *** ĐÃ SỬA: Gọi DAO thay vì chứa logic SQL ***
                LaborContractDTO contract = _dao.GetContractById(maHopDong); // logic, implementation

                if (contract == null || !contract.DenNgay.HasValue)
                {
                    Console.WriteLine("Contract not found or denNgay is null");
                    return false;
                }

                decimal soNam = ConvertToDecimalYears(thoiGianGiaHan); //
                if (soNam <= 0)
                {
                    Console.WriteLine("Invalid duration");
                    return false;
                }

                DateTime newDenNgay = contract.DenNgay.Value.AddYears((int)soNam).AddMonths((int)((soNam % 1) * 12)); //
                Console.WriteLine($"New denNgay: {newDenNgay}");
                return _dao.ExtendContract(maHopDong, soNam, newDenNgay); //
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BLL Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Chuyển đổi chuỗi thời gian gia hạn thành số năm
        /// </summary>
        private decimal ConvertToDecimalYears(string thoiGianGiaHan)
        {
            switch (thoiGianGiaHan.Trim()) //
            {
                case "0.5 năm": return 0.5m;
                case "1 năm": return 1m;
                case "1.5 năm": return 1.5m;
                case "2 năm": return 2m;
                case "3 năm": return 3m;
                case "4 năm": return 4m;
                default: return 0m;
            }
        }

        /// <summary>
        /// Lấy chi tiết hợp đồng lao động theo maHopDong
        /// </summary>
        public LaborContractDTO GetContractById(string maHopDong)
        {
            try
            {
                return _dao.GetContractById(maHopDong);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BLL Error GetContractById: {ex.Message}");
                return null;
            }
        }
        public List<LaborContractDTO> SearchContracts(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return GetAllContracts();
            }
            try
            {
                return _dao.SearchContracts(keyword); //
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching contracts: {ex.Message}");
                return new List<LaborContractDTO>();
            }
        }

        public List<string> GetAllDepartments()
        {
            try
            {
                return _dao.GetAllDepartments(); //
            }
            catch (Exception ex)
            {
                MessageBox.Show("BLL Error load departments: " + ex.Message);
                return new List<string>();
            }
        }

        /// <summary>
        /// *** HÀM ĐÃ ĐƯỢC CẬP NHẬT ***
        /// Tạo hợp đồng, lương, và cập nhật nhân viên trong một Transaction
        /// </summary>
        public bool CreateContractWithSalary(LaborContractDTO contract, decimal luongTheoGio)
        {
            if (string.IsNullOrEmpty(contract.MaHopDong) || string.IsNullOrEmpty(contract.MaNhanVien)) //
                return false;

            // DTO 'contract' đã chứa LuongCoBan (từ form)
            // Gọi thẳng hàm Transaction trong DAO đã tạo ở bước trước
            return _dao.CreateContractAndSalary_Transaction(contract, luongTheoGio);
        }

        public string GetMaHopDongByMaNhanVien(string maNhanVien)
          => _dao.GetMaHopDongByMaNhanVien(maNhanVien); //

        public List<ExtensionHistoryDTO> GetExtensionHistory(string maNhanVien)
            => _dao.GetExtensionHistory(maNhanVien); //

        public EmployeeFullDTO GetEmployeeDetailsById(string maNhanVien)
            => _dao.GetEmployeeById(maNhanVien); //
        /// <summary>
        /// Lấy danh sách nhân viên chưa ký hợp đồng
        /// </summary>
        public List<EmployeeFullDTO> GetUnsignedEmployees(string phongBan = null, string sortBySalary = null)
        {
            try
            {
                return _dao.GetUnsignedEmployees(phongBan, sortBySalary); //
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving unsigned employees: {ex.Message}");
                return new List<EmployeeFullDTO>();
            }
        }

        /// <summary>
        /// Lấy danh sách hợp đồng theo phòng ban
        /// </summary>
        public List<LaborContractDTO> GetContractsByDepartment(string phongBan)
        {
            if (string.IsNullOrEmpty(phongBan))
            {
                throw new ArgumentException("Phòng ban không được để trống.");
            }
            try
            {
                return _dao.GetContractsByDepartment(phongBan); //
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving contracts by department: {ex.Message}");
                return new List<LaborContractDTO>();
            }
        }

        /// <summary>
        /// Lấy danh sách hợp đồng theo phòng ban với sort theo mức lương
        /// </summary>
        public List<LaborContractDTO> GetContractsByDepartment(string phongBan, string sortBySalary = null)
        {
            if (string.IsNullOrEmpty(phongBan))
            {
                throw new ArgumentException("Phòng ban không được để trống.");
            }
            try
            {
                return _dao.GetContractsByDepartment(phongBan, sortBySalary); //
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving contracts by department: {ex.Message}");
                return new List<LaborContractDTO>();
            }
        }


        /// <summary>
        /// Tạo mới hợp đồng lao động
        /// </summary>
        public bool CreateContract(LaborContractDTO contract)
        {
            if (string.IsNullOrEmpty(contract.MaHopDong) || string.IsNullOrEmpty(contract.MaNhanVien)) //
            {
                return false;
            }
            return _dao.Create(contract); //
        }

        /// <summary>
        /// Cập nhật hợp đồng lao động
        /// </summary>
        public bool UpdateContract(LaborContractDTO contract)
        {
            if (string.IsNullOrEmpty(contract.MaHopDong)) //
            {
                return false;
            }
            return _dao.Update(contract); //
        }

        /// <summary>
        /// Xóa hợp đồng lao động
        /// </summary>
        public bool DeleteContract(string maHopDong)
        {
            if (string.IsNullOrEmpty(maHopDong)) //
            {
                return false;
            }
            return _dao.Delete(maHopDong); //
        }
    }
}   