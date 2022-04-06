using HomeCare.Common;

namespace ProjetoIntegradoTeste.Domain.Suppliers
{
    public class Location : ValueObject
    {
        /// <summary>
        /// 
        /// </summary>
        public long Latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Range { get; set; }
        public long X1 => Latitude - Range;
        public long X2 => Latitude + Range;
        public long Y1 => Longitude - Range;
        public long Y2 => Longitude + Range;

        public bool Near(Location location)
        {
            var x = Latitude.IsBetween(location.X1, location.X2);
            var y = Longitude.IsBetween(location.Y1, location.Y2);

            return x && y;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
            yield return Range;
        }
    }
}
