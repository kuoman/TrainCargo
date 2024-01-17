using TrainCargo.Stock;

namespace TrainCargo;

public class City
{
    private readonly string _city;
    private readonly List<Industry> _industries;

    public City(string city, List<Industry> industries)
    {
        _city = city;
        _industries = industries;
    }

    public List<RollingStock> GetCars()
    {
        List<RollingStock> stock = new();

        _industries.ForEach(x => stock.AddRange(x.GetCars(_city)));
            
        return stock;
    }
}