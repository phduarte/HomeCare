using Microsoft.Extensions.DependencyInjection;
using HomeCare.Data;
using HomeCare.Domain;
using HomeCare.PayPal;
using HomeCare.RabbitMQ;
using HomeCare.SendGrid;

namespace HomeCare.IoC
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddHomeCare(this IServiceCollection services)
        {
            return services.AddData()
                .AddSendGrid()
                .AddRabbitMq()
                .AddPayPal()
                .AddDomain();
        }
    }
}