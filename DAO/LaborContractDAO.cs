using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using YourNamespace.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// Data Access Object for LaborContract table with additional display functionality
    /// </summary>
    public class LaborContractDAO
    {
        /// <summary>
        /// Retrieves all labor contracts with additional employee and department information
        /// </summary>
        public List<LaborContractDTO> GetAllContracts()
        {
            List<LaborContractDTO> contracts = new List<LaborContractDTO>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = connectDB.getConnection();
                conn.Open();
                string query = @"
                    SELECT 
                        hd.maHopDong,
                        CONCAT(hs.hoTen, ' (', hd.maNhanVien, ')') AS tenNhanVien,
                        pb.tenPhong AS phongBan,
                        hd.tuNgay,
                        hd.denNgay,
                        hd.loaiHopDong,
                        hd.luongCoBan
                    FROM hopdonglaodong hd
                    LEFT JOIN nhanvien nv ON hd.maNhanVien = nv.maNhanVien
                    LEFT JOIN hosocanhan hs ON nv.soCmnd = hs.soCmnd
                    LEFT JOIN phongban pb ON hd.phongBan = pb.maPhong
                    ORDER BY hd.tuNgay DESC";

                using (var command = new MySqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    int stt = 1;
                    while (reader.Read())
                    {
                        LaborContractDTO contract = new LaborContractDTO
                        {
                            STT = stt++,
                            MaHopDong = reader["maHopDong"].ToString(),
                            TenNhanVien = reader["tenNhanVien"].ToString(),
                            PhongBan = reader["phongBan"].ToString(),
                            TuNgay = reader["tuNgay"] != DBNull.Value ? Convert.ToDateTime(reader["tuNgay"]) : (DateTime?)null,
                            DenNgay = reader["denNgay"] != DBNull.Value ? Convert.ToDateTime(reader["denNgay"]) : (DateTime?)null,
                            LoaiHopDong = reader["loaiHopDong"].ToString(),
                            LuongCoBan = reader["luongCoBan"] != DBNull.Value ? Convert.ToDecimal(reader["luongCoBan"]) : 0m
                        };
                        contracts.Add(contract);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error retrieving labor contracts: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                connectDB.closeConnection(conn);
            }

            return contracts;
        }

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
                string query = "DELETE FROM hopdonglaodong WHERE maHopDong = @maHopDong";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maHopDong", maHopDong);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting labor contract: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }
    }
}