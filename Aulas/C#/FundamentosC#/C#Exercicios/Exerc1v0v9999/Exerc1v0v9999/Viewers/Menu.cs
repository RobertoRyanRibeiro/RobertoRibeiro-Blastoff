using System;
using System.Collections.Generic;
using System.Text;
using Exerc1v0v9999.Entities;

namespace Exerc1v0v9999.Viewers
{
    public static class Menu
    {
        public static void View()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Digite um Valor entre 0 - 9999:");
                try
                {
                    uint value = ushort.Parse(Console.ReadLine());
                    Numero num = new Numero(value);
                    Console.WriteLine(num.ToString());
                    OpMessage();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        static void OpMessage()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Aperte Esc para sair da Aplicação,Caso deseje repetir aperte qualquer outra tecla");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
