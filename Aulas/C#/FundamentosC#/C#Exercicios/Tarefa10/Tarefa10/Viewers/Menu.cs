using System;
using System.Collections.Generic;
using System.Text;
using Tarefa10.Entities;

namespace Tarefa10.Viewers
{
    internal class Menu
    {
        public static void View()
        {
            do
            {
                try
                {
                    InputDado();
                }
                catch (OverflowException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    ErrorMsg();
                }
                catch (ArgumentException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    ErrorMsg();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    ErrorMsg();
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static void InputDado()
        {
            Console.Clear();
            DrawMenu();
            string nome = Console.ReadLine();
            var name = new Nome(nome);
            name.VerificarNome();
            DrawMenuOp();
        }

        static void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome completo:");
            Console.WriteLine("=======================");
        }

        static void DrawMenuOp()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Aperte Esc para sair,se quiser repetir aperte qualquer outra tecla.");
            Console.WriteLine("=======================");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ErrorMsg()
        {
            Console.Clear();
            Console.WriteLine("|Error de formatação");
            Console.WriteLine("|Digite novamente...");
            Console.WriteLine("");
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
