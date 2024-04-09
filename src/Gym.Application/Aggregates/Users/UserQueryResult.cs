namespace Gym.Application.Aggregates.Users;

public class UserQueryResult
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string CountryName { get; set; }

    public string CityName { get; set; }

    public string RegionName { get; set; }

    public string Address { get; set; }

    public bool IsActive { get; set; }

    public int Version { get; set; }
}