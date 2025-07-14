using MediatR;
using Microsoft.Extensions.Logging;
using Worker.Application.Common.Messaging;
using Worker.Application.Common.Messaging.Events;

namespace Worker.Application.Workers.EventHandlers.Integration;

public class WorkerAcceptedEventHandler(ISender sender, ILogger<WorkerAcceptedEventHandler> logger)
    : IIntegrationEventHandler<WorkerAcceptedEvent>
{
    public async Task Handle(WorkerAcceptedEvent @event)
    {
        logger.LogInformation("Worker {EmployeeId} was accepted by Kitchen.", @event.order.Id);

        // update order status to Accepted
        //await sender.Send(new UpdateOrderStatusCommand(@event.order.Id, OrderStatus.Processing));

        await Task.CompletedTask;
    }
}
