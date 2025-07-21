using MediatR;
using Worker.Domain.Entities;

namespace Worker.Application.Workers.Queries.GetAllWorkers;
public sealed record GetAllWorkersQuery() : IRequest<List<Employee>>;