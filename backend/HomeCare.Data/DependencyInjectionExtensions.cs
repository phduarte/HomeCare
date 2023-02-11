using HomeCare.Domain.Aggregates.Clients;
using HomeCare.Domain.Aggregates.Contracts;
using HomeCare.Domain.Aggregates.Payments;
using HomeCare.Domain.Aggregates.Suppliers;
using Microsoft.Extensions.DependencyInjection;

namespace HomeCare.Data.InMemory
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
