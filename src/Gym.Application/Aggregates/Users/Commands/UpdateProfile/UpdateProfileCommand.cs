using MediatR;

namespace Gym.Application.Aggregates.Users.Commands.UpdateProfile;

public class UpdateProfileCommand: IRequest
{
    public string CurrentUsername { get; set; }

    public string CountryName { get; set; }

    public string CityName { get; set; }

    public string RegionName { get; set; }

    public string Address { get; set; }

    public Guid UpdaterId { get; set; }
}