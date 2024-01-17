using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace TrainCargoTests
{
    [TestClass]
    public class IndustryTests
    {
        [TestMethod]
        public void ShouldReturnRollingStock()
        {
            Industry industry = new Industry("1");

            List<RollingStock> cars = industry.GetCars();

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

        public List<RollingStock> GetCars()
        {
            List<RollingStock> rollingStocks = new List<RollingStock>();
            
            rollingStocks.Add(new FlatCar("a", _industry));
            rollingStocks.Add(new FlatCar("a", _industry));
            
            return rollingStocks;
        }
    }
}
