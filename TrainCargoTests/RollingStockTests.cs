using FluentAssertions;
using TrainCargo.Stock;

namespace TrainCargoTests
{
    [TestClass]
    public class RollingStockTests
    {
        [TestMethod]
        public void ShouldReturnTrueForTanker()
        {
            TankerCar rollingStock = new();
            rollingStock.AddNew("a", "1");

            rollingStock.IsType("tanker").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForNonTanker()
        {
            TankerCar rollingStock = new();
            rollingStock.AddNew("a", "1");

            rollingStock.IsType("box").Should().BeFalse();
        }

        [TestMethod]
        public void ShouldIgnoreCase()
        {
            TankerCar rollingStock = new();
            rollingStock.AddNew("a", "1");

            rollingStock.IsType("TANKER").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForFreight()
        {
            FreightCar rollingStock = new();
            rollingStock.AddNew("a", "1");

            rollingStock.IsType("freight").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForFlat()
        {
            FlatCar rollingStock = new();

            rollingStock.AddNew("a", "1");

            rollingStock.IsType("flat").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForGivenCity()
        {
            FlatCar rollingStock = new();
            
            RollingStock newStock = rollingStock.AddNew("a", "1");

            newStock.IsCity("a").Should().BeTrue(); 
        }

        [TestMethod]
        public void ShouldReturnTrueForGivenCityIgnoreCase()
        {
            FlatCar rollingStock = new();
            RollingStock newStock = rollingStock.AddNew("a", "1");

            newStock.IsCity("A").Should().BeTrue(); 
        }

        [TestMethod]
        public void ShouldReturnTrueForGivenIndustry()
        {
            FlatCar rollingStock = new();
            RollingStock newStock = rollingStock.AddNew("a", "c");

            newStock.IsIndustry("c").Should().BeTrue(); 
        }

        [TestMethod]
        public void ShouldReturnTrueForGivenIndustryIgnoreCase()
        {
            FlatCar rollingStock = new();
            RollingStock newStock = rollingStock.AddNew("a", "c");

            newStock.IsIndustry("C").Should().BeTrue(); 
        }
    }
}
