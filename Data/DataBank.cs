using System.Collections.Generic;

public static class DataBank
{
    // Acts like tables in a database
    public static Dictionary<int, Product> Products = new();
    public static Dictionary<int, Customer> Customers = new();
    public static Dictionary<int, Order> Orders = new();
}
