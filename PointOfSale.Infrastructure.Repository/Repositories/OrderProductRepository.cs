using PointOfSale.Domain.Entities;
using PointOfSale.Infrastructure.Repository.EF;
using PointOfSale.Infrastructure.Repository.Interfaces;

namespace PointOfSale.Infrastructure.Repository.Repositories
{
    public class OrderProductRepository : BaseRepository<PointOfSaleContext, OrderProduct>, IOrderProductRepository
    {
    }
}
