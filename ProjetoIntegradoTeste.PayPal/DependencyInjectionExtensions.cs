using Microsoft.Extensions.DependencyInjection;
using ProjetoIntegradoTeste.Domain.Payments;

namespace ProjetoIntegradoTeste.PayPal
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPayPal(this IServiceCollection services)
        {
            return services.AddScoped<IPaymentGateway, PayPalPaymentGateway>();
        }
    }
}
