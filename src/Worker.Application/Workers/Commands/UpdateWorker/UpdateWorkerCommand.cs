using MediatR;

namespace Worker.Application.Workers.Commands.UpdateWorker;
public sealed record UpdateWorkerCommand : IRequest<bool>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Position { get; init; }
    public bool Active { get; init; }
}