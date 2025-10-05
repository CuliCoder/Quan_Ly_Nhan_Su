using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class Employee2DAO
    {

        private MySqlConnection conn;
        public List<Employee2DTO> getAll()
        {
            List<Employee2DTO> list = new List<Employee2DTO>();
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM nhanvien";
                    using (var command = new MySqlCommand(sql, conn))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) {
                            Employee2DTO emp = new Employee2DTO
                            {
                                MaNhanVien = reader["maNhanVien"].ToString(),
                                SoCmnd = reader["soCmnd"].ToString(),
                                MaLuong = reader["maluong"].ToString(),
                                MaHopDong = reader["mahopdong"].ToString(),
                                MaTrinhDo = reader["maTrinhDo"] == DBNull.Value ? null : reader["maTrinhDo"].ToString(),
                                MaChucVu = reader["maChucVu"] == DBNull.Value ? null : reader["maChucVu"].ToString(),
                                MaTaiKhoan = reader["maTaiKhoan"] == DBNull.Value ? null : reader["maTaiKhoan"].ToString(),
                                MaPhong = reader["maPhong"] == DBNull.Value ? null : reader["maPhong"].ToString(),
                                MucLuong = reader["mucLuong"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["mucLuong"])
                            };
                            list.Add(emp);
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            return list;
        }

        public bool createEmployee(Employee2DTO employeeDTO)
        {
            try
            {
                using (conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO nhanvien 
                          (maNhanVien, soCmnd, maLuong, maHopDong, maTrinhDo, maChucVu, maTaiKhoan, maPhong, mucLuong) 
                          VALUES 
                          (@maNhanVien, @soCmnd, @maLuong, @maHopDong, @maTrinhDo, @maChucVu, @maTaiKhoan, @maPhong, @mucLuong)";

                    using (var cmd = new MySqlCommand(sql, conn)) 
                    {
                        cmd.Parameters.AddWithValue("@maNhanVien", employeeDTO.MaNhanVien);
                        cmd.Parameters.AddWithValue("@soCmnd", employeeDTO.SoCmnd);
                        cmd.Parameters.AddWithValue("@maLuong", employeeDTO.MaLuong);
                        cmd.Parameters.AddWithValue("@maHopDong", employeeDTO.MaHopDong);
                        cmd.Parameters.AddWithValue("@maTrinhDo", employeeDTO.MaTrinhDo);
                        cmd.Parameters.AddWithValue("@maChucVu", employeeDTO.MaChucVu);
                        cmd.Parameters.AddWithValue("@maTaiKhoan", employeeDTO.MaTaiKhoan);
                        cmd.Parameters.AddWithValue("@maPhong", employeeDTO.MaPhong);
                        cmd.Parameters.AddWithValue("@mucLuong", employeeDTO.MucLuong.HasValue ? employeeDTO.MucLuong.Value : (object)DBNull.Value);      
                        
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating position: {ex.Message}");
                return false;
            }
        }

        public bool updateEmployee(Employee2DTO employeeDTO)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE nhanvien 
                           SET soCmnd = @soCmnd,
                               maLuong = @maLuong,
                               maHopDong = @maHopDong,
                               maTrinhDo = @maTrinhDo,
                               maChucVu = @maChucVu,
                               maTaiKhoan = @maTaiKhoan,
                               maPhong = @maPhong,
                               mucLuong = @mucLuong
                           WHERE maNhanVien = @maNhanVien";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhanVien", employeeDTO.MaNhanVien);
                        cmd.Parameters.AddWithValue("@soCmnd", employeeDTO.SoCmnd);
                        cmd.Parameters.AddWithValue("@maLuong", employeeDTO.MaLuong);
                        cmd.Parameters.AddWithValue("@maHopDong", employeeDTO.MaHopDong);
                        cmd.Parameters.AddWithValue("@maTrinhDo", employeeDTO.MaTrinhDo ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@maChucVu", employeeDTO.MaChucVu ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@maTaiKhoan", employeeDTO.MaTaiKhoan ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@maPhong", employeeDTO.MaPhong ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@mucLuong", employeeDTO.MucLuong.HasValue ? employeeDTO.MucLuong.Value : (object)DBNull.Value);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating employee: {ex.Message}");
                return false;
            }
        }

        public bool deleteEmployee(string maNhanVien)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM nhanvien WHERE maNhanVien = @maNhanVien";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
                return false;
            }
        }

        public List<Employee2DTO> searchEmployee(string keyword)
        {
            List<Employee2DTO> list = new List<Employee2DTO>();

            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"SELECT * FROM nhanvien 
                           WHERE maNhanVien LIKE @keyword 
                              OR soCmnd LIKE @keyword
                              OR maLuong LIKE @keyword
                              OR maHopDong LIKE @keyword
                              OR maTrinhDo LIKE @keyword
                              OR maChucVu LIKE @keyword
                              OR maTaiKhoan LIKE @keyword
                              OR maPhong LIKE @keyword";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Employee2DTO dto = new Employee2DTO(
                                    reader["maNhanVien"].ToString(),
                                    reader["soCmnd"].ToString(),
                                    reader["maluong"].ToString(),
                                    reader["mahopdong"].ToString(),
                                    reader["maTrinhDo"] == DBNull.Value ? null : reader["maTrinhDo"].ToString(),
                                    reader["maChucVu"] == DBNull.Value ? null : reader["maChucVu"].ToString(),
                                    reader["maTaiKhoan"] == DBNull.Value ? null : reader["maTaiKhoan"].ToString(),
                                    reader["maPhong"] == DBNull.Value ? null : reader["maPhong"].ToString(),
                                    reader["mucLuong"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["mucLuong"])
                                );

                                list.Add(dto);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($" Error searching employees: {ex.Message}");
            }

            return list;
        }

    }
}




