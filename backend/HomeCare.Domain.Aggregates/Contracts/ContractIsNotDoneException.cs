using System.Runtime.Serialization;

namespace HomeCare.Domain.Aggregates.Contracts
{
    public class ContractIsNotDoneException : DomainException, ISerializable
    {
    }
}
