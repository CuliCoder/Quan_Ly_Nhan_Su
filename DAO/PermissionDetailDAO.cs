using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// DAO cho chi tiết phân quyền - Phiên bản cải tiến
    /// Tương thích với cả tên bảng/cột cũ và mới
    /// </summary>
    public class PermissionDetailDAO
    {
        /// <summary>
        /// Lấy danh sách quyền theo mã nhóm quyền
        /// Alias cho GetByPermissionGroup để tương thích code cũ
        /// </summary>
        public List<PermissionDetailDTO> GetByGroupId(int permissionGroupId)
        {
            return GetByPermissionGroup(permissionGroupId);
        }

        /// <summary>
        /// Lấy danh sách quyền theo mã nhóm quyền
        /// </summary>
        public List<PermissionDetailDTO> GetByPermissionGroup(int permissionGroupId)
        {
            var list = new List<PermissionDetailDTO>();
            
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    
                    // Query tương thích với cả 2 tên cột: MaQuyen/MaNhomQuyen và MaCN/MaChucNang
                    string query = @"SELECT * FROM chitietquyen 
                                   WHERE MaQuyen = @MaQuyen";
                    
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaQuyen", permissionGroupId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PermissionDetailDTO
                            {
                                PermissionGroupID = GetColumnValue<int>(reader, "MaQuyen", "MaNhomQuyen"),
                                FunctionID = GetColumnValue<int>(reader, "MaCN", "MaChucNang"),
                                CanRead = GetColumnValue<bool>(reader, "CanRead", "CoTheXem"),
                                CanCreate = GetColumnValue<bool>(reader, "CanCreate", "CoTheThem"),
                                CanUpdate = GetColumnValue<bool>(reader, "CanUpdate", "CoTheSua"),
                                CanDelete = GetColumnValue<bool>(reader, "CanDelete", "CoTheXoa")
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in GetByPermissionGroup: {ex.Message}");
                }
            }
            
            return list;
        }

        /// <summary>
        /// Lấy tất cả quyền chi tiết
        /// </summary>
        public List<PermissionDetailDTO> GetAll()
        {
            var list = new List<PermissionDetailDTO>();
            
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM chitietquyen";
                    
                    var cmd = new MySqlCommand(query, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PermissionDetailDTO
                            {
                                PermissionGroupID = GetColumnValue<int>(reader, "MaQuyen", "MaNhomQuyen"),
                                FunctionID = GetColumnValue<int>(reader, "MaCN", "MaChucNang"),
                                CanRead = GetColumnValue<bool>(reader, "CanRead", "CoTheXem"),
                                CanCreate = GetColumnValue<bool>(reader, "CanCreate", "CoTheThem"),
                                CanUpdate = GetColumnValue<bool>(reader, "CanUpdate", "CoTheSua"),
                                CanDelete = GetColumnValue<bool>(reader, "CanDelete", "CoTheXoa")
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in GetAll: {ex.Message}");
                }
            }
            
            return list;
        }

        /// <summary>
        /// Lưu danh sách quyền cho một nhóm quyền (Transaction-safe)
        /// </summary>
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
                        var deleteCmd = new MySqlCommand(
                            @"DELETE FROM chitietquyen 
                              WHERE MaQuyen = @MaQuyen", 
                            conn, transaction);
                        deleteCmd.Parameters.AddWithValue("@MaQuyen", permissionGroupId);
                        deleteCmd.ExecuteNonQuery();

                        // 2. Thêm lại các quyền mới được chọn
                        foreach (var p in permissions)
                        {
                            // Chỉ lưu những dòng có ít nhất một quyền được cấp
                            if (p.CanRead || p.CanCreate || p.CanUpdate || p.CanDelete)
                            {
                                // Tự động detect tên cột từ schema
                                string insertQuery = GetInsertQuery(conn);
                                
                                var insertCmd = new MySqlCommand(insertQuery, conn, transaction);
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
                        Console.WriteLine($"Transaction Error saving permissions: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Insert một quyền chi tiết
        /// </summary>
        public bool Insert(PermissionDetailDTO dto)
        {
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string insertQuery = GetInsertQuery(conn);
                    
                    var cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@MaQuyen", dto.PermissionGroupID);
                    cmd.Parameters.AddWithValue("@MaCN", dto.FunctionID);
                    cmd.Parameters.AddWithValue("@CanRead", dto.CanRead);
                    cmd.Parameters.AddWithValue("@CanCreate", dto.CanCreate);
                    cmd.Parameters.AddWithValue("@CanUpdate", dto.CanUpdate);
                    cmd.Parameters.AddWithValue("@CanDelete", dto.CanDelete);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in Insert: {ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// Update một quyền chi tiết
        /// </summary>
        public bool Update(PermissionDetailDTO dto)
        {
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string updateQuery = GetUpdateQuery(conn);
                    
                    var cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@MaQuyen", dto.PermissionGroupID);
                    cmd.Parameters.AddWithValue("@MaCN", dto.FunctionID);
                    cmd.Parameters.AddWithValue("@CanRead", dto.CanRead);
                    cmd.Parameters.AddWithValue("@CanCreate", dto.CanCreate);
                    cmd.Parameters.AddWithValue("@CanUpdate", dto.CanUpdate);
                    cmd.Parameters.AddWithValue("@CanDelete", dto.CanDelete);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in Update: {ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// Xóa một quyền chi tiết
        /// </summary>
        public bool Delete(int permissionGroupId, int functionId)
        {
            using (var conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"DELETE FROM chitietquyen 
                                   WHERE (MaQuyen = @MaQuyen OR MaNhomQuyen = @MaQuyen)
                                     AND (MaCN = @MaCN OR MaChucNang = @MaCN)";
                    
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaQuyen", permissionGroupId);
                    cmd.Parameters.AddWithValue("@MaCN", functionId);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in Delete: {ex.Message}");
                    return false;
                }
            }
        }

        // ================ HELPER METHODS ================

        /// <summary>
        /// Lấy giá trị cột với nhiều tên có thể (tương thích code cũ/mới)
        /// </summary>
        private T GetColumnValue<T>(MySqlDataReader reader, params string[] columnNames)
        {
            foreach (var columnName in columnNames)
            {
                try
                {
                    int ordinal = reader.GetOrdinal(columnName);
                    if (!reader.IsDBNull(ordinal))
                    {
                        object value = reader.GetValue(ordinal);
                        return (T)Convert.ChangeType(value, typeof(T));
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // Column không tồn tại, thử column tiếp theo
                    continue;
                }
            }
            
            return default(T);
        }

        /// <summary>
        /// Tự động detect schema và tạo INSERT query phù hợp
        /// </summary>
        private string GetInsertQuery(MySqlConnection conn)
        {
            // Kiểm tra tên cột trong database
            bool usesOldNames = TableHasColumn(conn, "chitietquyen", "MaQuyen");
            
            if (usesOldNames)
            {
                return @"INSERT INTO chitietquyen 
                        (MaQuyen, MaCN, CanRead, CanCreate, CanUpdate, CanDelete) 
                        VALUES (@MaQuyen, @MaCN, @CanRead, @CanCreate, @CanUpdate, @CanDelete)";
            }
            else
            {
                return @"INSERT INTO chitietquyen 
                        (MaNhomQuyen, MaChucNang, CoTheXem, CoTheThem, CoTheSua, CoTheXoa) 
                        VALUES (@MaQuyen, @MaCN, @CanRead, @CanCreate, @CanUpdate, @CanDelete)";
            }
        }

        /// <summary>
        /// Tự động detect schema và tạo UPDATE query phù hợp
        /// </summary>
        private string GetUpdateQuery(MySqlConnection conn)
        {
            bool usesOldNames = TableHasColumn(conn, "chitietquyen", "MaQuyen");
            
            if (usesOldNames)
            {
                return @"UPDATE chitietquyen 
                        SET CanRead = @CanRead, 
                            CanCreate = @CanCreate, 
                            CanUpdate = @CanUpdate, 
                            CanDelete = @CanDelete
                        WHERE MaQuyen = @MaQuyen AND MaCN = @MaCN";
            }
            else
            {
                return @"UPDATE chitietquyen 
                        SET CoTheXem = @CanRead, 
                            CoTheThem = @CanCreate, 
                            CoTheSua = @CanUpdate, 
                            CoTheXoa = @CanDelete
                        WHERE MaNhomQuyen = @MaQuyen AND MaChucNang = @MaCN";
            }
        }

        /// <summary>
        /// Kiểm tra xem bảng có cột chỉ định không
        /// </summary>
        private bool TableHasColumn(MySqlConnection conn, string tableName, string columnName)
        {
            try
            {
                string query = @"SELECT COUNT(*) 
                               FROM INFORMATION_SCHEMA.COLUMNS 
                               WHERE TABLE_SCHEMA = DATABASE() 
                                 AND TABLE_NAME = @TableName 
                                 AND COLUMN_NAME = @ColumnName";
                
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TableName", tableName);
                cmd.Parameters.AddWithValue("@ColumnName", columnName);
                
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}