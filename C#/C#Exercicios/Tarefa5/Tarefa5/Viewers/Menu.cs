using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tarefa5.Entities;

namespace Tarefa5.Viewers
{
    internal struct Menu
    {
        public static void View()
        {
            do
            {
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

            }while(Console.ReadKey().Key != ConsoleKey.Escape);  
        }

        static void Dados()
        {
            Console.Clear();
            Console.WriteLine("Digite a quantidade de horas");
            Console.WriteLine("===========================");
            var hrTrab = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor da Hora");
            Console.WriteLine("======================");
            var valHr = double.Parse(Console.ReadLine());

            FolhaPagamento folPag = new FolhaPagamento(hrTrab, valHr);
            folPag.CalcularSalLiquido();

            Console.WriteLine(folPag.ToString());
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
