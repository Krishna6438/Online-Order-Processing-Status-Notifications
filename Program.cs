using System;

class Program
{
    static void Main()
    {
        // 1. Load sample data
        DataBank.Products.Add(1, new Product { Id = 1, Name = "Laptop", Price = 50000 });
        DataBank.Products.Add(2, new Product { Id = 2, Name = "Mouse", Price = 500 });
        DataBank.Products.Add(3, new Product { Id = 3, Name = "Keyboard", Price = 1500 });
        DataBank.Products.Add(4, new Product { Id = 4, Name = "Monitor", Price = 12000 });
        DataBank.Products.Add(5, new Product { Id = 5, Name = "Headset", Price = 2000 });

        DataBank.Customers.Add(1, new Customer { Id = 1, Name = "Krishna" });
        DataBank.Customers.Add(2, new Customer { Id = 2, Name = "Ravi" });
        DataBank.Customers.Add(3, new Customer { Id = 3, Name = "Amit" });

        var orderService = new OrderService();
        var reportService = new ReportService();

        // 2. Create orders
        var order1 = orderService.CreateOrder(101, 1);
        var order2 = orderService.CreateOrder(102, 2);
        var order3 = orderService.CreateOrder(103, 3);
        var order4 = orderService.CreateOrder(104, 1);

        // 3. Add items
        orderService.AddItemToOrder(101, 1, 1);
        orderService.AddItemToOrder(101, 2, 2);

        orderService.AddItemToOrder(102, 3, 1);
        orderService.AddItemToOrder(102, 5, 1);

        orderService.AddItemToOrder(103, 4, 1);

        orderService.AddItemToOrder(104, 2, 3);
        orderService.AddItemToOrder(104, 5, 2);

        // 4. Setup notifications
        var customerNotify = new CustomerNotification();
        var logisticsNotify = new LogisticsNotification();

        foreach (var order in DataBank.Orders.Values)
        {
            order.OnStatusChanged += customerNotify.Notify;
            order.OnStatusChanged += logisticsNotify.Notify;
        }

        // 5. Change status
        orderService.ChangeOrderStatus(101, OrderStatus.Paid);
        orderService.ChangeOrderStatus(101, OrderStatus.Shipped);
        orderService.ChangeOrderStatus(101, OrderStatus.Delivered);

        orderService.ChangeOrderStatus(102, OrderStatus.Paid);
        orderService.ChangeOrderStatus(102, OrderStatus.Shipped);

        orderService.ChangeOrderStatus(103, OrderStatus.Shipped);   // ❌ invalid
        orderService.ChangeOrderStatus(103, OrderStatus.Paid);
        orderService.ChangeOrderStatus(103, OrderStatus.Shipped);

        orderService.ChangeOrderStatus(104, OrderStatus.Cancelled);
        orderService.ChangeOrderStatus(104, OrderStatus.Paid);     // ❌ invalid

        // 6. Print final report
        reportService.PrintAllOrders();
    }
}
