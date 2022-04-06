using ProjetoIntegradoTeste.Domain.Clients;

namespace HomeCare.WebApi.Models
{
    public class ClientResponse
    {
        public string Name { get; set; }
        public Guid ClientId { get; set; }
        public string Username { get; set; }

        public static ClientResponse Parse(Client client)
        {
            return new ClientResponse
            {
                ClientId = client.Id,
                Username = client.Username,
                Name = client.Name,
            };
        }
    }
}
