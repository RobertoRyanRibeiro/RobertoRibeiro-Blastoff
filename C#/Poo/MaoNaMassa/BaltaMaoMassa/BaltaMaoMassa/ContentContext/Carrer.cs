using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaMaoMassa.ContentContext
{
    public class Carrer : Content
    {
        public IList<CarrerItem> Items { get;  set; }
        //public int TotalCourses { get { return Items.Count; } }
        public int TotalCourses => Items.Count;
    } 
}
