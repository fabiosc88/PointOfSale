using PointOfSale.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PointOfSale.Infrastructure.Repository.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IEnumerable<Product> GetMany(List<Guid> items);
    }
}
