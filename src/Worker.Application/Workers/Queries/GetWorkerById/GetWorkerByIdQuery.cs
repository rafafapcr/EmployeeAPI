using MediatR;
using Worker.Domain.Entities;

namespace Worker.Application.Workers.Queries.GetWorkerById;
public sealed record GetWorkerByIdQuery(Guid Id) : IRequest<Employee>;