using MediatR;

namespace Worker.Application.Workers.Commands.DeleteWorker;

public sealed record DeleteWorkerCommand(Guid Id) : IRequest<bool>;