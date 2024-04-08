using FluentAssertions;
using Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;

namespace Gym.Domain.UnitTest.Aggregates.Users.ValueObjects;

public class UserAddressUnitTest
{
    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange
        const string countryName = "Iran";
        const string cityName = "Tehran";
        const string regionName = "Tehran";
        const string address = null!;


        // act
        var userAddress = new UserAddressBuilder()
            .WithCountry(countryName)
            .WithCityName(cityName)
            .WithRegionName(regionName)
            .WithAddress(address)
            .Build();

        // assert
        userAddress.CountryName.Should().Be(countryName);
        userAddress.CityName.Should().Be(cityName);
        userAddress.RegionName.Should().Be(regionName);
        userAddress.Address.Should().Be(address);
    }

    [Fact]
    public void TestEquality_WhenEverythingIsOk_MustBeTrue()
    {
        const string countryName = "Iran";
        const string cityName = "Tehran";
        const string regionName = "Tehran";
        const string address = null!;

        var first = new UserAddressBuilder()
            .WithCountry(countryName)
            .WithCityName(cityName)
            .WithRegionName(regionName)
            .WithAddress(address)
            .Build(); 
        var second = new UserAddressBuilder()
            .WithCountry(countryName)
            .WithCityName(cityName)
            .WithRegionName(regionName)
            .WithAddress(address)
            .Build();

        first.Should().Be(second);
    }
}