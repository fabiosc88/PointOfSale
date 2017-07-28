using PointOfSale.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PointOfSale.Infrastructure.Repository.EF
{
    internal class OrderProductMap : EntityTypeConfiguration<OrderProduct>
    {
        public OrderProductMap()
        {
            ToTable("OrderProduct");

            Property(x => x.Price)
                .HasColumnName("Price")
                .IsRequired()
                .HasColumnType("Money");

            Property(x => x.Amount)
                .HasColumnName("Amount")
                .IsRequired();

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
