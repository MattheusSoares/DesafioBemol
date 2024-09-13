using ApiUm.Domain.Shared.Notifications;

namespace ApiUm.Domain.Shared.Commands.Result;

public class CommandResult
{
    public int StatusCode { get; private set; }
    public bool Success { get; private set; }
    public string? Message { get; private set; }
    public object? Data { get; private set; }
    public List<Notification>? Errors { get; private set; }

    public CommandResult() { }

    public CommandResult(int statusCode, string message, object data = null)
    {
        StatusCode = statusCode;
        Success = true;
        Message = message;
        Data = data;
        Errors = new List<Notification>();
    }

    public CommandResult(int statusCode, string message, IEnumerable<Notification> errors)
    {
        StatusCode = statusCode;
        Success = false;
        Message = message;
        Data = null;
        Errors = errors.ToList();
    }

    public CommandResult(int statusCode, string message, string propertyNotification, string messageNotification)
    {
        StatusCode = statusCode;
        Success = false;
        Message = message;
        Data = null;
        Errors = new List<Notification>() { new Notification(propertyNotification, messageNotification) };
    }
}