//public List<EmployeeDTO> GetAll()
//{
//    List<EmployeeDTO> employees = new List<EmployeeDTO>();
//    MySqlConnection conn = null;
//    MySqlDataReader reader = null;

//    try
//    {
//        conn = connectDB.getConnection();
//        if (conn == null)
//        {
//            throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
//        }

//        conn.Open();
//        string query = @"
//            SELECT nv.maNhanVien, hs.hoTen, hs.ngaySinh, hs.gioiTinh, hs.email, hs.sdt, hs.soCmnd,
//                   hs.hocVan, hs.chuyenNganh, pb.tenPhong AS phongBan, cv.tenChucVu AS chucVu, 
//                   nv.mucLuong, hs.diaChi
//            FROM nhanvien nv
//            LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
//            LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
//            LEFT JOIN chucvu cv ON nv.maChucVu = cv.maChucVu";

//        using (var command = new MySqlCommand(query, conn))
//        {
//            reader = command.ExecuteReader();
//            while (reader.Read())
//            {
//                EmployeeDTO emp = new EmployeeDTO
//                {
//                    MaNhanVien = reader["maNhanVien"].ToString(),
//                    HoTen = reader["hoTen"].ToString(),
//                    NgaySinh = reader["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["ngaySinh"]) : (DateTime?)null,
//                    GioiTinh = reader["gioiTinh"].ToString(),
//                    Email = reader["email"].ToString(),
//                    Sdt = reader["sdt"].ToString(),
//                    SoCmnd = reader["soCmnd"].ToString(),
//                    HocVan = reader["hocVan"].ToString(),
//                    ChuyenNganh = reader["chuyenNganh"].ToString(),
//                    PhongBan = reader["phongBan"].ToString(),
//                    ChucVu = reader["chucVu"].ToString(),
//                    MucLuong = reader["mucLuong"] != DBNull.Value ? Convert.ToDecimal(reader["mucLuong"]) : 0m,
//                    DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : ""
//                };
//                employees.Add(emp);
//            }
//        }
//    }
//    catch (MySqlException ex)
//    {
//        Console.WriteLine($"Error retrieving employees: {ex.Message}");
//        throw new Exception($"Lỗi khi lấy danh sách nhân viên: {ex.Message}");
//    }
//    finally
//    {
//        if (reader != null) reader.Close();
//        connectDB.closeConnection(conn);
//    }

