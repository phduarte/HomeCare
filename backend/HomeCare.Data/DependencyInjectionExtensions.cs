using Microsoft.Extensions.DependencyInjection;
using HomeCare.Domain.Clients;
using HomeCare.Domain.Contracts;
using HomeCare.Domain.Payments;
using HomeCare.Domain.Suppliers;

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
