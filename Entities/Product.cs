using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulExam5.Entities
{
    public class Product : IAuditable
    {
        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
