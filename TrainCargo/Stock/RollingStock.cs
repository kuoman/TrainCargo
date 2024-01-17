namespace TrainCargo.Stock;

public class RollingStock
{
    private readonly string _type;
    private readonly string _city;
    private readonly string _industry;

    private RollingStock(string type, string city, string industry)
    {
        _type = type;
        _city = city;
        _industry = industry;
    }

    public RollingStock(string type): this(type, "", "") { }

    public bool IsType(string type)
    {
        return type.ToLower() == _type;
    }
    public bool IsCity(string city)
    {
        return city.ToLower() == _city;
    }
    public bool IsIndustry(string industry)
    {
        return industry.ToLower() == _industry;
    }

    public RollingStock AddNew(string city, string industry)
    {
        return new RollingStock(_type, city, industry);
    }

}