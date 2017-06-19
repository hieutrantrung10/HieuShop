using HieuShop.Data.Infrastructure;
using HieuShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.Data.Repositories
{
    public interface ISystemConfigRepository
    {
    }
    public class SystemConfigRepository : RepositoryBase<SystemConfig>, ISupportOnlineRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
    }
}
}
