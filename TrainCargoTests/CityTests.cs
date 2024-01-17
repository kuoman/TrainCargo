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

            List<Industry> industries = new() { new("1", rollingStocks) };

            City city = new("a", industries);

            List<RollingStock> trainCars = city.GetCars();

            trainCars.Should().HaveCount(3);
        }
    }

    public class City
    {
        private readonly string _city;
        private readonly List<Industry> _industries;

        public City(string city, List<Industry> industries)
        {
            _city = city;
            _industries = industries;
        }

        public List<RollingStock> GetCars()
        {
            List<RollingStock> stock = new();

            foreach (Industry industry in _industries)
            {
                stock.AddRange(industry.GetCars(_city));
            }
            
            return stock;
        }
    }
}
