using ProjetoIntegradoTeste.Domain.Contracts;
using ProjetoIntegradoTeste.Domain.Payments;

namespace ProjetoIntegradoTeste.Domain.Suppliers
{
    internal class SupplierService : ISupplierService
    {
        readonly IPaymentRequestQueueService _paymentRequestQueue;
        private readonly IContractService _contractService;
        private readonly ISuppliersRepository _suppliersRepository;

        public SupplierService(IPaymentRequestQueueService paymentRequestQueue,
            IContractService contractService,
            ISuppliersRepository suppliersRepository)
        {
            _paymentRequestQueue = paymentRequestQueue;
            _contractService = contractService;
            _suppliersRepository = suppliersRepository;
        }

        public IEnumerable<Supplier> Find(SearchCriteria searchCriteria)
        {
            var suppliers = _suppliersRepository.Find(searchCriteria);

            if (searchCriteria.SearchType == SearchType.Quality)
            {
                suppliers = suppliers.OrderByDescending(x => x.Rate);
            }
            else
            {
                suppliers = suppliers.OrderByDescending(x => x.Price);
            }

            return suppliers;
        }

        public void Hire(Contract contract)
        {
            _contractService.Emmit(contract);

            var payment = new Payment
            {
                Description = string.Empty,
                Id = Guid.NewGuid(),
                Status = PaymentStatus.Requested,
                Value = contract.Price
            };

            _paymentRequestQueue.Publish(payment);
        }
    }
}
