using ProjetoIntegradoTeste.Domain;

namespace HomeCare.Domain.Contracts
{
    public class ContractSketch
    {
        public Guid SupplierId { get; set; }
        public Guid ClientId { get; set; }
        //public Money Price { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
