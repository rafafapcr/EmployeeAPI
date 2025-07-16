using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worker.Domain.Entities;

namespace Worker.Infrastructure.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.CreatedAt);
        builder.Property(p => p.CreatedBy)
            .HasMaxLength(100);
        builder.Property(p => p.LastModified);
        builder.Property(p => p.LastModifiedBy)
            .HasMaxLength(100);
    }
}