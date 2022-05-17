using BaltaMaoMassa.SharedContext;
using BaltaMaoMassa.NotificationContext;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BaltaMaoMassa.SubscriptionContext
{
    public class Student : Base
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public User User { get; set; }

        public IList<Subscription> Subscriptions { get; set; }
        public bool IsPremium => Subscriptions.Any(x => !x.IsInactive);

        public void CreateSubscription(Subscription subscription)
        {
            if (IsPremium)
            {
                AddNotification(new Notification("Premium", "O aluno já tem uma assinatura ativa"));
            }

            Subscriptions.Add(subscription);

        }

        public Student()
        {
            Subscriptions = new List<Subscription>();
        }

    }
}
