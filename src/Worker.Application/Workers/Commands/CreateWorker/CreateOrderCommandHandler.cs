using MediatR;
using Worker.Application.Common.Messaging;
using Worker.Application.Common.Messaging.Events;
using Worker.Application.Data;
using Worker.Domain.Entities;
using Worker.Domain.ValueObjects;

namespace Worker.Application.Orders.Commands.CreateOrder;

public sealed class CreateOrderCommandHandler(
    IApplicationDbContext dbContext, IEventBus eventBus) : IRequestHandler<CreateWorkerCommand, Guid>
{
    public async Task<Guid> Handle(CreateWorkerCommand command, CancellationToken cancellationToken)
    {
        var newOrder = Order.Create(
            OrderId.Of(Guid.NewGuid()),
            CustomerId.Of(command.CustomerId)
        );

        foreach (var item in command.OrderItems)
        {
            newOrder.Add(
                ProductId.Of(item.ProductId),
                item.Quantity,
                item.Price
            );
        }

        dbContext.Orders.Add(newOrder);
        await dbContext.SaveChangesAsync(cancellationToken);

        var orderEvent = new OrderCreatedEvent(newOrder);

        await eventBus.PublishAsync(orderEvent, "order-created");

        return newOrder.Id.Value;
    }
}
