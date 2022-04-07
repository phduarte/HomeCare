using Microsoft.Extensions.DependencyInjection;
using HomeCare.Domain.Payments;

namespace HomeCare.PayPal
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPayPal(this IServiceCollection services)
        {
            return services.AddScoped<IPaymentGateway, PayPalPaymentGateway>();
        }
    }
}
