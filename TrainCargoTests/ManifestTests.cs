
using FluentAssertions;

namespace TrainCargoTests
{
    [TestClass]
    public class ManifestTests
    {
        [TestMethod]
        public void ShouldGetTotalCars()
        {
            Manifest manifest = new();

            manifest.Add(new FreightCar("a", "1"));
            manifest.Add(new FlatCar("a", "1"));
            manifest.Add(new TankerCar("a", "1"));

            manifest.TotalCars().Should().Be(3);
        }

        [TestMethod]
        public void ShouldGet3BoxCars()
        {
            Manifest manifest = new();
            manifest.Add(new FreightCar("a", "1"));
            manifest.Add(new FreightCar("a", "1"));
            manifest.Add(new FreightCar("a", "1"));
            manifest.TotalBoxCars().Should().Be(3);
        }

        [TestMethod]
        public void ShouldGet3FlatCars()
        {
            Manifest manifest = new();
            manifest.Add(new FlatCar("a", "1"));
            manifest.Add(new FlatCar("a", "1"));
            manifest.Add(new FlatCar("a", "1"));
            manifest.TotalFlatCars().Should().Be(3);
        }

        [TestMethod]
        public void ShouldGet4TankerCars()
        {
            Manifest manifest = new(); 
            manifest.Add(new TankerCar("a", "1"));
            manifest.Add(new TankerCar("a", "1"));
            manifest.Add(new TankerCar("a", "1"));
            manifest.Add(new TankerCar("a", "1"));
            manifest.TotalTankerCars().Should().Be(4);
        }

        [TestMethod]
        public void ShouldReturnCarsForCity()
        {
            Manifest manifest = new();
            manifest.Add(new TankerCar("b", "1"));
            manifest.Add(new FreightCar("b", "1"));
            manifest.Add(new FreightCar("a", "1"));
            manifest.Add(new FlatCar("b", "1"));
            manifest.Add(new FlatCar("a", "1"));

            List<RollingStock> cityAStock = manifest.RollingStockForCity("a");
            cityAStock.Count.Should().Be(2);
        }

    }

    public class Manifest
    {
        public int TotalCars()
        {
            return TotalBoxCars() + TotalFlatCars() + TotalTankerCars();
        }

        public int TotalBoxCars()
        {
            return _train.Count(x => x.IsType("freight"));
        }

        public int TotalFlatCars()
        {
            return _train.Count(x => x.IsType("flat"));
        }

        public int TotalTankerCars()
        {
            return _train.Count(x => x.IsType("tanker"));
        }

        readonly List<RollingStock> _train = new();
        public void Add(RollingStock car)
        {
            _train.Add(car);    
        }

        public List<RollingStock> RollingStockForCity(string city)
        {
            return _train.Where(x => x.IsCity(city)).ToList();
        }
    }


}