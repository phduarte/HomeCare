using HomeCare.Domain.Suppliers;
namespace HomeCare.WebApi.Suppliers.Models;

public class SupplierSearchResponse
{
    public Guid SupplierId { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string? Tags { get; set; }
    public int Rate { get; private set; }
    public long Latitude { get; set; }
    public long Longitude { get; set; }
    public long Range { get; set; }
    public string Image { get; set; } = "https://thumbs.dreamstime.com/z/home-care-logo-design-template-vector-icon-128771044.jpg";
    public string Description { get; set; } = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.";

    public static SupplierSearchResponse Parse(Supplier supplier)
    {
        return new SupplierSearchResponse
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