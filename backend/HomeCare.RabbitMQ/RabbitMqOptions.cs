namespace HomeCare.RabbitMQ
{
    public class RabbitMqOptions
    {
        public string Uri { get; set; }
        public string ProcessedQueueName { get; set; }
        public string RequestedQueueName { get; set; }
    }
}
