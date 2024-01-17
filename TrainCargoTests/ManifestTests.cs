
using FluentAssertions;

namespace TrainCargoTests
{
    [TestClass]
    public class ManifestTests
    {
        [TestMethod]
        public void ShouldGetTotalCars()
        {
            List<RollingStock> lumberRollingStock = new()
            {
                new FlatCar(),
                new FlatCar(),
                new FlatCar()
            };
            Industry mill1 = new("mill1", lumberRollingStock);
            
            List<Industry> industries = new() { mill1 };

            City cityA = new("a", industries);
            
            List<City> cities = new () { cityA };

            Manifest manifest = new(cities);

            manifest.TotalCars().Should().Be(3);
        }

        [TestMethod]
        public void ShouldGet3BoxCars()
        {
            List<RollingStock> freightStock = new()
            {
                new FreightCar(),
                new FreightCar(),
                new FreightCar()
            };
            Industry box1 = new("box1", freightStock);

            List<Industry> industriesB = new() { box1 };

            City cityB = new("b", industriesB);

            List<City> cities = new() { cityB };

            Manifest manifest = new(cities);

            manifest.TotalBoxCars().Should().Be(3);
        }

        [TestMethod]
        public void ShouldGet3FlatCars()
        {
            List<RollingStock> lumberRollingStock = new()
            {
                new FlatCar(),
                new FlatCar(),
                new FlatCar()
            };
            Industry mill1 = new("mill1", lumberRollingStock);

            List<Industry> industries = new() { mill1 };

            City cityA = new("a", industries);

            List<City> cities = new() { cityA };

            Manifest manifest = new(cities);
            manifest.TotalFlatCars().Should().Be(3);
        }

        [TestMethod]
        public void ShouldGet4TankerCars()
        {
            List<RollingStock> oilStock = new()
            {
                new TankerCar(),
                new TankerCar(),
                new TankerCar(),
                new TankerCar()
            };
            Industry oil1 = new("oil1", oilStock);

            List<Industry> industriesC = new() { oil1 };

            City cityC = new("c", industriesC);

            List<City> cities = new() { cityC };

            Manifest manifest = new(cities);

            manifest.TotalTankerCars().Should().Be(4);
        }

        [TestMethod]
        public void ShouldReturnCarsForCity()
        {
            List<RollingStock> lumberRollingStock = new()
            {
                new FlatCar(),
                new FlatCar()
            };
            Industry mill1 = new("mill1", lumberRollingStock);

            List<Industry> industriesA = new() { mill1 };

            City cityA = new("a", industriesA);

            List<RollingStock> freightStock = new()
            {
                new FreightCar(),
                new FreightCar(),
                new FreightCar()
            };
            Industry box1 = new("box1", freightStock);

            List<Industry> industriesB = new() { box1 };

            City cityB = new("b", industriesB);
            
            List<RollingStock> oilStock = new()
            {
                new TankerCar(),
                new TankerCar(),
                new TankerCar()
            };
            Industry oil1 = new("oil1", oilStock);
            
            List<Industry> industriesC = new() { oil1 };

            City cityC = new("c", industriesC);

            List<City> cities = new()
            {
                cityA,
                cityB,
                cityC
            };

            Manifest manifest = new(cities);


            List<RollingStock> cityAStock = manifest.RollingStockForCity("a");
            cityAStock.Count.Should().Be(2);
        }
    }

    public class Manifest
    {
        private readonly List<City> _cities;

        public Manifest(List<City> cities)
        {
            _cities = cities;
        }

        public int TotalCars()
        {
            return TotalBoxCars() + TotalFlatCars() + TotalTankerCars();
        }

        public int TotalBoxCars()
        {
            return GetStockCars().Count(x => x.IsType("freight"));
        }

        public int TotalFlatCars()
        {
            return GetStockCars().Count(x => x.IsType("flat"));
        }

        public int TotalTankerCars()
        {
            return GetStockCars().Count(x => x.IsType("tanker"));
        }

        public List<RollingStock> RollingStockForCity(string city)
        {
            return GetStockCars().Where(x => x.IsCity(city)).ToList();
        }
        private List<RollingStock> GetStockCars()
        {
            List<RollingStock> stock = new();

            foreach (City city in _cities)
            {
                stock.AddRange(city.GetCars());
            }

            return stock;
        }

    }
}