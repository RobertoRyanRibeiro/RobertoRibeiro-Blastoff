using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa2.Entities
{
    public class GambleMatch
    {
        //Attributes
        private int defaultLimit = 5;

        //The limit of the array during the game
        public Player Player { get; private set; }
        public int MaxLimiter { get; private set; }
        public int Number { get; private set; }
        public bool Win { get; private set; }

        //Maybe Tips

        public GambleMatch(Player ply)
        {
            MaxLimiter = defaultLimit;
            Number = 0;
            Win = false;
            Player = ply;
        }

        public void Edit(int maxLimiter)
        {
            MaxLimiter = maxLimiter;
        }

        public void Start()
        {
            Player.RestartLive(3);
            Win = false;

            var rand = new Random();
            Number = (rand.Next(MaxLimiter + 1));
        }

        public void Play(int value)
        {
            if (value == Number)
                Win = true;
            else
            {
                Console.WriteLine("You answer wrong,try again..");
                Player.LostLive(1);
            }
        }

        public override string ToString()
        {
            Console.Clear();
            var result = new StringBuilder();

            if (Win)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                result.AppendLine("+Parabéns você Ganhou!!!+");
            }
            else if (Player.Life <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                result.AppendLine($"-Que pena, você Perdeu...O numero era {Number}-");
            }

            return result.ToString();
        }
    }
}
