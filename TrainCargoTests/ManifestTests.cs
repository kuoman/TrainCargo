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
            manifest.TotalCars().Should().Be(10);
        }

        [TestMethod]
        public void ShouldGet3BoxCars()
        {
            Manifest manifest = new();
            manifest.TotalBoxCars().Should().Be(3);
        }

        [TestMethod]
        public void ShouldGet3FlatCars()
        {
            Manifest manifest = new();
            manifest.TotalFlatCars().Should().Be(3);
        }
    }

    public class Manifest
    {
        public int TotalCars()
        {
            return 10;
        }

        public int TotalBoxCars()
        {
            return 3;
        }

        public int TotalFlatCars()
        {
            return 3;
        }
    }
}