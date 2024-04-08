using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users.Events;

public class UserAddressChangedEvent : BaseDomainEvent
{
    public UserAddressChangedEvent(UserId id, UserAddress oldValue, UserAddress newValue, Guid updaterId) 
        : base(id.Value)
    {
        OldCountryName = oldValue?.CountryName;
        OldCityName = oldValue?.CityName;
        OldRegionName = oldValue?.RegionName;
        OldAddress = oldValue?.Address;
        NewCountryName = newValue?.CountryName;
        NewCityName = newValue?.CityName;
        NewRegionName = newValue?.RegionName;
        NewAddress = newValue?.Address;
        UpdaterId = updaterId;
    }

    public Guid UpdaterId { get; }

    public string? NewAddress { get; }

    public string? NewRegionName { get; }

    public string? NewCityName { get; }

    public string? NewCountryName { get; }

    public string? OldAddress { get; }

    public string? OldRegionName { get; }

    public string? OldCityName { get; }

    public string? OldCountryName { get; }
}