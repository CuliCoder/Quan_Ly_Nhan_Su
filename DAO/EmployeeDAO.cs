using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class EmployeeDAO
    {

        private MySqlConnection conn;
        private string createNewCode(MySqlConnection conn, MySqlTransaction transaction,
                                   string tableName, string columnName, string prefix)
        {
            string newCode = "";
            string defaultCode = prefix + "001";

            string sqlQuery = $"SELECT `{columnName}` FROM `{tableName}` ORDER BY `{columnName}` DESC LIMIT 1 FOR UPDATE";

            using (var cmd = new MySqlCommand(sqlQuery, conn, transaction))
            {
                var result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    string lastcode = result.ToString();
                    int prefixLength = prefix.Length;
                    int nextNumber = int.Parse(lastcode.Substring(prefixLength)) + 1;

                    newCode = prefix + nextNumber.ToString("D3");
                }
                else
                {
                    newCode = defaultCode;
                }
            }
            return newCode;
        }

        private string createPositionCode(MySqlConnection conn, MySqlTransaction transaction)
        {
            return createNewCode(conn, transaction, "chucvu", "maChucVu", "CV");
        }

        private string createEmployeeCode(MySqlConnection conn, MySqlTransaction transaction)
        {
            return createNewCode(conn, transaction, "nhanvien", "maNhanVien", "NV");
        }

        public List<EmployeeDTO> getAll()
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
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
                            EmployeeDTO emp = new EmployeeDTO
                            {
                                MaNhanVien = reader["maNhanVien"].ToString(),
                                SoCmnd = reader["soCmnd"].ToString(),                 
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

        public bool createEmployee(EmployeeDTO employeeDTO, string maTuyenDung, PositionDTO positionDTO)
        {
            using (conn = connectDB.getConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {        
                    try
                    {
                        string newPositionCode = createPositionCode(conn, transaction);
                        string newEmployeeCode = createEmployeeCode(conn, transaction);

                        positionDTO.MaChucVu = newPositionCode;
                        employeeDTO.MaChucVu = newPositionCode;
                        employeeDTO.MaNhanVien = newEmployeeCode;

                        string sqlPo = @"
                            INSERT INTO chucvu (maChucVu, tenChucVu, phuCapChucVu, ngayNhanChuc)
                            VALUES (@maChucVu, @tenChucVu, @phuCapChucVu, @ngayNhanChuc)
                            ON DUPLICATE KEY UPDATE
                                tenChucVu = VALUES(tenChucVu),
                                phuCapChucVu = VALUES(phuCapChucVu),
                                ngayNhanChuc = VALUES(ngayNhanChuc);
                        ";

                        using (var cmdPo = new MySqlCommand(sqlPo, conn, transaction))
                        {
                            cmdPo.Parameters.AddWithValue("@maChucVu", positionDTO.MaChucVu);
                            cmdPo.Parameters.AddWithValue("@tenChucVu", positionDTO.TenChucVu);
                            cmdPo.Parameters.AddWithValue("@phuCapChucVu", positionDTO.PhuCapChucVu);
                            cmdPo.Parameters.AddWithValue("@ngayNhanChuc", positionDTO.NgayNhanChuc);
                            cmdPo.ExecuteNonQuery();
                        }
                        Console.WriteLine("✅ Insert/Update chucvu OK");

                        string sql = @"
                            INSERT INTO nhanvien 
                            (maNhanVien, soCmnd, maChucVu, maTaiKhoan, maPhong, mucLuong) 
                            VALUES 
                            (@maNhanVien, @soCmnd, @maChucVu, @maTaiKhoan, @maPhong, @mucLuong);
                        ";

                        using (var cmd = new MySqlCommand(sql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@maNhanVien", employeeDTO.MaNhanVien);
                            cmd.Parameters.AddWithValue("@soCmnd", employeeDTO.SoCmnd ?? "");
                            cmd.Parameters.AddWithValue("@maChucVu", employeeDTO.MaChucVu ?? null);
                            cmd.Parameters.AddWithValue("@maTaiKhoan", employeeDTO.MaTaiKhoan ?? null);
                            cmd.Parameters.AddWithValue("@maPhong", employeeDTO.MaPhong ?? null);
                            cmd.Parameters.AddWithValue("@mucLuong", employeeDTO.MucLuong.HasValue
                                ? employeeDTO.MucLuong.Value
                                : (object)DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                        Console.WriteLine("Insert nhanvien OK");
                        string sqlCandidate = @"
                            INSERT INTO dottuyendung_nhanvien
                            (maTuyenDung, maNhanVien, ngayTuyenDung)
                            VALUES
                            (@maTuyenDung, @maNhanVien, @ngayTuyenDung);
                        ";

                        using (var cmdCandidate = new MySqlCommand(sqlCandidate, conn, transaction))
                        {
                            cmdCandidate.Parameters.AddWithValue("@maTuyenDung", maTuyenDung);
                            cmdCandidate.Parameters.AddWithValue("@maNhanVien", employeeDTO.MaNhanVien);
                            cmdCandidate.Parameters.AddWithValue("@ngayTuyenDung", DateTime.Today);
                            cmdCandidate.ExecuteNonQuery();
                        }
                        Console.WriteLine("Insert dottuyendung_nhanvien OK");
                        transaction.Commit();
                        return true;
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"❌ Error creating employee: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public bool createEmployeeNoCandiDate(EmployeeDTO employeeDTO,PersonalProfileDTO personalProfileDTO , PositionDTO positionDTO)
        {
            using (conn = connectDB.getConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string newPositionCode = createPositionCode(conn, transaction);
                        string newEmployeeCode = createEmployeeCode(conn, transaction);

                        positionDTO.MaChucVu = newPositionCode;
                        employeeDTO.MaChucVu = newPositionCode;
                        employeeDTO.MaNhanVien = newEmployeeCode;
                        string sqlPo = @"
                            INSERT INTO chucvu (maChucVu, tenChucVu, phuCapChucVu, ngayNhanChuc)
                            VALUES (@maChucVu, @tenChucVu, @phuCapChucVu, @ngayNhanChuc)
                            ON DUPLICATE KEY UPDATE
                                tenChucVu = VALUES(tenChucVu),
                                phuCapChucVu = VALUES(phuCapChucVu),
                                ngayNhanChuc = VALUES(ngayNhanChuc);
                        ";

                        using (var cmdPo = new MySqlCommand(sqlPo, conn, transaction))
                        {
                            cmdPo.Parameters.AddWithValue("@maChucVu", positionDTO.MaChucVu);
                            cmdPo.Parameters.AddWithValue("@tenChucVu", positionDTO.TenChucVu);
                            cmdPo.Parameters.AddWithValue("@phuCapChucVu", positionDTO.PhuCapChucVu);
                            cmdPo.Parameters.AddWithValue("@ngayNhanChuc", positionDTO.NgayNhanChuc);
                            cmdPo.ExecuteNonQuery();
                        }
                        Console.WriteLine("Insert/Update chucvu OK");


                        string sqlPer = @"
                        INSERT INTO hosocanhan (soCmnd, hoTen, gioiTinh, ngaySinh, diaChi, email, sdt, noiCap, ngayCap, tinhTrangHonNhan, danToc, hocVan, chuyenNganh, anh)
                        VALUES (@soCmnd, @hoTen, @gioiTinh, @ngaySinh, @diaChi, @email, @sdt, @noiCap, @ngayCap, @tinhTrangHonNhan, @danToc, @hocVan, @chuyenNganh, @anh)";
                        using (var insertProfileCmd = new MySqlCommand(sqlPer, conn, transaction))
                        {
                            insertProfileCmd.Parameters.AddWithValue("@soCmnd", personalProfileDTO.SoCmnd);
                            insertProfileCmd.Parameters.AddWithValue("@hoTen", personalProfileDTO.HoTen);
                            insertProfileCmd.Parameters.AddWithValue("@gioiTinh", personalProfileDTO.GioiTinh);
                            insertProfileCmd.Parameters.AddWithValue("@ngaySinh", personalProfileDTO.NgaySinh);
                            insertProfileCmd.Parameters.AddWithValue("@diaChi", (object)personalProfileDTO.DiaChi ?? DBNull.Value);
                            insertProfileCmd.Parameters.AddWithValue("@email", (object)personalProfileDTO.Email ?? DBNull.Value);
                            insertProfileCmd.Parameters.AddWithValue("@sdt", (object)personalProfileDTO.SoDienThoai ?? DBNull.Value);
                            insertProfileCmd.Parameters.AddWithValue("@noiCap", (object)personalProfileDTO.NoiCap ?? DBNull.Value);
                            insertProfileCmd.Parameters.AddWithValue("@ngayCap", personalProfileDTO.NgayCap);
                            insertProfileCmd.Parameters.AddWithValue("@tinhTrangHonNhan", (object)personalProfileDTO.HonNhan ?? DBNull.Value);
                            insertProfileCmd.Parameters.AddWithValue("@danToc", (object)personalProfileDTO.DanToc ?? DBNull.Value);
                            insertProfileCmd.Parameters.AddWithValue("@hocVan", (object)personalProfileDTO.HocVan ?? DBNull.Value);
                            insertProfileCmd.Parameters.AddWithValue("@chuyenNganh", (object)personalProfileDTO.ChuyenNganh ?? DBNull.Value);
                            insertProfileCmd.Parameters.AddWithValue("@anh", (object)personalProfileDTO.HinhAnh ?? DBNull.Value);
                            insertProfileCmd.ExecuteNonQuery();
                        }
                        Console.WriteLine("Insert hosocanhan OK");

                        string sql = @"
                            INSERT INTO nhanvien 
                            (maNhanVien, soCmnd, maChucVu, maTaiKhoan, maPhong, mucLuong) 
                            VALUES 
                            (@maNhanVien, @soCmnd, @maChucVu, @maTaiKhoan, @maPhong, @mucLuong);
                        ";

                        using (var cmd = new MySqlCommand(sql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@maNhanVien", employeeDTO.MaNhanVien);
                            cmd.Parameters.AddWithValue("@soCmnd", employeeDTO.SoCmnd ?? "");
                            cmd.Parameters.AddWithValue("@maChucVu", employeeDTO.MaChucVu ?? null);
                            cmd.Parameters.AddWithValue("@maTaiKhoan", employeeDTO.MaTaiKhoan ?? null);
                            cmd.Parameters.AddWithValue("@maPhong", employeeDTO.MaPhong ?? null);
                            cmd.Parameters.AddWithValue("@mucLuong", employeeDTO.MucLuong.HasValue
                                ? employeeDTO.MucLuong.Value
                                : (object)DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                        Console.WriteLine("✅ Insert nhanvien OK");                   
                        transaction.Commit();
                        return true;
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"❌ Error creating employee: {ex.Message}");
                        return false;
                    }
                }
            }
        }
        public bool ImportEmployees(List<EmployeeFullDTO> employeeFulls)
        {
            using (conn = connectDB.getConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var employeeFull in employeeFulls)
                        {
                            string newPositionCode = createPositionCode(conn, transaction);
                            string newEmployeeCode = createEmployeeCode(conn, transaction);

                            // Insert chức vụ
                            string sqlPo = @"
                                INSERT INTO chucvu (maChucVu, tenChucVu, phuCapChucVu, ngayNhanChuc)
                                VALUES (@maChucVu, @tenChucVu, @phuCapChucVu, @ngayNhanChuc)
                                ON DUPLICATE KEY UPDATE
                                    tenChucVu = VALUES(tenChucVu),
                                    phuCapChucVu = VALUES(phuCapChucVu),
                                    ngayNhanChuc = VALUES(ngayNhanChuc);
                            ";

                            using (var cmdPo = new MySqlCommand(sqlPo, conn, transaction))
                            {
                                cmdPo.Parameters.AddWithValue("@maChucVu", newPositionCode);
                                cmdPo.Parameters.AddWithValue("@tenChucVu", employeeFull.ChucVu);
                                cmdPo.Parameters.AddWithValue("@phuCapChucVu", 0);
                                cmdPo.Parameters.AddWithValue("@ngayNhanChuc", DateTime.Today.Date);
                                cmdPo.ExecuteNonQuery();
                            }
                            Console.WriteLine("Insert chucvu OK");

                            // Insert hồ sơ cá nhân
                            string sqlPer = @"
                                INSERT INTO hosocanhan 
                                (soCmnd, hoTen, gioiTinh, ngaySinh, diaChi, email, sdt, noiCap, ngayCap, tinhTrangHonNhan, danToc, hocVan, chuyenNganh, anh)
                                VALUES 
                                (@soCmnd, @hoTen, @gioiTinh, @ngaySinh, @diaChi, @email, @sdt, @noiCap, @ngayCap, @tinhTrangHonNhan, @danToc, @hocVan, @chuyenNganh, @anh);
                            ";

                            using (var insertProfileCmd = new MySqlCommand(sqlPer, conn, transaction))
                            {
                                insertProfileCmd.Parameters.AddWithValue("@soCmnd", employeeFull.SoCmnd);
                                insertProfileCmd.Parameters.AddWithValue("@hoTen", employeeFull.HoTen);
                                insertProfileCmd.Parameters.AddWithValue("@gioiTinh", employeeFull.GioiTinh);
                                insertProfileCmd.Parameters.AddWithValue("@ngaySinh", employeeFull.NgaySinh);
                                insertProfileCmd.Parameters.AddWithValue("@diaChi", (object)employeeFull.DiaChi ?? DBNull.Value);
                                insertProfileCmd.Parameters.AddWithValue("@email", (object)employeeFull.Email ?? DBNull.Value);
                                insertProfileCmd.Parameters.AddWithValue("@sdt", (object)employeeFull.Sdt ?? DBNull.Value);
                                insertProfileCmd.Parameters.AddWithValue("@noiCap", (object)employeeFull.NoiCap ?? DBNull.Value);
                                insertProfileCmd.Parameters.AddWithValue("@ngayCap", employeeFull.NgayCap);
                                insertProfileCmd.Parameters.AddWithValue("@tinhTrangHonNhan", (object)employeeFull.TinhTranHonNhan ?? DBNull.Value);
                                insertProfileCmd.Parameters.AddWithValue("@danToc", (object)employeeFull.DanToc ?? DBNull.Value);
                                insertProfileCmd.Parameters.AddWithValue("@hocVan", (object)employeeFull.HocVan ?? DBNull.Value);
                                insertProfileCmd.Parameters.AddWithValue("@chuyenNganh", (object)employeeFull.ChuyenNganh ?? DBNull.Value);
                                insertProfileCmd.Parameters.AddWithValue("@anh", (object)employeeFull.HinhAnh ?? DBNull.Value);
                                insertProfileCmd.ExecuteNonQuery();
                            }
                            Console.WriteLine("Insert hosocanhan OK");

                            // Insert nhân viên
                            string sql = @"
                                INSERT INTO nhanvien 
                                (maNhanVien, soCmnd, maChucVu, maTaiKhoan, maPhong, mucLuong) 
                                VALUES 
                                (@maNhanVien, @soCmnd, @maChucVu, @maTaiKhoan, @maPhong, @mucLuong);
                            ";

                            using (var cmd = new MySqlCommand(sql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@maNhanVien", newEmployeeCode);
                                cmd.Parameters.AddWithValue("@soCmnd", employeeFull.SoCmnd ?? "");
                                cmd.Parameters.AddWithValue("@maChucVu", newPositionCode);
                                cmd.Parameters.AddWithValue("@maTaiKhoan", null);
                                cmd.Parameters.AddWithValue("@maPhong", null);
                                cmd.Parameters.AddWithValue("@mucLuong", employeeFull.MucLuong);
                                cmd.ExecuteNonQuery();
                            }
                            Console.WriteLine("Insert nhanvien OK");
                        }
          
                        transaction.Commit();
                        return true;
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"❌ Error creating employee: {ex.Message}");
                        return false;
                    }
                }
            }
        }


        public bool updateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE nhanvien 
                           SET soCmnd = @soCmnd,
                               maChucVu = @maChucVu,
                               maTaiKhoan = @maTaiKhoan,
                               maPhong = @maPhong,
                               mucLuong = @mucLuong
                           WHERE maNhanVien = @maNhanVien";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhanVien", employeeDTO.MaNhanVien);
                        cmd.Parameters.AddWithValue("@soCmnd", employeeDTO.SoCmnd);
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

        public List<EmployeeDTO> searchEmployee(string keyword)
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();

            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"SELECT * FROM nhanvien 
                           WHERE maNhanVien LIKE @keyword 
                              OR soCmnd LIKE @keyword
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
                                EmployeeDTO dto = new EmployeeDTO(
                                    reader["maNhanVien"].ToString(),
                                    reader["soCmnd"].ToString(),                                                            
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

        /// <summary>
        /// Gets a specific employee by their account ID (maTaiKhoan).
        /// </summary>
        public EmployeeDTO GetByAccountId(string maTaiKhoan)
        {
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM nhanvien WHERE maTaiKhoan = @maTaiKhoan";
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Giả định bạn có một phương thức helper để map dữ liệu
                                // Nếu không, bạn có thể map trực tiếp tại đây:
                                return new EmployeeDTO
                                {
                                    MaNhanVien = reader["maNhanVien"].ToString(),
                                    SoCmnd = reader["soCmnd"].ToString(),
                                    MaChucVu = reader["maChucVu"] != DBNull.Value ? reader["maChucVu"].ToString() : null,
                                    MaTaiKhoan = reader["maTaiKhoan"] != DBNull.Value ? reader["maTaiKhoan"].ToString() : null,
                                    MaPhong = reader["maPhong"] != DBNull.Value ? reader["maPhong"].ToString() : null,
                                    MucLuong = reader["mucLuong"] != DBNull.Value ? Convert.ToDecimal(reader["mucLuong"]) : (decimal?)null
                                };
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting employee by account ID: {ex.Message}");
                }
            }
            return null; // Trả về null nếu không tìm thấy
        }
        public bool updateChucVu(string MaNV, string ChucVu)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE nhanvien 
                           SET maChucVu = @maChucVu
                           WHERE maNhanVien = @maNhanVien";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhanVien", MaNV);
                        cmd.Parameters.AddWithValue("@maChucVu", ChucVu);
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
    }
}