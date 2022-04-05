using Microsoft.Extensions.DependencyInjection;
using ProjetoIntegradoTeste.Domain.Clients;
using ProjetoIntegradoTeste.Infrastructure.Data;

namespace ProjetoIntegradoTeste.Data
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            return services.AddScoped<IClientsRepository, ClientsRepository>();
        }
    }
}
