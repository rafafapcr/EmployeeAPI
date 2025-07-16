namespace Worker.Application.Exceptions;

public class WorkerNotFoundException : NotFoundException
{
    public WorkerNotFoundException(Guid id) : base("Worker", id)
    {
    }
}