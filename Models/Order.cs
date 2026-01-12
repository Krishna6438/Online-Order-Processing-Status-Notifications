using System.Collections.Generic;
using System.Linq;

public class Order
{
    public int OrderId { get; set; }
    public Customer Customer { get; set; }

    private OrderStatus _status = OrderStatus.Created;
    public OrderStatus Status => _status;

    public List<OrderItem> Items = new();
    public Queue<StatusHistory> History = new();

    public double GetTotal()
    {
        return Items.Sum(i => i.GetTotal());
    }

    public delegate void OrderStatusChanged(Order order, OrderStatus status);
    public OrderStatusChanged OnStatusChanged;

    public void ChangeStatus(OrderStatus newStatus)
    {
        if (!IsValidTransition(newStatus))
        {
            Console.WriteLine($" Invalid transition: {_status} → {newStatus}");
            return;
        }

        _status = newStatus;

        History.Enqueue(new StatusHistory
        {
            Status = newStatus,
            Time = DateTime.Now
        });

        OnStatusChanged?.Invoke(this, newStatus);
    }

    private bool IsValidTransition(OrderStatus next)
    {
        if (_status == OrderStatus.Cancelled) return false;
        if (next == OrderStatus.Shipped && _status != OrderStatus.Paid) return false;
        if (next == OrderStatus.Delivered && _status != OrderStatus.Shipped) return false;

        return true;
    }
}
