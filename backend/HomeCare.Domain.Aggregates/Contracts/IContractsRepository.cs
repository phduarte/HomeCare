namespace HomeCare.Domain.Aggregates.Contracts
{
    public interface IContractsRepository : IRepository<Contract>
    {
        Contract GetById(Guid guid);
        void Create(Contract contract);
        void Update(Contract contract);
    }
}
