using MediatR;
using Worker.Application.Workers.DTOs;

namespace Worker.Application.Workers.Commands.CreateOrder;

public sealed record CreateWorkerCommand : IRequest<Guid>
{
    public Guid CustomerId { get; init; }
    public List<OrderItemDto> OrderItems { get; init; } = new List<OrderItemDto>();
}
