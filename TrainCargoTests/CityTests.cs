using FluentAssertions;

namespace TrainCargoTests
{
    [TestClass]
    public class CityTests
    {
        [TestMethod]
        public void ShouldReturnListOfRollingStock()
        {
            City city = new City("a", null);

            List<RollingStock> trainCars = city.GetCars();

            trainCars.Should().HaveCount(3);
        }

        [TestMethod]
        public void ShouldReturnListOfRollingStock2()
        {
            Industry industry = new("1");

            City city = new City("a", industry);

            List<RollingStock> trainCars = city.GetCars();

            trainCars.Should().HaveCount(2);
        }
    }

    public class City
    {
        private readonly string _name;
        private readonly Industry _industry;

        public City(string name, Industry industry)
        {
            _name = name;
            _industry = industry;
        }

        public List<RollingStock> GetCars()
        {
            if (_industry == null)
            {

                List<RollingStock> rollingStocks = new List<RollingStock>
                {
                    new FlatCar(_name, "1"),
                    new FreightCar(_name, "2"),
                    new TankerCar(_name, "3")
                };

                return rollingStocks;
            }

            return _industry.GetCars(_name);
        }
    }
}
