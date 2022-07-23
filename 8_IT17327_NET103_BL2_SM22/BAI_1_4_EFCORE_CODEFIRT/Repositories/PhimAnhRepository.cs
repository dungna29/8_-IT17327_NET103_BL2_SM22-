using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAI_1_4_EFCORE_CODEFIRT.Context;
using BAI_1_4_EFCORE_CODEFIRT.DomainClass;

namespace BAI_1_4_EFCORE_CODEFIRT.Repositories
{
    //CRUD đối tượng với CSDL
    public class PhimAnhRepository
    {
        private FpolyDBContext _dbContext;

        public PhimAnhRepository()
        {
            _dbContext = new FpolyDBContext();
        }

        public List<PhimAnh> GetAll()
        {
            return _dbContext.PhimAnhs.ToList();
        }

        public bool Insert(PhimAnh obj)
        {
            if (obj == null) return false;
            obj.Id = Guid.NewGuid();
            obj.TheLoaiPhim = _dbContext.TheLoaiPhims.ToList().FirstOrDefault(c => c.Id == obj.TheLoaiPhim.Id);
            _dbContext.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(PhimAnh obj)
        {
            if (obj == null) return false;
            _dbContext.Update(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(PhimAnh obj)
        {
            if (obj == null) return false;
            _dbContext.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}