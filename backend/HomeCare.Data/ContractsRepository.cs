using HomeCare.Domain.Contracts;

namespace HomeCare.Data.InMemory
{
    internal class ContractsRepository : IContractsRepository
    {
        private static IList<Contract> _contracts = new List<Contract>();

        public void Create(Contract contract)
        {
            _contracts.Add(contract);
        }

        public Contract GetById(Guid guid)
        {
            return _contracts.FirstOrDefault(x => guid.Equals(x.Id));
        }

        public void Update(Contract contract)
        {
            var r = _contracts.FirstOrDefault(x => x.Equals(contract)) ?? throw new ContractNotFoundException(contract.Id);

            _contracts.Remove(r);
            _contracts.Add(contract);
        }
    }
}
