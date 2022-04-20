using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Tarefa8.Entities;

namespace Tarefa8.Viewers
{
    public static class Menu
    {
        static Regex pattern = new Regex(@"\d{4}\-?\d{3,4}");

        public static void View()
        {
            do
            {

                Console.Clear();
                Console.WriteLine("Digite um numero de telefone : XXXX-XXXX");
                Console.WriteLine("========================================");
                var tel = Console.ReadLine();
                Match match = pattern.Match(tel);

                try
                {
                    if (match.Success)
                    {
                        Telefone telefone = new Telefone(match.Value);
                        
                        telefone.AnalisarNum();
                        Console.WriteLine(telefone.ToString());
                        
                        OpMessage();
                    }
                    else
                    {
                        throw new ArgumentException("Error: Formatação Invalida");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Clear();
                    ErrorMsg();
                }
                catch (OverflowException ex)
                {
                    Console.Clear();
                    ErrorMsg();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Clear();
                    ErrorMsg();
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static void ErrorMsg()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-Error: Formatação Errada-");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|O Numero precisa ser numerico.");
            Console.WriteLine("|Nos formatos XXXX-XXXX | XXXXXXXX.");
            Console.WriteLine("|No minimo 7 digitos.");
            Console.WriteLine("=======================================");
            Console.WriteLine("Aperte qualquer tecla para continuar...");
            Console.ReadKey();
            Menu.View();
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
