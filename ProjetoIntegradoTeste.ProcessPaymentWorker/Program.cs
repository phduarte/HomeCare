// See https://aka.ms/new-console-template for more information
using ProjetoIntegradoTeste.Domain.Payments;
using ProjetoIntegradoTeste.RabbitMQ;

Console.WriteLine("Hello, World!");

// 
var messagePublisher = new MessageBroker<Payment>("https://jackal.rmq.cloudamqp.com/", "payments_requested");

Console.WriteLine($"{DateTime.Now} - ProcessPaymentWorker started.");

//messagePublisher.MessageReceived += MessagePublisher_MessageReceived; 
//messagePublisher.StartConsume();
//messagePublisher.StartConsume(MessagePublisher_MessageReceived);
messagePublisher.StartConsume((p) =>
{
    Console.WriteLine($"{DateTime.Now} - Payment {p.Id} received.");
});

Console.WriteLine($"{DateTime.Now} - ProcessPaymentWorker finished.");
Console.ReadLine();