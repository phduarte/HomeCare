using HomeCare.Domain.Contracts;

namespace HomeCare.Models
{
    public class ContractFinishResponse
    {
        public Guid ContractId { get; set; }

        public static ContractFinishResponse Parse(Contract contract)
        {
            return new ContractFinishResponse
            {
                ContractId = contract.Id
            };
        }
    }
}
