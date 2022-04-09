namespace HomeCare.Domain.Contracts
{
    public class RefundSpecification : ISpecification<Contract>
    {
        public bool IsSatisfied(Contract contract)
        {
            return contract.Status == ContractStatus.Emmited && contract.ExecutionDate > DateTime.Today.AddDays(60);
        }
    }
}
