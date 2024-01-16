
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
    }

    public class Manifest
    {
        public int TotalCars()
        {
            return TotalBoxCars() + TotalFlatCars() + TotalTankerCars();
        }

        public int TotalBoxCars()
        {
            return train.Count(x => x.IsType("freight"));
        }

        public int TotalFlatCars()
        {
            return train.Count(x => x.IsType("flat"));
        }

        public int TotalTankerCars()
        {
            return train.Count(x => x.IsType("tanker"));
        }

        List<RollingStock> train = new List<RollingStock>();
        public void Add(RollingStock car)
        {
            train.Add(car);    
        }
    }


}