//    return employees;
//}

//public EmployeeDTO GetEmployeeById(string maNhanVien)
//{
//    EmployeeDTO employee = null;
//    MySqlConnection conn = null;
//    MySqlDataReader reader = null;

//    try
//    {
//        conn = connectDB.getConnection();
//        conn.Open();
//        string query = @"
//        SELECT nv.maNhanVien, hs.hoTen, hs.ngaySinh, hs.gioiTinh, hs.email, hs.sdt, hs.soCmnd,
//               hs.hocVan, hs.chuyenNganh, pb.tenPhong AS phongBan, cv.tenChucVu AS chucVu, 
//               nv.mucLuong, hs.diaChi
//        FROM nhanvien nv
//        LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
//        LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
//        LEFT JOIN chucvu cv ON nv.maChucVu = cv.maChucVu
//        WHERE nv.maNhanVien = @maNhanVien";

//        using (var command = new MySqlCommand(query, conn))
//        {
//            command.Parameters.AddWithValue("@maNhanVien", maNhanVien);
//            reader = command.ExecuteReader();
//            if (reader.Read())
//            {
//                employee = new EmployeeDTO
//                {
//                    MaNhanVien = reader["maNhanVien"].ToString(),
//                    HoTen = reader["hoTen"].ToString(),
//                    NgaySinh = reader["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["ngaySinh"]) : (DateTime?)null,
//                    GioiTinh = reader["gioiTinh"].ToString(),
//                    Email = reader["email"].ToString(),
//                    Sdt = reader["sdt"].ToString(),
//                    SoCmnd = reader["soCmnd"].ToString(),
//                    HocVan = reader["hocVan"].ToString(),
//                    ChuyenNganh = reader["chuyenNganh"].ToString(),
//                    PhongBan = reader["phongBan"].ToString(),
//                    ChucVu = reader["chucVu"].ToString(),
//                    MucLuong = reader["mucLuong"] != DBNull.Value ? Convert.ToDecimal(reader["mucLuong"]) : 0m,
//                    DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : ""
//                };
//            }
//        }
//    }
//    catch (MySqlException ex)
//    {
//        Console.WriteLine($"Error retrieving employee: {ex.Message}");
//        throw new Exception($"Lỗi khi lấy thông tin nhân viên: {ex.Message}");
//    }
//    finally
//    {
//        if (reader != null) reader.Close();
//        connectDB.closeConnection(conn);
//    }

//    return employee;
//}
//// Thêm method này vào class EmployeeDAO
//public List<EmployeeDTO> GetEmployeesWithoutContract()
//{
//    List<EmployeeDTO> employees = new List<EmployeeDTO>();
//    MySqlConnection conn = null;
//    MySqlDataReader reader = null;

//    try
//    {
//        conn = connectDB.getConnection();
//        if (conn == null)
//        {
//            throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
//        }

//        conn.Open();
//        string query = @"
//    SELECT nv.maNhanVien, hs.hoTen, hs.ngaySinh, hs.gioiTinh, hs.email, hs.sdt, hs.soCmnd,
//           hs.hocVan, hs.chuyenNganh, pb.tenPhong AS phongBan, cv.tenChucVu AS chucVu, 
//           nv.mucLuong, hs.diaChi
//    FROM nhanvien nv
//    LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
//    LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
//    LEFT JOIN chucvu cv ON nv.maChucVu = cv.maChucVu
//    LEFT JOIN hopdonglaodong hd ON nv.maNhanVien = hd.maNhanVien
//    WHERE hd.maHopDong IS NULL";

