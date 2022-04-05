using Newtonsoft.Json;

namespace ProjetoIntegradoTeste.Models
{
    public class SearchRequest
    {
        [JsonProperty("lat")]
        public int Latitude { get; set; }
        [JsonProperty("lng")]
        public int Longitude { get; set; }
        [JsonProperty("raio")]
        public int Raio { get; set; }
        public string OrderBy { get; set; }
    }
}
