using FluentAssertions;

namespace TrainCargoTests
{
    [TestClass]
    public class RollingStockTests
    {
        [TestMethod]
        public void ShouldReturnTrueForTanker()
        {
            TankerCar tankerCar = new("a", "1");

            tankerCar.IsType("tanker").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForNonTanker()
        {
            TankerCar tankerCar = new("a", "1");

            tankerCar.IsType("box").Should().BeFalse();
        }

        [TestMethod]
        public void ShouldIgnoreCase()
        {
            TankerCar tankerCar = new("a", "1");

            tankerCar.IsType("TANKER").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForFreight()
        {
            FreightCar rollingStock = new("a", "1");

            rollingStock.IsType("freight").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForFlat()
        {
            FlatCar rollingStock = new("a", "1");

            rollingStock.IsType("flat").Should().BeTrue();
        }

        public class RollingStock
        {
            private readonly string _type;
            private readonly string _city;
            private readonly string _industry;

            public RollingStock(string type, string city, string industry)
            {
                _type = type;
                _city = city;
                _industry = industry;
            }

            public bool IsType(string type)
            {
                return type.ToLower() == _type;
            }
        }

        public class TankerCar : RollingStock
        {
            public TankerCar(string city, string industry) : base("tanker", city, industry)
            {
            }
        }

        public class FreightCar : RollingStock
        {
            public FreightCar(string city, string industry) : base("freight", city, industry)
            {
            }
        }

        public class FlatCar : RollingStock
        {
            public FlatCar(string city, string industry) : base("flat", city, industry)
            {
            }
        }

    }
}
