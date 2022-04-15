using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa2.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public int Life { get; private set; }

        public Player(string name,string dscp)
        {
            Name = name;
            Description = dscp;
            Life = 3;
        }

        public void LostLive(int dmg)
        {
            Life -= dmg;
        }
    }
}
