using System;
using System.Collections.Generic;
using System.Text;
using BaltaMaoMassa.SharedContext;

namespace BaltaMaoMassa.SubscriptionContext
{
    public class Subscription : Base
    {

        public Plan plan { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsInactive => EndDate <= DateTime.Now;

    }
}
