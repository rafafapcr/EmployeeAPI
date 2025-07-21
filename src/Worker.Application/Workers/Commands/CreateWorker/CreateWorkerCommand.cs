using MediatR;

namespace Worker.Application.Workers.Commands.CreateWorker;

public sealed record CreateWorkerCommand : IRequest<Guid>
{
    public string Name { get; init; } = string.Empty;
    public int Registration { get; init; }
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public int PositionId { get; init; }
    public bool Active { get; init; }
}
