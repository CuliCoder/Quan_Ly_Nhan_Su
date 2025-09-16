using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for Account table
    /// </summary>
    public class AccountDAO
    {
        /// <summary>
        /// Creates a new account in the taikhoan table
        /// </summary>
        public bool Create(AccountDTO account)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "INSERT INTO taikhoan (maTaiKhoan, tenDangNhap, matKhau, maNhomQuyen) VALUES (@maTaiKhoan, @tenDangNhap, @matKhau, @maNhomQuyen)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maTaiKhoan", account.MaTaiKhoan);
                    command.Parameters.AddWithValue("@tenDangNhap", account.TenDangNhap);
                    command.Parameters.AddWithValue("@matKhau", account.MatKhau);
                    command.Parameters.AddWithValue("@maNhomQuyen", (object)account.MaNhomQuyen ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating account: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing account in the taikhoan table
        /// </summary>
        public bool Update(AccountDTO account)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "UPDATE taikhoan SET tenDangNhap = @tenDangNhap, matKhau = @matKhau, maNhomQuyen = @maNhomQuyen WHERE maTaiKhoan = @maTaiKhoan";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maTaiKhoan", account.MaTaiKhoan);
                    command.Parameters.AddWithValue("@tenDangNhap", account.TenDangNhap);
                    command.Parameters.AddWithValue("@matKhau", account.MatKhau);
                    command.Parameters.AddWithValue("@maNhomQuyen", (object)account.MaNhomQuyen ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating account: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Deletes an account from the taikhoan table
        /// </summary>
        public bool Delete(string maTaiKhoan)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM taikhoan WHERE maTaiKhoan = @maTaiKhoan";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting account: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

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
                                MaNhomQuyen = reader.IsDBNull(reader.GetOrdinal("maNhomQuyen")) ? null : reader.GetString("maNhomQuyen")
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
    }
}