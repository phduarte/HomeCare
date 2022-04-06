using ProjetoIntegradoTeste.Domain.Contracts;

namespace HomeCare.Domain.Contracts
{
    [Serializable]
    public class ContractNotFoundException : Exception
    {
        public Contract Contract { get; }

        public ContractNotFoundException(Contract contract)
        {
            Contract = contract;
        }
    }
}
