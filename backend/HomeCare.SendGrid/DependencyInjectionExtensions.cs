using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SendGrid;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using HomeCare.Domain.Aggregates.Shared;

[assembly: InternalsVisibleTo("HomeCare.Adapters.SendGrid.Tests")]
namespace HomeCare.Adapters.SendGrid
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddSendGrid(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("SendGrid").Get<SendGridSettings>());
            services
                .AddScoped(s =>
                {
                    var sendGridOptions = s.GetService<SendGridSettings>();
                    return new SendGridClient(sendGridOptions.ApiKey);
                })
                .AddScoped<INotificationSender, SendGridNotificationService>();
            return services;
        }
    }
}
