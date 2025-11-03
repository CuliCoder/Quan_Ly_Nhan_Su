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
        /// Lấy tất cả hồ sơ cá nhân từ bảng hosocanhan
        /// </summary>
        public List<PersonalProfileDTO> GetAll()
        {
            var list = new List<PersonalProfileDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM hosocanhan";
                using (var command = new MySqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var profile = new PersonalProfileDTO
                            {
                                SoCmnd = reader["soCmnd"] != DBNull.Value ? reader["soCmnd"].ToString() : "",
                                HoTen = reader["hoTen"] != DBNull.Value ? reader["hoTen"].ToString() : "",
                                NgaySinh = reader["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["ngaySinh"]) : DateTime.MinValue,
                                GioiTinh = reader["gioiTinh"] != DBNull.Value ? reader["gioiTinh"].ToString() : "",
                                DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : "",
                                Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : "",
                                SoDienThoai = reader["sdt"] != DBNull.Value ? reader["sdt"].ToString() : "",
                                NoiCap = reader["noiCap"] != DBNull.Value ? reader["noiCap"].ToString() : "",
                                NgayCap = reader["ngayCap"] != DBNull.Value ? Convert.ToDateTime(reader["ngayCap"]) : DateTime.MinValue,
                                DanToc = reader["danToc"] != DBNull.Value ? reader["danToc"].ToString() : "",
                                HocVan = reader["hocVan"] != DBNull.Value ? reader["hocVan"].ToString() : "",
                                HonNhan = reader["tinhTrangHonNhan"] != DBNull.Value ? reader["tinhTrangHonNhan"].ToString() : "",
                                ChuyenNganh = reader["chuyenNganh"] != DBNull.Value ? reader["chuyenNganh"].ToString() : "",
                                HinhAnh = reader["anh"] != DBNull.Value ? reader["anh"].ToString() : ""
                            };
                            list.Add(profile);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting personal profiles: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }

            return list;
        }

        public PersonalProfileDTO GetById(string cccd)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM hosocanhan WHERE soCmnd=@cccd";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cccd", cccd);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // ✅ Di chuyển tới bản ghi đầu tiên
                            {
                                return new PersonalProfileDTO
                                {
                                    SoCmnd = reader["soCmnd"] != DBNull.Value ? reader["soCmnd"].ToString() : "",
                                    HoTen = reader["hoTen"] != DBNull.Value ? reader["hoTen"].ToString() : "",
                                    NgaySinh = reader["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["ngaySinh"]) : DateTime.MinValue,
                                    GioiTinh = reader["gioiTinh"] != DBNull.Value ? reader["gioiTinh"].ToString() : "",
                                    DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : "",
                                    Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : "",
                                    SoDienThoai = reader["sdt"] != DBNull.Value ? reader["sdt"].ToString() : "",
                                    NoiCap = reader["noiCap"] != DBNull.Value ? reader["noiCap"].ToString() : "",
                                    NgayCap = reader["ngayCap"] != DBNull.Value ? Convert.ToDateTime(reader["ngayCap"]) : DateTime.MinValue,
                                    DanToc = reader["danToc"] != DBNull.Value ? reader["danToc"].ToString() : "",
                                    HocVan = reader["hocVan"] != DBNull.Value ? reader["hocVan"].ToString() : "",
                                    HonNhan = reader["tinhTrangHonNhan"] != DBNull.Value ? reader["tinhTrangHonNhan"].ToString() : "",
                                    ChuyenNganh = reader["chuyenNganh"] != DBNull.Value ? reader["chuyenNganh"].ToString() : "",
                                    HinhAnh = reader["anh"] != DBNull.Value ? reader["anh"].ToString() : ""
                                };
                            }
                            else
                            {
                                // Không tìm thấy dữ liệu
                                return null;
                            }
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
        }


        public bool CheckCccd(string soCccd)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM hosocanhan WHERE soCmnd = @soCmnd";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@soCmnd", soCccd);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count == 0; 
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
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
                string query = @"
                INSERT INTO hosocanhan 
                (soCmnd, hoTen, gioiTinh, ngaySinh, diaChi, email, sdt, noiCap, ngayCap, tinhTrangHonNhan, danToc, hocVan, chuyenNganh, anh)
                VALUES 
                (@soCmnd, @hoTen, @gioiTinh, @ngaySinh, @diaChi, @email, @sdt, @noiCap, @ngayCap, @tinhTrangHonNhan, @danToc, @hocVan, @chuyenNganh, @anh)";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@soCmnd", profile.SoCmnd);
                    command.Parameters.AddWithValue("@hoTen", profile.HoTen);
                    command.Parameters.AddWithValue("@gioiTinh", profile.GioiTinh);
                    command.Parameters.AddWithValue("@ngaySinh", profile.NgaySinh == DateTime.MinValue ? DateTime.Now : profile.NgaySinh);
                    command.Parameters.AddWithValue("@diaChi", (object)profile.DiaChi ?? DBNull.Value);
                    command.Parameters.AddWithValue("@email", (object)profile.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@sdt", (object)profile.SoDienThoai ?? DBNull.Value);
                    command.Parameters.AddWithValue("@noiCap", (object)profile.NoiCap ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ngayCap", profile.NgayCap == DateTime.MinValue ? DateTime.Now : profile.NgayCap);
                    command.Parameters.AddWithValue("@tinhTrangHonNhan", (object)profile.HonNhan ?? DBNull.Value);
                    command.Parameters.AddWithValue("@danToc", (object)profile.DanToc ?? DBNull.Value);
                    command.Parameters.AddWithValue("@hocVan", (object)profile.HocVan ?? DBNull.Value);
                    command.Parameters.AddWithValue("@chuyenNganh", (object)profile.ChuyenNganh ?? DBNull.Value);
                    command.Parameters.AddWithValue("@anh", (object)profile.HinhAnh ?? DBNull.Value);

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
                    command.Parameters.AddWithValue("@diaChi", (object)profile.DiaChi ?? DBNull.Value);
                    command.Parameters.AddWithValue("@email", (object)profile.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@sdt", (object)profile.SoDienThoai ?? DBNull.Value);
                    command.Parameters.AddWithValue("@noiCap", (object)profile.NoiCap ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ngayCap", profile.NgayCap);
                    command.Parameters.AddWithValue("@tinhTrangHonNhan", (object)profile.HonNhan ?? DBNull.Value);
                    command.Parameters.AddWithValue("@danToc", (object)profile.DanToc ?? DBNull.Value);
                    command.Parameters.AddWithValue("@hocVan", (object)profile.HocVan ?? DBNull.Value);
                    command.Parameters.AddWithValue("@chuyenNganh", (object)profile.ChuyenNganh ?? DBNull.Value);
                    command.Parameters.AddWithValue("@anh", (object)profile.HinhAnh ?? DBNull.Value);

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
                                SoCmnd = reader["soCmnd"] != DBNull.Value ? reader["soCmnd"].ToString() : "",
                                HoTen = reader["hoTen"] != DBNull.Value ? reader["hoTen"].ToString() : "",
                                NgaySinh = reader["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["ngaySinh"]) : DateTime.MinValue,
                                GioiTinh = reader["gioiTinh"] != DBNull.Value ? reader["gioiTinh"].ToString() : "",
                                DiaChi = reader["diaChi"] != DBNull.Value ? reader["diaChi"].ToString() : "",
                                Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : "",
                                SoDienThoai = reader["sdt"] != DBNull.Value ? reader["sdt"].ToString() : "",
                                NoiCap = reader["noiCap"] != DBNull.Value ? reader["noiCap"].ToString() : "",
                                NgayCap = reader["ngayCap"] != DBNull.Value ? Convert.ToDateTime(reader["ngayCap"]) : DateTime.MinValue,
                                DanToc = reader["danToc"] != DBNull.Value ? reader["danToc"].ToString() : "",
                                HocVan = reader["hocVan"] != DBNull.Value ? reader["hocVan"].ToString() : "",
                                HonNhan = reader["tinhTrangHonNhan"] != DBNull.Value ? reader["tinhTrangHonNhan"].ToString() : "",
                                ChuyenNganh = reader["chuyenNganh"] != DBNull.Value ? reader["chuyenNganh"].ToString() : "",
                                HinhAnh = reader["anh"] != DBNull.Value ? reader["anh"].ToString() : ""
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