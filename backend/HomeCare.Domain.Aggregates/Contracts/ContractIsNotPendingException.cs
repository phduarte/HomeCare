using System.Runtime.Serialization;

namespace HomeCare.Domain.Aggregates.Contracts
{
    [Serializable]
    public class ContractIsNotPendingException : DomainException, ISerializable
    {

    }
}
