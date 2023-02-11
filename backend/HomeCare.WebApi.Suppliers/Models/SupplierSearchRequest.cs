using HomeCare.Domain.Aggregates.Suppliers;
namespace HomeCare.WebApi.Suppliers.Models;

public class SupplierSearchRequest
{
    public long Latitude { get; set; }
    public long Longitude { get; set; }
    public long Range { get; set; }
    public string? OrderBy { get; set; }
    public string? ServiceName { get; set; }

    public SearchCriteria ToModel()
    {
        var type = GetSearchType(OrderBy);

        return new SearchCriteria
        {
            Location = new Location
            {
                Latitude = Latitude,
                Longitude = Longitude,
                Range = Range
            },
            SearchType = type,
            Tag = ServiceName
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

    public static bool TryParse(string? value, IFormatProvider? provider, out SupplierSearchRequest request)
    {

        request = new SupplierSearchRequest();
        return false;
    }
}
