using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for Timesheet table
    /// </summary>
    public class TimesheetDAO
    {
        /// <summary>
        /// Creates a new timesheet in the bangchamcong table
        /// </summary>
        public bool Create(TimesheetDTO timesheet)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "INSERT INTO bangchamcong (maBangChamCong, maNV, thangChamCong, namChamCong, soNgayLamViec, soNgayNghi, soNgayTre, soGioLamThem, chiTiet, trangThai) VALUES (@maBangChamCong, @maNV, @thangChamCong, @namChamCong, @soNgayLamViec, @soNgayNghi, @soNgayTre, @soGioLamThem, @chiTiet, @trangThai)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maBangChamCong", timesheet.MaBangChamCong);
                    command.Parameters.AddWithValue("@maNV", timesheet.MaNV);
                    command.Parameters.AddWithValue("@thangChamCong", timesheet.ThangChamCong);
                    command.Parameters.AddWithValue("@namChamCong", timesheet.NamChamCong);
                    command.Parameters.AddWithValue("@soNgayLamViec", timesheet.SoNgayLamViec);
                    command.Parameters.AddWithValue("@soNgayNghi", timesheet.SoNgayNghi);
                    command.Parameters.AddWithValue("@soNgayTre", timesheet.SoNgayTre);
                    command.Parameters.AddWithValue("@soGioLamThem", timesheet.SoGioLamThem);
                    command.Parameters.AddWithValue("@chiTiet", (object)timesheet.ChiTiet ?? DBNull.Value);
                    command.Parameters.AddWithValue("@trangThai", (object)timesheet.TrangThai ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating timesheet: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing timesheet in the bangchamcong table
        /// </summary>
        public bool Update(TimesheetDTO timesheet)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "UPDATE bangchamcong SET maNV = @maNV, thangChamCong = @thangChamCong, namChamCong = @namChamCong, soNgayLamViec = @soNgayLamViec, soNgayNghi = @soNgayNghi, soNgayTre = @soNgayTre, soGioLamThem = @soGioLamThem, chiTiet = @chiTiet, trangThai = @trangThai WHERE maBangChamCong = @maBangChamCong";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maBangChamCong", timesheet.MaBangChamCong);
                    command.Parameters.AddWithValue("@maNV", timesheet.MaNV);
                    command.Parameters.AddWithValue("@thangChamCong", timesheet.ThangChamCong);
                    command.Parameters.AddWithValue("@namChamCong", timesheet.NamChamCong);
                    command.Parameters.AddWithValue("@soNgayLamViec", timesheet.SoNgayLamViec);
                    command.Parameters.AddWithValue("@soNgayNghi", timesheet.SoNgayNghi);
                    command.Parameters.AddWithValue("@soNgayTre", timesheet.SoNgayTre);
                    command.Parameters.AddWithValue("@soGioLamThem", timesheet.SoGioLamThem);
                    command.Parameters.AddWithValue("@chiTiet", (object)timesheet.ChiTiet ?? DBNull.Value);
                    command.Parameters.AddWithValue("@trangThai", (object)timesheet.TrangThai ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating timesheet: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Deletes a timesheet from the bangchamcong table
        /// </summary>
        public bool Delete(string maBangChamCong)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM bangchamcong WHERE maBangChamCong = @maBangChamCong";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maBangChamCong", maBangChamCong);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting timesheet: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Searches for timesheets by maBangChamCong or maNV
        /// </summary>
        public List<TimesheetDTO> Search(string searchTerm)
        {
            var timesheets = new List<TimesheetDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM bangchamcong WHERE maBangChamCong = @searchTerm OR maNV LIKE @searchTermLike";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            timesheets.Add(new TimesheetDTO
                            {
                                MaBangChamCong = reader.GetString("maBangChamCong"),
                                MaNV = reader.GetString("maNV"),
                                ThangChamCong = reader.GetInt32("thangChamCong"),
                                NamChamCong = reader.GetInt32("namChamCong"),
                                SoNgayLamViec = reader.GetInt32("soNgayLamViec"),
                                SoNgayNghi = reader.GetInt32("soNgayNghi"),
                                SoNgayTre = reader.GetInt32("soNgayTre"),
                                SoGioLamThem = reader.GetInt32("soGioLamThem"),
                                ChiTiet = reader.IsDBNull(reader.GetOrdinal("chiTiet")) ? null : reader.GetString("chiTiet"),
                                TrangThai = reader.IsDBNull(reader.GetOrdinal("trangThai")) ? null : reader.GetString("trangThai")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching timesheets: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return timesheets;
        }
    }
}