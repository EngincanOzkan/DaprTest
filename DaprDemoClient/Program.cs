using Dapr.Client;
using System.Net.Http.Json;

Console.WriteLine("...RUNNING...");

using var client = new DaprClientBuilder().Build();

Console.WriteLine("...CLIENT CREATED...");

var products = await client.InvokeMethodAsync<List<Product>>(HttpMethod.Get, "productservice", "allproducts");

Console.WriteLine("...DISPLAYING THE PRODUCT/S INFORMATIONS...");

if (products != null)
foreach (var product in products)
{
    Console.WriteLine($"Id:{product.Id}," +
        $"Name:{product.Name}," +
        $"Quantity:{product.Quantity}," +
        $"Price:{product.Price}");
}

Console.ReadLine();

public record Product
{ 
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}
