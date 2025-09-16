using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for Employee table
    /// </summary>
    public class EmployeeDAO
    {
        /// <summary>
        /// Creates a new employee in the nhanvien table
        /// </summary>
        public bool Create(EmployeeDTO employee)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "INSERT INTO nhanvien (maNhanVien, soCmnd, maluong, mahopdong, maTrinhDo, maChucVu, maTaiKhoan, maPhong) VALUES (@maNhanVien, @soCmnd, @maluong, @mahopdong, @maTrinhDo, @maChucVu, @maTaiKhoan, @maPhong)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maNhanVien", employee.MaNhanVien);
                    command.Parameters.AddWithValue("@soCmnd", employee.SoCmnd);
                    command.Parameters.AddWithValue("@maluong", employee.MaLuong);
                    command.Parameters.AddWithValue("@mahopdong", employee.MaHopDong);
                    command.Parameters.AddWithValue("@maTrinhDo", (object)employee.MaTrinhDo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@maChucVu", (object)employee.MaChucVu ?? DBNull.Value);
                    command.Parameters.AddWithValue("@maTaiKhoan", (object)employee.MaTaiKhoan ?? DBNull.Value);
                    command.Parameters.AddWithValue("@maPhong", (object)employee.MaPhong ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating employee: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing employee in the nhanvien table
        /// </summary>
        public bool Update(EmployeeDTO employee)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "UPDATE nhanvien SET soCmnd = @soCmnd, maluong = @maluong, mahopdong = @mahopdong, maTrinhDo = @maTrinhDo, maChucVu = @maChucVu, maTaiKhoan = @maTaiKhoan, maPhong = @maPhong WHERE maNhanVien = @maNhanVien";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maNhanVien", employee.MaNhanVien);
                    command.Parameters.AddWithValue("@soCmnd", employee.SoCmnd);
                    command.Parameters.AddWithValue("@maluong", employee.MaLuong);
                    command.Parameters.AddWithValue("@mahopdong", employee.MaHopDong);
                    command.Parameters.AddWithValue("@maTrinhDo", (object)employee.MaTrinhDo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@maChucVu", (object)employee.MaChucVu ?? DBNull.Value);
                    command.Parameters.AddWithValue("@maTaiKhoan", (object)employee.MaTaiKhoan ?? DBNull.Value);
                    command.Parameters.AddWithValue("@maPhong", (object)employee.MaPhong ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating employee: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Deletes an employee from the nhanvien table
        /// </summary>
        public bool Delete(string maNhanVien)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM nhanvien WHERE maNhanVien = @maNhanVien";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Searches for employees by maNhanVien or soCmnd
        /// </summary>
        public List<EmployeeDTO> Search(string searchTerm)
        {
            var employees = new List<EmployeeDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM nhanvien WHERE maNhanVien = @searchTerm OR soCmnd LIKE @searchTermLike";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new EmployeeDTO
                            {
                                MaNhanVien = reader.GetString("maNhanVien"),
                                SoCmnd = reader.GetString("soCmnd"),
                                MaLuong = reader.GetString("maluong"),
                                MaHopDong = reader.GetString("mahopdong"),
                                MaTrinhDo = reader.IsDBNull(reader.GetOrdinal("maTrinhDo")) ? null : reader.GetString("maTrinhDo"),
                                MaChucVu = reader.IsDBNull(reader.GetOrdinal("maChucVu")) ? null : reader.GetString("maChucVu"),
                                MaTaiKhoan = reader.IsDBNull(reader.GetOrdinal("maTaiKhoan")) ? null : reader.GetString("maTaiKhoan"),
                                MaPhong = reader.IsDBNull(reader.GetOrdinal("maPhong")) ? null : reader.GetString("maPhong")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching employees: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return employees;
        }
    }
}