using ProjetoIntegradoTeste.Domain.Contracts;

namespace ProjetoIntegradoTeste.Models
{
    public class ContractResponse
    {
        public Guid ContractId { get; set; }

        public static ContractResponse Parse(Contract contract)
        {
            return new ContractResponse
            {
                ContractId = contract.Id
            };
        }
    }
}
