using FluentAssertions;

namespace TrainCargoTests
{
    [TestClass]
    public class IndustryTests
    {
        [TestMethod]
        public void ShouldReturnRollingStock()
        {
            List<RollingStock> rollingStocks = new();
            rollingStocks.Add(new FlatCar());
            rollingStocks.Add(new FlatCar());

            Industry industry = new("1", rollingStocks);
            
            List<RollingStock> cars = industry.GetCars("a");

            cars.Should().HaveCount(2);
        }

        [TestMethod]
        public void ShouldReturnRollingStock2()
        {
            List<RollingStock> rollingStocks = new();
            rollingStocks.Add(new FlatCar());
            rollingStocks.Add(new FlatCar());
            
            Industry industry = new("1", rollingStocks);

            List<RollingStock> cars = industry.GetCars("a");

            cars.Should().HaveCount(2);
        }
    }

    public class Industry
    {
        private readonly string _industry;
        private readonly List<RollingStock> _rollingStocks;

        public Industry(string industry, List<RollingStock> rollingStocks)
        {
            _industry = industry;
            _rollingStocks = rollingStocks;
        }

        public List<RollingStock> GetCars(string city)
        {
            List<RollingStock> rollingStocks = new();
            
            foreach (RollingStock stock in _rollingStocks)
            {
                rollingStocks.Add(stock.AddNew(city, _industry));
            }
            
            return rollingStocks;
        }
    }
}
