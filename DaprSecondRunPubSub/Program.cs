const string PUBSUB = "orderpubsub";
const string TOPIC = "orders";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/orderprocessing/subscribe", () =>
{
    Console.WriteLine(
        $"The Dapr pub/sub is now subscribed to" +
        $"pubsub: {PUBSUB}, topic: {TOPIC}"
    );
});

app.MapPost("/orders", (Order order) =>
{
    Console.WriteLine(
        $"The subscriber received Order Id: {order.Id}"
    );

    return Results.Ok(order);
});

await app.RunAsync();

public record Order
{
    public int Id { get; set; }
    public string? Product_Code { get; set; }
}