using MediatR;
using Microsoft.EntityFrameworkCore;
using Worker.Application.Data;
using Worker.Application.Workers.Queries.GetAllWorkers;
using Worker.Domain.Entities;

public class GetAllWorkersQueryHandler : IRequestHandler<GetAllWorkersQuery, List<Employee>>
{
    private readonly IApplicationDbContext _context;

    public GetAllWorkersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Employees.ToListAsync(cancellationToken);
    }
}