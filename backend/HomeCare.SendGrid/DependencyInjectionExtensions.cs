using Microsoft.Extensions.DependencyInjection;
using HomeCare.Domain.Contracts;
using HomeCare.Domain.Payments;

namespace HomeCare.SendGrid
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddSendGrid(this IServiceCollection services)
        {
            return services
                .AddScoped<IPaymentNotificationFacade, SendGridNotificationFacade>()
                .AddScoped<IContractFinishedNotificationFacade, SendGridNotificationFacade>();
        }
    }
}
