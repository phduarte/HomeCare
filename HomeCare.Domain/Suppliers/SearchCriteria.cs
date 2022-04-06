namespace HomeCare.Domain.Suppliers
{
    public class SearchCriteria : ValueObject
    {
        public string Tag { get; set; }
        public Location Location { get; set; }

        public SearchType SearchType { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Tag;
            yield return Location;
        }
    }
}
