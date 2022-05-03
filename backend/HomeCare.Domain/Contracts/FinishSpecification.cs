namespace HomeCare.Domain.Contracts
{
    public class FinishSpecification : ISpecification<Contract>
    {
        public bool IsSatisfied(Contract contract)
        {
            return contract.Status == ContractStatus.Done;
        }
    }
}
