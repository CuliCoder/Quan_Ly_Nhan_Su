using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class PermissionGroupDAO
    {
        private MySqlConnection conn = null;
        // get All
        public List<PermissionGroupDTO> GetAll()
        {
            var list = new List<PermissionGroupDTO>();
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT MaNQ, TenNQ, MoTa FROM nhomquyen WHERE TinhTrang = 1", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PermissionGroupDTO
                            {
                                MaNhomQuyen = Convert.ToInt32(reader["MaNQ"]),
                                TenNhomQuyen = reader["TenNQ"].ToString(),
                                MoTa = reader["MoTa"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return null;
            }
            return list;
        }
        // get by ID
        public PermissionGroupDTO GetbyID(int ID)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return null;
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT MaNQ, TenNQ, MoTa FROM nhomquyen WHERE MaNQ = @MaNQ AND TinhTrang = 1", conn);
                    cmd.Parameters.AddWithValue("@MaNQ", ID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PermissionGroupDTO
                            {
                                MaNhomQuyen = Convert.ToInt32(reader["MaNQ"]),
                                TenNhomQuyen = reader["TenNQ"].ToString(),
                                MoTa = reader["MoTa"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return null;
            }
        }
        // thêm
        public bool Insert(PermissionGroupDTO group)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "INSERT INTO nhomquyen (TenNQ, MoTa, TinhTrang) VALUES (@TenNQ, @MoTa, 1)", conn);
                    cmd.Parameters.AddWithValue("@TenNQ", group.TenNhomQuyen);
                    cmd.Parameters.AddWithValue("@MoTa", (object)group.MoTa ?? DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }
        // update
        public bool Update(PermissionGroupDTO group)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "UPDATE nhomquyen SET TenNQ = @TenNQ, MoTa = @MoTa WHERE MaNQ = @MaNQ", conn);
                    cmd.Parameters.AddWithValue("@MaNQ", group.MaNhomQuyen);
                    cmd.Parameters.AddWithValue("@TenNQ", group.TenNhomQuyen);
                    cmd.Parameters.AddWithValue("@MoTa", (object)group.MoTa ?? DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }
        // xóa
        public bool Delete(int maNhomQuyen)
        {
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    var cmd = new MySqlCommand("UPDATE nhomquyen SET TinhTrang = 0 WHERE MaNQ = @MaNQ", conn);
                    cmd.Parameters.AddWithValue("@MaNQ", maNhomQuyen);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
        }
    }
}