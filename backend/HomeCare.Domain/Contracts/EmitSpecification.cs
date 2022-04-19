namespace HomeCare.Domain.Contracts
{
    public class EmitSpecification : ISpecification<Contract>
    {
        public bool IsSatisfied(Contract entity)
        {
            return entity.Status == ContractStatus.Sketch;
        }
    }
}
