using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for RecruitmentBatch_Employee table
    /// </summary>
    public class RecruitmentBatchEmployeeDAO
    {
        /// <summary>
        /// Creates a new record in the dottuyendung_nhanvien table
        /// </summary>
        public bool Create(RecruitmentBatchEmployeeDTO batchEmployee)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "INSERT INTO dottuyendung_nhanvien (maTuyenDung, maNhanVien, ngayTuyenDung) VALUES (@maTuyenDung, @maNhanVien, @ngayTuyenDung)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maTuyenDung", batchEmployee.MaTuyenDung);
                    command.Parameters.AddWithValue("@maNhanVien", batchEmployee.MaNhanVien);
                    command.Parameters.AddWithValue("@ngayTuyenDung", batchEmployee.NgayTuyenDung);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating recruitment batch employee: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing record in the dottuyendung_nhanvien table
        /// </summary>
        public bool Update(RecruitmentBatchEmployeeDTO batchEmployee)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "UPDATE dottuyendung_nhanvien SET ngayTuyenDung = @ngayTuyenDung WHERE maTuyenDung = @maTuyenDung AND maNhanVien = @maNhanVien";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maTuyenDung", batchEmployee.MaTuyenDung);
                    command.Parameters.AddWithValue("@maNhanVien", batchEmployee.MaNhanVien);
                    command.Parameters.AddWithValue("@ngayTuyenDung", batchEmployee.NgayTuyenDung);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating recruitment batch employee: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Deletes a record from the dottuyendung_nhanvien table
        /// </summary>
        public bool Delete(string maTuyenDung, string maNhanVien)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM dottuyendung_nhanvien WHERE maTuyenDung = @maTuyenDung AND maNhanVien = @maNhanVien";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maTuyenDung", maTuyenDung);
                    command.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting recruitment batch employee: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Searches for records by maTuyenDung or maNhanVien
        /// </summary>
        public List<RecruitmentBatchEmployeeDTO> Search(string searchTerm)
        {
            var batchEmployees = new List<RecruitmentBatchEmployeeDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM dottuyendung_nhanvien WHERE maTuyenDung = @searchTerm OR maNhanVien LIKE @searchTermLike";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            batchEmployees.Add(new RecruitmentBatchEmployeeDTO
                            {
                                MaTuyenDung = reader.GetString("maTuyenDung"),
                                MaNhanVien = reader.GetString("maNhanVien"),
                                NgayTuyenDung = reader.GetDateTime("ngayTuyenDung")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching recruitment batch employees: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return batchEmployees;
        }
    }
}