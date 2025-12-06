using Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DAO.Models
{
    [Table("dottuyendung")]
    internal class RecruitmentBatchEntity
    {
        [Key]
        [Column("maTuyenDung")]
        [StringLength(20)]
        public string MaTuyenDung { get; set; }

        [Required]
        [Column("chucVu")] 
        [StringLength(100)]
        public string ChucVu { get; set; }

        [Required]
        [Column("soLuongCanTuyen")]
        public int SoLuongCanTuyen { get; set; }

        [Required]
        [Column("hanNopHoSo", TypeName = "date")] 
        public DateTime HanNopHoSo { get; set; }


        [Column("hocVan")]
        [StringLength(100)]
        public string HocVan { get; set; }

        [Column("gioiTinh")]
        [StringLength(10)]
        public string GioiTinh { get; set; }

        [Column("doTuoi")]
        [StringLength(50)]
        public string DoTuoi { get; set; }

        [Column("mucLuongToiThieu")]
        public decimal? MucLuongToiThieu { get; set; }

        [Column("mucLuongToiDa")]
        public decimal? MucLuongToiDa { get; set; }

        [Column("soLuongNopHoSo")]
        public int? SoLuongNopHoSo { get; set; }

        [Column("soLuongDaTuyen")]
        public int? SoLuongDaTuyen { get; set; }

        public RecruitmentBatchEntity()
        {
            SoLuongNopHoSo = 0;
            SoLuongDaTuyen = 0;
        }
    }
}
