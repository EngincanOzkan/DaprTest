var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/allproducts", () =>
{
    List<Product> products = new List<Product>();

    products.Add(new Product 
    { 
        Id = Guid.NewGuid(),
        Name = "Sony TV",
        Quantity = 25,
        Price = 90000
    });

    products.Add(new Product
    {
        Id = Guid.NewGuid(),
        Name = "Samsung TV",
        Quantity = 50,
        Price = 65000
    });

    products.Add(new Product
    {
        Id = Guid.NewGuid(),
        Name = "LG TV",
        Quantity = 15,
        Price = 55000
    });

    return products;
});

app.Run();

public record Product
{ 
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}