using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace HomeCare.RabbitMQ
{
    public class MessageBroker : IMessageBroker
    {
        private readonly string _queueName;
        private readonly string _uri;

        public MessageBroker(string uri, string queueName)
        {
            _uri = uri;
            _queueName = queueName;

            Setup();
        }

        public void Publish<T>(T message)
        {
            using IModel channel = CreateChannel();

            var properties = channel.CreateBasicProperties();
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            
            properties.Persistent = true;

            channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 basicProperties: properties,
                                 body: body);
        }

        public void StartConsume<T>(Action<T> action)
        {
            var channel = CreateChannel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var payload = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<T>(payload);

                try
                {
                    action(message);
                    channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
                }
                catch
                {
                    channel.BasicNack(e.DeliveryTag, false, true);
                }
            };

            channel.BasicConsume(queue: _queueName,
                                 autoAck: false,
                                 consumer: consumer);
        }

        private IModel CreateChannel()
        {
            var factory = new ConnectionFactory() { Uri = new Uri(_uri) };
            var connection = factory.CreateConnection();
            return connection.CreateModel();
        }

        private void Setup()
        {
            using IModel channel = CreateChannel();
            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
        }
    }
}