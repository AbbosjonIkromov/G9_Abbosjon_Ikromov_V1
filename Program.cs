using ModulExam5.Data;
using ModulExam5.Entities;
using ModulExam5.Services;

namespace ModulExam5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using var context = new ShopContext();
            var productService = new ProductService(context);
            var orderService = new OrderService(context);

            //var products = new List<Product>()
            //{
            //    new Product()
            //    {
            //        ProductName = "Phone",
            //        Price = 55
            //    },
            //    new Product()
            //    {
            //        ProductName = "Notebook",
            //        Price = 89
            //    },
            //    new Product()
            //    {
            //        ProductName = "Macbook",
            //        Price = 122
            //    },
            //    new Product()
            //    {
            //        ProductName = "Iphone",
            //        Price = 87
            //    },
            //    new Product()
            //    {
            //        ProductName = "Headphone",
            //        Price = 45
            //    }
            //};

            //context.Products.AddRange(products);
            //context.SaveChanges();

            //var orders = new List<Order>()
            //{
            //    new Order()
            //    {

            //    },
            //    new Order()
            //    {

            //    },
            //    new Order()
            //    {

            //    },
            //    new Order()
            //    {

            //    },
            //    new Order()
            //    {

            //    }
            //};

            //context.Orders.AddRange(orders);
            //context.SaveChanges();

            //var orderDetails = new List<OrderDetail>()
            //{
            //    new OrderDetail()
            //    {
            //        OrderId = 1,
            //        ProductId = 1,
            //        Quantity = 5

            //    },
            //    new OrderDetail()
            //    {
            //        OrderId = 2,
            //        ProductId = 1,
            //        Quantity = 7

            //    },
            //    new OrderDetail()
            //    {
            //        OrderId = 3,
            //        ProductId = 2,
            //        Quantity = 10

            //    },
            //    new OrderDetail()
            //    {
            //        OrderId = 4,
            //        ProductId = 3,
            //        Quantity = 8

            //    },
            //    new OrderDetail()
            //    {
            //        OrderId = 5,
            //        ProductId = 4,
            //        Quantity = 20

            //    },
            //};

            //context.OrderDetails.AddRange(orderDetails);
            //context.SaveChanges();

            // 1
            var productbelow50 = context.Products
                .Where(r => r.Price > 50)
                .ToList();
            foreach (var product in productbelow50)
            {
                Console.WriteLine($"ProductId: {product.ProductId}, ProductName: {product.ProductName}, ProductPrice: {product.Price}");
            }

            // 2
            var lastWeekOrders = context.Orders
                .Where(r => r.OrderDate > DateTime.Now.AddDays(-7))
                .ToList();
            foreach (var order in lastWeekOrders)
            {
                Console.WriteLine($"OrderId: {order.OrderId}, {order.OrderDate}");
            }
            
            // 3
            var orderProducts = context.OrderDetails.ToList()
                .GroupBy(r => r.ProductId)
                .Join(context.Products, o => o.Key, p => p.ProductId, (o, p) => new
                {
                    p.ProductName,
                    count = p.OrderDetails.Count
                })
                .ToList();
            foreach (var product in orderProducts)
            {
                Console.WriteLine($"ProductName: {product.ProductName}, Count: {product.count}");
            }

            // 4 
            var quantity3 = context.OrderDetails.ToList()
                .Join(context.Products, o => o.ProductId, p => p.ProductId, (o, p) => new
                {
                    p.ProductId,
                    p.ProductName,
                    p.Price,
                    o.Quantity
                })
                .Select(r => new
                {
                    r.ProductId,
                    r.ProductName,
                    r.Price,
                    r.Quantity,
                })
                .Where(r => r.Quantity > 3)
                .ToList();

            foreach (var product in quantity3)
            {
                Console.WriteLine($"ProductId: {product.ProductId}, ProductName: {product.ProductName}, Price: {product.Price}, Quantity: {product.Quantity}");
            }


            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
