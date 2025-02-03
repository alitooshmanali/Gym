namespace Gym.API.V1.Aggregates.Users.Models
{
    public class UserResponse
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
}
