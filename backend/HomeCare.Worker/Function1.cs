using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using HomeCare.Worker.Models;

namespace HomeCare.Worker
{
    public class Function1
    {
        private static HttpClient _client = new HttpClient();
        private readonly string _requestedCallbackEndpoint;
        private readonly string _processedCallbackEndpoint;
        private readonly int _delay = 0;

        public Function1(IConfiguration configuration)
        {
            _requestedCallbackEndpoint = configuration.GetValue<string>("AzureFunctionsJobHost:RequestedCallbackEndpoint");
            _processedCallbackEndpoint = configuration.GetValue<string>("AzureFunctionsJobHost:ProcessedCallbackEndpoint");
            _delay = configuration.GetValue<int>("AzureFunctionsJobHost:Delay");
        }

        [FunctionName("Requested")]
        public async Task RunRequested([RabbitMQTrigger("payments_requested", ConnectionStringSetting = "rabbitMQ")] PaymentMessage message,
                ILogger log)
        {
            await Task.Delay(_delay);
            await PostAsJsonAsync(log, _requestedCallbackEndpoint, message);
        }

        [FunctionName("Processed")]
        public async Task RunProcessed([RabbitMQTrigger("payments_processed", ConnectionStringSetting = "rabbitMQ")] PaymentMessage message,
            ILogger log)
        {
            await Task.Delay(_delay);
            await PostAsJsonAsync(log, _processedCallbackEndpoint, message);
        }

        private async Task PostAsJsonAsync<T>(ILogger log, string endpoint, T message)
        {
            log.LogInformation($"C# Queue trigger function processed: {message}");
            var contentResult = string.Empty;

            try
            {
                var result = await _client.PostAsJsonAsync(endpoint, message);
                contentResult = result.Content.ReadAsStringAsync().Result;

                result.EnsureSuccessStatusCode();

                log.LogInformation($"Requested is completed. {result}");
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Failed to call {endpoint}", message, contentResult);
                throw;
            }
        }
    }
}
