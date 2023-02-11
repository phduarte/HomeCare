using HomeCare.Domain.Aggregates.Suppliers;

namespace HomeCare.Data.InMemory
{
    public class SuppliersRepository : ISuppliersRepository
    {
        static List<Supplier> _suppliers = new List<Supplier>
        {
            new Supplier
            {
                Id = Guid.Parse("{F0941629-5C8D-4A5E-87FC-237DFB513A64}"),
                Name = "Prestador 1",
                Tags = new List<string>{ "montador", "pedreiro", "eletricista" },
                Price = 150,
                Rate = 4,
                Username = "prestador1",
                Location = new Location
                {
                    Latitude = 2,
                    Longitude = 2,
                    Range = 1
                },
                Email="paulohincdig@gmail.com"
            },
            new Supplier
            {
                Id = Guid.Parse("{42A60981-2C50-4B04-8169-B8F75539876E}"),
                Name = "Prestador 2",
                Tags = new List<string>{ "montador" },
                Price = 80,
                Rate = 2,
                Username = "prestador2",
                Location = new Location
                {
                    Latitude = 5,
                    Longitude = 5,
                    Range = 5
                },
                Email="paulohincdig@gmail.com"
            },
            new Supplier
            {
                Id = Guid.Parse("{A1A3A6BE-6CAD-41B6-AAEA-DE2E15FD5354}"),
                Name = "Prestador 3",
                Tags = new List<string>{ "montador" },
                Price = 95,
                Rate = 4,
                Username = "prestador3",
                Location = new Location
                {
                    Latitude = 2,
                    Longitude = 9,
                    Range = 3
                },
                Email="paulohincdig@gmail.com"
            },
            new Supplier
            {
                Id = Guid.Parse("{A1A3A6BE-6CAD-41B6-AAEA-DE2E15FD5354}"),
                Name = "Prestador 4",
                Tags = new List<string>{ "pedreiro" },
                Price = 120,
                Rate = 5,
                Username = "prestador4",
                Location = new Location
                {
                    Latitude = 3,
                    Longitude = 14,
                    Range = 2
                },
                Email="paulohincdig@gmail.com"
            },
            new Supplier
            {
                Id = Guid.Parse("{56096BD4-FAA1-4285-9648-CDB694E0B940}"),
                Name = "Prestador 5",
                Tags = new List<string>{ "eletricista", "elétrica", "eletrica" },
                Price = 135,
                Rate = 4,
                Username = "prestador5",
                Location = new Location
                {
                    Latitude = 7,
                    Longitude = 5,
                    Range = 5
                },
                Email="paulohincdig@gmail.com"
            },
            new Supplier
            {
                Id = Guid.Parse("{FC3AF6D6-6119-4167-8AE5-7D7A59F93190}"),
                Name = "Prestador 6",
                Tags = new List<string>{ "bombeiro-hidráulico", "bombeiro", "hidráulico", "hidraulico" },
                Price = 97,
                Rate = 4,
                Username = "prestador6",
                Location = new Location
                {
                    Latitude = 6,
                    Longitude = 6,
                    Range = 10
                },
                Email="paulohincdig@gmail.com"
            },
            new Supplier
            {
                Id = Guid.Parse("{0DC7B31E-D547-49BB-A29D-98B450738220}"),
                Name = "Prestador 7",
                Tags = new List<string>{ "mecânico", "mecanico" },
                Price = 180,
                Rate = 5,
                Username = "prestador7",
                Location = new Location
                {
                    Latitude = 12,
                    Longitude = 1,
                    Range = 5
                },
                Email="paulohincdig@gmail.com"
            },
            new Supplier
            {
                Id = Guid.Parse("{4FC89E60-FEF2-4199-841F-23B413F3EDFA}"),
                Name = "Prestador 8",
                Tags = new List<string>{ "informática", "informatica", "formatação", "impressora" },
                Price = 50,
                Rate = 3,
                Username = "prestador8",
                Location = new Location
                {
                    Latitude = 8,
                    Longitude = 3,
                    Range = 10
                },
                Email="paulohincdig@gmail.com"
            }
        };

        public IQueryable<Supplier> Search(SearchCriteria criteria)
        {
            return _suppliers
                .Where(x => x.Match(criteria))
                .AsQueryable();
        }

        public Supplier GetById(Guid guid)
        {
            return _suppliers.FirstOrDefault(x => x.Id == guid);
        }

        public Supplier GetByUserName(string username)
        {
            return _suppliers.FirstOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
