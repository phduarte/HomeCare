using System.Runtime.Serialization;

namespace HomeCare.Domain.Contracts
{
    [Serializable]
    public class ContractIsNotPendingException : Exception, ISerializable
    {

    }
}
