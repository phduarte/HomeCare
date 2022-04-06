using Newtonsoft.Json;
using HomeCare.Domain;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace HomeCare.RabbitMQ
{
    public class MessageBroker<T> : IMessageBroker<T>
    {
        private readonly string _queueName;
        private readonly string _hostName;

        public event MessageReceivedEventHandler<T> MessageReceived;

        public MessageBroker(string hostname, string queueName)
        {
            _hostName = hostname;
            _queueName = queueName;

            Setup();
        }

        public void Setup()
        {
            using IModel channel = CreateChannel();
            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
        }

        public void Publish(T message)
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

        public void StartConsume(Action<T> action)
        {
            var channel = CreateChannel();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var payload = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<T>(payload);

                action.Invoke(message);

                channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
            };

            channel.BasicConsume(queue: _queueName,
                                 autoAck: false,
                                 consumer: consumer);
        }

        public void StartConsume()
        {
            StartConsume((p) => MessageReceived?.Invoke(p));
        }

        private IModel CreateChannel()
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            var connection = factory.CreateConnection();
            return connection.CreateModel();
        }
    }
}