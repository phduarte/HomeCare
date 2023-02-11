using HomeCare.Domain.Aggregates.Suppliers;
using NUnit.Framework;

namespace HomeCare.Domain.Tests
{
    public class ValueObjectTests
    {
        [Test]
        public void Equals_WhenSameTypesAndValue_ShouldBeSuccess()
        {
            Money money = 100;
            Money vo = 100;

            Assert.IsTrue(money.Equals(vo));
        }

        [Test]
        public void Equals_WhenDifferentTypes_ShouldFail()
        {
            Money money = 100;
            Location vo = new() { Latitude = 100, Longitude = 200, Range = 50 };

            Assert.IsFalse(money.Equals(vo));
        }

        [Test]
        public void Equals_WhenDifferentValues_ShouldFail()
        {
            Money money = 100;
            Money vo = 50;

            Assert.IsFalse(money.Equals(vo));
        }
    }
}
