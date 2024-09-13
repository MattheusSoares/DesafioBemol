using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ApiUm.Filters;

public class PerformanceFilter : IActionFilter
{
    private Stopwatch _stopwatch;

    public PerformanceFilter()
    {
        _stopwatch = new();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch = Stopwatch.StartNew();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();
        var elapsedTime = _stopwatch.Elapsed;
        var path = context.HttpContext.Request.Path;
        var method = context.HttpContext.Request.Method;

        Console.WriteLine($"Tempo de execução da request {method} {path}: {elapsedTime.TotalMilliseconds} ms.");
    }
}
