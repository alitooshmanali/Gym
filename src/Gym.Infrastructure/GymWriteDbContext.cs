using System.Reflection;
using Gym.Domain.Aggregates.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gym.Infrastructure;

public class GymWriteDbContext : DbContext
{
    public GymWriteDbContext(DbContextOptions<GymWriteDbContext> options)
    : base(options)
    {
    }

    public DbSet<User> Users { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("citext");
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

#if DEBUG
public class DesignTimeResourceDbContextFactory : IDesignTimeDbContextFactory<GymWriteDbContext>
{
    public GymWriteDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<GymWriteDbContext>();

        builder.UseNpgsql("Username=U;Password=P;Database=D;Host=127.0.0.1");

        return new(builder.Options);
    }
}
#endif