using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BAI_1_4_EFCORE_CODEFIRT.DomainClass
{
    [Table("PhimAnh")]//Đặt tên bảng
    public class PhimAnh
    {
        [Key]//Chỉ ra khóa chính
        public Guid Id { get; set; }

        [StringLength(100)]
        public string TenPhim { get; set; }

        public string MaPhim { get; set; }
        public string TheLoaiPhim { get; set; }
        public int TrangThai { get; set; }

        [ForeignKey("IdTheLoaiPhim")]
        public TheLoaiPhim TheLoaiPhims { get; set; }
    }
}