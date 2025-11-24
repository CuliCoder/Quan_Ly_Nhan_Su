using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.DTO;
using Quan_Ly_Nhan_Su.config;

namespace Quan_Ly_Nhan_Su.DAO
{
    /// <summary>
    /// DAO cho bảng chucnang - Tương thích với hệ thống cũ và mới
    /// </summary>
    public class FunctionDAO
    {
        /// <summary>
        /// Lấy chức năng theo ID
        /// </summary>
        public FunctionDTO GetById(int maChucNang)
        {
            FunctionDTO func = null;
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                // Tương thích cả MaChucNang và maChucNang
                string query = @"SELECT * FROM chucnang 
                               WHERE maChucNang = @maChucNang 
                                  OR MaChucNang = @maChucNang";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maChucNang", maChucNang);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            func = new FunctionDTO
                            {
                                MaChucNang = GetColumnValue<int>(reader, "maChucNang", "MaChucNang"),
                                TenChucNang = GetColumnValue<string>(reader, "tenChucNang", "TenChucNang"),
                                MoTa = GetColumnValueNullable<string>(reader, "moTa", "MoTa"),
                                TinhTrang = GetColumnValue<bool>(reader, "tinhTrang", "TinhTrang")
                            };
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting function by ID: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return func;
        }

