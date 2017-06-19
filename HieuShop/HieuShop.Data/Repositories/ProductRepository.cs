using HieuShop.Data.Infrastructure;
using HieuShop.Models.Models;

namespace HieuShop.Data.Repositories
{
    public interface IProductRepository
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}