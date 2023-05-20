var sales = new Sales();

sales.AddSale(new Product("Soap", 2));
sales.AddSale(new Product("Beans", 3));
sales.AddSale(new Product("Ruffles", 5));

Report.Print(sales.ToString());

class Product
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
}

class Sales
{
    public List<Product> ProductsSold => _productsSold;

    private List<Product> _productsSold = new List<Product>();
    private int count = 0;

    public int AddSale(Product product)
    {
        _productsSold.Add(product);
        return ++count;
    }

    public void RemoveSale(int index)
    {
        _productsSold.RemoveAt(index);
        count--;
    }

    public override string ToString()
    {
        var stringProductsSold = string.Empty;

        int i = 0;
        foreach (var p in _productsSold)
            stringProductsSold += $"{++i}: {p.Name} - ${p.Price}{Environment.NewLine}";

        return stringProductsSold;
    }
}

class Report
{
    public static void Print(string report)
    {
        // imagine this is a save-to-file instead of a WriteLine
        Console.WriteLine(report);
    }
}