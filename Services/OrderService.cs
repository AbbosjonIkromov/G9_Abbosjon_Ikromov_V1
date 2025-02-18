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
            var order = await _context.OrderDetails.FindAsync(orderId);
            if (order is null) return 0;

            

            return 0;
        }


        public int SaveChanges() => _context.SaveChanges();
    }
}
