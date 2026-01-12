using System;

public class ReportService
{
    public void PrintAllOrders()
    {
        Console.WriteLine("\n========= FINAL ORDER REPORT =========");

        foreach (var order in DataBank.Orders.Values)
        {
            Console.WriteLine($"\nOrder ID: {order.OrderId}");
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine($"Current Status: {order.Status}");
            Console.WriteLine("Items:");

            foreach (var item in order.Items)
            {
                Console.WriteLine($"  {item.Product.Name} x {item.Quantity} = ₹{item.GetTotal()}");
            }

            Console.WriteLine($"Total: ₹{order.GetTotal()}");

            Console.WriteLine("Status History:");
            foreach (var h in order.History)
            {
                Console.WriteLine($"  {h.Status} at {h.Time}");
            }
        }
    }
}
