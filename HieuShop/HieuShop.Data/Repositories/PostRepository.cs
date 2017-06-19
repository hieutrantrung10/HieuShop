using System;
using System.Collections.Generic;
using HieuShop.Data.Infrastructure;
using HieuShop.Models.Models;
using System.Linq;

namespace HieuShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int page, int pageSize, out int total);
        //IEnumerable<Post> GetAllByCategory(int categoryID, int page, int pageSize, out int total);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int page, int pageSize, out int total)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where pt.TagID == tag && p.Status == true
                        orderby p.CreatedDate descending
                        select p;
            total = query.AsEnumerable().Count();
            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            return query;
        }

        /*public IEnumerable<Post> GetAllByCategory(int categoryID, int page, int pageSize, out int total)
        {
            var query = from p in DbContext.Posts
                        join pc in DbContext.PostCategories
                        on p.PostCategoryID equals pc.ID
                        where pc.ID == categoryID && p.Status == true
                        orderby p.CreatedDate descending
                        select p;
            total = query.AsEnumerable().Count();
            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            return query;
        }*/
    }
}