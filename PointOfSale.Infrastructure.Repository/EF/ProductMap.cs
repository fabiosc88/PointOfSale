using PointOfSale.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PointOfSale.Infrastructure.Repository.EF
{
    internal class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.Price)
                .HasColumnName("Price")
                .IsRequired()
                .HasColumnType("Money");

            HasRequired(x => x.Category)
                .WithMany(x => x.Products);

            HasKey(x => x.Id);
        }
    }
}
