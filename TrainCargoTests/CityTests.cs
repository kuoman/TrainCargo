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
        private readonly string _city;
        private readonly Industry _industry;

        public City(string city, Industry industry)
        {
            _city = city;
            _industry = industry;
        }

        public List<RollingStock> GetCars()
        {
            return _industry.GetCars(_city);
        }
    }
}
