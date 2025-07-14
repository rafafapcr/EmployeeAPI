using Worker.Domain.Abstractions;
using Worker.Domain.Entities;

namespace Worker.Domain.Events;

public record OrderUpdatedEvent(Order order) : IDomainEvent;
