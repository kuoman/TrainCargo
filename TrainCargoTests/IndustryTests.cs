using FluentAssertions;
using TrainCargo;
using TrainCargo.Stock;

namespace TrainCargoTests
{
    [TestClass]
    public class IndustryTests
    {
        [TestMethod]
        public void ShouldReturnRollingStock()
        {
            List<RollingStock> rollingStocks = new()
            {
                new FlatCar(),
                new FlatCar()
            };

            Industry industry = new("1", rollingStocks);
            
            List<RollingStock> cars = industry.GetCars("a");

            cars.Should().HaveCount(2);
        }

        [TestMethod]
        public void ShouldReturnRollingStock2()
        {
            List<RollingStock> rollingStocks = new()
            {
                new FlatCar(),
                new FlatCar()
            };

            Industry industry = new("1", rollingStocks);

            List<RollingStock> cars = industry.GetCars("a");

            cars.Should().HaveCount(2);
        }
    }
}
