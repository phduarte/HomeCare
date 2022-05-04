using Microsoft.Extensions.DependencyInjection;
using HomeCare.Domain.Payments;
using Microsoft.Extensions.Configuration;

namespace HomeCare.RabbitMQ
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("RabbitMq").Get<RabbitMqOptions>());
            services.AddSingleton<IPaymentsProcessedQueueService, PaymentsProcessedQueueService>();
            services.AddSingleton<IPaymentRequestQueueService, PaymentRequestQueueService>();

            return services;
        }
    }
}
