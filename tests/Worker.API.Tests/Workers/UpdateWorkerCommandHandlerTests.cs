using Moq;
using Worker.Application.Data;
using Worker.Application.Workers.Commands.UpdateWorker;
using Worker.Domain.Entities;

public class UpdateWorkerCommandHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsFalse_WhenEmployeeNotFound()
    {
        var mockContext = new Mock<IApplicationDbContext>();
        mockContext.Setup(c => c.Employees.FindAsync(It.IsAny<object[]>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync((Employee)null);

        var handler = new UpdateWorkerCommandHandler(mockContext.Object);
        var command = new UpdateWorkerCommand
        {
            Name = "Test",
            Position = 1,
            Active = true
        };

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.False(result);
    }
}