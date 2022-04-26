using System;
using System.Collections.Generic;
using System.Text;
using BaltaMaoMassa.SharedContext;

namespace BaltaMaoMassa.SubscriptionContext
{
    public class User : Base
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
