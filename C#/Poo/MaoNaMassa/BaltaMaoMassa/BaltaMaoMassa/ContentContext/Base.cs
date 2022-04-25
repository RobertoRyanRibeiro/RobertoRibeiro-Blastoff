using System;
using System.Collections.Generic;
using System.Text;
using BaltaMaoMassa.NotificationContext;

namespace BaltaMaoMassa.ContentContext
{
    public abstract class Base : Notifiable
    {
        public Base()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
