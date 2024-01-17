using FluentAssertions;

namespace TrainCargoTests
{
    [TestClass]
    public class RollingStockTests
    {
        [TestMethod]
        public void ShouldReturnTrueForTanker()
        {
            TankerCar rollingStock = new();
            rollingStock.AddNew("a", "1");

            rollingStock.IsType("tanker").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForNonTanker()
        {
            TankerCar rollingStock = new();
            rollingStock.AddNew("a", "1");

            rollingStock.IsType("box").Should().BeFalse();
        }

        [TestMethod]
        public void ShouldIgnoreCase()
        {
            TankerCar rollingStock = new();
            rollingStock.AddNew("a", "1");

            rollingStock.IsType("TANKER").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForFreight()
        {
            FreightCar rollingStock = new();
            rollingStock.AddNew("a", "1");

            rollingStock.IsType("freight").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForFlat()
        {
            FlatCar rollingStock = new();

            rollingStock.AddNew("a", "1");

            rollingStock.IsType("flat").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForGivenCity()
        {
            FlatCar rollingStock = new();
            
            RollingStock newStock = rollingStock.AddNew("a", "1");

            newStock.IsCity("a").Should().BeTrue(); 
        }

        [TestMethod]
        public void ShouldReturnTrueForGivenCityIgnoreCase()
        {
            FlatCar rollingStock = new();
            RollingStock newStock = rollingStock.AddNew("a", "1");

            newStock.IsCity("A").Should().BeTrue(); 
        }

        [TestMethod]
        public void ShouldReturnTrueForGivenIndustry()
        {
            FlatCar rollingStock = new();
            RollingStock newStock = rollingStock.AddNew("a", "c");

            newStock.IsIndustry("c").Should().BeTrue(); 
        }

        [TestMethod]
        public void ShouldReturnTrueForGivenIndustryIgnoreCase()
        {
            FlatCar rollingStock = new();
            RollingStock newStock = rollingStock.AddNew("a", "c");

            newStock.IsIndustry("C").Should().BeTrue(); 
        }
    }

    public class RollingStock
    {
        private readonly string _type;
        private readonly string? _city;
        private readonly string? _industry;

        private RollingStock(string type, string city, string industry)
        {
            _type = type;
            _city = city;
            _industry = industry;
        }

        public RollingStock(string type)
        {
            _type = type;
        }

        public bool IsType(string type)
        {
            return type.ToLower() == _type;
        }
        public bool IsCity(string city)
        {
            return city.ToLower() == _city;
        }
        public bool IsIndustry(string industry)
        {
            return industry.ToLower() == _industry;
        }

        public RollingStock AddNew(string city, string industry)
        {
            return new RollingStock(_type, city, industry );
        }

    }

    public class TankerCar : RollingStock
    {
        public TankerCar() : base("tanker")
        {
        }
    }

    public class FreightCar : RollingStock
    {
        public FreightCar() : base("freight")
        {
        }
    }

    public class FlatCar : RollingStock
    {
        public FlatCar() : base("flat")
        {
        }
    }
}
