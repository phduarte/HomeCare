using Microsoft.Extensions.DependencyInjection;
using ProjetoIntegradoTeste.Data;
using ProjetoIntegradoTeste.Domain;
using ProjetoIntegradoTeste.PayPal;
using ProjetoIntegradoTeste.RabbitMQ;
using ProjetoIntegradoTeste.SendGrid;

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