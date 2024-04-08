using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;

public class UserAddressBuilder
{
    private string? _countryName;

    private string? _cityName;

    private string? _regionName;

    private string? _address;

    public UserAddressBuilder()
    {
        _countryName = "CountryName";
        _cityName = "CityName";
        _regionName = "RegionName";
        _address = "Address";
    }

    public UserAddressBuilder WithCountry(string? countryName)
    {
        _countryName = countryName;

        return this;
    }

    public UserAddressBuilder WithCityName(string? cityName)
    {
        _cityName = cityName;

        return this;
    }

    public UserAddressBuilder WithRegionName(string? regionName)
    {
        _regionName = regionName;

        return this;
    }

    public UserAddressBuilder WithAddress(string? address)
    {
        _address = address;

        return this;
    }

    public UserAddress Build() => UserAddress.Create(_countryName,
        _cityName,
        _regionName,
        _address);
}