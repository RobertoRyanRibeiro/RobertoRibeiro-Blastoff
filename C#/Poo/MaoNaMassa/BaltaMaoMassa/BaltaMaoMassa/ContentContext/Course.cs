﻿using System;
using System.Collections.Generic;
using System.Text;
using BaltaMaoMassa.ContentContext.Enums;

namespace BaltaMaoMassa.ContentContext
{
    public class Course : Content
    {
        public string Tag { get; set; }
        public IList<Module> Modules { get; set; }
        public EContentLevel Level { get; set; }

        public Course()
        {
            Modules = new List<Module>();
        }
    }
}
