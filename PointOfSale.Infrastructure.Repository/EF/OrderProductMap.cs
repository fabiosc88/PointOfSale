using PointOfSale.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Infrastructure.Repository.EF
{
    internal class OrderProductMap : EntityTypeConfiguration<OrderProduct>
    {
        public OrderProductMap()
        {
            ToTable("OrderProduct");

            HasKey(x => new { x.OrderId, x.ProductId });

            HasRequired(x => x.Order)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.OrderId);

            HasRequired(x => x.Product)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
