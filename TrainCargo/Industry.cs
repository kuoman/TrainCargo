using TrainCargo.Stock;

namespace TrainCargo;

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
        return _rollingStocks.Select(stock => stock.AddNew(city, _industry)).ToList();
    }
}