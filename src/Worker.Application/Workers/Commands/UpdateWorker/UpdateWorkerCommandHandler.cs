using MediatR;
using Worker.Application.Data;
using Worker.Application.Workers.Commands.UpdateWorker;

public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateWorkerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FindAsync(new object[] { request.Id }, cancellationToken);
        if (employee == null) return false;

        employee.UpdateInfo(request.Name, employee.Registration, employee.Email);
        employee.ChangePosition((int)request.Position);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}