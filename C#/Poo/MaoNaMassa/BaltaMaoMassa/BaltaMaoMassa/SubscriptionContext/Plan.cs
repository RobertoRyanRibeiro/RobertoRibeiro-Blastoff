using System;
using System.Collections.Generic;
using System.Text;
using BaltaMaoMassa.SharedContext;

namespace BaltaMaoMassa.SubscriptionContext
{
    public class Plan : Base
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

    }
}
