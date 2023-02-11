using System.Runtime.Serialization;

namespace HomeCare.Domain.Aggregates.Clients
{
    public class ClientNotFoundException : DomainException, ISerializable
    {
        public Guid ClientId { get; }

        public ClientNotFoundException(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
