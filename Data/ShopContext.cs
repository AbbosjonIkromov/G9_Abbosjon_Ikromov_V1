using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using ModulExam5.Entities;

namespace ModulExam5.Data
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted })
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(new AuditInterceptor());

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
