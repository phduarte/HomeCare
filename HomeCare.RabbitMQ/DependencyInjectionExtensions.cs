using Microsoft.Extensions.DependencyInjection;
using HomeCare.Domain.Payments;

namespace HomeCare.RabbitMQ
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection service)
        {
            service.AddScoped<IPaymentsProcessedQueueService, PaymentsProcessedQueueService>();
            service.AddScoped<IPaymentRequestQueueService, PaymentRequestQueueService>();

            return service;
        }
    }
}
