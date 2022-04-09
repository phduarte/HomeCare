using HomeCare.Domain.Payments;
using HomeCare.RabbitMQ;
using System.Net.Http.Json;

Console.WriteLine("Worker de pedidos de pagamento");

// 
var uri = "amqps://nnbhglxk:OyPflRd0OVBDL6w5XuXz-bLMTYqIZNlH@jackal.rmq.cloudamqp.com/nnbhglxk";
var messageBroker = new MessageBroker<Payment>(uri, "payments_requested");
var client = new HttpClient();

Console.WriteLine($"{DateTime.Now} - ProcessedWorker started.");

messageBroker.StartConsume((p) =>
{
    var result = client.PostAsJsonAsync("https://localhost:7258/api/v1/public/payment/pay", p).Result;
    result.EnsureSuccessStatusCode();

    Console.WriteLine($"{DateTime.Now} - Payment {p.Id} received. {result}");
});

Console.WriteLine($"{DateTime.Now} - ProcessedWorker finished.");
Console.ReadLine();