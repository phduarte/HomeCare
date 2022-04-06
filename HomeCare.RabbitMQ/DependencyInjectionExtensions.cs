using Microsoft.Extensions.DependencyInjection;
using ProjetoIntegradoTeste.Domain.Payments;

namespace ProjetoIntegradoTeste.RabbitMQ
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
