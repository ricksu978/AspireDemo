using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AspireDemo.Domain.Common.Interfaces;
using AspireDemo.Domain.Teams;

namespace AspireDemo.Infrastructure.Persistence.Configuration;

public class MissionConfiguration : AuditableConfiguration<Mission>
{
    public override void PostConfigure(EntityTypeBuilder<Mission> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Description)
            .HasMaxLength(Mission.DescriptionMaxLength)
            .IsRequired();
    }
}