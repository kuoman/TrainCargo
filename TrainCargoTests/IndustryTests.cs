using FluentAssertions;

namespace TrainCargoTests
{
    [TestClass]
    public class IndustryTests
    {
        [TestMethod]
        public void ShouldReturnRollingStock()
        {
            Industry industry = new("1");

            List<RollingStock> cars = industry.GetCars("a");

            cars.Should().HaveCount(2);
        }

        [TestMethod]
        public void ShouldReturnRollingStock2()
        {
            Industry industry = new("1");

            List<RollingStock> cars = industry.GetCars("a");

            cars.Should().HaveCount(2);
        }
    }

    public class Industry
    {
        private readonly string _industry;

        public Industry(string industry)
        {
            _industry = industry;
        }

        public List<RollingStock> GetCars(string name)
        {
            List<RollingStock> rollingStocks = new();
            
            rollingStocks.Add(new FlatCar(name, _industry));
            rollingStocks.Add(new FlatCar(name, _industry));
            
            return rollingStocks;
        }
    }
}
