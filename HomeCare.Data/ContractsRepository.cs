using HomeCare.Domain.Contracts;
using ProjetoIntegradoTeste.Domain.Contracts;

namespace ProjetoIntegradoTeste.Infrastructure.Data
{
    internal class ContractsRepository : IContractsRepository
    {
        private static IList<Contract> _contracts = new List<Contract>();

        public void Create(Contract contract)
        {
            _contracts.Add(contract);
        }

        public void Update(Contract contract)
        {
            var r = _contracts.FirstOrDefault(x => x.Equals(contract));

            if (r == null)
                throw new ContractNotFoundException(contract);

            _contracts.Remove(r);
            _contracts.Add(contract);
        }
    }
}
