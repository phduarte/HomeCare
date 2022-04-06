using HomeCare.Domain.Contracts;

namespace HomeCare.Models
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
