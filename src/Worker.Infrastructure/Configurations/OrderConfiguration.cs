using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worker.Domain.Entities;
using Worker.Domain.Enums;
using Worker.Domain.ValueObjects;

namespace Worker.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id).HasConversion(
                        orderId => orderId.Value,
                        dbId => OrderId.Of(dbId));

        builder.HasOne<Customer>()
          .WithMany()
          .HasForeignKey(o => o.CustomerId)
          .IsRequired();

        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId);

        builder.Property(o => o.Status)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

        builder.Property(o => o.TotalPrice);
    }
}
