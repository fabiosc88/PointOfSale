using PointOfSale.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PointOfSale.Infrastructure.Repository.EF
{
    internal class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Category");

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(20)
                .IsRequired();

            HasKey(x => x.Id);
        }
    }
}
