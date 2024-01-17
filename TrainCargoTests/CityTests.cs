using FluentAssertions;

namespace TrainCargoTests
{
    [TestClass]
    public class CityTests
    {
        [TestMethod]
        public void ShouldReturnListOfRollingStock()
        {
            List<RollingStock> rollingStocks = new()
            {
                new FlatCar(),
                new FreightCar(),
                new TankerCar()
            };
            
            Industry industry = new("1", rollingStocks);

            City city = new("a", industry);

            List<RollingStock> trainCars = city.GetCars();

            trainCars.Should().HaveCount(3);
        }
    }

    public class City
    {
        private readonly string? _name;
        private readonly Industry _industry;

        public City(string? name, Industry industry)
        {
            _name = name;
            _industry = industry;
        }

        public List<RollingStock> GetCars()
        {
            return _industry.GetCars(_name);
        }
    }
}
