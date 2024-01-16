using FluentAssertions;

namespace TrainCargoTests
{
    [TestClass]
    public class FreightTests
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

        public class Freight
        {
            private readonly string _type;
            private readonly string _city;
            private readonly string _industry;

            public Freight(string type, string city, string industry)
            {
                _type = type;
                _city = city;
                _industry = industry;
            }

            public bool IsType(string type)
            {
                return type == _type;
            }
        }

        public class TankerCar : Freight
        {
            public TankerCar(string city, string industry) : base("tanker", city, industry)
            {
            }
        }

    }
}
