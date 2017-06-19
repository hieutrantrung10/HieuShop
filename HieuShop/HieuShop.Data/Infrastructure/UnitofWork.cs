using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.Data.Infrastructure
{
    class UnitofWork : IUnitofWork
    {
        private readonly IDbFactory DbFactory;
        private HieuShopDbContext DbContext;

        public UnitofWork(IDbFactory dbFac)
        {
            DbFactory = dbFac;
        }

        public HieuShopDbContext Context
        {
            get { return DbContext ?? (DbContext = DbFactory.Init()); }
        }
        public void Commit()
        {
            //throw new NotImplementedException();
            Context.SaveChanges();
        }
    }
}
