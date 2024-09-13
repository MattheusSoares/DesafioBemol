using System.Text.Json.Serialization;

namespace ApiUm.Domain.Shared.Notifications;

public class Notifier
{
    [JsonIgnore]
    public bool Valid { get; private set; }

    [JsonIgnore]
    public bool Invalid { get; private set; }

    [JsonIgnore]
    public IReadOnlyCollection<Notification> Notifications => _notifications.ToList();

    private readonly IList<Notification> _notifications;

    public Notifier()
    {
        _notifications = new List<Notification>();
        Invalid = false;
        Valid = true;
    }

    public void AddNotification(string property, string message)
    {
        Inactivate();
        _notifications.Add(new Notification(property, message));
    }

    public void AddNotification(IReadOnlyCollection<Notification> notifications)
    {
        if (notifications != null && notifications.Count > 0)
        {
            Inactivate();
            foreach (var notification in notifications)
                _notifications.Add(notification);
        }
    }

    private void Inactivate()
    {
        Valid = false;
        Invalid = true;
    }
}
