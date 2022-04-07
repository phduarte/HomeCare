using HomeCare.Domain.Suppliers;

namespace HomeCare.Models
{
    public class SearchResponse
    {
        public Guid SupplierId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string? Tags { get; set; }
        public int Rate { get; private set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public long Range { get; set; }

        public static SearchResponse Map(Supplier supplier)
        {
            return new SearchResponse
            {
                SupplierId = supplier.Id,
                Name = supplier.Name,
                Price = supplier.Price.Amount,
                Rate = supplier.Rate,
                Latitude = supplier.Location.Latitude,
                Longitude = supplier.Location.Longitude,
                Range = supplier.Location.Range,
                Tags = string.Join(", ", supplier.Tags)
            };
        }
    }
}
