using System;
using System.Collections.Generic;
using System.Text;

namespace Questão1.NotificationContext
{
    public abstract class Notifiable
    {
        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }
        
        public void AddNotifications(List<Notification> notifications)
        {
            Notifications.AddRange(notifications);
        }

        public void PrintNotification()
        {
            foreach(Notification notification in Notifications)
            {
                Console.WriteLine(notification.Message()); 
            }
        }

    }
}
