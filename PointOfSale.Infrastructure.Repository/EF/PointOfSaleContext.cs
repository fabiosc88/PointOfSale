using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Infrastructure.Repository.EF
{
    public class PointOfSaleContext : DbContext
    {
        public PointOfSaleContext()
            : base("PointOfSaleContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
