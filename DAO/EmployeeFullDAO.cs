using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;
using Org.BouncyCastle.Ocsp;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class EmployeeFullDAO
    {
        public List<EmployeeFullDTO> GetAll()
        {
            List<EmployeeFullDTO> employees = new List<EmployeeFullDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                if (conn == null)
                {
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                }

                conn.Open();
                string query = @"
                    SELECT nv.maNhanVien, hs.hoTen, hs.ngaySinh, hs.gioiTinh, hs.email, hs.sdt, hs.soCmnd,
                           hs.hocVan, hs.chuyenNganh, pb.tenPhong AS phongBan, cv.tenChucVu AS chucVu, 
                           nv.mucLuong, hs.diaChi, hs.anh, hs.noicap, hs.ngaycap, hs.tinhtranghonnhan, hs.dantoc
                    FROM nhanvien nv
                    LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
                    LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
                    LEFT JOIN chucvu cv ON nv.maChucVu = cv.maChucVu";

                using (var command = new MySqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeFullDTO emp = new EmployeeFullDTO
                        {
                            MaNhanVien = reader["maNhanVien"].ToString(),
                            HoTen = reader["hoTen"].ToString(),
                            NgaySinh = reader["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["ngaySinh"]) : (DateTime?)null,
                            GioiTinh = reader["gioiTinh"].ToString(),
                            Email = reader["email"].ToString(),
                            Sdt = reader["sdt"].ToString(),
                            SoCmnd = reader["soCmnd"].ToString(),
                            NoiCap = reader["noicap"].ToString(),
                            NgayCap = reader["ngaycap"] != DBNull.Value ? Convert.ToDateTime(reader["ngaycap"]) : (DateTime?)null,
                            TinhTranHonNhan = reader["tinhtranghonnhan"].ToString(),
                            DanToc = reader["dantoc"].ToString(),
                            HocVan = reader["hocVan"].ToString(),
                            ChuyenNganh = reader["chuyenNganh"].ToString(),
                            PhongBan = reader["phongBan"].ToString(),
                            ChucVu = reader["chucVu"].ToString(),
                            MucLuong = reader["mucLuong"] != DBNull.Value ? Convert.ToDecimal(reader["mucLuong"]) : 0m,
                            DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : "",
                            HinhAnh = reader["anh"] != DBNull.Value ? reader["anh"].ToString() : "",
                        };
                        employees.Add(emp);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error retrieving employees: {ex.Message}");
                throw new Exception($"Lỗi khi lấy danh sách nhân viên: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return employees;
        }

        public EmployeeFullDTO GetEmployeeById(string maNhanVien)
        {
            EmployeeFullDTO employee = null;
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
                        employee = new EmployeeFullDTO
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
                            DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : ""
                        };
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error retrieving employee: {ex.Message}");
                throw new Exception($"Lỗi khi lấy thông tin nhân viên: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return employee;
        }
        // Thêm method này vào class EmployeeDAO
        public List<EmployeeFullDTO> GetEmployeesWithoutContract()
        {
            List<EmployeeFullDTO> employees = new List<EmployeeFullDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                if (conn == null)
                {
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                }

                conn.Open();
                string query = @"
            SELECT nv.maNhanVien, hs.hoTen, hs.ngaySinh, hs.gioiTinh, hs.email, hs.sdt, hs.soCmnd,
                   hs.hocVan, hs.chuyenNganh, pb.tenPhong AS phongBan, cv.tenChucVu AS chucVu, 
                   nv.mucLuong, hs.diaChi
            FROM nhanvien nv
            LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
            LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
            LEFT JOIN chucvu cv ON nv.maChucVu = cv.maChucVu
            LEFT JOIN hopdonglaodong hd ON nv.maNhanVien = hd.maNhanVien
            WHERE hd.maHopDong IS NULL";

                using (var command = new MySqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeFullDTO emp = new EmployeeFullDTO
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
                            DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : ""
                            // Nếu EmployeeDTO có HinhAnh, thêm: , HinhAnh = reader["hinhAnh"] != DBNull.Value ? reader["hinhAnh"].ToString() : ""
                        };
                        employees.Add(emp);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error retrieving employees without contract: {ex.Message}");
                throw new Exception($"Lỗi khi lấy danh sách nhân viên chưa ký hợp đồng: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return employees;
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
                if (conn == null)
                {
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                }

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
                        l.LuongCoBan
                    FROM nhanvien nv
                    LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
                    LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
                    LEFT JOIN hopdonglaodong hd ON nv.maNhanVien = hd.maNhanVien
                    LEFT JOIN luong l ON nv.maNhanVien = l.MaNhanVien
                    WHERE nv.maNhanVien = @maNhanVien
                    ORDER BY hd.tuNgay DESC
                    LIMIT 1";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        contract = new LaborContractDTO
                        {
                            MaNhanVien = reader["maNhanVien"].ToString(),
                            TenNhanVien = reader["hoTen"] != DBNull.Value ? reader["hoTen"].ToString() : "",
                            PhongBan = reader["phongBan"] != DBNull.Value ? reader["phongBan"].ToString() : "",
                            MaHopDong = reader["maHopDong"] != DBNull.Value ? reader["maHopDong"].ToString() : "",
                            TuNgay = reader["tuNgay"] != DBNull.Value ? Convert.ToDateTime(reader["tuNgay"]) : (DateTime?)null,
                            DenNgay = reader["denNgay"] != DBNull.Value ? Convert.ToDateTime(reader["denNgay"]) : (DateTime?)null,
                            LoaiHopDong = reader["loaiHopDong"] != DBNull.Value ? reader["loaiHopDong"].ToString() : "",
                            LuongCoBan = reader["LuongCoBan"] != DBNull.Value ? Convert.ToDecimal(reader["LuongCoBan"]) : 0m
                        };
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error retrieving employee contract details: {ex.Message}");
                throw new Exception($"Lỗi khi lấy chi tiết hợp đồng nhân viên: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return contract;
        }

        public List<EmployeeFullDTO> GetEmployeesWithoutAccount()
        {
            List<EmployeeFullDTO> employees = new List<EmployeeFullDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                if (conn == null)
                {
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                }

                conn.Open();
                string query = @"
            SELECT nv.maNhanVien, hs.hoTen, hs.ngaySinh, hs.gioiTinh, hs.email, hs.sdt, hs.soCmnd,
                   hs.hocVan, hs.chuyenNganh, pb.tenPhong AS phongBan, cv.tenChucVu AS chucVu, 
                   nv.mucLuong, hs.diaChi
            FROM nhanvien nv
            LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
            LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
            LEFT JOIN chucvu cv ON nv.maChucVu = cv.maChucVu
            WHERE nv.maTaiKhoan IS NULL"; // <-- Thêm điều kiện lọc tại đây

                using (var command = new MySqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeFullDTO emp = new EmployeeFullDTO
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
                            DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : ""
                        };
                        employees.Add(emp);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error retrieving employees without account: {ex.Message}");
                throw new Exception($"Lỗi khi lấy danh sách nhân viên chưa có tài khoản: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return employees;
        }
    }
}