using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worker.Domain.Entities;

namespace Worker.Infrastructure.Configurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Registration)
            .IsRequired();

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Password)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.PositionId)
            .IsRequired();

        builder.Property(e => e.Active)
            .IsRequired();

        builder.Property(e => e.CreatedAt);
        builder.Property(e => e.CreatedBy)
            .HasMaxLength(100);
        builder.Property(e => e.LastModified);
        builder.Property(e => e.LastModifiedBy)
            .HasMaxLength(100);
    }
}