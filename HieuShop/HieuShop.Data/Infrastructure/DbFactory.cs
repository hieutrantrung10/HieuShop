using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private HieuShopDbContext DbContext;
        public HieuShopDbContext Init()
        {
            //throw new NotImplementedException();
            return DbContext ?? (DbContext = new HieuShopDbContext());
        }

        protected override void DisposeCore()
        {
            if(DbContext != null)
            {
                DbContext.Dispose();
            }
        }
    }
}
