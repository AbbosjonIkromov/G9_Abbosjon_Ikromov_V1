using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModulExam5.Entities;

namespace ModulExam5.ModelConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(r => r.ProductId);
            builder.Property(r => r.ProductId)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.ProductName)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(r => r.Price)
                .HasPrecision(10, 2)
                .HasDefaultValue(0.00m);

        }
    }
}
