using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for PersonalProfile table
    /// </summary>
    public class PersonalProfileDAO
    {
        /// <summary>
        /// Creates a new personal profile in the hosocanhan table
        /// </summary>
        public bool Create(PersonalProfileDTO profile)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "INSERT INTO hosocanhan (soCmnd, hoTen, gioiTinh, ngaySinh, diachi, email, sdt, noiCap, ngayCap, tinhTrangHonNhan, danToc) VALUES (@soCmnd, @hoTen, @gioiTinh, @ngaySinh, @diachi, @email, @sdt, @noiCap, @ngayCap, @tinhTrangHonNhan, @danToc)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@soCmnd", profile.SoCmnd);
                    command.Parameters.AddWithValue("@hoTen", profile.HoTen);
                    command.Parameters.AddWithValue("@gioiTinh", profile.GioiTinh);
                    command.Parameters.AddWithValue("@ngaySinh", profile.NgaySinh);
                    command.Parameters.AddWithValue("@diachi", (object)profile.DiaChi ?? DBNull.Value);
                    command.Parameters.AddWithValue("@email", (object)profile.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@sdt", (object)profile.Sdt ?? DBNull.Value);
                    command.Parameters.AddWithValue("@noiCap", profile.NoiCap);
                    command.Parameters.AddWithValue("@ngayCap", profile.NgayCap);
                    command.Parameters.AddWithValue("@tinhTrangHonNhan", (object)profile.TinhTrangHonNhan ?? DBNull.Value);
                    command.Parameters.AddWithValue("@danToc", (object)profile.DanToc ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating personal profile: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing personal profile in the hosocanhan table
        /// </summary>
        public bool Update(PersonalProfileDTO profile)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "UPDATE hosocanhan SET hoTen = @hoTen, gioiTinh = @gioiTinh, ngaySinh = @ngaySinh, diachi = @diachi, email = @email, sdt = @sdt, noiCap = @noiCap, ngayCap = @ngayCap, tinhTrangHonNhan = @tinhTrangHonNhan, danToc = @danToc WHERE soCmnd = @soCmnd";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@soCmnd", profile.SoCmnd);
                    command.Parameters.AddWithValue("@hoTen", profile.HoTen);
                    command.Parameters.AddWithValue("@gioiTinh", profile.GioiTinh);
                    command.Parameters.AddWithValue("@ngaySinh", profile.NgaySinh);
                    command.Parameters.AddWithValue("@diachi", (object)profile.DiaChi ?? DBNull.Value);
                    command.Parameters.AddWithValue("@email", (object)profile.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@sdt", (object)profile.Sdt ?? DBNull.Value);
                    command.Parameters.AddWithValue("@noiCap", profile.NoiCap);
                    command.Parameters.AddWithValue("@ngayCap", profile.NgayCap);
                    command.Parameters.AddWithValue("@tinhTrangHonNhan", (object)profile.TinhTrangHonNhan ?? DBNull.Value);
                    command.Parameters.AddWithValue("@danToc", (object)profile.DanToc ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating personal profile: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Deletes a personal profile from the hosocanhan table
        /// </summary>
        public bool Delete(string soCmnd)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM hosocanhan WHERE soCmnd = @soCmnd";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@soCmnd", soCmnd);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting personal profile: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Searches for personal profiles by soCmnd or hoTen
        /// </summary>
        public List<PersonalProfileDTO> Search(string searchTerm)
        {
            var profiles = new List<PersonalProfileDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM hosocanhan WHERE soCmnd = @searchTerm OR hoTen LIKE @searchTermLike";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            profiles.Add(new PersonalProfileDTO
                            {
                                SoCmnd = reader.GetString("soCmnd"),
                                HoTen = reader.GetString("hoTen"),
                                GioiTinh = reader.GetString("gioiTinh"),
                                NgaySinh = reader.GetDateTime("ngaySinh"),
                                DiaChi = reader.IsDBNull(reader.GetOrdinal("diachi")) ? null : reader.GetString("diachi"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                Sdt = reader.IsDBNull(reader.GetOrdinal("sdt")) ? null : reader.GetString("sdt"),
                                NoiCap = reader.GetString("noiCap"),
                                NgayCap = reader.GetDateTime("ngayCap"),
                                TinhTrangHonNhan = reader.IsDBNull(reader.GetOrdinal("tinhTrangHonNhan")) ? null : reader.GetString("tinhTrangHonNhan"),
                                DanToc = reader.IsDBNull(reader.GetOrdinal("danToc")) ? null : reader.GetString("danToc")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching personal profiles: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return profiles;
        }
    }
}