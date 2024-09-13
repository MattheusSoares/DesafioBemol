using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ApiUm.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var response = new
        {
            Error = context.Exception.Message,
            context.Exception.StackTrace
        };

        context.Result = new JsonResult(response)
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Value = response
        };

        context.ExceptionHandled = true;
    }
}
