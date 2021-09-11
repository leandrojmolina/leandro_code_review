using App.Domain.Notifications;
using System.Collections.Generic;


namespace App.Domain.Interfaces
{
    public interface INotifier
    {
        bool HaveNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
