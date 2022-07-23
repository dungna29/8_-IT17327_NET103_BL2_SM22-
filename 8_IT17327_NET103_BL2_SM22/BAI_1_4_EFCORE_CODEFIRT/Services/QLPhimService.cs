using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAI_1_4_EFCORE_CODEFIRT.DomainClass;
using BAI_1_4_EFCORE_CODEFIRT.Repositories;

namespace BAI_1_4_EFCORE_CODEFIRT.Services
{
    public class QLPhimService
    {
        private List<PhimAnh> _lstPhimAnhs;
        private PhimAnhRepository _phimAnhRepository;
        private TLPhimAnhRepository _tlPhimAnhRepository;

        public QLPhimService()
        {
            _lstPhimAnhs = new List<PhimAnh>();
            _phimAnhRepository = new PhimAnhRepository();
            _tlPhimAnhRepository = new TLPhimAnhRepository();
        }

        public List<TheLoaiPhim> GetAllTheLoaiPhim()
        {
            return _tlPhimAnhRepository.GetAll().ToList();
        }

        public void GetALLDataFromDB()
        {
            _lstPhimAnhs = _phimAnhRepository.GetAll();
        }

        //Thêm sửa xóa lấy danh sách tìm kiếm gần đúng
        public string Add(PhimAnh pa)
        {
            if (_phimAnhRepository.Insert(pa))
            {
                GetALLDataFromDB();
                return "Thêm thành công";
            }

            return "Không thành công";
        }

        //Code được đến đây
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