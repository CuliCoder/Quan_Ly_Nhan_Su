using System;

namespace Quan_Ly_Nhan_Su.DTO
{
    /// <summary>
    /// DTO for RecruitmentBatch_Employee table
    /// </summary>
    public class RecruitmentBatchEmployeeDTO
    {
        public string MaTuyenDung { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayTuyenDung { get; set; }
    }
}