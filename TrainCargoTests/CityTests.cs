using FluentAssertions;
using TrainCargo;
using TrainCargo.Stock;

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
}
