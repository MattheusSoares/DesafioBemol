using Google.Protobuf.WellKnownTypes;
using LibContract;
using Microsoft.AspNetCore.Mvc;
using static LibContract.MonsterService;

namespace ApiDois.Controllers;

public class MonsterController : ControllerBase
{
    private readonly MonsterServiceClient _client;

    public MonsterController(MonsterServiceClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Monster
    /// </summary>                
    /// <remarks><h2><b>Get Monster by Id.</b></h2></remarks>
    /// <response code="200">OK Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet]
    [Route("v1/monsters/{id}")]
    [ProducesResponseType(typeof(MonsterList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(MonsterList), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAsync(string id)
    {
        var monsterLookupModel = new MonsterLookupModel()
        {
            Id = id
        };

        var response = await _client.GetAsync(monsterLookupModel);

        return Ok(response);
    }

    /// <summary>
    /// Monster
    /// </summary>                
    /// <remarks><h2><b>List all Monsters.</b></h2></remarks>
    /// <response code="200">OK Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet]
    [Route("v1/monsters")]
    [ProducesResponseType(typeof(MonsterList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(MonsterList), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetListAsync()
    {
        var response = await _client.GetListAsync(new Empty());

        return Ok(response);
    }

    /// <summary>
    /// Add Monster
    /// </summary>                
    /// <remarks><h2><b>Add new Monster.</b></h2></remarks>
    /// <response code="201">Created</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost]
    [Route("v1/monsters")]
    [ProducesResponseType(typeof(Monster), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Monster), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> InsertAsync([FromBody] NewMonsterRequest request)
    {
        var response = await _client.InsertAsync(request);

        return Ok(response);
    }
}
