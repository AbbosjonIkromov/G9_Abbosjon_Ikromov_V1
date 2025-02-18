using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulExam5.Entities
{
    public class Order : IAuditable
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