        /// <summary>
        /// Lấy chức năng theo tên (MỚI - hỗ trợ PermissionManager)
        /// </summary>
        public FunctionDTO GetByName(string tenChucNang)
        {
            FunctionDTO func = null;
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                string query = @"SELECT * FROM chucnang 
                               WHERE tenChucNang = @tenChucNang 
                                  OR TenChucNang = @tenChucNang";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@tenChucNang", tenChucNang);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            func = new FunctionDTO
                            {
                                MaChucNang = GetColumnValue<int>(reader, "maChucNang", "MaChucNang"),
                                TenChucNang = GetColumnValue<string>(reader, "tenChucNang", "TenChucNang"),
                                MoTa = GetColumnValueNullable<string>(reader, "moTa", "MoTa"),
                                TinhTrang = GetColumnValue<bool>(reader, "tinhTrang", "TinhTrang")
                            };
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting function by name: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return func;
        }

        /// <summary>
        /// Lấy tất cả chức năng
        /// </summary>
        public List<FunctionDTO> GetAll()
        {
            var list = new List<FunctionDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                string query = "SELECT * FROM chucnang ORDER BY tenChucNang, TenChucNang";

                using (var command = new MySqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var func = new FunctionDTO
                            {
                                MaChucNang = GetColumnValue<int>(reader, "maChucNang", "MaChucNang"),
                                TenChucNang = GetColumnValue<string>(reader, "tenChucNang", "TenChucNang"),
                                MoTa = GetColumnValueNullable<string>(reader, "moTa", "MoTa"),
                                TinhTrang = GetColumnValue<bool>(reader, "tinhTrang", "TinhTrang")
                            };
                            list.Add(func);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting functions: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return list;
        }

        /// <summary>
        /// Lấy các chức năng đang hoạt động (MỚI)
        /// </summary>
        public List<FunctionDTO> GetActive()
        {
            var list = new List<FunctionDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                string query = @"SELECT * FROM chucnang 
                               WHERE tinhTrang = 1 OR TinhTrang = 1
                               ORDER BY tenChucNang, TenChucNang";

                using (var command = new MySqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var func = new FunctionDTO
                            {
                                MaChucNang = GetColumnValue<int>(reader, "maChucNang", "MaChucNang"),
                                TenChucNang = GetColumnValue<string>(reader, "tenChucNang", "TenChucNang"),
                                MoTa = GetColumnValueNullable<string>(reader, "moTa", "MoTa"),
                                TinhTrang = GetColumnValue<bool>(reader, "tinhTrang", "TinhTrang")
                            };
                            list.Add(func);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting active functions: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return list;
        }

        /// <summary>
        /// Thêm chức năng mới
        /// </summary>
        public bool Create(FunctionDTO function)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                // Auto-detect tên cột từ schema
                string insertQuery = GetInsertQuery(conn);

                using (var command = new MySqlCommand(insertQuery, conn))
                {
                    command.Parameters.AddWithValue("@tenChucNang", function.TenChucNang);
                    command.Parameters.AddWithValue("@moTa",
                        string.IsNullOrEmpty(function.MoTa) ? (object)DBNull.Value : function.MoTa);
                    command.Parameters.AddWithValue("@tinhTrang", function.TinhTrang);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error creating function: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Cập nhật chức năng
        /// </summary>
        public bool Update(FunctionDTO function)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                // Auto-detect tên cột từ schema
                string updateQuery = GetUpdateQuery(conn);

                using (var command = new MySqlCommand(updateQuery, conn))
                {
                    command.Parameters.AddWithValue("@maChucNang", function.MaChucNang);
                    command.Parameters.AddWithValue("@tenChucNang", function.TenChucNang);
                    command.Parameters.AddWithValue("@moTa",
                        string.IsNullOrEmpty(function.MoTa) ? (object)DBNull.Value : function.MoTa);
                    command.Parameters.AddWithValue("@tinhTrang", function.TinhTrang);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating function: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Xóa chức năng (soft delete)
        /// </summary>
        public bool Delete(int maChucNang)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                // Soft delete - set TinhTrang = 0
                string query = @"UPDATE chucnang 
                               SET tinhTrang = 0, TinhTrang = 0
                               WHERE maChucNang = @maChucNang 
                                  OR MaChucNang = @maChucNang";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maChucNang", maChucNang);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error deleting function: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Xóa vĩnh viễn (MỚI - cẩn thận khi dùng!)
        /// </summary>
        public bool HardDelete(int maChucNang)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                string query = @"DELETE FROM chucnang 
                               WHERE maChucNang = @maChucNang 
                                  OR MaChucNang = @maChucNang";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maChucNang", maChucNang);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error hard deleting function: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        /// <summary>
        /// Tìm kiếm chức năng theo tên
        /// </summary>
        public List<FunctionDTO> Search(string searchTerm)
        {
            var functions = new List<FunctionDTO>();
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                string query = @"SELECT * FROM chucnang 
                               WHERE tenChucNang LIKE @searchTermLike 
                                  OR TenChucNang LIKE @searchTermLike
                                  OR moTa LIKE @searchTermLike 
                                  OR MoTa LIKE @searchTermLike";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@searchTermLike", $"%{searchTerm}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            functions.Add(new FunctionDTO
                            {
                                MaChucNang = GetColumnValue<int>(reader, "maChucNang", "MaChucNang"),
                                TenChucNang = GetColumnValue<string>(reader, "tenChucNang", "TenChucNang"),
                                MoTa = GetColumnValueNullable<string>(reader, "moTa", "MoTa"),
                                TinhTrang = GetColumnValue<bool>(reader, "tinhTrang", "TinhTrang")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error searching functions: {ex.Message}");
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
            return functions;
        }

        /// <summary>
        /// Kiểm tra tên chức năng đã tồn tại chưa (MỚI)
        /// </summary>
        public bool ExistsByName(string tenChucNang, int? excludeId = null)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connectDB.getConnection();
                conn.Open();

                string query = @"SELECT COUNT(*) FROM chucnang 
                               WHERE (tenChucNang = @tenChucNang OR TenChucNang = @tenChucNang)";

                if (excludeId.HasValue)
                {
                    query += " AND maChucNang != @excludeId AND MaChucNang != @excludeId";
                }

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@tenChucNang", tenChucNang);
                    if (excludeId.HasValue)
                    {
                        command.Parameters.AddWithValue("@excludeId", excludeId.Value);
                    }

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error checking function existence: {ex.Message}");
                return false;
            }
            finally
            {
                connectDB.closeConnection(conn);
            }
        }

        // ================ HELPER METHODS ================

        /// <summary>
        /// Lấy giá trị cột với nhiều tên có thể (tự động detect)
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
                        if (typeof(T) == typeof(bool) && value is sbyte)
                        {
                            return (T)(object)(Convert.ToInt32(value) != 0);
                        }
                        return (T)Convert.ChangeType(value, typeof(T));
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Lấy giá trị cột nullable
        /// </summary>
        private T GetColumnValueNullable<T>(MySqlDataReader reader, params string[] columnNames) where T : class
        {
            foreach (var columnName in columnNames)
            {
                try
                {
                    int ordinal = reader.GetOrdinal(columnName);
                    if (!reader.IsDBNull(ordinal))
                    {
                        return reader.GetValue(ordinal) as T;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
            return null;
        }

        /// <summary>
        /// Tự động tạo INSERT query dựa trên schema
        /// </summary>
        private string GetInsertQuery(MySqlConnection conn)
        {
            bool usesLowerCase = TableHasColumn(conn, "chucnang", "tenChucNang");

            if (usesLowerCase)
            {
                return @"INSERT INTO chucnang (tenChucNang, moTa, tinhTrang) 
                        VALUES (@tenChucNang, @moTa, @tinhTrang)";
            }
            else
            {
                return @"INSERT INTO chucnang (TenChucNang, MoTa, TinhTrang) 
                        VALUES (@tenChucNang, @moTa, @tinhTrang)";
            }
        }

        /// <summary>
        /// Tự động tạo UPDATE query dựa trên schema
        /// </summary>
        private string GetUpdateQuery(MySqlConnection conn)
        {
            bool usesLowerCase = TableHasColumn(conn, "chucnang", "tenChucNang");

            if (usesLowerCase)
            {
                return @"UPDATE chucnang 
                        SET tenChucNang = @tenChucNang, 
                            moTa = @moTa, 
                            tinhTrang = @tinhTrang 
                        WHERE maChucNang = @maChucNang";
            }
            else
            {
                return @"UPDATE chucnang 
                        SET TenChucNang = @tenChucNang, 
                            MoTa = @moTa, 
                            TinhTrang = @tinhTrang 
                        WHERE MaChucNang = @maChucNang";
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
                                 AND TABLE_NAME = @tableName 
                                 AND COLUMN_NAME = @columnName";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    cmd.Parameters.AddWithValue("@columnName", columnName);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}