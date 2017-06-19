using HieuShop.Data.Infrastructure;
using HieuShop.Models.Models;

namespace HieuShop.Data.Repositories
{
    public interface IOrderRepository
    {
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}