using FluentAssertions;

namespace TrainCargoTests
{
    [TestClass]
    public class CityTests
    {
        [TestMethod]
        public void ShouldReturnListOfRollingStock()
        {
            City city = new City("a");

            List<RollingStock> trainCars = city.GetCars();

            trainCars.Should().HaveCount(3);
        }
    }

    public class City
    {
        private readonly string _name;

        public City(string name)
        {
            _name = name;
        }

        public List<RollingStock> GetCars()
        {
            List<RollingStock> rollingStocks = new List<RollingStock>
            {
                new FlatCar(_name, "1"),
                new FreightCar(_name, "2"),
                new TankerCar(_name, "3")
            };

            return rollingStocks;
        }
    }
}
