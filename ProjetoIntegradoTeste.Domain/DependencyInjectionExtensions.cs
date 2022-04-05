using Microsoft.Extensions.DependencyInjection;
using ProjetoIntegradoTeste.Domain.Clients;
using ProjetoIntegradoTeste.Domain.Contracts;
using ProjetoIntegradoTeste.Domain.Payments;
using ProjetoIntegradoTeste.Domain.Suppliers;

namespace ProjetoIntegradoTeste.Domain
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IClientsService, ClientsService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ISupplierService, SupplierService>();

            return services;
        }
    }
}
