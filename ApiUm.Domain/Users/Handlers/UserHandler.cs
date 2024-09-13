using ApiUm.Domain.Shared.Commands.Result;
using ApiUm.Domain.Shared.Settings;
using ApiUm.Domain.Users.Commands.Input;
using ApiUm.Domain.Users.Commands.Result;
using ApiUm.Domain.Users.Interfaces.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiUm.Domain.Users.Handlers;

public class UserHandler : IUserHandler
{
    private readonly AuthenticationSettings _settings;

    public UserHandler(AuthenticationSettings settings)
    {
        _settings = settings;
    }

    public CommandResult Login(UserLoginCommand command)
    {
        var expectedUsername = "user";
        var expectedPassword = "pass";

        if (command.Username != expectedUsername || command.Password != expectedPassword)
            return new CommandResult(StatusCodes.Status401Unauthorized, "Invalid credentials");

        var secretKey = _settings.SecurityKey;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, command.Username)
        };

        var token = new JwtSecurityToken(
            issuer: "my_issuer.com",
            audience: "my_audience.com",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        var commandResult = new UserLoginCommandResult()
        {
            Token = jwtToken,
        };

        return new CommandResult(StatusCodes.Status200OK, "Login successful", commandResult);
    }

    public bool ValidateToken(string jwtToken)
    {
        var secretKey = _settings.SecurityKey;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "my_issuer.com",
            ValidAudience = "my_audience.com",
            IssuerSigningKey = key,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            tokenHandler.ValidateToken(jwtToken, validationParameters, out SecurityToken validatedToken);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

