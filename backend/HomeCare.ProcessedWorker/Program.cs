using HomeCare.Domain.Payments;
using HomeCare.RabbitMQ;
using System.Net.Http.Json;

Console.WriteLine("Worker de pagamentos processados");

// 
var uri = "amqps://nnbhglxk:OyPflRd0OVBDL6w5XuXz-bLMTYqIZNlH@jackal.rmq.cloudamqp.com/nnbhglxk";
var messageBroker = new MessageBroker<Payment>(uri, "payments_processed");
var client = new HttpClient();

Console.WriteLine($"{DateTime.Now} - RequestedWorker started.");

messageBroker.StartConsume((p) =>
{
    var result = client.PostAsJsonAsync("https://localhost:7258/api/v1/public/payment/complete", p).Result;
    result.EnsureSuccessStatusCode();

    Console.WriteLine($"{DateTime.Now} - Payment {p.Id} completed. {result}");
});

Console.WriteLine($"{DateTime.Now} - RequestedWorker finished.");
Console.ReadLine();