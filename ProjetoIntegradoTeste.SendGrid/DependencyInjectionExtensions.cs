using Microsoft.Extensions.DependencyInjection;
using ProjetoIntegradoTeste.Domain.Payments;

namespace ProjetoIntegradoTeste.SendGrid
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddSendGrid(this IServiceCollection services)
        {
            return services.AddScoped<IPaymentNotificationFacade, SendGridNotificationFacade>();
        }
    }
}
