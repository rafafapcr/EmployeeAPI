using Worker.Domain.Abstractions;
using Worker.Domain.Entities;

namespace Worker.Domain.Events;

public record WorkerUpdatedEvent(Employee Employee) : IDomainEvent;
