using Worker.Domain.Entities;

namespace Worker.Application.Common.Messaging.Events;

public record WorkerCreatedEvent(Employee Employee) : IntegrationEvent;
