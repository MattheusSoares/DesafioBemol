using ApiUm.Domain.Characters.Commands.Input;
using ApiUm.Domain.Characters.Commands.Result;
using ApiUm.Domain.Characters.Interfaces.Handlers;
using ApiUm.Domain.Characters.Interfaces.Repositories;
using ApiUm.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ApiUm.Controllers.Characters;

[ApiController]
[ServiceFilter(typeof(AuthenticationFilter))]
public class CharacterController : ControllerBase
{
    private readonly ICharacterRepository _repository;
    private readonly ICharacterHandler _handler;

    public CharacterController(ICharacterRepository repository,
                               ICharacterHandler handler)
    {
        _repository = repository;
        _handler = handler;
    }

    /// <summary>
    /// Add Character
    /// </summary>                
    /// <remarks><h2><b>Add new Character.</b></h2></remarks>
    /// <response code="201">Created</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="422">Unprocessable Entity</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost]
    [Route("v1/characters")]
    [ProducesResponseType(typeof(CharacterCommandResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CharacterCommandResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CharacterCommandResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(CharacterCommandResult), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(CharacterCommandResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CharactersAsync([FromBody] CharacterAddCommand command)
    {
        var response = await _handler.InsertAsync(command);

        return StatusCode(response.StatusCode, response);
    }


    /// <summary>
    /// Characters
    /// </summary>                
    /// <remarks><h2><b>List all Character.</b></h2></remarks>
    /// <response code="200">OK Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet]
    [Route("v1/characters")]
    [ProducesResponseType(typeof(List<CharacterCommandResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<CharacterCommandResult>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(List<CharacterCommandResult>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CharactersAsync()
    {
        return Ok(await _repository.ListAsync());
    }
}
