namespace Worker.Application.Workers.DTOs;

public sealed record PositonDto(Guid ProductId, int Quantity, decimal Price);
