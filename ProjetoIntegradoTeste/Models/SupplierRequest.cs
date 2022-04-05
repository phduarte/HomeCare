using ProjetoIntegradoTeste.Domain;
using ProjetoIntegradoTeste.Domain.Contracts;

namespace ProjetoIntegradoTeste.Models
{
    public class ContractRequest
    {
        public Guid SupplierId { get; set; }
        public Guid ClientId { get; set; }
        public decimal Price { get; set; }
        public string ServiceDescription { get; set; }
        public DateTime ServiceDate { get; set; }

        public Contract ToModel()
        {
            return new Contract
            {
                Client = new Domain.Clients.Client { Id = ClientId },
                Id = Guid.NewGuid(),
                Price = Money.Parse(Price),
                ServiceDate = ServiceDate,
                Status = ContractStatus.Emmited,
                Supplier = new Domain.Suppliers.Supplier { Id = SupplierId }
            };
        }
    }

    public class ContractResponse
    {
        public int ContractId { get; set; }
        public Guid ProtocolNumber { get; set; }
    }

    public class ContractFinishRequest
    {
        public Guid ContractId { get; set; }

        internal Contract ToModel()
        {
            return new Contract
            {
                Id = ContractId
            };
        }
    }

    public class ContractFinishedResponse
    {
        public Guid ProtocolNumber { get; set; }
    }
}
