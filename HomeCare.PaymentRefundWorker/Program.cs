// See https://aka.ms/new-console-template for more information
using ProjetoIntegradoTeste.Domain.Payments;
using ProjetoIntegradoTeste.RabbitMQ;

Console.WriteLine("Hello, World!");

var messageBroker = new MessageBroker<Payment>("https://jackal.rmq.cloudamqp.com/", "payments_requested");
var continua = true;

do
{
    try
    {
        var message = new Payment();

        messageBroker.Publish(message);

        Console.WriteLine($"{DateTime.Now} - Payment {message.Id} sent.");
    }
    catch
    {
        continua = false;
    }

} while (continua);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();