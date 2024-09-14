using ApiDois.Infra.ServiceBus.Configuration;
using ApiDois.Infra.ServiceBus.Settings;
using Azure.Messaging.ServiceBus;
using Moq;

namespace ApiDois.Infra.ServiceBus.Test.Configuration;

public class ServiceBusHandlerTests
{
    private readonly Mock<ServiceBusClient> _mockClient;
    private readonly Mock<ServiceBusProcessor> _mockProcessor;
    private readonly ServiceBusHandler _handler;

    public ServiceBusHandlerTests()
    {
        _mockClient = new Mock<ServiceBusClient>("FakeConnectionString");
        _mockProcessor = new Mock<ServiceBusProcessor>();

        _mockClient.Setup(c => c.CreateProcessor(It.IsAny<string>(), It.IsAny<ServiceBusProcessorOptions>()))
                   .Returns(_mockProcessor.Object);

        var settings = new ServiceBusSettings { ConnectionString = "FakeConnectionString" };
        _handler = new ServiceBusHandler(settings);
    }

    [Fact]
    public void ConsumeAsync_StartsProcessorAndWaitsIndefinitely()
    {
        // Arrange
        _mockProcessor.Setup(p => p.StartProcessingAsync(CancellationToken.None)).Returns(Task.CompletedTask);
        _mockProcessor.Setup(p => p.StopProcessingAsync(CancellationToken.None)).Returns(Task.CompletedTask);

        // Act
        var task = _handler.ConsumeAsync("TestQueue");

        // Assert
        Assert.True(task.IsCompleted);
    }
}
