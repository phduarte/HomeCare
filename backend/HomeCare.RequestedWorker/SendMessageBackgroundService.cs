using HomeCare.Domain.Payments;
using HomeCare.RabbitMQ;

namespace HomeCare.RequestedWorker
{
    public class SendMessageBackgroundService : BackgroundService
    {
        private readonly ILogger<SendMessageBackgroundService> _logger;
        private readonly IMessageBroker _messageBroker;
        private readonly HttpClient _client;
        private string workerName;
        private string endpoint;

        public SendMessageBackgroundService(ILogger<SendMessageBackgroundService> logger)
        {
            _logger = logger;

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            workerName = config.GetValue<string>("WorkerName");
            endpoint = config.GetValue<string>("CallbackEndpoint");

            var uri = config.GetSection("RabbitMq").GetValue<string>("Uri");
            var queue = config.GetSection("RabbitMq").GetValue<string>("RequestedQueueName");

            _messageBroker = new MessageBroker(uri, queue);
            _client = new HttpClient();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{DateTime.Now} - {workerName} started.");
            
            stoppingToken.Register(() => _logger.LogInformation($"{workerName} is stopping."));

            _messageBroker.StartConsume<Payment>((payment) =>
            {
                if (stoppingToken.IsCancellationRequested)
                    throw new TaskCanceledException();

                _logger.LogInformation($"{DateTime.Now} - PaymentId {payment.Id} is being processed.");

                try
                {
                    var result = _client.PostAsJsonAsync(endpoint, payment).Result;
                    result.EnsureSuccessStatusCode();

                    _logger.LogInformation($"{DateTime.Now} - The PaymentId {payment.Id} is completed. {result}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to call {endpoint}", payment);
                    throw;
                }
            });

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"{DateTime.Now} - {workerName} is alive.");
                await Task.Delay(1000);
            }

            _logger.LogInformation($"{DateTime.Now} - {workerName} stopped.");
        }
    }
}
