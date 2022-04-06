using ProjetoIntegradoTeste.Domain.Suppliers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegradoTeste.Models
{
    public class SearchRequest
    {
        [DisplayName("Latitude (KM)")]
        public long Latitude { get; set; }
        [DisplayName("Latitude (KM)")]
        public long Longitude { get; set; }
        [Display(Name = "Range KM")]
        public long Range { get; set; }
        public string? OrderBy { get; set; }
        public string? ServiceName { get; set; }

        public static SearchCriteria Parse(SearchRequest request)
        {
            var type = GetSearchType(request.OrderBy);

            return new SearchCriteria
            {
                Location = new Location
                {
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Range = request.Range
                },
                SearchType = type,
                Tag = request.ServiceName
            };
        }

        private static SearchType GetSearchType(string type)
        {
            if (type?.Equals("price", StringComparison.OrdinalIgnoreCase) ?? false)
            {
                return SearchType.Price;
            }
            else if (type?.Equals("quality", StringComparison.OrdinalIgnoreCase) ?? false)
            {
                return SearchType.Quality;
            }

            return SearchType.None;
        }
    }
}
