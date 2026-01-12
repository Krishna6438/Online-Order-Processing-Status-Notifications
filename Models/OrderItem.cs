public class OrderItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public double GetTotal()
    {
        return Product.Price * Quantity;
    }
}
