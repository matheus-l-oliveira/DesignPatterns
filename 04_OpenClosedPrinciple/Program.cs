using System;

Order orderByAir = new("air", new Air(), 150, 200);
Order orderByGround = new("ground", new Ground(), 1, 1);

Console.WriteLine($"Air -> {orderByAir.ShippingCost} | {orderByAir.ShippingDate}");
Console.WriteLine($"Ground -> {orderByGround.ShippingCost} | {orderByGround.ShippingDate}");

public interface IShippingMethod
{
    public double GetCost(Order order);
    public DateTime GetDate(Order order);
}

public class Order
{
    public string LineItems { get; set; }
    public IShippingMethod ShippingMethod { get; set; }
    public double Total { get; set; }
    public double TotalWeight { get; set; }
    public double ShippingCost => ShippingMethod.GetCost(this);
    public DateTime ShippingDate => ShippingMethod.GetDate(this);

    public Order(string lineItems, IShippingMethod shippingMethod, double total, double totalWeight)
    {
        LineItems = lineItems;
        ShippingMethod = shippingMethod;
        Total = total;
        TotalWeight = totalWeight;
    }
}

class Ground : IShippingMethod
{
    private const double MinimalCost = 10;

    public double GetCost(Order order)
    {
        if (order.Total > 100) return 0;

        var value = order.TotalWeight * 1.5;
        return MinimalCost > value ? MinimalCost : value;
    }

    public DateTime GetDate(Order order)
    {
        return DateTime.Now;
    }
}

public class Air : IShippingMethod
{
    public double GetCost(Order order)
    {
        return order.TotalWeight * 5;
    }

    public DateTime GetDate(Order order)
    {
        return DateTime.Now;
    }
}