using Worker.Domain.Entities;

namespace Worker.Application.Common.Messaging.Events;

public record WorkerAcceptedEvent(Order order) : IntegrationEvent;
