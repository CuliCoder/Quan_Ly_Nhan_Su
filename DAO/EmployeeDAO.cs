using System;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config; // Giả sử connectDB ở đây

namespace Quan_Ly_Nhan_Su.DAO
{
    public class EmployeeDAO
    {
        public EmployeeDTO GetEmployeeById(string maNhanVien)
        {
            EmployeeDTO employee = null;
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = @"
                SELECT nv.maNhanVien, hs.hoTen, hs.ngaySinh, hs.gioiTinh, hs.email, hs.sdt, hs.soCmnd,
                       hs.hocVan, hs.chuyenNganh, pb.tenPhong AS phongBan, cv.tenChucVu AS chucVu, 
                       nv.mucLuong, hs.diaChi
                FROM nhanvien nv
                LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
                LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
                LEFT JOIN chucvu cv ON nv.maChucVu = cv.maChucVu
                WHERE nv.maNhanVien = @maNhanVien";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        employee = new EmployeeDTO
                        {
                            MaNhanVien = reader["maNhanVien"].ToString(),
                            HoTen = reader["hoTen"].ToString(),
                            NgaySinh = reader["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["ngaySinh"]) : (DateTime?)null,
                            GioiTinh = reader["gioiTinh"].ToString(),
                            Email = reader["email"].ToString(),
                            Sdt = reader["sdt"].ToString(),
                            SoCmnd = reader["soCmnd"].ToString(),
                            HocVan = reader["hocVan"].ToString(),
                            ChuyenNganh = reader["chuyenNganh"].ToString(),
                            PhongBan = reader["phongBan"].ToString(),
                            ChucVu = reader["chucVu"].ToString(),
                            MucLuong = reader["mucLuong"] != DBNull.Value ? Convert.ToDecimal(reader["mucLuong"]) : 0m,
                            DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : "" // Thêm DiaChi
                        };
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error retrieving employee: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return employee;
        }

        // Thêm hàm mới: Lấy thông tin kết hợp nhân viên và hợp đồng cho GUI
        public LaborContractDTO GetEmployeeContractDetails(string maNhanVien)
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
                        nv.maNhanVien,
                        hs.hoTen,
                        pb.tenPhong AS phongBan,
                        hd.maHopDong,
                        hd.tuNgay,
                        hd.denNgay,
                        hd.loaiHopDong,
                        hd.luongCoBan
                    FROM nhanvien nv
                    LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
                    LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
                    LEFT JOIN hopdonglaodong hd ON nv.maNhanVien = hd.maNhanVien
                    WHERE nv.maNhanVien = @maNhanVien";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        contract = new LaborContractDTO
                        {
                            MaNhanVien = reader["maNhanVien"].ToString(),
                            TenNhanVien = reader["hoTen"].ToString(),
                            PhongBan = reader["phongBan"].ToString(),
                            MaHopDong = reader["maHopDong"].ToString(),
                            TuNgay = reader["tuNgay"] != DBNull.Value ? Convert.ToDateTime(reader["tuNgay"]) : (DateTime?)null,
                            DenNgay = reader["denNgay"] != DBNull.Value ? Convert.ToDateTime(reader["denNgay"]) : (DateTime?)null,
                            LoaiHopDong = reader["loaiHopDong"].ToString(),
                            LuongCoBan = reader["luongCoBan"] != DBNull.Value ? Convert.ToDecimal(reader["luongCoBan"]) : 0m
                        };
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error retrieving employee contract details: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return contract;
        }
    }
}