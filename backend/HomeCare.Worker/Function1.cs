using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HomeCare.Worker
{
    public class Function1
    {
        private static HttpClient _client = new HttpClient();
        private readonly string _requestedCallbackEndpoint;
        private readonly string _processedCallbackEndpoint;

        public Function1(IConfiguration configuration)
        {
            _requestedCallbackEndpoint = configuration.GetValue<string>("AzureFunctionsJobHost:RequestedCallbackEndpoint");
            _processedCallbackEndpoint = configuration.GetValue<string>("AzureFunctionsJobHost:ProcessedCallbackEndpoint");
        }

        [FunctionName("Requested")]
        public async Task RunRequested([RabbitMQTrigger("payments_requested", ConnectionStringSetting = "rabbitMQ")] string myQueueItem,
                ILogger log)
        {
            await Task.Delay(60000);
            await PostAsJsonAsync(log, _requestedCallbackEndpoint, myQueueItem);
        }

        [FunctionName("Processed")]
        public async Task RunProcessed([RabbitMQTrigger("payments_processed", ConnectionStringSetting = "rabbitMQ")] string myQueueItem,
            ILogger log)
        {
            await Task.Delay(60000);
            await PostAsJsonAsync(log, _processedCallbackEndpoint, myQueueItem);
        }

        private async Task PostAsJsonAsync<T>(ILogger log, string endpoint, T myQueueItem)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            try
            {
                var result = await _client.PostAsJsonAsync(endpoint, myQueueItem);
                result.EnsureSuccessStatusCode();

                log.LogInformation($"Requested is completed. {result}");
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Failed to call {endpoint}", myQueueItem);
                throw;
            }
        }
    }
}
