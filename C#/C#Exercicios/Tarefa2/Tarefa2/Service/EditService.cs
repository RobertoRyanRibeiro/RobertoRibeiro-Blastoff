using System;
using System.Collections.Generic;
using System.Text;
using Tarefa2.Entities.Exceptions;
using Tarefa2.Entities;

namespace Tarefa2.Service
{
    public class EditService
    {
        public void Edit(GambleMatch gambleMatch)
        {
            //Setando Tela
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.CursorVisible = true;
            var limit = gambleMatch.MaxLimiter;
            Console.WriteLine($"|Current Limit:{gambleMatch.MaxLimiter}");
            Console.WriteLine("=========================");
            Console.Write("|Enter with the new limit and press Enter(The minimum is 5):");
            limit = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            //Tratamento
            if (limit < 5)
            {
                throw new ExceptionAboveLimitGamble("The value below the minimum limit.");
            }

            gambleMatch.Edit(limit);
        }
    }

}
