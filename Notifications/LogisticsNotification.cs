using System;

public class LogisticsNotification
{
    public void Notify(Order order, OrderStatus status)
    {
        Console.WriteLine($"🚚 Logistics Alert: Order #{order.OrderId} changed to {status}");
    }
}
