using Microsoft.Extensions.DependencyInjection;
using HomeCare.Domain.Clients;
using HomeCare.Domain.Contracts;
using HomeCare.Domain.Payments;
using HomeCare.Domain.Suppliers;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

[assembly: InternalsVisibleTo("HomeCare.Domain.Tests")]
namespace HomeCare.Domain
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
