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
    public class OrderService
    {
        private readonly ShopContext _context;

        public OrderService(ShopContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public async Task<decimal> GetOrderTotal(int orderId)
        {
            var quantity = _context.OrderDetails.FirstOrDefault(r => r.OrderId == orderId).Quantity;

            var temp = _context.Products
                .Include(r => r.OrderDetails)
                .ToList();

            return 0;
        }


        public int SaveChanges() => _context.SaveChanges();
    }
}
