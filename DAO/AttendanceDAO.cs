using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class AttendanceDAO
    {
        public AttendanceDAO() { }
        private AttendanceDTO MapReaderToAttendance(MySqlDataReader reader)

        {
            string machamcong = reader.GetString("maBangChamCong");
            string maNV = reader.GetString("maNV");
            DateTime ngayChamCong = reader.GetDateTime("ngayChamCong");
            DateTime? checkIn = reader.GetDateTime("checkIn");
            DateTime? checkOut = reader.IsDBNull(reader.GetOrdinal("checkOut")) ? (DateTime?)null : reader.GetDateTime("checkOut");
            int go_late = reader.IsDBNull(reader.GetOrdinal("go_late")) ? 0 : reader.GetInt32("go_late");
            int leave_early = reader.IsDBNull(reader.GetOrdinal("leave_early")) ? 0 : reader.GetInt32("leave_early");
            float sogiolamviec = reader.IsDBNull(reader.GetOrdinal("sogiolamviec")) ? 0 : reader.GetFloat("sogiolamviec");
            return new AttendanceDTO(machamcong, maNV, ngayChamCong, checkIn, checkOut, go_late, leave_early, sogiolamviec);
        }
        public List<AttendanceDTO> get_attendance_by_ID_NhanVien(string maNhanVien)
        {
            List<AttendanceDTO> attendance_ = new List<AttendanceDTO>();
            using (MySqlConnection conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string query = "select * from bangchamcong where maNV = @maNV ORDER BY maBangChamCong DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNV", maNhanVien);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                attendance_.Add(MapReaderToAttendance(reader));
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting all accounts: {ex.Message}");
                }
            }
            return attendance_;
        }
        public bool addAttendance(AttendanceDTO attendance)
        {
            using (MySqlConnection conn = connectDB.getConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string insertSQL = "insert into bangchamcong (maBangChamCong, maNV, ngayChamCong, checkIn, checkOut, go_late, leave_early, sogiolamviec) VALUES (@maBangChamCong, @maNV, @ngayChamCong, @checkIn, @checkOut, @go_late, @leave_early, @sogiolamviec)";
                        using (MySqlCommand cmd = new MySqlCommand(insertSQL, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@maBangChamCong", attendance.IdChamCong);
                            cmd.Parameters.AddWithValue("@maNV", attendance.MaNhanVien ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@ngayChamCong", attendance.NgayChamCong);

                            cmd.Parameters.AddWithValue("@checkIn", attendance.CheckInTime.HasValue ? (object)attendance.CheckInTime.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@checkOut", attendance.CheckOutTime.HasValue ? (object)attendance.CheckOutTime.Value : DBNull.Value);

                            cmd.Parameters.AddWithValue("@go_late", attendance.Go_late);
                            cmd.Parameters.AddWithValue("@leave_early", attendance.Leave_early);
                            cmd.Parameters.AddWithValue("@sogiolamviec", attendance.Sogiolamviec);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (MySqlException ex)
                    {
                        try { transaction.Rollback(); } catch { }
                        Console.WriteLine($"Error inserting attendance: {ex.Message}");
                        MessageBox.Show("Lỗi khi thêm bản ghi chấm công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
        public bool updateAttendance(AttendanceDTO attendance)
        {
            if (attendance == null) return false;

            using (MySqlConnection conn = connectDB.getConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string updateSQL = "UPDATE bangchamcong SET maNV = @maNV, ngayChamCong = @ngayChamCong, checkIn = @checkIn, checkOut = @checkOut, go_late = @go_late, leave_early = @leave_early, sogiolamviec = @sogiolamviec WHERE maBangChamCong = @id";
                        using (MySqlCommand cmd = new MySqlCommand(updateSQL, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@maNV", attendance.MaNhanVien ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@ngayChamCong", attendance.NgayChamCong);

                            cmd.Parameters.AddWithValue("@checkIn", attendance.CheckInTime.HasValue ? (object)attendance.CheckInTime.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@checkOut", attendance.CheckOutTime.HasValue ? (object)attendance.CheckOutTime.Value : DBNull.Value);

                            cmd.Parameters.AddWithValue("@go_late", attendance.Go_late);
                            cmd.Parameters.AddWithValue("@leave_early", attendance.Leave_early);
                            cmd.Parameters.AddWithValue("@sogiolamviec", attendance.Sogiolamviec);

                            cmd.Parameters.AddWithValue("@id", attendance.IdChamCong);

                            int affected = cmd.ExecuteNonQuery();
                            transaction.Commit();
                            return affected > 0;
                        }
                    }
                    catch (MySqlException ex)
                    {
                        try { transaction.Rollback(); } catch { }
                        Console.WriteLine($"Error updating attendance: {ex.Message}");
                        return false;
                    }
                }
            }
        }
        public bool updateStatusAttendance(string attendanceId, string status)
        {
            using (MySqlConnection conn = connectDB.getConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string updateSQL = "UPDATE bangchamcong SET status = @status WHERE maBangChamCong = @id";
                        using (MySqlCommand cmd = new MySqlCommand(updateSQL, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@status", status);
                            cmd.Parameters.AddWithValue("@id", attendanceId);

                            int affected = cmd.ExecuteNonQuery();
                            transaction.Commit();
                            return affected > 0;
                        }
                    }
                    catch (MySqlException ex)
                    {
                        try { transaction.Rollback(); } catch { }
                        Console.WriteLine($"Error updating attendance: {ex.Message}");
                        return false;
                    }
                }
            }
        }
        public AttendanceDTO get_attendance_by_id(string maBangChamCong)
        {
            if (string.IsNullOrEmpty(maBangChamCong)) return null;

            using (MySqlConnection conn = connectDB.getConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM bangchamcong WHERE maBangChamCong = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", maBangChamCong);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapReaderToAttendance(reader);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting attendance by id: {ex.Message}");
                }
            }

            return null;
        }
    }
}