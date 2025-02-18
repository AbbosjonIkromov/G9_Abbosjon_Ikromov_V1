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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(r => r.OrderId);
            builder.Property(r => r.OrderId)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.OrderDate)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("current_timestamp");


        }
    }
}
