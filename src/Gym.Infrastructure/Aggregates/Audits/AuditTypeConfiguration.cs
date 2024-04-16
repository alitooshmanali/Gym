using Gym.Application.Aggregates.Audits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Aggregates.Audits;

public class AuditTypeConfiguration: IEntityTypeConfiguration<Audit>
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder.ToTable(nameof(GymWriteDbContext.Audits));

        builder.HasKey(x => x.Id);
        builder.Property(i => i.Action).IsRequired();
        builder.Property(i => i.Data).IsRequired();
        builder.Property(i => i.Client).IsRequired();
        builder.Property(i => i.ClientAddress).IsRequired();
    }
}