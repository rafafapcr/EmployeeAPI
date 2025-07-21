using MediatR;
using Worker.Application.Data;
using Worker.Application.Workers.Commands.DeleteWorker;

public class DeleteWorkerCommandHandler : IRequestHandler<DeleteWorkerCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteWorkerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = await _context.Employees.FindAsync(new object[] { request.Id }, cancellationToken);
        if (worker == null) return false;

        _context.Employees.Remove(worker);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}