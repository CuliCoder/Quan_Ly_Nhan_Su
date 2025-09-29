using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <summary>
        /// Retrieves a single labor contract by maHopDong with additional employee and department information
        /// </summary>
        // Thêm vào LaborContractDAO.cs (nếu chưa có, thêm phương thức GetContractById để lấy đầy đủ thông tin, bao gồm hinhAnh từ hosocanhan)
        public LaborContractDTO GetContractById(string maHopDong)
        {
            LaborContractDTO contract = null;
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = @"
            SELECT 
                hd.maHopDong,
                hd.maNhanVien,
                CONCAT(hs.hoTen, ' (', hd.maNhanVien, ')') AS tenNhanVien,
                pb.tenPhong AS phongBan,
                hd.tuNgay,
                hd.denNgay,
                hd.loaiHopDong,
                hd.luongCoBan,
                hs.anh  -- Lấy cột 'anh'
            FROM hopdonglaodong hd
            LEFT JOIN nhanvien nv ON hd.maNhanVien = nv.maNhanVien
            LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
            LEFT JOIN phongban pb ON hd.phongBan = pb.maPhong
            WHERE hd.maHopDong = @maHopDong";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maHopDong", maHopDong);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Console.WriteLine($"Debug DAO - maHopDong: {maHopDong}, anh: {reader["anh"]?.ToString() ?? "null"}"); // Log chi tiết
                        contract = new LaborContractDTO
                        {
                            MaHopDong = reader["maHopDong"].ToString(),
                            MaNhanVien = reader["maNhanVien"].ToString(),
                            TenNhanVien = reader["tenNhanVien"].ToString(),
                            PhongBan = reader["phongBan"].ToString(),
                            TuNgay = reader["tuNgay"] != DBNull.Value ? Convert.ToDateTime(reader["tuNgay"]) : (DateTime?)null,
                            DenNgay = reader["denNgay"] != DBNull.Value ? Convert.ToDateTime(reader["denNgay"]) : (DateTime?)null,
                            LoaiHopDong = reader["loaiHopDong"].ToString(),
                            LuongCoBan = reader["luongCoBan"] != DBNull.Value ? Convert.ToDecimal(reader["luongCoBan"]) : 0m,
                            HinhAnh = reader["anh"] != DBNull.Value ? reader["anh"].ToString() : ""
                        };
                    }
                    else
                    {
                        Console.WriteLine($"Debug DAO: No record found for maHopDong = {maHopDong}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error DAO: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return contract;
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