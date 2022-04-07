using HomeCare.Domain.Contracts;

namespace HomeCare.Models
{
    public class ContractFinishedResponse
    {
        public Guid ContractId { get; set; }

        public static ContractFinishedResponse Parse(Contract contract)
        {
            return new ContractFinishedResponse
            {
                ContractId = contract.Id
            };
        }
    }
}
