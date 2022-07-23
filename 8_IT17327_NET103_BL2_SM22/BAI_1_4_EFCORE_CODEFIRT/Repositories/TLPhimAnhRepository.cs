using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAI_1_4_EFCORE_CODEFIRT.Context;
using BAI_1_4_EFCORE_CODEFIRT.DomainClass;

namespace BAI_1_4_EFCORE_CODEFIRT.Repositories
{
    public class TLPhimAnhRepository
    {
        private FpolyDBContext _dbContext;

        public TLPhimAnhRepository()
        {
            _dbContext = new FpolyDBContext();
        }

        public List<TheLoaiPhim> GetAll()
        {
            return _dbContext.TheLoaiPhims.ToList();
        }
    }
}