namespace HomeCare.Domain.Aggregates.Contracts
{
    public class PendingSpecification : ISpecification<Contract>
    {
        public bool IsSatisfied(Contract contract)
        {
            return contract.Status == ContractStatus.Emitted && contract.ExecutionDate < DateTime.Today.AddDays(1);
        }
    }
}
