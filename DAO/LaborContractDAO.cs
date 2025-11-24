using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for LaborContract table with additional display functionality
    /// </summary>
    public class LaborContractDAO
    {
        /// <summary>
        /// Retrieves all labor contracts with additional employee and department information
        /// </summary>
        public List<LaborContractDTO> GetAllContracts()
        {
            List<LaborContractDTO> contracts = new List<LaborContractDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = @"
                    SELECT 
                        hd.maNhanVien,
                        hd.maHopDong,
                        CONCAT(hs.hoTen, ' (', hd.maNhanVien, ')') AS tenNhanVien,
                        pb.tenPhong AS phongBan,
                        hd.tuNgay,
                        hd.denNgay,
                        hd.loaiHopDong, 
                        IFNULL(l.LuongCoBan, 0) AS luongCoBan,
                        hs.anh AS hinhAnh   
                    FROM hopdonglaodong hd
                    LEFT JOIN nhanvien nv ON hd.maNhanVien = nv.maNhanVien
                    LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
                    LEFT JOIN phongban pb ON hd.phongBan = pb.maPhong
                    LEFT JOIN luong l ON hd.maNhanVien = l.MaNhanVien
                    ORDER BY hd.tuNgay DESC";

                using (var command = new MySqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    int stt = 1;
                    while (reader.Read())
                    {
                        LaborContractDTO contract = new LaborContractDTO
                        {
                            STT = stt++,
                            MaNhanVien = reader["maNhanVien"].ToString(),
                            MaHopDong = reader["maHopDong"].ToString(),
                            TenNhanVien = reader["tenNhanVien"].ToString(),
                            PhongBan = reader["phongBan"].ToString(),
                            TuNgay = reader["tuNgay"] != DBNull.Value ? Convert.ToDateTime(reader["tuNgay"]) : (DateTime?)null,
                            DenNgay = reader["denNgay"] != DBNull.Value ? Convert.ToDateTime(reader["denNgay"]) : (DateTime?)null,
                            LoaiHopDong = reader["loaiHopDong"].ToString(),
                            LuongCoBan = reader["luongCoBan"] != DBNull.Value ? Convert.ToDecimal(reader["luongCoBan"]) : 0m
                        };
                        contracts.Add(contract);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error retrieving labor contracts: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return contracts;
        }
        public bool ExtendContract(string maHopDong, decimal thoiGianGiaHan, DateTime newDenNgay)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    // Lấy maNhanVien từ hopdonglaodong
                    string getMaNhanVienQuery = "SELECT maNhanVien FROM hopdonglaodong WHERE maHopDong = @maHopDong";
                    string maNhanVien;
                    using (var cmd = new MySqlCommand(getMaNhanVienQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maHopDong", maHopDong);
                        maNhanVien = cmd.ExecuteScalar()?.ToString();
                        if (string.IsNullOrEmpty(maNhanVien)) return false;
                    }

                    // Generate maQuyetDinh mới (ví dụ: QD-YYYYMMDD-XXX)
                    string maQuyetDinh = GenerateMaQuyetDinh(conn, transaction); // Hàm tự viết, ví dụ dưới

                    // Insert vào quyetdinh
                    string insertQuyetDinh = @"
                INSERT INTO quyetdinh (maQuyetDinh, maNhanVien, ngayQuyetDinh, chucVuBanDau, chucVuSauQuyetDinh, nguoiLapQuyetDinh, lyDo)
                VALUES (@maQuyetDinh, @maNhanVien, @ngayQuyetDinh, @chucVuBanDau, @chucVuSauQuyetDinh, @nguoiLap, @lyDo)";
                    using (var cmd = new MySqlCommand(insertQuyetDinh, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maQuyetDinh", maQuyetDinh);
                        cmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                        cmd.Parameters.AddWithValue("@ngayQuyetDinh", DateTime.Now);
                        cmd.Parameters.AddWithValue("@chucVuBanDau", "Chuc vu cu"); // Lấy từ DB nếu cần
                        cmd.Parameters.AddWithValue("@chucVuSauQuyetDinh", "Chuc vu sau gia han");
                        cmd.Parameters.AddWithValue("@nguoiLap", "Admin"); // Hardcode hoặc lấy từ user login
                        cmd.Parameters.AddWithValue("@lyDo", "Gia han hop dong " + thoiGianGiaHan + " nam");
                        if (cmd.ExecuteNonQuery() <= 0) throw new Exception("Insert quyetdinh failed");
                    }

                    // Insert vào giahanhopdong
                    string insertGiaHan = "INSERT INTO giahanhopdong (maQuyetDinh, thoiGianGiaHan) VALUES (@maQuyetDinh, @thoiGianGiaHan)";
                    using (var cmd = new MySqlCommand(insertGiaHan, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maQuyetDinh", maQuyetDinh);
                        cmd.Parameters.AddWithValue("@thoiGianGiaHan", thoiGianGiaHan);
                        if (cmd.ExecuteNonQuery() <= 0) throw new Exception("Insert giahanhopdong failed");
                    }

                    // Cập nhật denNgay trong hopdonglaodong
                    string updateHopDong = "UPDATE hopdonglaodong SET denNgay = @newDenNgay WHERE maHopDong = @maHopDong";
                    using (var cmd = new MySqlCommand(updateHopDong, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@newDenNgay", newDenNgay);
                        cmd.Parameters.AddWithValue("@maHopDong", maHopDong);
                        if (cmd.ExecuteNonQuery() <= 0) throw new Exception("Update hopdonglaodong failed");
                    }

                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extending contract: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        // Hàm generate maQuyetDinh (ví dụ)
        private string GenerateMaQuyetDinh(MySqlConnection conn, MySqlTransaction transaction)
        {
            string query = "SELECT COUNT(*) FROM quyetdinh";
            using (var cmd = new MySqlCommand(query, conn, transaction))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                return "QD-" + DateTime.Now.ToString("yyyyMMdd") + "-" + count.ToString("D3");
            }
        }
        /// <summary>
        /// Creates a new labor contract in the hopdonglaodong table
        /// </summary>
        public bool Create(LaborContractDTO contract)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                // Kiểm tra xem maHopDong đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM hopdonglaodong WHERE maHopDong = @maHopDong";
                using (var checkCommand = new MySqlCommand(checkQuery, conn))
                {
                    checkCommand.Parameters.AddWithValue("@maHopDong", contract.MaHopDong);
                    long count = (long)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        Console.WriteLine($"Hợp đồng {contract.MaHopDong} đã tồn tại.");
                        return false;
                    }
                }

                // *** ĐÃ SỬA: Bỏ luongCoBan ***
                string query = "INSERT INTO hopdonglaodong (maHopDong, maNhanVien, tuNgay, denNgay, loaiHopDong, phongBan, maBangChamCong) VALUES (@maHopDong, @maNhanVien, @tuNgay, @denNgay, @loaiHopDong, @phongBan, @maBangChamCong)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maHopDong", contract.MaHopDong);
                    command.Parameters.AddWithValue("@maNhanVien", contract.MaNhanVien);
                    command.Parameters.AddWithValue("@tuNgay", contract.TuNgay);
                    command.Parameters.AddWithValue("@denNgay", (object)contract.DenNgay ?? DBNull.Value);
                    command.Parameters.AddWithValue("@loaiHopDong", contract.LoaiHopDong);
                    command.Parameters.AddWithValue("@phongBan", contract.PhongBan);
                    // *** ĐÃ SỬA: Bỏ luongCoBan ***
                    command.Parameters.AddWithValue("@maBangChamCong", (object)contract.MaBangChamCong ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating labor contract: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        // *** HÀM MỚI 1 (PRIVATE): Hỗ trợ tạo mã lương ***
        private string GenerateNewMaLuong(MySqlConnection conn, MySqlTransaction transaction)
        {
            string newMaLuong = "L001"; // Giá trị mặc định nếu bảng trống
            // Lấy mã lương lớn nhất hiện tại, ví dụ 'L006'
            string query = @"
                SELECT MaLuong FROM luong 
                WHERE MaLuong LIKE 'L%' 
                ORDER BY CAST(SUBSTRING(MaLuong, 2) AS UNSIGNED) DESC 
                LIMIT 1";

            using (var command = new MySqlCommand(query, conn, transaction))
            {
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    string lastMaLuong = result.ToString();
                    if (int.TryParse(lastMaLuong.Substring(1), out int lastNum))
                    {
                        // Tăng lên 1 (ví dụ: L006 -> L007)
                        newMaLuong = "L" + (lastNum + 1).ToString("D3");
                    }
                }
            }
            return newMaLuong;
        }

        // *** HÀM MỚI 2 (PUBLIC): HÀM GỘP 3-TRONG-1 ***
        public bool CreateContractAndSalary_Transaction(LaborContractDTO contract, decimal luongTheoGio)
        {
            MySqlConnection conn = null;
            MySqlTransaction transaction = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                transaction = conn.BeginTransaction();

                // === Bước 1 & 2: Tạo Lương và lấy mã lương mới ===
                string newMaLuong = GenerateNewMaLuong(conn, transaction);
                string queryLuong = @"
                    INSERT INTO luong (MaLuong, MaNhanVien, LuongCoBan, LuongTheoGio, Thang, Nam) 
                    VALUES (@MaLuong, @MaNhanVien, @LuongCoBan, @LuongTheoGio, @Thang, @Nam)";

                using (var cmdLuong = new MySqlCommand(queryLuong, conn, transaction))
                {
                    cmdLuong.Parameters.AddWithValue("@MaLuong", newMaLuong);
                    cmdLuong.Parameters.AddWithValue("@MaNhanVien", contract.MaNhanVien);
                    cmdLuong.Parameters.AddWithValue("@LuongCoBan", contract.LuongCoBan); // Lấy từ DTO
                    cmdLuong.Parameters.AddWithValue("@LuongTheoGio", luongTheoGio);
                    cmdLuong.Parameters.AddWithValue("@Thang", DateTime.Now.Month);
                    cmdLuong.Parameters.AddWithValue("@Nam", DateTime.Now.Year);

                    if (cmdLuong.ExecuteNonQuery() <= 0)
                    {
                        throw new Exception("Tạo bản ghi lương thất bại.");
                    }
                }

                // === Bước 3: Cập nhật Nhân Viên ===
                string queryNhanVien = @"
                    UPDATE nhanvien 
                    SET maluong = @maLuong 
                    WHERE maNhanVien = @maNhanVien";

                using (var cmdNhanVien = new MySqlCommand(queryNhanVien, conn, transaction))
                {
                    cmdNhanVien.Parameters.AddWithValue("@maLuong", newMaLuong);
                    cmdNhanVien.Parameters.AddWithValue("@maNhanVien", contract.MaNhanVien);

                    if (cmdNhanVien.ExecuteNonQuery() <= 0)
                    {
                        throw new Exception("Cập nhật mã lương cho nhân viên thất bại.");
                    }
                }

                // === Bước 4: Tạo Hợp đồng (KHÔNG CÓ LƯƠNG) ===
                string queryHopDong = @"
                    INSERT INTO hopdonglaodong (maHopDong, maNhanVien, tuNgay, denNgay, loaiHopDong, phongBan, maBangChamCong) 
                    VALUES (@maHopDong, @maNhanVien, @tuNgay, @denNgay, @loaiHopDong, @phongBan, @maBangChamCong)";

                using (var cmdHopDong = new MySqlCommand(queryHopDong, conn, transaction))
                {
                    cmdHopDong.Parameters.AddWithValue("@maHopDong", contract.MaHopDong);
                    cmdHopDong.Parameters.AddWithValue("@maNhanVien", contract.MaNhanVien);
                    cmdHopDong.Parameters.AddWithValue("@tuNgay", contract.TuNgay);
                    cmdHopDong.Parameters.AddWithValue("@denNgay", (object)contract.DenNgay ?? DBNull.Value);
                    cmdHopDong.Parameters.AddWithValue("@loaiHopDong", contract.LoaiHopDong);
                    cmdHopDong.Parameters.AddWithValue("@phongBan", contract.PhongBan);
                    cmdHopDong.Parameters.AddWithValue("@maBangChamCong", (object)contract.MaBangChamCong ?? DBNull.Value);

                    if (cmdHopDong.ExecuteNonQuery() <= 0)
                    {
                        throw new Exception("Tạo hợp đồng lao động thất bại.");
                    }
                }

                // === Nếu cả 3 bước OK thì Commit ===
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // Nếu có 1 bước lỗi, Rollback tất cả
                Console.WriteLine($"Transaction Error: {ex.Message}");
                try
                {
                    transaction?.Rollback();
                }
                catch (Exception rbEx)
                {
                    Console.WriteLine($"Rollback Error: {rbEx.Message}");
                }
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }


        public List<ExtensionHistoryDTO> GetExtensionHistory(string maNhanVien)
        {
            var list = new List<ExtensionHistoryDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                // Giả định bảng:
                // - quyetdinh(maQuyetDinh, maNhanVien, ngayQuyetDinh, ...)
                // - giahanhopdong(maQuyetDinh, thoiGianGiaHan)
                string query = @"
                    SELECT qd.maQuyetDinh, qd.maNhanVien, qd.ngayQuyetDinh, gh.thoiGianGiaHan
                    FROM quyetdinh qd
                    INNER JOIN giahanhopdong gh ON qd.maQuyetDinh = gh.maQuyetDinh
                    WHERE qd.maNhanVien = @maNhanVien
                    ORDER BY qd.ngayQuyetDinh DESC;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ExtensionHistoryDTO
                        {
                            MaQuyetDinh = reader["maQuyetDinh"].ToString(),
                            MaNhanVien = reader["maNhanVien"].ToString(),
                            NgayQuyetDinh = reader["ngayQuyetDinh"] != DBNull.Value
                                ? Convert.ToDateTime(reader["ngayQuyetDinh"]) 
                                : DateTime.MinValue,
                            ThoiGianGiaHan = reader["thoiGianGiaHan"] != DBNull.Value
                                ? Convert.ToDecimal(reader["thoiGianGiaHan"]) 
                                : 0m
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error GetExtensionHistory: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return list;
        }
        public string GetMaHopDongByMaNhanVien(string maNhanVien)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                // Lấy HĐ mới nhất theo tuNgay (hoặc denNgay nếu bạn muốn)
                string query = @"
                    SELECT maHopDong 
                    FROM hopdonglaodong 
                    WHERE maNhanVien = @maNhanVien
                    ORDER BY IFNULL(denNgay, tuNgay) DESC
                    LIMIT 1;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error GetMaHopDongByMaNhanVien: {ex.Message}");
                return null;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }
        /// <summary>
        /// Updates an existing labor contract in the hopdonglaodong table
        /// </summary>
        public bool Update(LaborContractDTO contract)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                // *** ĐÃ SỬA: Bỏ luongCoBan ***
                string query = "UPDATE hopdonglaodong SET maNhanVien = @maNhanVien, tuNgay = @tuNgay, denNgay = @denNgay, loaiHopDong = @loaiHopDong, phongBan = @phongBan, maBangChamCong = @maBangChamCong WHERE maHopDong = @maHopDong";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maHopDong", contract.MaHopDong);
                    command.Parameters.AddWithValue("@maNhanVien", contract.MaNhanVien);
                    command.Parameters.AddWithValue("@tuNgay", contract.TuNgay);
                    command.Parameters.AddWithValue("@denNgay", (object)contract.DenNgay ?? DBNull.Value);
                    command.Parameters.AddWithValue("@loaiHopDong", contract.LoaiHopDong);
                    command.Parameters.AddWithValue("@phongBan", contract.PhongBan);
                    // *** ĐÃ SỬA: Bỏ luongCoBan ***
                    command.Parameters.AddWithValue("@maBangChamCong", (object)contract.MaBangChamCong ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating labor contract: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }
        public List<LaborContractDTO> SearchContracts(string keyword)
        {
            List<LaborContractDTO> contracts = new List<LaborContractDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = @"
            SELECT 
                hd.maHopDong,
                CONCAT(hs.hoTen, ' (', hd.maNhanVien, ')') AS tenNhanVien,
                pb.tenPhong AS phongBan,
                hd.tuNgay,          
                hd.denNgay,
                hd.loaiHopDong,
                IFNULL(l.luongCoBan, 0) AS luongCoBan
            FROM hopdonglaodong hd
            LEFT JOIN nhanvien nv ON hd.maNhanVien = nv.maNhanVien
            LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
            LEFT JOIN phongban pb ON hd.phongBan = pb.maPhong
            LEFT JOIN luong l ON hd.maNhanVien = l.maNhanVien
            WHERE hd.maHopDong LIKE @keyword 
            OR hs.hoTen LIKE @keyword 
            OR pb.tenPhong LIKE @keyword
            ORDER BY hd.tuNgay DESC";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    reader = command.ExecuteReader();
                    int stt = 1;
                    while (reader.Read())
                    {
                        LaborContractDTO contract = new LaborContractDTO
                        {
                            STT = stt++,
                            MaHopDong = reader["maHopDong"].ToString(),
                            TenNhanVien = reader["tenNhanVien"].ToString(),
                            PhongBan = reader["phongBan"].ToString(),
                            TuNgay = reader["tuNgay"] != DBNull.Value ? Convert.ToDateTime(reader["tuNgay"]) : (DateTime?)null,
                            DenNgay = reader["denNgay"] != DBNull.Value ? Convert.ToDateTime(reader["denNgay"]) : (DateTime?)null,
                            LoaiHopDong = reader["loaiHopDong"].ToString(),
                            LuongCoBan = reader["luongCoBan"] != DBNull.Value ? Convert.ToDecimal(reader["luongCoBan"]) : 0m
                        };
                        contracts.Add(contract);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching contracts: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return contracts;
        }

        public List<string> GetAllDepartments()
        {
            List<string> depts = new List<string>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            string query = "SELECT DISTINCT tenPhong FROM phongban WHERE tenPhong IS NOT NULL AND tenPhong != '' ORDER BY tenPhong ASC";

            try
            {
                conn = connectDB.getConnection();
                if (conn == null)
                {
                    MessageBox.Show("Kết nối DB null. Kiểm tra config!");
                    return depts;
                }
                conn.Open();
                using (var command = new MySqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string tenPhong = reader["tenPhong"].ToString().Trim();
                        if (!string.IsNullOrEmpty(tenPhong))
                        {
                            depts.Add(tenPhong);
                        }
                    }
                }
                MessageBox.Show("Danh sách phòng ban từ DB: " + string.Join(", ", depts) + "\nSố lượng: " + depts.Count);  // Debug
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi query phòng ban: " + ex.Message + "\nQuery: " + query);
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }
            return depts;
        }
        /// <summary>
        /// Lấy danh sách nhân viên chưa ký hợp đồng, với filter phòng ban và sort theo lương
        /// </summary>
        // LaborContractDAO.cs
        public List<EmployeeFullDTO> GetUnsignedEmployees(string phongBan = null, string sortBySalary = null)
        {
            var employees = new List<EmployeeFullDTO>();
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
                hs.ngaySinh AS ngayVaoLam,
                nv.mucLuong
            FROM nhanvien nv
            LEFT JOIN hosocanhan  hs ON nv.soCmnd   = hs.soCmnd
            LEFT JOIN phongban    pb ON nv.maPhong  = pb.maPhong
            LEFT JOIN hopdonglaodong hd ON nv.maNhanVien = hd.maNhanVien
            WHERE hd.maHopDong IS NULL";

                if (!string.IsNullOrEmpty(phongBan))
                    query += " AND pb.tenPhong = @phongBan";

                // Interpret sortBySalary parameter as a sort key (can be LUONG_ASC, LUONG_DESC, NGAY_ASC, NGAY_DESC)
                if (!string.IsNullOrEmpty(sortBySalary))
                {
                    switch (sortBySalary)
                    {
                        case "LUONG_ASC":
                            query += " ORDER BY nv.mucLuong ASC";
                            break;
                        case "LUONG_DESC":
                            query += " ORDER BY nv.mucLuong DESC";
                            break;
                        case "NGAY_ASC":
                            // Order by the alias ngayVaoLam (hs.ngaySinh)
                            query += " ORDER BY hs.ngaySinh ASC";
                            break;
                        case "NGAY_DESC":
                            query += " ORDER BY hs.ngaySinh DESC";
                            break;
                        default:
                            // fallback: order by employee id
                            query += " ORDER BY nv.maNhanVien ASC";
                            break;
                    }
                }
                else
                {
                    // Default ordering
                    query += " ORDER BY nv.maNhanVien ASC";
                }

                using (var command = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(phongBan))
                        command.Parameters.AddWithValue("@phongBan", phongBan);

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employees.Add(new EmployeeFullDTO
                        {
                            MaNhanVien = reader["maNhanVien"].ToString(),
                            HoTen = reader["hoTen"].ToString(),
                            PhongBan = reader["phongBan"].ToString(),
                            NgaySinh = reader["ngayVaoLam"] != DBNull.Value ? Convert.ToDateTime(reader["ngayVaoLam"]) : (DateTime?)null,
                            MucLuong = reader["mucLuong"] != DBNull.Value ? Convert.ToDecimal(reader["mucLuong"]) : 0m
                        });
                    }
                }
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }
            return employees;
        }

        /// <summary>
        /// Deletes a labor contract from the hopdonglaodong table
        /// </summary>
        public bool Delete(string maHopDong)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM hopdonglaodong WHERE maHopDong = @maHopDong";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maHopDong", maHopDong);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting labor contract: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }
        /// <summary>
        /// Gia hạn hợp đồng lao động bằng cách cập nhật ngày hết hạn
        /// </summary>
        public bool ExtendContract(string maHopDong, int soNamGiaHan)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                // Lấy ngày hết hạn hiện tại
                string getQuery = "SELECT denNgay FROM hopdonglaodong WHERE maHopDong = @maHopDong";
                DateTime? denNgayHienTai = null;

                using (var getCommand = new MySqlCommand(getQuery, conn))
                {
                    getCommand.Parameters.AddWithValue("@maHopDong", maHopDong);
                    var result = getCommand.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        denNgayHienTai = Convert.ToDateTime(result);
                    }
                }

                // Nếu không có ngày hết hạn, lấy ngày bắt đầu
                if (denNgayHienTai == null)
                {
                    string getTuNgayQuery = "SELECT tuNgay FROM hopdonglaodong WHERE maHopDong = @maHopDong";
                    using (var getCommand = new MySqlCommand(getTuNgayQuery, conn))
                    {
                        getCommand.Parameters.AddWithValue("@maHopDong", maHopDong);
                        var result = getCommand.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            denNgayHienTai = Convert.ToDateTime(result);
                        }
                    }
                }

                if (denNgayHienTai == null) return false;

                // Tính ngày hết hạn mới
                DateTime denNgayMoi = denNgayHienTai.Value.AddYears(soNamGiaHan);

                // Cập nhật ngày hết hạn mới
                string updateQuery = "UPDATE hopdonglaodong SET denNgay = @denNgay WHERE maHopDong = @maHopDong";
                using (var updateCommand = new MySqlCommand(updateQuery, conn))
                {
                    updateCommand.Parameters.AddWithValue("@maHopDong", maHopDong);
                    updateCommand.Parameters.AddWithValue("@denNgay", denNgayMoi);
                    return updateCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error extending labor contract: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        internal LaborContractDTO GetContractById(string maHopDong)
        {
            LaborContractDTO contract = null;
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                
                // Use simple join to luong; schema does not include Nam/Thang in luong
                string query = @"
    SELECT 
        hd.maHopDong,
        hd.maNhanVien,
        CONCAT(hs.hoTen, ' (', hd.maNhanVien, ')') AS tenNhanVien,
        pb.tenPhong AS phongBan,
        hd.tuNgay,
        hd.denNgay,
        hd.loaiHopDong,
        IFNULL(l.LuongCoBan, 0) AS luongCoBan,
        hs.anh AS hinhAnh
    FROM hopdonglaodong hd
    LEFT JOIN nhanvien nv ON hd.maNhanVien = nv.maNhanVien
    LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
    LEFT JOIN phongban pb ON hd.phongBan = pb.maPhong
    LEFT JOIN luong l ON hd.maNhanVien = l.MaNhanVien
    WHERE hd.maHopDong = @maHopDong";

        using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maHopDong", maHopDong);
                    reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                Console.WriteLine($"DAO Debug: maHopDong={maHopDong}, luongCoBan={reader["luongCoBan"]}, hinhAnh={reader["hinhAnh"]?.ToString() ?? "null"}");
                
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
                    HinhAnh = reader["hinhAnh"] != DBNull.Value ? reader["hinhAnh"].ToString() : ""
                };
            }
            else
            {
                Console.WriteLine($"DAO Debug: No data for maHopDong={maHopDong}");
            }
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine($"Error retrieving labor contract: {ex.Message}");
        MessageBox.Show($"Lỗi DB: {ex.Message}\n\nQuery có thể bị lỗi. Kiểm tra Console Output!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    finally
    {
        if (reader != null) reader.Close();
        connectDB.closeConnection(conn);
    }

    return contract;
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
                       nv.mucLuong, hs.diaChi, hs.hinhAnh
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
                            DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : "",
                            HinhAnh = reader["hinhAnh"] != DBNull.Value ? reader["hinhAnh"].ToString() : "" // Thêm HinhAnh
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

        /// <summary>
        /// Retrieves all employees by department (phongBan)
        /// </summary>
        public List<EmployeeFullDTO> GetEmployeesByDepartment(string phongBan)
        {
            List<EmployeeFullDTO> employees = new List<EmployeeFullDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = @"
                    SELECT nv.maNhanVien, hs.hoTen, hs.ngaySinh, hs.gioiTinh, hs.email, hs.sdt, hs.soCmnd,
                           hs.hocVan, hs.chuyenNganh, pb.tenPhong AS phongBan, cv.tenChucVu AS chucVu, 
                           nv.mucLuong, hs.diaChi, hs.anh AS hinhAnh
                    FROM nhanvien nv
                    LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
                    LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
                    LEFT JOIN chucvu cv ON nv.maChucVu = cv.maChucVu
                    WHERE pb.tenPhong = @phongBan";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@phongBan", phongBan);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeFullDTO employee = new EmployeeFullDTO
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
                            DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : "",
                            HinhAnh = reader["hinhAnh"] != DBNull.Value ? reader["hinhAnh"].ToString() : ""
                        };
                        employees.Add(employee);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error retrieving employees by department: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return employees;
        }


        // Nếu cần lọc hợp đồng (không phải nhân viên), thêm phương thức tương tự
        public List<LaborContractDTO> GetContractsByDepartment(string phongBan, string sortBySalary = null)
        {
            List<LaborContractDTO> contracts = new List<LaborContractDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = @"
            SELECT 
                hd.maHopDong,
                CONCAT(hs.hoTen, ' (', hd.maNhanVien, ')') AS tenNhanVien,
                pb.tenPhong AS phongBan,
                hd.tuNgay,
                hd.denNgay,
                hd.loaiHopDong,
                IFNULL(l.luongCoBan, 0) AS luongCoBan
            FROM hopdonglaodong hd
            LEFT JOIN nhanvien nv ON hd.maNhanVien = nv.maNhanVien
            LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
            LEFT JOIN phongban pb ON hd.phongBan = pb.maPhong
            LEFT JOIN luong l ON hd.maNhanVien = l.maNhanVien
            WHERE pb.tenPhong = @phongBan";

                if (!string.IsNullOrEmpty(sortBySalary))
                {
                    query += $" ORDER BY l.luongCoBan {sortBySalary}";
                }
                else
                {
                    query += " ORDER BY hd.tuNgay DESC";
                }

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@phongBan", phongBan);
                    reader = command.ExecuteReader();
                    int stt = 1;
                    while (reader.Read())
                    {
                        LaborContractDTO contract = new LaborContractDTO
                        {
                            STT = stt++,
                            MaHopDong = reader["maHopDong"].ToString(),
                            TenNhanVien = reader["tenNhanVien"].ToString(),
                            PhongBan = reader["phongBan"].ToString(),
                            TuNgay = reader["tuNgay"] != DBNull.Value ? Convert.ToDateTime(reader["tuNgay"]) : (DateTime?)null,
                            DenNgay = reader["denNgay"] != DBNull.Value ? Convert.ToDateTime(reader["denNgay"]) : (DateTime?)null,
                            LoaiHopDong = reader["loaiHopDong"].ToString(),
                            LuongCoBan = reader["luongCoBan"] != DBNull.Value ? Convert.ToDecimal(reader["luongCoBan"]) : 0m
                        };
                        contracts.Add(contract);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error retrieving contracts by department: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return contracts;
        }


        /// <summary>
        /// Searches employees by keyword (maNhanVien, hoTen, or phongBan)
        /// </summary>
        public List<EmployeeFullDTO> SearchEmployees(string keyword)
        {
            List<EmployeeFullDTO> employees = new List<EmployeeFullDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = @"
                    SELECT nv.maNhanVien, hs.hoTen, hs.ngaySinh, hs.gioiTinh, hs.email, hs.sdt, hs.soCmnd,
                           hs.hocVan, hs.chuyenNganh, pb.tenPhong AS phongBan, cv.tenChucVu AS chucVu, 
                           nv.mucLuong, hs.diaChi, hs.hinhAnh
                    FROM nhanvien nv
                    LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
                    LEFT JOIN phongban pb ON nv.maPhong = pb.maPhong
                    LEFT JOIN chucvu cv ON nv.maChucVu = cv.maChucVu
                    WHERE nv.maNhanVien LIKE @keyword 
                    OR hs.hoTen LIKE @keyword 
                    OR pb.tenPhong LIKE @keyword";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeFullDTO employee = new EmployeeFullDTO
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
                            DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : "",
                            HinhAnh = reader["hinhAnh"] != DBNull.Value ? reader["hinhAnh"].ToString() : ""
                        };
                        employees.Add(employee);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching employees: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return employees;
        }

        /// <summary>
        /// Lấy danh sách hợp đồng theo bộ lọc ngày và phòng ban, kèm sắp xếp
        /// </summary>
        public List<LaborContractDTO> GetContracts(DateTime? fromDate = null, DateTime? toDate = null, string phongBan = null, string sortKey = null)
        {
            var contracts = new List<LaborContractDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                string query = @"
            SELECT 
                hd.maHopDong,
                CONCAT(hs.hoTen, ' (', hd.maNhanVien, ')') AS tenNhanVien,
                pb.tenPhong AS phongBan,
                hd.tuNgay,
                hd.denNgay,
                hd.loaiHopDong,
                IFNULL(l.LuongCoBan, 0) AS luongCoBan
            FROM hopdonglaodong hd
            LEFT JOIN nhanvien nv ON hd.maNhanVien = nv.maNhanVien
            LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
            LEFT JOIN phongban pb ON hd.phongBan = pb.maPhong
            LEFT JOIN luong l ON hd.maNhanVien = l.MaNhanVien
            WHERE 1=1";

                if (!string.IsNullOrEmpty(phongBan))
                {
                    query += " AND pb.tenPhong = @phongBan";
                }

                if (fromDate.HasValue)
                {
                    query += " AND hd.tuNgay >= @fromDate";
                }

                if (toDate.HasValue)
                {
                    query += " AND (hd.denNgay IS NOT NULL AND hd.denNgay <= @toDate)";
                }

                // sortKey: TU_ASC, TU_DESC, DEN_ASC, DEN_DESC, LUONG_ASC, LUONG_DESC
                if (!string.IsNullOrEmpty(sortKey))
                {
                    switch (sortKey)
                    {
                        case "TU_ASC": query += " ORDER BY hd.tuNgay ASC"; break;
                        case "TU_DESC": query += " ORDER BY hd.tuNgay DESC"; break;
                        case "DEN_ASC": query += " ORDER BY hd.denNgay ASC"; break;
                        case "DEN_DESC": query += " ORDER BY hd.denNgay DESC"; break;
                        case "LUONG_ASC": query += " ORDER BY l.LuongCoBan ASC"; break;
                        case "LUONG_DESC": query += " ORDER BY l.LuongCoBan DESC"; break;
                        default: query += " ORDER BY hd.tuNgay DESC"; break;
                    }
                }
                else
                {
                    query += " ORDER BY hd.tuNgay DESC";
                }

                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(phongBan)) cmd.Parameters.AddWithValue("@phongBan", phongBan);
                    if (fromDate.HasValue) cmd.Parameters.AddWithValue("@fromDate", fromDate.Value.Date);
                    if (toDate.HasValue) cmd.Parameters.AddWithValue("@toDate", toDate.Value.Date);

                    reader = cmd.ExecuteReader();
                    int stt = 1;
                    while (reader.Read())
                    {
                        contracts.Add(new LaborContractDTO
                        {
                            STT = stt++,
                            MaHopDong = reader["maHopDong"].ToString(),
                            TenNhanVien = reader["tenNhanVien"].ToString(),
                            PhongBan = reader["phongBan"].ToString(),
                            TuNgay = reader["tuNgay"] != DBNull.Value ? Convert.ToDateTime(reader["tuNgay"]) : (DateTime?)null,
                            DenNgay = reader["denNgay"] != DBNull.Value ? Convert.ToDateTime(reader["denNgay"]) : (DateTime?)null,
                            LoaiHopDong = reader["loaiHopDong"].ToString(),
                            LuongCoBan = reader["luongCoBan"] != DBNull.Value ? Convert.ToDecimal(reader["luongCoBan"]) : 0m
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error GetContracts: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return contracts;
        }

    }

}