using Microsoft.Extensions.DependencyInjection;
using HomeCare.Domain.Contracts;
using HomeCare.Domain.Payments;
using Microsoft.Extensions.Configuration;

namespace HomeCare.SendGrid
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddSendGrid(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("SendGrid").Get<SendGridOptions>());
            services
                .AddScoped<IPaymentNotificationFacade, SendGridNotificationFacade>()
                .AddScoped<IContractFinishedNotificationFacade, SendGridNotificationFacade>();
            return services;
        }
    }
}
