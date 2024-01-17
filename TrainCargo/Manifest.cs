using TrainCargo.Stock;

namespace TrainCargo;

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