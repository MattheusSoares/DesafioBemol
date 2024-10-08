﻿namespace ApiUm.Domain.Shared.Notifications;

public sealed class Notification
{
    public string Property { get; private set; }
    public string Message { get; private set; }

    public Notification() { }

    public Notification(string property, string message)
    {
        Property = property;
        Message = message;
    }
}
