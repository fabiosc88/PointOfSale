using PointOfSale.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PointOfSale.Infrastructure.Repository.EF
{
    internal class PaymentMethodMap : EntityTypeConfiguration<PaymentMethod>
    {
        public PaymentMethodMap()
        {
            ToTable("PaymentMethod");

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(15)
                .IsRequired();

            HasKey(x => x.Id);
        }
    }
}
