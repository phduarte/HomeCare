using Microsoft.Extensions.DependencyInjection;
using HomeCare.Data.InMemory;
using Microsoft.Extensions.Configuration;
using HomeCare.Adapters.SendGrid;
using HomeCare.Adapters.RabbitMQ;
using HomeCare.Adapters.PayPal;
using HomeCare.Domain.Aggregates;

namespace HomeCare.IoC
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddHomeCare(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddData()
                .AddSendGrid(configuration)
                .AddRabbitMq(configuration)
                .AddPayPal()
                .AddDomain();
        }
    }
}