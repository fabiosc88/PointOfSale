using System;
using System.Collections.Generic;
using PointOfSale.Domain.Entities;
using PointOfSale.Infrastructure.Repository.EF;
using PointOfSale.Infrastructure.Repository.Interfaces;
using System.Linq;

namespace PointOfSale.Infrastructure.Repository.Repositories
{
    public class ProductRepository : BaseRepository<PointOfSaleContext, Product>, IProductRepository
    {
        public IEnumerable<Product> GetMany(List<Guid> items)
        {
            return Context.Products.Where(p => items.Contains(p.Id)).ToList();
        }
    }
}
