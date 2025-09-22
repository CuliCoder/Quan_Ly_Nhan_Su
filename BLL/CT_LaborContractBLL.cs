using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourNamespace.DTO;

namespace Quan_Ly_Nhan_Su.BLL
{
    internal class CT_LaborContractBLL
    {
        // Giả lập danh sách hợp đồng (thay bằng truy vấn cơ sở dữ liệu thực tế)
        private List<LaborContractDTO> _contracts;

        public CT_LaborContractBLL()
        {
            // Khởi tạo dữ liệu mẫu (có thể thay bằng kết nối DB)
            _contracts = new List<LaborContractDTO>
            {
                new LaborContractDTO
                {
                    MaNhanVien = "001",
                    TenNhanVien = "Nguyễn Văn A",
                    PhongBan = "ABC",
                    MaHopDong = "HD001",
                    DenNgay = DateTime.Parse("20/09/2025"),
                    LoaiHopDong = "1 năm",
                    LuongCoBan = 999999999
                }
                // Thêm các hợp đồng khác nếu cần
            };
        }

        /// <summary>
        /// Lấy thông tin chi tiết hợp đồng theo mã hợp đồng
        /// </summary>
        /// <param name="maHopDong">Mã hợp đồng</param>
        /// <returns>Đối tượng LaborContractDTO hoặc null nếu không tìm thấy</returns>
        public LaborContractDTO GetContractById(string maHopDong)
        {
            try
            {
                return _contracts.FirstOrDefault(c => c.MaHopDong == maHopDong);
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine($"Lỗi khi lấy thông tin hợp đồng: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Gia hạn hợp đồng
        /// </summary>
        /// <param name="maHopDong">Mã hợp đồng cần gia hạn</param>
        /// <param name="giaHanThem">Thời gian gia hạn thêm (ví dụ: "1 năm", "6 tháng")</param>
        /// <returns>True nếu gia hạn thành công, False nếu thất bại</returns>
        public bool ExtendContract(string maHopDong, string giaHanThem)
        {
            try
            {
                var contract = _contracts.FirstOrDefault(c => c.MaHopDong == maHopDong);
                if (contract == null)
                {
                    return false;
                }

                // Giả lập logic gia hạn (cộng thời gian dựa trên LoaiHopDong)
                if (DateTime.TryParse(contract.DenNgay.ToString(), out DateTime currentEndDate))
                {
                    TimeSpan additionalTime;
                    if (giaHanThem.Contains("năm"))
                    {
                        int years = int.Parse(giaHanThem.Split(' ')[0]);
                        additionalTime = TimeSpan.FromDays(years * 365);
                    }
                    else if (giaHanThem.Contains("tháng"))
                    {
                        int months = int.Parse(giaHanThem.Split(' ')[0]);
                        additionalTime = TimeSpan.FromDays(months * 30); // Giả sử 1 tháng = 30 ngày
                    }
                    else
                    {
                        return false; // Không hỗ trợ định dạng khác
                    }

                    contract.DenNgay = currentEndDate + additionalTime;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine($"Lỗi khi gia hạn hợp đồng: {ex.Message}");
                return false;
            }
        }
    }
}