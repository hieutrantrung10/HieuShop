using HieuShop.Data.Infrastructure;
using HieuShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.Data.Repositories
{
    public interface IErrorLogRepository : IRepository<ErrorLog>
    {

    }
    public class ErrorLogRepository : RepositoryBase<ErrorLog>
    {
        public ErrorLogRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}
