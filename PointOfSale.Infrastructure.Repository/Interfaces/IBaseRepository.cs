using System;
using System.Collections.Generic;

namespace PointOfSale.Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T obj);
        void Remove(T obj);
        bool Remove(Guid id);
        T Update(T obj, Guid id);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}
