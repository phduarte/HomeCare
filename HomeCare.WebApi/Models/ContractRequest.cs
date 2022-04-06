using HomeCare.Domain.Contracts;

namespace ProjetoIntegradoTeste.Models
{
    public class ContractRequest
    {
        public Guid SupplierId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime ServiceDate { get; set; }

        public ContractSketch ToModel()
        {
            return new ContractSketch
            {
                ClientId = ClientId,
                ServiceDate = ServiceDate,
                SupplierId = SupplierId
            };
        }
    }
}
