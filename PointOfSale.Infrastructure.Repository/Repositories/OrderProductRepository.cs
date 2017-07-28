using PointOfSale.Domain.Entities;
using PointOfSale.Infrastructure.Repository.Interfaces;

namespace PointOfSale.Infrastructure.Repository.Repositories
{
    public class OrderProductRepository : BaseRepository<OrderProduct>, IOrderProductRepository
    {
    }
}
