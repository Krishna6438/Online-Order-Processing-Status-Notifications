using System;

public class OrderService
{
    public Order CreateOrder(int orderId, int customerId)
    {
        if (!DataBank.Customers.ContainsKey(customerId))
            throw new Exception("Customer not found");

        Order order = new Order
        {
            OrderId = orderId,
            Customer = DataBank.Customers[customerId]
        };

        DataBank.Orders.Add(orderId, order);
        return order;
    }

    public void AddItemToOrder(int orderId, int productId, int qty)
    {
        if (!DataBank.Orders.ContainsKey(orderId))
            throw new Exception("Order not found");

        if (!DataBank.Products.ContainsKey(productId))
            throw new Exception("Product not found");

        Order order = DataBank.Orders[orderId];

        order.Items.Add(new OrderItem
        {
            Product = DataBank.Products[productId],
            Quantity = qty
        });
    }

    public void ChangeOrderStatus(int orderId, OrderStatus status)
    {
        if (!DataBank.Orders.ContainsKey(orderId))
            throw new Exception("Order not found");

        DataBank.Orders[orderId].ChangeStatus(status);
    }
}
