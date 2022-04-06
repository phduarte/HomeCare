using ProjetoIntegradoTeste.Domain.Contracts;

namespace ProjetoIntegradoTeste.Models
{
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
}
