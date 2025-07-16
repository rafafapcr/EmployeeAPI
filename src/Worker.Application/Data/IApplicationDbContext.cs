using Microsoft.EntityFrameworkCore;
using Worker.Domain.Entities;

namespace Worker.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Employee> Employees { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
