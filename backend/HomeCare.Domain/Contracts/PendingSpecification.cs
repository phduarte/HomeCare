namespace HomeCare.Domain.Contracts
{
    public class PendingSpecification : ISpecification<Contract>
    {
        public bool IsSatisfied(Contract contract)
        {
            return contract.Status == ContractStatus.Emmited && contract.ServiceDate > DateTime.Today.AddDays(1);
        }
    }
}