//        using (var command = new MySqlCommand(query, conn))
//        {
//            reader = command.ExecuteReader();
//            while (reader.Read())
//            {
//                EmployeeDTO emp = new EmployeeDTO
//                {
//                    MaNhanVien = reader["maNhanVien"].ToString(),
//                    HoTen = reader["hoTen"].ToString(),
//                    NgaySinh = reader["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["ngaySinh"]) : (DateTime?)null,
//                    GioiTinh = reader["gioiTinh"].ToString(),
//                    Email = reader["email"].ToString(),
//                    Sdt = reader["sdt"].ToString(),
//                    SoCmnd = reader["soCmnd"].ToString(),
//                    HocVan = reader["hocVan"].ToString(),
//                    ChuyenNganh = reader["chuyenNganh"].ToString(),
//                    PhongBan = reader["phongBan"].ToString(),
//                    ChucVu = reader["chucVu"].ToString(),
//                    MucLuong = reader["mucLuong"] != DBNull.Value ? Convert.ToDecimal(reader["mucLuong"]) : 0m,
//                    DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : ""
//                    // Nếu EmployeeDTO có HinhAnh, thêm: , HinhAnh = reader["hinhAnh"] != DBNull.Value ? reader["hinhAnh"].ToString() : ""
//                };
//                employees.Add(emp);
//            }
//        }
//    }
//    catch (MySqlException ex)
//    {
//        Console.WriteLine($"Error retrieving employees without contract: {ex.Message}");
//        throw new Exception($"Lỗi khi lấy danh sách nhân viên chưa ký hợp đồng: {ex.Message}");
//    }
//    finally
//    {
//        if (reader != null) reader.Close();
//        connectDB.closeConnection(conn);
//    }

//    return employees;
//}

//// Thêm hàm mới: Lấy thông tin kết hợp nhân viên và hợp đồng cho GUI
//public LaborContractDTO GetEmployeeContractDetails(string maNhanVien)
//{
//    LaborContractDTO contract = null;
//    MySqlConnection conn = null;
//    MySqlDataReader reader = null;

//    try
//    {
//        conn = connectDB.getConnection();
//        conn.Open();
//        string query = @"
//            SELECT 
//                nv.maNhanVien,
//                hs.hoTen,
//                pb.tenPhong AS phongBan,
//                hd.maHopDong,
//                hd.tuNgay,
//                hd.denNgay,
//                hd.loaiHopDong,
//                hd.luongCoBan
//            FROM nhanvien nv
//            LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
//            LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
//            LEFT JOIN hopdonglaodong hd ON nv.maNhanVien = hd.maNhanVien
//            WHERE nv.maNhanVien = @maNhanVien";

//        using (var command = new MySqlCommand(query, conn))
//        {
//            command.Parameters.AddWithValue("@maNhanVien", maNhanVien);
//            reader = command.ExecuteReader();
//            if (reader.Read())
//            {
//                contract = new LaborContractDTO
//                {
//                    MaNhanVien = reader["maNhanVien"].ToString(),
//                    TenNhanVien = reader["hoTen"].ToString(),
//                    PhongBan = reader["phongBan"].ToString(),
//                    MaHopDong = reader["maHopDong"] != DBNull.Value ? reader["maHopDong"].ToString() : "",
//                    TuNgay = reader["tuNgay"] != DBNull.Value ? Convert.ToDateTime(reader["tuNgay"]) : (DateTime?)null,
//                    DenNgay = reader["denNgay"] != DBNull.Value ? Convert.ToDateTime(reader["denNgay"]) : (DateTime?)null,
//                    LoaiHopDong = reader["loaiHopDong"] != DBNull.Value ? reader["loaiHopDong"].ToString() : "",
//                    LuongCoBan = reader["luongCoBan"] != DBNull.Value ? Convert.ToDecimal(reader["luongCoBan"]) : 0m
//                };
//            }
//        }
//    }
//    catch (MySqlException ex)
//    {
//        Console.WriteLine($"Error retrieving employee contract details: {ex.Message}");
//        throw new Exception($"Lỗi khi lấy chi tiết hợp đồng nhân viên: {ex.Message}");
//    }
//    finally
//    {
//        if (reader != null) reader.Close();
//        connectDB.closeConnection(conn);
//    }

//    return contract;
//}
