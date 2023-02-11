using Microsoft.Extensions.DependencyInjection;
using HomeCare.Domain.Aggregates.Payments;

namespace HomeCare.Adapters.PayPal
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPayPal(this IServiceCollection services)
        {
            return services.AddScoped<IPaymentGateway, PayPalPaymentGateway>();
        }
    }
}
