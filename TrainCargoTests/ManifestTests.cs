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
            manifest.TotalCars.Should().Be(10);
        }
    }

    public class Manifest
    {
        public int TotalCars { get; set; }
    }
}