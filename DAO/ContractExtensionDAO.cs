using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for ContractExtension table
    /// </summary>
    public class ContractExtensionDAO
    {
        /// <summary>
        /// Creates a new contract extension in the giahanhopdong table
        /// </summary>
        public bool Create(ContractExtensionDTO extension)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "INSERT INTO giahanhopdong (maQuyetDinh, thoiGianGiaHan) VALUES (@maQuyetDinh, @thoiGianGiaHan)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maQuyetDinh", extension.MaQuyetDinh);
                    command.Parameters.AddWithValue("@thoiGianGiaHan", extension.ThoiGianGiaHan);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating contract extension: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing contract extension in the giahanhopdong table
        /// </summary>
        public bool Update(ContractExtensionDTO extension)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "UPDATE giahanhopdong SET thoiGianGiaHan = @thoiGianGiaHan WHERE maQuyetDinh = @maQuyetDinh";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maQuyetDinh", extension.MaQuyetDinh);
                    command.Parameters.AddWithValue("@thoiGianGiaHan", extension.ThoiGianGiaHan);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating contract extension: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Deletes a contract extension from the giahanhopdong table
        /// </summary>
        public bool Delete(string maQuyetDinh)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM giahanhopdong WHERE maQuyetDinh = @maQuyetDinh";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maQuyetDinh", maQuyetDinh);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting contract extension: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Searches for contract extensions by maQuyetDinh
        /// </summary>
        public List<ContractExtensionDTO> Search(string searchTerm)
        {
            var extensions = new List<ContractExtensionDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM giahanhopdong WHERE maQuyetDinh = @searchTerm";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            extensions.Add(new ContractExtensionDTO
                            {
                                MaQuyetDinh = reader.GetString("maQuyetDinh"),
                                ThoiGianGiaHan = reader.GetDecimal("thoiGianGiaHan")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching contract extensions: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return extensions;
        }
    }
}