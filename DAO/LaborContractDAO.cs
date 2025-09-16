using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for LaborContract table
    /// </summary>
    public class LaborContractDAO
    {
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
                string query = "INSERT INTO hopdonglaodong (maHopDong, maNhanVien, tuNgay, denNgay, loaiHopDong, phongBan, luongCoBan, maBangChamCong) VALUES (@maHopDong, @maNhanVien, @tuNgay, @denNgay, @loaiHopDong, @phongBan, @luongCoBan, @maBangChamCong)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maHopDong", contract.MaHopDong);
                    command.Parameters.AddWithValue("@maNhanVien", contract.MaNhanVien);
                    command.Parameters.AddWithValue("@tuNgay", contract.TuNgay);
                    command.Parameters.AddWithValue("@denNgay", (object)contract.DenNgay ?? DBNull.Value);
                    command.Parameters.AddWithValue("@loaiHopDong", contract.LoaiHopDong);
                    command.Parameters.AddWithValue("@phongBan", contract.PhongBan);
                    command.Parameters.AddWithValue("@luongCoBan", contract.LuongCoBan);
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
                string query = "UPDATE hopdonglaodong SET maNhanVien = @maNhanVien, tuNgay = @tuNgay, denNgay = @denNgay, loaiHopDong = @loaiHopDong, phongBan = @phongBan, luongCoBan = @luongCoBan, maBangChamCong = @maBangChamCong WHERE maHopDong = @maHopDong";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maHopDong", contract.MaHopDong);
                    command.Parameters.AddWithValue("@maNhanVien", contract.MaNhanVien);
                    command.Parameters.AddWithValue("@tuNgay", contract.TuNgay);
                    command.Parameters.AddWithValue("@denNgay", (object)contract.DenNgay ?? DBNull.Value);
                    command.Parameters.AddWithValue("@loaiHopDong", contract.LoaiHopDong);
                    command.Parameters.AddWithValue("@phongBan", contract.PhongBan);
                    command.Parameters.AddWithValue("@luongCoBan", contract.LuongCoBan);
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
                string query = "DELETE FROM hopdonglaodong WHERE maHopDong =