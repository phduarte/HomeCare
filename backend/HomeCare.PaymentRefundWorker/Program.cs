using HomeCare.Domain.Payments;
using HomeCare.RabbitMQ;
using System.Net.Http.Json;

Console.WriteLine("Worker de Estorno!");

// 
var messageBroker = new MessageBroker<Payment>("payments_processed");
var client = new HttpClient();

Console.WriteLine($"{DateTime.Now} - ProcessPaymentWorker started.");

messageBroker.StartConsume((p) =>
{
    var result = client.PostAsJsonAsync("https://localhost:7258/api/v1/public/payment/complete", p).Result;
    result.EnsureSuccessStatusCode();

    Console.WriteLine($"{DateTime.Now} - Payment {p.Id} completed. {result}");
});

Console.WriteLine($"{DateTime.Now} - ProcessPaymentWorker finished.");
Console.ReadLine();