using System;
using System.Collections.Generic;
using System.Text;
using BaltaMaoMassa.NotificationContext;

namespace BaltaMaoMassa.ContentContext
{
   public class CarrerItem : Base
    { 
        public CarrerItem(int order, string title, string description, Course course)
        {
            if (course == null)
                AddNotification(new Notification("Course","Curso Invalido")); 

            Order = order;
            Title = title;
            Description = description;
            Course = course;
        }

        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }

    }
}
