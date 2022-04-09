using Microsoft.Extensions.DependencyInjection;
using HomeCare.Data.InMemory;
using HomeCare.Domain;
using HomeCare.PayPal;
using HomeCare.RabbitMQ;
using HomeCare.SendGrid;
using Microsoft.Extensions.Configuration;

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