using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for Position table
    /// </summary>
    public class PositionDAO
    {
        /// <summary>
        /// Creates a new position in the chucvu table
        /// </summary>
        public bool Create(PositionDTO position)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "INSERT INTO chucvu (maChucVu, tenChucVu, phuCapChucVu, ngayNhanChuc) VALUES (@maChucVu, @tenChucVu, @phuCapChucVu, @ngayNhanChuc)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maChucVu", position.MaChucVu);
                    command.Parameters.AddWithValue("@tenChucVu", position.TenChucVu);
                    command.Parameters.AddWithValue("@phuCapChucVu", position.PhuCapChucVu);
                    command.Parameters.AddWithValue("@ngayNhanChuc", (object)position.NgayNhanChuc ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating position: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing position in the chucvu table
        /// </summary>
        public bool Update(PositionDTO position)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "UPDATE chucvu SET tenChucVu = @tenChucVu, phuCapChucVu = @phuCapChucVu, ngayNhanChuc = @ngayNhanChuc WHERE maChucVu = @maChucVu";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maChucVu", position.MaChucVu);
                    command.Parameters.AddWithValue("@tenChucVu", position.TenChucVu);
                    command.Parameters.AddWithValue("@phuCapChucVu", position.PhuCapChucVu);
                    command.Parameters.AddWithValue("@ngayNhanChuc", (object)position.NgayNhanChuc ?? DBNull.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating position: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Deletes a position from the chucvu table
        /// </summary>
        public bool Delete(string maChucVu)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "DELETE FROM chucvu WHERE maChucVu = @maChucVu";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maChucVu", maChucVu);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting position: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Searches for positions by maChucVu or tenChucVu
        /// </summary>
        public List<PositionDTO> Search(string searchTerm)
        {
            var positions = new List<PositionDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = "SELECT * FROM chucvu WHERE maChucVu = @searchTerm OR tenChucVu LIKE @searchTermLike";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            positions.Add(new PositionDTO
                            {
                                MaChucVu = reader.GetString("maChucVu"),
                                TenChucVu = reader.GetString("tenChucVu"),
                                PhuCapChucVu = reader.GetDecimal("phuCapChucVu"),
                                NgayNhanChuc = reader.IsDBNull(reader.GetOrdinal("ngayNhanChuc")) ? null : reader.GetDateTime("ngayNhanChuc")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching positions: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return positions;
        }
    }
}