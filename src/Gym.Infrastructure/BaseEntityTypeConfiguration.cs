using Gym.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure;

public abstract class BaseEntityTypeConfiguration<T>: IEntityTypeConfiguration<T>
    where T: Entity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property<Guid>("CreatorId");
        builder.Property<Guid?>("UpdaterId");
        builder.Property<DateTimeOffset>("Created");
        builder.Property<DateTimeOffset?>("Updated");
        builder.Property<int>("Version").IsConcurrencyToken();
    }
}