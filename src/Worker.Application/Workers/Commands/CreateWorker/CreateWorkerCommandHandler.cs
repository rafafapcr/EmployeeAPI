using MediatR;
using Worker.Domain.Entities;
using Worker.Application.Data;

namespace Worker.Application.Workers.Commands.CreateWorker;

public class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateWorkerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateWorkerCommand command, CancellationToken cancellationToken)
    {
        var employee = Employee.Create(
            command.Name,
            command.Registration,
            command.Email,
            command.Password,
            command.PositionId,
            command.Active        );

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}