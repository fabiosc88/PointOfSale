using Microsoft.Practices.ServiceLocation;
using PointOfSale.Infrastructure.Repository.EF;
using PointOfSale.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PointOfSale.Infrastructure.Repository.Repositories
{
    public abstract class BaseRepository<C,T> : 
        IBaseRepository<T> where T : class where C : DbContext, new()
    {

        private C _context = new C();
        public C Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public virtual T Add(T obj)
        {
            var entity = _context.Set<T>().Add(obj);
            _context.SaveChanges();

            return entity;
        }

        public bool Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                Remove(obj);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Update(T obj, Guid id)
        {
            if (obj == null)
            {
                return null;
            }

            T existing = _context.Set<T>().Find(id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(obj);
                _context.Entry(existing).State = EntityState.Modified;
            }

            _context.SaveChanges();

            return existing;
        }
    }
}
