using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_TongQuanWindowForm
{
    internal class Phim
    {
        public Guid Id { get; set; }
        public string TenPhim { get; set; }
        public string TheLoaiPhim { get; set; }
        public int TrangThai { get; set; }

        public List<Phim> GetLstPhim()
        {
            return new List<Phim>()
            {
                new Phim(){Id = Guid.NewGuid(),TenPhim = "ABC",TheLoaiPhim = "18+",TrangThai = 1},
                new Phim(){Id = Guid.NewGuid(),TenPhim = "XYZ",TheLoaiPhim = "16+",TrangThai = 1},
                new Phim(){Id = Guid.NewGuid(),TenPhim = "ABC Phần 2",TheLoaiPhim = "18+",TrangThai = 0},
            };
        }
    }
}
