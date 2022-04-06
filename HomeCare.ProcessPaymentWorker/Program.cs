using HomeCare.Domain.Payments;
using HomeCare.RabbitMQ;
using System.Net.Http.Json;

Console.WriteLine("Hello, World!");

// 
var messageBroker = new MessageBroker<Payment>("payments_requested");
var client = new HttpClient();

Console.WriteLine($"{DateTime.Now} - ProcessPaymentWorker started.");

messageBroker.StartConsume((p) =>
{
    var result = client.PostAsJsonAsync("https://localhost:7258/api/v1/public/payment/pay", p).Result;
    result.EnsureSuccessStatusCode();
    
    Console.WriteLine($"{DateTime.Now} - Payment {p.Id} received. {result}");
});

Console.WriteLine($"{DateTime.Now} - ProcessPaymentWorker finished.");
Console.ReadLine();