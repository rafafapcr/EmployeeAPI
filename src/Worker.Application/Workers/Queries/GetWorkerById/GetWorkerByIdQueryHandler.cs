using MediatR;
using Worker.Application.Data;
using Worker.Application.Workers.Queries.GetWorkerById;
using Worker.Domain.Entities;

public class GetWorkerByIdQueryHandler : IRequestHandler<GetWorkerByIdQuery, Employee?>
{
    private readonly IApplicationDbContext _context;

    public GetWorkerByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> Handle(GetWorkerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Employees.FindAsync(new object[] { request.Id }, cancellationToken);
    }
}