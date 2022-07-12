using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_TongQuanWindowForm
{
    internal class QLPhimService
    {
        private List<PhimAnh> _lstPhimAnhs;

        public QLPhimService()
        {
            _lstPhimAnhs = new List<PhimAnh>();
        }

        public void FakeData()//Đổ data vào List Phim
        {
            _lstPhimAnhs = new List<PhimAnh>()
            {
                new PhimAnh(){Id =Guid.NewGuid(),MaPhim = "ABC",TenPhim = "Hoa cỏ may",TheLoaiPhim = "18+",TrangThai = 1},
                new PhimAnh(){Id =Guid.NewGuid(),MaPhim = "Z21",TenPhim = "Học lại C#3 phần 1",TheLoaiPhim = "21+",TrangThai = 1},
                new PhimAnh(){Id =Guid.NewGuid(),MaPhim = "ABC",TenPhim = "Hoa cỏ may phần 2",TheLoaiPhim = "18+",TrangThai = 0},
            };
        }

        public List<string> GetAllTheLoai()//Data đổ vào combobox thể loại
        {
            return new List<string>() { "18+", "21+", "61+", "Kinh dị" };
        }

        //Thêm sửa xóa lấy danh sách tìm kiếm gần đúng
        public string Add(PhimAnh pa)
        {
            pa.Id = Guid.NewGuid();//Khi thêm mới zen mã khóa chính
            _lstPhimAnhs.Add(pa);
            return "Thêm thành công";
        }

        public string Update(PhimAnh pa)
        {
            int index = _lstPhimAnhs.FindIndex(c => c.Id == pa.Id);
            if (index == -1)
            {
                return "Sửa không thành công";
            }
            _lstPhimAnhs[index] = pa;
            return "Sửa thành công";
        }

        public string Delete(PhimAnh pa)
        {
            int index = _lstPhimAnhs.FindIndex(c => c.Id == pa.Id);
            if (index == -1)
            {
                return "Xóa không thành công";
            }
            _lstPhimAnhs.RemoveAt(index);
            return "Xóa thành công";
        }

        public List<PhimAnh> GetALL()
        {
            return _lstPhimAnhs;
        }

        public List<PhimAnh> GetALL(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return GetALL();
            }
            return _lstPhimAnhs.Where(c => c.MaPhim.ToLower().StartsWith(input.ToLower()) || c.TenPhim.ToLower().StartsWith(input.ToLower())).ToList();
        }
    }
}