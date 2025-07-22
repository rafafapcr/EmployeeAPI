using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Worker.Application.Data;
using Worker.Application.Workers.Commands.CreateWorker;
using Worker.Domain.Entities;
using Xunit;
using Microsoft.EntityFrameworkCore;

public class CreateWorkerCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldAddEmployeeAndReturnId()
    {
        // Arrange
        var mockSet = new Mock<DbSet<Employee>>();
        var mockContext = new Mock<IApplicationDbContext>();
        mockContext.Setup(m => m.Employees).Returns(mockSet.Object);
        mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var handler = new CreateWorkerCommandHandler(mockContext.Object);

        var command = new CreateWorkerCommand
        {
            Name = "Test User",
            Registration = 123,
            Email = "test@domain.com",
            Password = "password",
            PositionId = 1,
            Active = true
        };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        mockSet.Verify(m => m.Add(It.IsAny<Employee>()), Times.Once);
        mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        Assert.NotEqual(Guid.Empty, result);
    }
}