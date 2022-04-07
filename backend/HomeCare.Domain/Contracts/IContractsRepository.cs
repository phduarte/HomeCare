namespace HomeCare.Domain.Contracts
{
    public interface IContractsRepository : IRepository<Contract>
    {
        void Create(Contract contract);
        void Update(Contract contract);
    }
}
