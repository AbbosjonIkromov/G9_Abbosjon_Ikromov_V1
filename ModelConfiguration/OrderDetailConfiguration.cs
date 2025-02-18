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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Quantity)
                .HasDefaultValue(0);

            builder.HasOne(r => r.Product)
                .WithMany(r => r.OrderDetails)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Order)
                .WithMany(r => r.OrderDetails)
                .HasForeignKey(r => r.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
