using System.Runtime.Serialization;

namespace HomeCare.Domain.Contracts
{
    public class ContractIsNotDoneException : Exception, ISerializable
    {
    }
}
