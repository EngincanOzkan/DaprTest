using System.Text;
using System.Text.Json;

var baseURL = "http://localhost:3500";
const string PUBSUB = "orderpubsub";
const string TOPIC = "orders";
const string APP_ID = "orderprocessing";

Console.WriteLine($"Publishing to " +
    $"baseURL: {baseURL}, PubSub Name: {PUBSUB}, Topic: {TOPIC}"
);

var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Accept
    .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

httpClient.DefaultRequestHeaders
    .Add("dapr-app-id", APP_ID);

for (int i = 1; i <= 5; i++) 
{
    var order = new Order() { Id = i, Product_Code = "P000" + i.ToString() };
    var content = new StringContent(JsonSerializer.Serialize<Order>(order), Encoding.UTF8, "application/json");
    var response = await httpClient.PostAsync($"{baseURL}/orders", content);
    Console.WriteLine($"Published Order Id: {order.Id}");
}

public record Order
{
    public int Id { get; set; }
    public string Product_Code { get; set; }
}