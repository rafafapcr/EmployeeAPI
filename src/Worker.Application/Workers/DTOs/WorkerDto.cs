public class WorkerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int PositionId { get; set; }  // Nome amigável
    public bool Active { get; set; }

}