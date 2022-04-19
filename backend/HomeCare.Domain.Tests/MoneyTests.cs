using NUnit.Framework;

namespace HomeCare.Domain.Tests
{
    public class MoneyTests
    {
        [Test]
        public void Equals_WhenValuesAreEquals_ShouldReturnTrue()
        {
            Money value1 = 100;
            Money value2 = 100;

            Assert.AreEqual(value1, value2);
        }

        [Test]
        public void Equals_WhenValuesAreNotEqual_ShouldReturnFalse()
        {
            Money value1 = 100;
            Money value2 = 50;

            Assert.AreNotEqual(value1, value2);
        }
    }
}
