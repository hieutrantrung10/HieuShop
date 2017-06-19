using HieuShop.Data.Infrastructure;
using HieuShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.Data.Repositories
{
    public interface ISystemConfigRepository : IRepository<SystemConfig>
    {
    }
    public class SystemConfigRepository : RepositoryBase<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
    }
}
}
