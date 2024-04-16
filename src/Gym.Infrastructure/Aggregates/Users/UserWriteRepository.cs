using Gym.Application.Aggregates.Users;
using Gym.Domain.Aggreagtes.Users;
using Microsoft.EntityFrameworkCore;

namespace Gym.Infrastructure.Aggregates.Users;

public class UserWriteRepository: IUserWriteRepository
{
    private readonly GymWriteDbContext _dbContext;

    public UserWriteRepository(GymWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Users.Add(user);
    }

    public Task<User?> GetByUsername(string username, CancellationToken cancellationToken = default)
    {
        return _dbContext.Users
            .Where(i => i.Username.Value == username)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public void Remove(User user, Guid deleterId)
    {
        user.Delete(deleterId);
        _dbContext.Users.Remove(user);
    }
}