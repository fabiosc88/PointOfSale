using PointOfSale.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PointOfSale.Infrastructure.Repository.EF
{
    internal class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Order");

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            HasKey(x => x.Id);

            HasRequired(x => x.PaymentMethod)
                .WithMany(x => x.Orders);
        }
    }
}
