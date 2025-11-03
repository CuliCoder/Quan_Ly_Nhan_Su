using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for Account table
    /// </summary>
    public class AccountDAO
    {
        /// <summary>
        /// Helper method to map a MySqlDataReader row to an AccountDTO object.
        /// </summary>
        private AccountDTO MapReaderToAccount(MySqlDataReader reader)
        {
            return new AccountDTO
            {
                MaTaiKhoan = reader.GetString("maTaiKhoan"),
                TenDangNhap = reader.GetString("tenDangNhap"),
                MatKhau = reader.GetString("matKhau"),
                MaNhomQuyen = reader.IsDBNull(reader.GetOrdinal("maNhomQuyen")) ? (int?)null : reader.GetInt32("maNhomQuyen"),
                TinhTrang = reader.GetBoolean("TinhTrang")
            };
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
                                    MaLuong = reader["maluong"].ToString(),
                                    MaHopDong = reader["mahopdong"].ToString(),
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

        /// <summary>
        /// Gets all accounts from the 'taikhoan' table.
        /// </summary>
        public List<AccountDTO> GetAll()
        {
            var accounts = new List<AccountDTO>();
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM taikhoan";
                    using (var command = new MySqlCommand(query, conn))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(MapReaderToAccount(reader));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting all accounts: {ex.Message}");
                }
            }
            return accounts;
        }

        /// <summary>
        /// Gets a specific account by its ID (maTaiKhoan).
        /// </summary>
        public AccountDTO GetById(string maTaiKhoan)
        {
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM taikhoan WHERE maTaiKhoan = @maTaiKhoan";
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapReaderToAccount(reader);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting account by ID: {ex.Message}");
                }
            }
            return null;
        }

        /// <summary>
        /// Gets a specific account by its username.
        /// </summary>
        public AccountDTO GetByUsername(string username)
        {
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM taikhoan WHERE tenDangNhap = @tenDangNhap";
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@tenDangNhap", username);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapReaderToAccount(reader);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting account by username: {ex.Message}");
                }
            }
            return null;
        }

        /// <summary>
        /// Inserts a new account and links it to an employee within a transaction.
        /// </summary>
        public bool InsertForEmployee(AccountDTO account, string maNhanVien)
        {
            using (var conn = connectDB.getConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Step 1: Insert the new account
                        string insertAccountQuery = "INSERT INTO taikhoan (maTaiKhoan, tenDangNhap, matKhau, maNhomQuyen, TinhTrang) VALUES (@maTaiKhoan, @tenDangNhap, @matKhau, @maNhomQuyen, @tinhTrang)";
                        using (var cmd1 = new MySqlCommand(insertAccountQuery, conn, transaction))
                        {
                            cmd1.Parameters.AddWithValue("@maTaiKhoan", account.MaTaiKhoan);
                            cmd1.Parameters.AddWithValue("@tenDangNhap", account.TenDangNhap);
                            cmd1.Parameters.AddWithValue("@matKhau", account.MatKhau);
                            cmd1.Parameters.AddWithValue("@maNhomQuyen", (object)account.MaNhomQuyen ?? DBNull.Value);
                            cmd1.Parameters.AddWithValue("@tinhTrang", account.TinhTrang);
                            cmd1.ExecuteNonQuery();
                        }

                        // Step 2: Update the employee record with the new account ID
                        string updateEmployeeQuery = "UPDATE nhanvien SET maTaiKhoan = @maTaiKhoan WHERE maNhanVien = @maNhanVien";
                        using (var cmd2 = new MySqlCommand(updateEmployeeQuery, conn, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@maTaiKhoan", account.MaTaiKhoan);
                            cmd2.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                            cmd2.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error in transaction: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Updates an existing account in the taikhoan table.
        /// </summary>
        public bool Update(AccountDTO account)
        {
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE taikhoan SET tenDangNhap = @tenDangNhap, matKhau = @matKhau, maNhomQuyen = @maNhomQuyen, TinhTrang = @tinhTrang WHERE maTaiKhoan = @maTaiKhoan";
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@tenDangNhap", account.TenDangNhap);
                        command.Parameters.AddWithValue("@matKhau", account.MatKhau);
                        command.Parameters.AddWithValue("@maNhomQuyen", (object)account.MaNhomQuyen ?? DBNull.Value);
                        command.Parameters.AddWithValue("@tinhTrang", account.TinhTrang);
                        command.Parameters.AddWithValue("@maTaiKhoan", account.MaTaiKhoan);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating account: {ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// Updates the status (TinhTrang) of an account.
        /// </summary>
        public bool UpdateStatus(string maTaiKhoan, bool newStatus)
        {
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE taikhoan SET TinhTrang = @tinhTrang WHERE maTaiKhoan = @maTaiKhoan";
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@tinhTrang", newStatus);
                        command.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating account status: {ex.Message}");
                    return false;
                }
            }
        }

        /*
        /// The physical delete logic is replaced by UpdateStatus (toggling TinhTrang).
        /// This method is kept here for reference but should not be used.
        public bool Delete(string maTaiKhoan)
        {
            // ... original delete code ...
        }
        */


        /// <summary>
        /// Searches for accounts by maTaiKhoan or tenDangNhap
        /// </summary>
        public List<AccountDTO> Search(string searchTerm)
        {
            var accounts = new List<AccountDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM taikhoan WHERE maTaiKhoan = @searchTerm OR tenDangNhap LIKE @searchTermLike";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(new AccountDTO
                            {
                                MaTaiKhoan = reader.GetString("maTaiKhoan"),
                                TenDangNhap = reader.GetString("tenDangNhap"),
                                MatKhau = reader.GetString("matKhau"),
                                TinhTrang = reader.GetBoolean("TinhTrang")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching accounts: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return accounts;
        }

        /// <summary>
        /// Migrate any plaintext (non-bcrypt) passwords to bcrypt hashes.
        /// Returns number of accounts updated.
        /// Call this once (or run from an admin tool) if you want to bulk-convert passwords.
        /// </summary>
        public int MigratePlaintextPasswords()
        {
            var updates = new List<Tuple<string, string>>();
            using (var conn = connectDB.getConnection())
            {
                if (conn == null) return 0;
                conn.Open();

                // Read all accounts (only id + password)
                using (var cmd = new MySqlCommand("SELECT maTaiKhoan, matKhau FROM taikhoan", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.IsDBNull(reader.GetOrdinal("maTaiKhoan")) ? null : reader.GetString("maTaiKhoan");
                        var pwd = reader.IsDBNull(reader.GetOrdinal("matKhau")) ? null : reader.GetString("matKhau");
                        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pwd))
                            continue;

                        // Basic bcrypt detection: bcrypt hashes start with "$2"
                        if (!pwd.StartsWith("$2"))
                        {
                            var hashed = BCrypt.Net.BCrypt.HashPassword(pwd);
                            updates.Add(Tuple.Create(id, hashed));
                        }
                    }
                }

                if (updates.Count == 0) return 0;

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var t in updates)
                        {
                            using (var upd = new MySqlCommand("UPDATE taikhoan SET matKhau = @matKhau WHERE maTaiKhoan = @maTaiKhoan", conn, transaction))
                            {
                                upd.Parameters.AddWithValue("@matKhau", t.Item2);
                                upd.Parameters.AddWithValue("@maTaiKhoan", t.Item1);
                                upd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        return updates.Count;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }

}