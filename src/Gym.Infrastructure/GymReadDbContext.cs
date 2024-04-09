using System.Reflection;
using Gym.Application.Aggregates.Users;
using Microsoft.EntityFrameworkCore;

namespace Gym.Infrastructure;

public class GymReadDbContext : DbContext
{
    public GymReadDbContext(DbContextOptions<GymReadDbContext> options)
    : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
    }

    public DbSet<UserQueryResult> UserQueryResults { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("citext");
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}