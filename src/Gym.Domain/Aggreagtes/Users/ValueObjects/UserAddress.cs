namespace Gym.Domain.Aggregates.Users.ValueObjects;

public class UserAddress : ValueObject
{
    private UserAddress() { }

    public string? CountryName { get; private init; }

    public string? CityName { get; private init; }

    public string? RegionName { get; private init; }

    public string? Address { get; private init; }

    public static UserAddress Create(string? countryName = null!,
        string? cityName = null!,
        string? regionName = null!,
        string? address = null!)
    {
        return new()
        {
            CountryName = countryName,
            CityName = cityName,
            RegionName = regionName,
            Address = address
        };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CountryName!;
        yield return CityName!;
        yield return RegionName!;
        yield return Address!;
    }
}