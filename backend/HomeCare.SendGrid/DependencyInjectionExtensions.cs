using Microsoft.Extensions.DependencyInjection;
using HomeCare.Domain.Contracts;
using HomeCare.Domain.Payments;
using Microsoft.Extensions.Configuration;
using SendGrid;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

[assembly: InternalsVisibleTo("HomeCare.SendGrid.Tests")]
namespace HomeCare.SendGrid
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddSendGrid(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("SendGrid").Get<SendGridOptions>());
            services
                .AddScoped(s =>
                {
                    var sendGridOptions = s.GetService<SendGridOptions>();
                    return new SendGridClient(sendGridOptions.ApiKey);
                })
                .AddScoped<IPaymentNotificationFacade, SendGridNotificationFacade>()
                .AddScoped<IContractFinishedNotificationFacade, SendGridNotificationFacade>();
            return services;
        }
    }
}
