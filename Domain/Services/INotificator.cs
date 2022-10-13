using Domain.Entities.Notifications;

namespace Domain.Services
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
