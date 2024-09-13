using Microsoft.AspNetCore.Mvc;

namespace ApiUm.Controllers.Exceptions;

public class ExceptionController : ControllerBase
{
    /// <summary>
    /// Exception
    /// </summary>                
    /// <remarks><h2><b>Throw an Exception.</b></h2></remarks>
    /// <response code="500">Internal Server Error</response>
    [HttpPost]
    [Route("v1/error")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status500InternalServerError)]
    public IActionResult Error()
    {
        throw new Exception("Isso é uma exceção para o ExceptionFilter");
    }
}
