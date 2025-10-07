using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class PermissionDetailDAO
    {
        public List<PermissionDetailDTO> GetByGroupId(int permissionGroupId)
        {
            var list = new List<PermissionDetailDTO>();
            try
            {
                using (var conn = connectDB.getConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM chitietquyen WHERE MaQuyen = @MaQuyen", conn);
                    cmd.Parameters.AddWithValue("@MaQuyen", permissionGroupId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PermissionDetailDTO
                            {
                                PermissionGroupID = Convert.ToInt32(reader["MaQuyen"]),
                                FunctionID = Convert.ToInt32(reader["MaCN"]),
                                CanRead = Convert.ToBoolean(reader["CanRead"]),
                                CanCreate = Convert.ToBoolean(reader["CanCreate"]),
                                CanUpdate = Convert.ToBoolean(reader["CanUpdate"]),
                                CanDelete = Convert.ToBoolean(reader["CanDelete"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error getting permissions: " + ex.Message);
                return null;
            }
            return list;
        }

        public bool SavePermissions(int permissionGroupId, List<PermissionDetailDTO> permissions)
        {
            using (var conn = connectDB.getConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Xóa tất cả quyền cũ của nhóm quyền này
                        var deleteCmd = new MySqlCommand("DELETE FROM chitietquyen WHERE MaQuyen = @MaQuyen", conn, transaction);
                        deleteCmd.Parameters.AddWithValue("@MaQuyen", permissionGroupId);
                        deleteCmd.ExecuteNonQuery();

                        // 2. Thêm lại các quyền mới được chọn
                        foreach (var p in permissions)
                        {
                            // Chỉ lưu những dòng có ít nhất một quyền được cấp
                            if (p.CanRead || p.CanCreate || p.CanUpdate || p.CanDelete)
                            {
                                var insertCmd = new MySqlCommand(
                                    "INSERT INTO chitietquyen (MaQuyen, MaCN, CanRead, CanCreate, CanUpdate, CanDelete) " +
                                    "VALUES (@MaQuyen, @MaCN, @CanRead, @CanCreate, @CanUpdate, @CanDelete)", conn, transaction);

                                insertCmd.Parameters.AddWithValue("@MaQuyen", p.PermissionGroupID);
                                insertCmd.Parameters.AddWithValue("@MaCN", p.FunctionID);
                                insertCmd.Parameters.AddWithValue("@CanRead", p.CanRead);
                                insertCmd.Parameters.AddWithValue("@CanCreate", p.CanCreate);
                                insertCmd.Parameters.AddWithValue("@CanUpdate", p.CanUpdate);
                                insertCmd.Parameters.AddWithValue("@CanDelete", p.CanDelete);
                                insertCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction Error saving permissions: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}