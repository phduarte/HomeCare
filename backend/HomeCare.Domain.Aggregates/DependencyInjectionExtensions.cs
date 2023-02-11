using HomeCare.Domain.Aggregates.Clients;
using HomeCare.Domain.Aggregates.Contracts;
using HomeCare.Domain.Aggregates.Payments;
using HomeCare.Domain.Aggregates.Suppliers;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HomeCare.Domain.Tests")]
namespace HomeCare.Domain.Aggregates
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ISupplierService, SupplierService>();

            return services;
        }
    }
}
