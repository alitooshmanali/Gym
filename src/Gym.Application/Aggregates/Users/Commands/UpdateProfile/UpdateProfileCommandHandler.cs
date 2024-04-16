using Gym.Application.Properties;
using Gym.Domain.Aggregates.Users.ValueObjects;
using Gym.Domain.Exceptions;
using MediatR;
using User = Gym.Domain.Aggreagtes.Users.User;

namespace Gym.Application.Aggregates.Users.Commands.UpdateProfile;

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
{
    private readonly IUserWriteRepository _writeRepository;

    public UpdateProfileCommandHandler(IUserWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await _writeRepository.GetByUsername(request.CurrentUsername, cancellationToken)
            .ConfigureAwait(false);

        if (user is null)
            throw new DomainException(string.Format(ApplicationResources.Global_UnableToFind, nameof(User)));

        var userAddress = UserAddress.Create(request.CountryName
            , request.CityName
            , request.RegionName
            , request.Address);

        user.ChangeUserAddress(userAddress, request.UpdaterId);
    }
}