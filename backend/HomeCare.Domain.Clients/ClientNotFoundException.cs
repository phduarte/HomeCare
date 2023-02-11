using System.Runtime.Serialization;

namespace HomeCare.Domain.Clients
{
    public class ClientNotFoundException : Exception, ISerializable
    {
        public Guid ClientId { get; }

        public ClientNotFoundException(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
