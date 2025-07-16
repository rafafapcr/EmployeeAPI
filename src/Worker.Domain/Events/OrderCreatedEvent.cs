using Worker.Domain.Abstractions;
using Worker.Domain.Entities;

namespace Worker.Domain.Events;

public record WorkerCreatedEvent(Employee Employee) : IDomainEvent;
