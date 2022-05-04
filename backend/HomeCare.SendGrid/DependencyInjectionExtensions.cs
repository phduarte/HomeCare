using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SendGrid;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using HomeCare.Domain;

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
                .AddScoped<INotificationFacade, SendGridNotificationFacade>();
            return services;
        }
    }
}
