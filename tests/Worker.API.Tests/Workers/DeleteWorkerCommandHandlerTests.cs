using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Worker.Application.Data;
using Worker.Application.Workers.Commands.DeleteWorker;
using Worker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class DeleteWorkerCommandHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsTrue_WhenEmployeeIsDeleted()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var employee = Employee.Create("Test", 1, "test@domain.com", "password", 1, true);

        var mockSet = new Mock<DbSet<Employee>>();
        var mockContext = new Mock<IApplicationDbContext>();
        mockContext.Setup(m => m.Employees.FindAsync(new object[] { employeeId }, It.IsAny<CancellationToken>()))
                   .ReturnsAsync(employee);
        mockContext.Setup(m => m.Employees).Returns(mockSet.Object);
        mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var handler = new DeleteWorkerCommandHandler(mockContext.Object);
        var command = new DeleteWorkerCommand { Id = employeeId };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        mockSet.Verify(m => m.Remove(employee), Times.Once);
        mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        Assert.True(result);
    }

    [Fact]
    public async Task Handle_ReturnsFalse_WhenEmployeeNotFound()
    {
        // Arrange
        var employeeId = Guid.NewGuid();

        var mockSet = new Mock<DbSet<Employee>>();
        var mockContext = new Mock<IApplicationDbContext>();
        mockContext.Setup(m => m.Employees.FindAsync(new object[] { employeeId }, It.IsAny<CancellationToken>()))
                   .ReturnsAsync((Employee)null);
        mockContext.Setup(m => m.Employees).Returns(mockSet.Object);

        var handler = new DeleteWorkerCommandHandler(mockContext.Object);
        var command = new DeleteWorkerCommand { Id = employeeId };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        mockSet.Verify(m => m.Remove(It.IsAny<Employee>()), Times.Never);
        mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        Assert.False(result);
    }
}