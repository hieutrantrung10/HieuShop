using HieuShop.Data.Infrastructure;
using HieuShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.Data.Repositories
{
    public interface ISlideTagRepository
    {
    }

    public class SlideRepository : RepositoryBase<Slide>, ISlideTagRepository
    {
        public SlideRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
