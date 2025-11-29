using Quan_Ly_Nhan_Su.GUI.TuyenDungUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quan_Ly_Nhan_Su.DAO.Models
{
    [Table("hosocanhan")]
    public class PersonalProfileEntity
    {
        [Key]
        [Column("soCmnd")] 
        [StringLength(20)] 
        public string SoCmnd { get; set; }


        [Required]
        [Column("hoTen")]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [Column("gioiTinh")]
        [StringLength(10)]
        public string GioiTinh { get; set; }

        [Required]
        [Column("ngaySinh", TypeName = "date")] 
        public DateTime NgaySinh { get; set; }

        [Required]
        [Column("noiCap")]
        [StringLength(100)]
        public string NoiCap { get; set; }

        [Required]
        [Column("ngayCap", TypeName = "date")]
        public DateTime NgayCap { get; set; }

        
        [Column("diachi", TypeName = "text")]
        public string DiaChi { get; set; }

        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }

        [Column("sdt")]
        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [Column("tinhTrangHonNhan")]
        [StringLength(50)]
        public string TinhTrangHonNhan { get; set; }

        [Column("danToc")]
        [StringLength(50)]
        public string DanToc { get; set; }

        [Column("hocVan")]
        [StringLength(100)]
        public string HocVan { get; set; }

        [Column("chuyenNganh")]
        [StringLength(100)]
        public string ChuyenNganh { get; set; }

        [Column("anh")] 
        [StringLength(255)]
        public string HinhAnh { get; set; }
    }
}
