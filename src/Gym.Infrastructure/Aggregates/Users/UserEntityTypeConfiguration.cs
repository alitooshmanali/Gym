using Gym.Domain.Aggreagtes.Users.ValueObjects;
using Gym.Domain.Aggregates.Users.ValueObjects;
using Gym.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User = Gym.Domain.Aggreagtes.Users.User;

namespace Gym.Infrastructure.Aggregates.Users;

public class UserEntityTypeConfiguration : BaseEntityTypeConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(GymWriteDbContext.Users));

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(i => i.Id)
            .HasConversion(i => i.Value, i => UserId.Create(i));

        builder.Property(i => i.Username)
            .HasConversion(i => i.Value, i => Username.Create(i));
        builder.Property(i => i.Password)
            .HasConversion(i => PasswordHashProvider.HashPassword(i.Value), i => UserPassword.Create(i));

        builder.Property(i => i.IsActive)
            .HasConversion(i => i.Value, i => UserActivation.Create(i));

        base.Configure(builder);
    }
}