using HomeCare.Domain.Payments;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace HomeCare.RabbitMQ
{
    internal abstract class QueueService
    {
        private IConnection _connection;

        public string Uri { get; }
        public string QueueName { get; }

        public QueueService(string uri, string queueName)
        {
            Uri = uri;
            QueueName = queueName;
            Setup();
        }

        public void Publish(Payment payment)
        {
            var message = PaymentRequestMessage.Parse(payment);

            Publish(message);
        }

        private void Publish<T>(T message)
        {
            using IModel channel = CreateChannel();

            var properties = channel.CreateBasicProperties();
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            properties.Persistent = true;

            channel.BasicPublish(exchange: "",
                                 routingKey: QueueName,
                                 basicProperties: properties,
                                 body: body);
        }

        private IModel CreateChannel()
        {
            var factory = new ConnectionFactory() { Uri = new Uri(Uri) };
            _connection = factory.CreateConnection();

            return _connection.CreateModel();
        }

        private void Setup()
        {
            using IModel channel = CreateChannel();

            channel.QueueDeclare(queue: QueueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
        }

        ~QueueService()
        {
            if (_connection.IsOpen)
            {
                _connection.Close();
            }
        }
    }
}
