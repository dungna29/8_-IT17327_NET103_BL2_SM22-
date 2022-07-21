using System;
using System.Collections.Generic;
using System.Text;
using BAI_1_4_EFCORE_CODEFIRT.DomainClass;
using Microsoft.EntityFrameworkCore;

namespace BAI_1_4_EFCORE_CODEFIRT.Context
{
    public class FpolyDBContext : DbContext//Bắt buộc phải kế thừa lớp DBcontext
    {
        //1. Phải ghi đè lại phương thức OnConfiguring
        /*
         * @"Data Source=DUNGNAPC\SQLEXPRESS;Initial Catalog=PhimAnh_IT17327;Persist Security Info=True;User ID=dungna33;Password=123456"
         */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DUNGNAPC\SQLEXPRESS;Initial Catalog=PhimAnh_IT17327;Persist Security Info=True;User ID=dungna33;Password=123456");
        }

        //2. Khai báo các bảng
        public DbSet<PhimAnh> PhimAnhs { get; set; }

        public DbSet<TheLoaiPhim> TheLoaiPhims { get; set; }
    }
}