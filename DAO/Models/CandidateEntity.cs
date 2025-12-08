using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quan_Ly_Nhan_Su.DAO.Models
{
    [Table("ungvien")]
    public class CandidateEntity
    {
        [Key]
        [Column("maUngVien")]
        [StringLength(20)]
        public string MaUngVien { get; set; }

       
        [Required]
        [Column("soCmnd")]
        [StringLength(20)]
        public string SoCmnd { get; set; } 

        [ForeignKey("SoCmnd")]
        public virtual PersonalProfileEntity personalProfile { get; set; }

    
        [Required]
        [Column("maTuyenDung")]
        [StringLength(20)]
        public string MaTuyenDung { get; set; } 


        [ForeignKey("MaTuyenDung")]
        public virtual RecruitmentBatchEntity recruitmentBatch { get; set; }

        [Column("mucLuongDeal")]
        public decimal? MucLuongDeal { get; set; }

        [Column("chucVu")]
        [StringLength(100)]
        public string ChucVu { get; set; }

        [Column("trangThai")]
        [StringLength(50)]
        public string TrangThai { get; set; }
    }
}
