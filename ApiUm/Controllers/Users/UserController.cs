using ApiUm.Domain.Characters.Commands.Result;
using ApiUm.Domain.Users.Commands.Input;
using ApiUm.Domain.Users.Interfaces.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ApiUm.Controllers.Users;

public class UserController : ControllerBase
{
    private readonly IUserHandler _handler;

    public UserController(IUserHandler handler)
    {
        _handler = handler;
    }

    /// <summary>
    /// User Login
    /// </summary>                
    /// <remarks><h2><b>Authenticate the User.</b></h2></remarks>
    /// <response code="200">OK Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost]
    [Route("v1/login")]
    [ProducesResponseType(typeof(CharacterCommandResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CharacterCommandResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(CharacterCommandResult), StatusCodes.Status500InternalServerError)]
    public IActionResult Login([FromBody] UserLoginCommand command)
    {
        var response = _handler.Login(command);

        return StatusCode(response.StatusCode, response);
    }
}
