using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModulExam5.Data;
using ModulExam5.Entities;

namespace ModulExam5.Services
{
    public class ProductService
    {
        private readonly ShopContext _context;

        public ProductService(ShopContext context)
        {
            _context = context;
        }

        public void AddProduct(string name, decimal price)
        {
            var newProduct = new Product()
            {
                ProductName = name,
                Price = price
                
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product is null) return;

            var products = await _context.Products
                
                .Where(r => r.OrderDetails.Any(p => p.ProductId == id))
                .ToListAsync();

            if (products.Count == 0)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

        }

        public int SaveChanges() => _context.SaveChanges();

    }
}
