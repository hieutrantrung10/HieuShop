using HieuShop.Data.Infrastructure;
using HieuShop.Models.Models;

namespace HieuShop.Data.Repositories
{
    public interface IPostRepository
    {
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}