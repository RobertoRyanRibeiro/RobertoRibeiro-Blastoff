using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa2.Entities
{
    public class AIGamble
    {
        //Attributes
        private Player player;
        private int defaultLimit = 5;

        //The limit of the array during the game
        public int MaxLimiter { get; private set; }
        public int Number { get; private set; }
        public bool Win { get; private set; }

        //Maybe Tips

        public AIGamble(Player ply)
        {
            MaxLimiter = defaultLimit;
            Number = 0;
            Win = false;
            player = ply;
        }

        public AIGamble(int maxLimiter, Player ply)
        {
            MaxLimiter = maxLimiter;
            Number = 0;
            Win = false;
            player = ply;
        }

        public void Edit(int maxLimiter)
        {
            MaxLimiter = maxLimiter;
        }

        public void Start()
        {
            var rand = new Random();
            Number = (rand.Next(MaxLimiter));
        }

        public void Play(int value)
        {
            if (value == Number)
                Win = true;
            else
                player.LostLive(1);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            if (Win)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                result.AppendLine("+Parabéns você Ganhou!!!+");
            }
            else if (player.Life <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                result.AppendLine("-Que pena, você Perdeu...-");
            }

            Console.ForegroundColor = ConsoleColor.White;
            result.AppendLine("");
            result.AppendLine("====================================");
            result.AppendLine("Aperte Qualquer tecla para continuar");

            return result.ToString();
        }
    }
}
