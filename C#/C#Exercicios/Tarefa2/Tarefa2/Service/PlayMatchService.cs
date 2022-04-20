using System;
using System.Collections.Generic;
using System.Threading;
using System.Text.RegularExpressions;
using Tarefa2.Entities;
using Tarefa2.Entities.Exceptions;

namespace Tarefa2.Service
{
    public class PlayMatchService
    {
        string pattern = @"[0-9]*";

        public void PlayMatch(GambleMatch gambleMatch)
        {

            var value = 0;
            while (gambleMatch.Player.Life > 0 && !gambleMatch.Win)
            {
                //Setando Tela
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                Console.WriteLine($"|LimitMax : {gambleMatch.MaxLimiter}");
                Console.WriteLine($"|Lives: {gambleMatch.Player.Life}");
                Console.WriteLine("=========================");
                Console.Write("|What's The Number::");
                value = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                //Tratamento
                if (value < 0)
                {
                    throw new ExceptionPlayGame("The value is wrong.");
                }

                gambleMatch.Play(value);
                Thread.Sleep(1000);
            }

            Console.WriteLine(gambleMatch.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("====================================");
            Console.WriteLine("Aperte Qualquer tecla para continuar");
            Console.ReadKey();
        }
    }
}
