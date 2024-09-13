using ApiUm.Domain.Users.Interfaces.Handlers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ApiUm.Filters;

public class AuthenticationFilter : IAsyncActionFilter
{
    private readonly IUserHandler _handler;

    public AuthenticationFilter(IUserHandler handler)
    {
        _handler = handler;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var header = context.HttpContext.Request.Headers["X-Authorization"].ToString();

        var isTokenValid = _handler.ValidateToken(header);

        if (!isTokenValid)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}
