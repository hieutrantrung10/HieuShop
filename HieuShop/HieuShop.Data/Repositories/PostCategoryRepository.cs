using HieuShop.Data.Infrastructure;
using HieuShop.Models.Models;

namespace HieuShop.Data.Repositories
{
    public interface IPostCategoryRepository
    {
    }

    public class PostCategoryRepository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}