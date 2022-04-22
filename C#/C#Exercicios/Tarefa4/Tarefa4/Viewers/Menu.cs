using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tarefa4.Entities;

namespace Tarefa4.Viewers
{
    internal class Menu
    {
        public static void View()
        {
            do
            {
                Console.Clear();
                try
                {
                    Dados();
                    OpMessage();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                    ErrorMsg();
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                    ErrorMsg();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                    ErrorMsg();
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }


        static void Dados()
        {
            Console.WriteLine("Digite a Taxa:");
            Console.WriteLine("====================");
            var taxa = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Kg do peixe");
            Console.WriteLine("====================");
            var kg = double.Parse(Console.ReadLine());
            
            var notaFiscal = new NotaFiscal(taxa, kg);

            notaFiscal.CalcularExcesso();

            Console.Clear();
            Console.WriteLine(notaFiscal.ToString());
        }

        static void ErrorMsg()
        {
            Console.WriteLine("Digite Novamente...");
            Thread.Sleep(1000);
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
