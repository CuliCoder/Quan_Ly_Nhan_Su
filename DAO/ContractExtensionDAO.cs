//using System;
//using System.Collections.Generic;
//using MySql.Data.MySqlClient;
//using Quan_Ly_Nhan_Su.DTO;
//using Quan_Ly_Nhan_Su.config;

//namespace Quan_Ly_Nhan_Su.DAO
//{
//    /// <summary>
//    /// Data Access Object for LaborContract table
//    /// </summary>
//    public class LaborContractDAO
//    {
//        /// <summary>
//        /// Gets all labor contracts with employee and department details
//        /// </summary>
//        public List<LaborContractDTO> GetAllContracts()
//        {
//            var contracts = new List<LaborContractDTO>();
//            MySqlConnection conn = null;
//            try
//            {
//                conn = connectDB.getConnection();
//                conn.Open();
//                string query = @"
//                    SELECT 
//                        hd.maHopDong, nv.maNhanVien, nv.tenNhanVien, pb.tenPhongBan,
//                        hd.tuNgay, hd.denNgay, hd.loaiHopDong, hd.luongCoBan
//                    FROM hopdonglaodong hd
//                    INNER JOIN nhanvien nv ON hd.maNhanVien = nv.maNhanVien
//                    INNER JOIN phongban pb ON nv.maPhongBan = pb.maPhongBan";
//                using (var command = new MySqlCommand(query, conn))
//                {
//                    using (var reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            contracts.Add(new LaborContractDTO
//                            {
//                                MaHopDong = reader.GetString("maHopDong"),
//                                MaNhanVien = reader.GetString("maNhanVien"),
//                                TenNhanVien = reader.GetString("tenNhanVien"),
//                                PhongBan = reader.GetString("tenPhongBan"),
//                                TuNgay = reader.IsDBNull(reader.GetOrdinal("tuNgay")) ? (DateTime?)null : reader.GetDateTime("tuNgay"),
//                                DenNgay = reader.IsDBNull(reader.GetOrdinal("denNgay")) ? (DateTime?)null : reader.GetDateTime("denNgay"),
//                                LoaiHopDong = reader.GetString("loaiHopDong"),
//                                LuongCoBan = reader.GetDecimal("luongCoBan")
//                            });
//                        }
//                    }
//                }
//            }
//            catch (MySqlException ex)
//            {
//                Console.WriteLine($"Error getting all contracts: {ex.Message}");
//                throw;
//            }
//            finally
//            {
//                connectDB.closeConnection(conn);
//            }
//            return contracts;
//        }

//        /// <summary>
//        /// Searches for labor contracts by keyword (supports partial match)
//        /// </summary>
//        public List<LaborContractDTO> SearchContracts(string searchTerm)
//        {
//            var contracts = new List<LaborContractDTO>();
//            MySqlConnection conn = null;
//            try
//            {
//                conn = connectDB.getConnection();
//                conn.Open();
//                string query = @"
//                    SELECT 
//                        hd.maHopDong, nv.maNhanVien, nv.tenNhanVien, pb.tenPhongBan,
//                        hd.tuNgay, hd.denNgay, hd.loaiHopDong, hd.luongCoBan
//                    FROM hopdonglaodong hd
//                    INNER JOIN nhanvien nv ON hd.maNhanVien = nv.maNhanVien
//                    INNER JOIN phongban pb ON nv.maPhongBan = pb.maPhongBan
//                    WHERE nv.maNhanVien LIKE @searchTerm 
//                       OR nv.tenNhanVien LIKE @searchTerm 
//                       OR pb.tenPhongBan LIKE @searchTerm";
//                using (var command = new MySqlCommand(query, conn))
//                {
//                    command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
//                    using (var reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            contracts.Add(new LaborContractDTO
//                            {
//                                MaHopDong = reader.GetString("maHopDong"),
//                                MaNhanVien = reader.GetString("maNhanVien"),
//                                TenNhanVien = reader.GetString("tenNhanVien"),
//                                PhongBan = reader.GetString("tenPhongBan"),
//                                TuNgay = reader.IsDBNull(reader.GetOrdinal("tuNgay")) ? (DateTime?)null : reader.GetDateTime("tuNgay"),
//                                DenNgay = reader.IsDBNull(reader.GetOrdinal("denNgay")) ? (DateTime?)null : reader.GetDateTime("denNgay"),
//                                LoaiHopDong = reader.GetString("loaiHopDong"),
//                                LuongCoBan = reader.GetDecimal("luongCoBan")
//                            });
//                        }
//                    }
//                }
//            }
//            catch (MySqlException ex)
//            {
//                Console.WriteLine($"Error searching contracts: {ex.Message}");
//                throw;
//            }
//            finally
//            {
//                connectDB.closeConnection(conn);
//            }
//            return contracts;
//        }

//        /// <summary>
//        /// Deletes a labor contract by maHopDong
//        /// </summary>
//        public bool DeleteContract(string maHopDong)
//        {
//            MySqlConnection conn = null;
//            try
//            {
//                conn = connectDB.getConnection();
//                conn.Open();
//                string query = "DELETE FROM hopdonglaodong WHERE maHopDong = @maHopDong";
//                using (var command = new MySqlCommand(query, conn))
//                {
//                    command.Parameters.AddWithValue("@maHopDong", maHopDong);
//                    return command.ExecuteNonQuery() > 0;
//                }
//            }
//            catch (MySqlException ex)
//            {
//                Console.WriteLine($"Error deleting contract: {ex.Message}");
//                throw;
//            }
//            finally
//            {
//                connectDB.closeConnection(conn);
//            }
//        }
//    }
//}