using static System.Math;

namespace ProjetoIntegradoTeste.Domain.Suppliers
{
    public class Location : ValueObject
    {
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public long Range { get; set; }

        public bool Near(Location location)
        {
            return Abs(Latitude - location.Latitude) < Range && Abs(Longitude - location.Longitude) < Range;
        }
    }
}
