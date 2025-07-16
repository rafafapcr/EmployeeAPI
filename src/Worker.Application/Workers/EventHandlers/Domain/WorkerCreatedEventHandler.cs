using MediatR;
using Microsoft.Extensions.Logging;
using Worker.Application.Common.Messaging;
using WorkerCreatedEvent = Worker.Domain.Events.WorkerCreatedEvent;

namespace Worker.Application.Workers.EventHandlers.Domain;

public class WorkerCreatedEventHandler(
    IEventBus eventBus, ILogger<WorkerCreatedEventHandler> logger)
    : INotificationHandler<WorkerCreatedEvent>
{
    public async Task Handle(WorkerCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

        await eventBus.PublishAsync(domainEvent, "worker-created");
    }
}
