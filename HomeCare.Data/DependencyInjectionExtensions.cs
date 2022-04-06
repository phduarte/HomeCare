using Microsoft.Extensions.DependencyInjection;
using ProjetoIntegradoTeste.Domain.Clients;
using ProjetoIntegradoTeste.Domain.Contracts;
using ProjetoIntegradoTeste.Domain.Payments;
using ProjetoIntegradoTeste.Domain.Suppliers;
using ProjetoIntegradoTeste.Infrastructure.Data;

namespace ProjetoIntegradoTeste.Data
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            return services
                .AddScoped<IClientRepository, ClientsRepository>()
                .AddScoped<IContractsRepository, ContractsRepository>()
                .AddScoped<IPaymentsRepository, PaymentsRepository>()
                .AddScoped<ISuppliersRepository, SuppliersRepository>()
                ;
        }
    }
}
