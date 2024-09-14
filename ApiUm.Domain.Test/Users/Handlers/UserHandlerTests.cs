using ApiUm.Domain.Shared.Settings;
using ApiUm.Domain.Users.Commands.Input;
using ApiUm.Domain.Users.Commands.Result;
using ApiUm.Domain.Users.Handlers;
using Microsoft.AspNetCore.Http;

namespace ApiUm.Domain.Test.Users.Handlers;

public class UserHandlerTests
{
    private readonly UserHandler _userHandler;
    private readonly AuthenticationSettings _settings;

    public UserHandlerTests()
    {
        _settings = new AuthenticationSettings
        {
            SecurityKey = "u18VAySjfgQCqwFp7kejg4a1JYGiYePR"
        };

        _userHandler = new UserHandler(_settings);
    }

    [Fact]
    public void Login_WithValidCredentials_ReturnsSuccess()
    {
        // Arrange
        var command = new UserLoginCommand
        {
            Username = "user",
            Password = "pass"
        };

        // Act
        var result = _userHandler.Login(command);

        // Assert
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal("Login successful", result.Message);

        var commandResult = Assert.IsType<UserLoginCommandResult>(result.Data);
        Assert.NotNull(commandResult.Token);
    }

    [Fact]
    public void Login_WithInvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange
        var command = new UserLoginCommand
        {
            Username = "invalid_user",
            Password = "invalid_pass"
        };

        // Act
        var result = _userHandler.Login(command);

        // Assert
        Assert.Equal(StatusCodes.Status401Unauthorized, result.StatusCode);
        Assert.Equal("Invalid credentials", result.Message);
    }

    [Fact]
    public void ValidateToken_WithValidToken_ReturnsTrue()
    {
        // Arrange
        var command = new UserLoginCommand
        {
            Username = "user",
            Password = "pass"
        };

        var loginResult = _userHandler.Login(command);
        var commandResult = Assert.IsType<UserLoginCommandResult>(loginResult.Data);
        var token = commandResult.Token;

        // Act
        var isValid = _userHandler.ValidateToken(token);

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void ValidateToken_WithInvalidToken_ReturnsFalse()
    {
        // Arrange
        var invalidToken = "invalid_token";

        // Act
        var isValid = _userHandler.ValidateToken(invalidToken);

        // Assert
        Assert.False(isValid);
    }
}
