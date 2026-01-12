using System;

public class CustomerNotification
{
    public void Notify(Order order, OrderStatus status)
    {
        Console.WriteLine($"📧 Email to {order.Customer.Name}: " +
                        $"Your order #{order.OrderId} is now {status}");
    }
}
