using ApiUm.Controllers.Users;
using ApiUm.Domain.Shared.Commands.Result;
using ApiUm.Domain.Users.Commands.Input;
using ApiUm.Domain.Users.Commands.Result;
using ApiUm.Domain.Users.Interfaces.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApiUm.Test.Controllers.Users;

public class UserControllerTests
{
    private readonly Mock<IUserHandler> _mockHandler;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _mockHandler = new Mock<IUserHandler>();
        _controller = new UserController(_mockHandler.Object);
    }

    [Fact]
    public void Login_Success_ReturnsOk()
    {
        // Arrange
        var command = new UserLoginCommand();

        var result = new CommandResult(
            StatusCodes.Status200OK,
            "Login successful",
            new UserLoginCommandResult
            {
                Token = "sampleToken"
            }
        );

        _mockHandler.Setup(h => h.Login(command))
            .Returns(result);

        // Act
        var response = _controller.Login(command);

        // Assert
        var actionResult = Assert.IsType<ObjectResult>(response);
        Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
    }

    [Fact]
    public void Login_Unauthorized_ReturnsUnauthorized()
    {
        // Arrange
        var command = new UserLoginCommand();

        var result = new CommandResult(
            StatusCodes.Status401Unauthorized,
            "Unauthorized"
        );

        _mockHandler.Setup(h => h.Login(command))
            .Returns(result);

        // Act
        var response = _controller.Login(command);

        // Assert
        var actionResult = Assert.IsType<ObjectResult>(response);
        Assert.Equal(StatusCodes.Status401Unauthorized, actionResult.StatusCode);
    }

    [Fact]
    public void Login_InternalServerError_ReturnsInternalServerError()
    {
        // Arrange
        var command = new UserLoginCommand();

        var result = new CommandResult(
            StatusCodes.Status500InternalServerError,
            "Internal Server Error"
        );

        _mockHandler.Setup(h => h.Login(command))
            .Returns(result);

        // Act
        var response = _controller.Login(command);

        // Assert
        var actionResult = Assert.IsType<ObjectResult>(response);
        Assert.Equal(StatusCodes.Status500InternalServerError, actionResult.StatusCode);
    }
}
